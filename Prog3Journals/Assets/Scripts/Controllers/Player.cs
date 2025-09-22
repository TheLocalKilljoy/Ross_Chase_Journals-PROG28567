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

    public float range = 5;

    Vector3 velocity;
    public float maxSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

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

        if (Input.GetKeyDown(KeyCode.L))
        {
            WarpPlayer(enemyTransform, warpRatio);
        }

        DetectAsteroids(range, asteroidTransforms);
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

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform t in inAsteroids) 
        {
            if(Vector3.Distance(transform.position, t.transform.position) <= inMaxRange) 
            {
                Vector3.Normalize(t.transform.position);

                Debug.DrawLine(transform.position, t.transform.position, UnityEngine.Color.green);
            }
        }
    }

    private void PlayerMovement()
    {
        velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            velocity += maxSpeed * Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += maxSpeed * Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += maxSpeed * Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += maxSpeed * Vector3.down;
        }

        transform.position += velocity * Time.deltaTime;
    }
}
