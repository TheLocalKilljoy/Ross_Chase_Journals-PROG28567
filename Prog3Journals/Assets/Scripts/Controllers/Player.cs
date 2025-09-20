using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    public Vector2 bombOffset = new Vector2(0,1);
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(bombOffset);
        }
    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawn = transform.position + inOffset;
        Instantiate(bombPrefab, spawn, Quaternion.identity);
    }
}
