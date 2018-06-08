using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> poolList;
    //public Dictionary<string, Queue<GameObject>> poolDictionary;
    public Dictionary<GameObject, Queue<GameObject>> poolDictionary;

    // Use this for initialization
    void Start () {
        //poolDictionary = new Dictionary<string, Queue<GameObject>>();
        poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

        foreach (Pool pool in poolList)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            //poolDictionary.Add(pool.tag, objectPool);
            poolDictionary.Add(pool.prefab, objectPool);
        }
    }

    public GameObject SpawnFromPool(GameObject go, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(go))
        {
            Debug.LogWarning("Pool with game object " + go + " doesn't exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[go].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[go].Enqueue(objectToSpawn);

        Debug.Log("Return tile: " + objectToSpawn);

        return objectToSpawn;
    }
        /*public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
        */
    }
