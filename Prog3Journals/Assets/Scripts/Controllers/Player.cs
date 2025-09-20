using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    public Vector3 bombOffset = new Vector3(0,1);

    public float bombTrailSpacing;
    public int numberOfTrailBombs;

    Vector2 spawnCorner = new Vector2(0,1);

    public float warpRatio = 0.2f;

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

        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnBombAtCorners(transform.position, Vector2.one);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            WarpPlayer(enemyTransform, warpRatio);
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

    public void SpawnBombAtCorners(Vector2 position, Vector2 size)
    {
        float halfWidth = size.x / 2;
        float halfHeight = size.y / 2;
        int corner = UnityEngine.Random.Range(1, 5);

        Vector2 topLeft = position + new Vector2(-halfWidth, halfHeight);
        Vector2 topRight = topLeft + new Vector2(size.x, 0);
        Vector2 bottomRight = topRight + new Vector2(0, -size.y);
        Vector2 bottomLeft = bottomRight + new Vector2(-size.x, 0);

        if (corner == 1) 
        {
            spawnCorner = topRight;
            Instantiate(bombPrefab, spawnCorner, Quaternion.identity);
            Debug.Log("1");
        }
        if (corner == 2) 
        {
            spawnCorner = topLeft;
            Instantiate(bombPrefab, spawnCorner, Quaternion.identity);
            Debug.Log("2");
        }
        if (corner == 3) 
        {
            spawnCorner = bottomLeft;
            Instantiate(bombPrefab, spawnCorner, Quaternion.identity);
            Debug.Log("3");
        }
        if (corner == 4) 
        {
            spawnCorner = bottomRight;
            Instantiate(bombPrefab, spawnCorner, Quaternion.identity);
            Debug.Log("4");
        }
    }

    public void WarpPlayer(Transform target, float ratio)
    {

        if (warpRatio <= 1) 
        {
            ratio = warpRatio;

            transform.position = Vector2.Lerp(transform.position, target.position, ratio);
        }

        Debug.Log("method works");
    }
}
