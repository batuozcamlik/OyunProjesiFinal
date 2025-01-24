using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab; 
    [SerializeField] private int poolSize = 10; 
    private Queue<GameObject> pool = new Queue<GameObject>();

    

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.GetComponent<Rigidbody2D>().velocity= Vector3.zero;
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
