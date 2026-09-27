using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    //stores random destination point
    private Vector3 targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        //initialize targetPoint to a random point
        PickNewTargetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {
        //check whether asteroid has reached within arrivalDistance of point
        if (Vector3.Distance(transform.position, targetPoint) <= arrivalDistance)
        {
            //choose new point
            PickNewTargetPoint();
        }

        //calc direction to target
        Vector3 direction = (targetPoint - transform.position).normalized;

        //move asteroid in the direction of the point at move speed
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void PickNewTargetPoint()
    {
        //pick random coords (stay away from the edges)
        float randomX = Random.Range(0.1f, 0.9f);
        float randomY = Random.Range(0.1f, 0.9f);

        //convert screen coords to game coords
        targetPoint = Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 0f));
        targetPoint.z = 0f;
    }
}
