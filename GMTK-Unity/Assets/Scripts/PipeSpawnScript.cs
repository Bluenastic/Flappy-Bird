using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public float initialSpawnInterval = 2f;  
    public float minSpawnInterval = 1f;      
    public float spawnIntervalDecrement = 0.1f; 
    public Transform spawnPoint;

    private float currentSpawnInterval;

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        InvokeRepeating("SpawnPipe", currentSpawnInterval, currentSpawnInterval);
    }

    void SpawnPipe()
    {
        GameObject pipe = PipePoolManager.Instance.GetPipe();
        pipe.transform.position = spawnPoint.position;
        pipe.transform.rotation = Quaternion.identity;

        // Giảm khoảng cách giữa các lần sinh cột
        currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - spawnIntervalDecrement);

        // Cập nhật thời gian cho InvokeRepeating
        CancelInvoke();
        InvokeRepeating("SpawnPipe", currentSpawnInterval, currentSpawnInterval);
    }
}
