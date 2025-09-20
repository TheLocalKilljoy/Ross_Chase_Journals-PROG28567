using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    public Vector3 bombOffset = new Vector3(0,1);

    public float bombTrailSpacing;
    public int numberOfTrailBombs;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(bombOffset);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs);
        }
    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawn = transform.position + inOffset;
        Instantiate(bombPrefab, spawn, Quaternion.identity);
    }

    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        Vector3 spawn = transform.position + bombOffset;


        for (int i = 0; i < inNumberOfBombs; i++)
            Instantiate(bombPrefab, spawn, Quaternion.identity);
    }

}
