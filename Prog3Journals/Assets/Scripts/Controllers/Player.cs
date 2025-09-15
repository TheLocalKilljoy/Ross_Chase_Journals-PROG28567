using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(Vector3.up);
        }
    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawn = transform.position + inOffset;
        Instantiate(bombPrefab, spawn, Quaternion.identity);
    }
}
