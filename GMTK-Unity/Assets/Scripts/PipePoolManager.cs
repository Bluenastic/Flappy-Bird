using System.Collections.Generic;
using UnityEngine;

public class PipePoolManager : MonoBehaviour
{
    public static PipePoolManager Instance;
    public GameObject pipePrefab;
    public int poolSize = 5;
    private Queue<GameObject> pool;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        pool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pipePrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetPipe()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(pipePrefab);
            obj.SetActive(true);
            return obj;
        }
    }

    public void ReturnPipe(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
