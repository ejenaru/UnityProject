using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public static Pooler pooler;
    public List<GameObject> pooledObjects; //Esta es la piscina donde voy a meter toooooooooodo
    public GameObject[] objectToPool; //es el objeto que quiero meter en la piscina. Es un molde (mas tarde haré un array)
    public int amountToPool;
    
    void Awake()
    {
        pooler = this;
    }
    private void Start()
    {
        pooledObjects = new List<GameObject>();
        amountToPool = 20;
        Pool(0); //instancia pecha de lo que haya en la posicion 0 del array



    }

    public void Pool(int _objectInList)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool[_objectInList]);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
}
