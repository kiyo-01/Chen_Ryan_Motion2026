using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public Vector3 bombOffset;

    public float bombTrailSpacing = 1f;
    public int numberOfTrailBombs = 10;

    public float warpRatio = 0.5f;

    public float maxRange = 5f;
    

    void Update()
    {   
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBombAtOffset();
        }
        
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs);
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            SpawnBombOnRandomCorner(2f);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            WarpPlayer(enemyTransform, warpRatio);
        }

        DetectAsteroids(maxRange, asteroidTransforms);
    }

    public void SpawnBombAtOffset()
    { 
        Vector3 spawnPosition = transform.position + bombOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity, bombsTransform);
    }

    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        for (int i = 0; i < inNumberOfBombs; i++)
        {
            Vector3 spawnPosition = transform.position - bombOffset - (transform.up * (i * inBombSpacing));
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity, bombsTransform);
        }
    }

    public void SpawnBombOnRandomCorner(float inDistance)
    { 
     Vector3 offset = Vector3.zero;
    int randomCorner = Random.Range(0, 4);
        if (randomCorner == 0)
        {   //top left
            offset = new Vector3(-inDistance, inDistance, 0);
        } else if (randomCorner == 1)
        { //top right
            offset = new Vector3(inDistance, inDistance, 0);
        }
        else if (randomCorner == 2)
        { //bottom left
            offset = new Vector3(-inDistance, -inDistance, 0);
        }
        else
        { //bottom right
            offset = new Vector3(inDistance, -inDistance, 0);
        }

        Vector3 spawnPosition = transform.position + offset;

        Instantiate(bombPrefab, spawnPosition, Quaternion.identity, bombsTransform);      
    }

    public void WarpPlayer(Transform target, float ratio)
    { 
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position, ratio);
        transform.position = newPosition;
    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform asteroidTransform in inAsteroids)
        {
            if (asteroidTransform == null) continue;

            float distance = Vector3.Distance(transform.position, asteroidTransform.position);
            
            if (distance <= inMaxRange)
            {
                Vector3 direction = (asteroidTransform.position - transform.position).normalized;

                Vector3 lineEnd = transform.position + (direction * 2.5f);

                Debug.DrawLine(transform.position, lineEnd, Color.green);
            }
        }
    }
}
