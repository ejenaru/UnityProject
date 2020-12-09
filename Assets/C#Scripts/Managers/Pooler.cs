using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public static Pooler pooler;
    public List<GameObject> pooledObjects; //Esta es la piscina donde voy a meter toooooooooodo
    public ObjectPoolItem[] objectsToPool; //un array con los objetos que se pueden poolear
    
    
    void Awake()
    {
        pooler = this;
    }
    private void OnEnable()
    {
        pooledObjects = new List<GameObject>();

        
        foreach (ObjectPoolItem item in objectsToPool)
        {
            Pool("Bullet");
            //Pool("Bullet1");
            for (int i = 0; i < item.amountToPool; i++)
            {
                
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public void Pool(string _objectTag) //solo crea la pool del objeto que le digo.
    {
        foreach (ObjectPoolItem item in objectsToPool)
        {
            if (item.objectToPool.CompareTag(_objectTag))
            {
                
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }
    public GameObject GetPooledObject(string _objectTag) //te pide el tag del objeto que (tenemos en el array) queremos poolear
    {
        
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(_objectTag))
                return pooledObjects[i];
        }
        foreach (ObjectPoolItem item in objectsToPool)
        {
            if (item.shouldExpand && item.objectToPool.CompareTag(_objectTag))
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        
        return null;
    }
}
