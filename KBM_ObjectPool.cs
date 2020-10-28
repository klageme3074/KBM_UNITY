using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KBM
{
    public class ObjectPool<T> where T : Object
    {
        int size;
        int curIndex;
        Queue<GameObject> pool;
        GameObject owner;

        /**
        /*오브젝트 pool 생성
        * @ param GameObject _owner  오브젝트를 가지고 있을 객체
        * @ param GameObject _createObject 생성될 오브젝트
        * @ param int _size 오브젝트 풀 사이즈
        */
        public ObjectPool(GameObject _owner,T _originalObject, int _size = 10)
        {
            curIndex = 0;
            size = _size;
            pool = new Queue<GameObject>();
            
            GameObject g = _originalObject as GameObject;
            for (int i=0;i<size; i++)
            {
                GameObject tmp = GameObject.Instantiate(g);
                tmp.transform.SetParent(_owner.transform);
                pool.Enqueue(tmp);
            }
        }

        public T PopObject()
        {
            GameObject reVal = pool.Dequeue();
            reVal.SetActive(true);
            curIndex++;
            return reVal as T;
        }

        public void ReturnObject(T _object)
        {
            GameObject g = _object as GameObject;
            g.SetActive(false);
            pool.Enqueue(_object as GameObject);
        }

        public void RemoveAll()
        {
            foreach(GameObject g in pool)
            {
                GameObject.Destroy(g);
            }
        }
    }
}