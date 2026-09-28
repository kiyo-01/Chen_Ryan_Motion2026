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

    //class work
    public Vector3 currentVelocity = Vector3.right;

    public float speed;
    public float accelTime;
    public float currentAccel;
    public float maxSpeed = 5f;

    public float decelTime;
    public float decel;


    //journal 4
    public int noOfPoints;
    private float circlePointsAngles;
    public float circleRadius;

    void Start()
    {
        currentAccel = maxSpeed / accelTime;
        decel = maxSpeed / decelTime;

        if (noOfPoints != 0)
        {
            circlePointsAngles = 360f / noOfPoints;
        }
        else
        {
            circlePointsAngles = 0f;
        }
    }


    
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

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            WarpPlayer(enemyTransform, warpRatio);
        }

        DetectAsteroids(maxRange, asteroidTransforms);

        PlayerMovement();

        PlayerRadar(noOfPoints, circlePointsAngles);
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

    public void PlayerMovement()
    {
        Vector3 accelDirection = Vector3.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            accelDirection = Vector3.up;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            accelDirection = Vector3.down;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            accelDirection = Vector3.left;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            accelDirection = Vector3.right;
        }
        else
        {
            accelDirection = Vector3.zero;

            //use accel logic on deceleration when no keys are pressed
            if (currentVelocity.magnitude > 0)
            {
                currentVelocity -= currentVelocity.normalized * decel * Time.deltaTime;

                //if the current velocity is less than the deceleration amount, set it to zero
                if (currentVelocity.magnitude < decel * Time.deltaTime)
                {
                    currentVelocity = Vector3.zero;
                }
            }
        
        }
        currentVelocity += accelDirection.normalized * currentAccel * Time.deltaTime;
        
        //teacher's way!
        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }
        
        //Vector3 speedCap = new Vector3(maxSpeed, maxSpeed, maxSpeed);

        //if (currentVelocity.x >= speedCap.x)
        //{
        //    currentVelocity.x = speedCap.x;
        //}
        //if (currentVelocity.y >= speedCap.y)
        //{
        //    currentVelocity.y = speedCap.y;
        //}
        //if (currentVelocity.x <= -speedCap.x)
        //{
        //    currentVelocity.x = -speedCap.x;
        //}
        //if (currentVelocity.y <= -speedCap.y)
        //{
        //    currentVelocity.y = -speedCap.y;
        //}

        transform.position += currentVelocity * Time.deltaTime;
    }

    public void PlayerRadar(int points, float angles) 
    {
        float anglesInRadians = angles * Mathf.Deg2Rad;
        
        
        
        List<float> circlePoints = new List<float>();
        for (int i = 0; i > points - 1; i++)
        {
            float endPointX = Mathf.Cos(anglesInRadians * i);
            float endPointY = Mathf.Sin(anglesInRadians * i);
        }
    }
}
