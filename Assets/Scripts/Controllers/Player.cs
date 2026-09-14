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

    public float distanceToEnemy;

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            Vector2 offSet = transform.position + Vector3.up;

            SpawnBombAtOffset(offSet);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            //find the direction to the enemy and activate warp
            Vector2 direction = (enemyTransform.position - transform.position);
            WarpZone(direction);
        }
    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {
        GameObject bomb = Instantiate(bombPrefab);
        bomb.transform.position = inOffset;
    }

    public void WarpZone(Vector2 inDirection)
    {
        //normalize makes you move "1 unit" in the direction of the vector
        transform.position += Vector3.Normalize(inDirection);
    }
}
