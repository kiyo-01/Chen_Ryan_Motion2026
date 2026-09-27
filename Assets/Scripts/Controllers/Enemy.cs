using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;

    //movement
    public float maxSpeed = 4f;
    public float accelRate = 3f;
    public float decelRate = 2f;
    public float stopDistance = 3f;

    private Vector3 currentVelocity = Vector3.zero;

    private void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        //does the player exist
        if (playerTransform == null) return;

        //calc dist to player
        float distancePlayer = Vector3.Distance(transform.position, playerTransform.position);
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        //chase player if outside stopping distance
        if (distancePlayer > stopDistance)
        {
            currentVelocity += direction * accelRate * Time.deltaTime;
        }

        //apply decel if the player is within the stopDist
        else if (currentVelocity.magnitude > 0f)
        {
            float speedLoss = decelRate * Time.deltaTime;

            if (currentVelocity.magnitude <= speedLoss)
            {
                currentVelocity = Vector3.zero;
            }
            else
            {
                currentVelocity -= currentVelocity.normalized * speedLoss;
            }
        }
        //clamp velo so enemy doesnt exceed max speed
        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }

        transform.position += currentVelocity * Time.deltaTime;
    }    
}
