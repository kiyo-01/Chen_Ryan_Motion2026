using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class AngleTest : MonoBehaviour
{
    public List<float> angles;
    private int cAngleIndex = 0;
    public float circleRadius;
    public Vector3 circleOffset;
    public float shiftDuration;
    private float shiftProgress = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float fortyFiveDegree = 45f;

        //float ffDInRadians = fortyFiveDegree * Mathf.Deg2Rad;

        //float twoPiRadians = 2 * Mathf.PI;
        //float tprInDegrees = twoPiRadians * Mathf.Deg2Rad;

         
    }

    // Update is called once per frame
    void Update()
    {
        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //    cAngleIndex++;

        //    if (cAngleIndex >= angles.Count)
        //    {
        //        cAngleIndex = 0;
        //    }
        //}

        shiftProgress += Time.deltaTime;
        
        if (shiftProgress > shiftDuration)
        {
            cAngleIndex++;

            if (cAngleIndex >= angles.Count)
            {
                cAngleIndex = 0;
            }
            shiftProgress = 0f;
        }

        float currentAngle = angles[cAngleIndex];
        float currentAInRadians = currentAngle * Mathf.Deg2Rad;

        Vector3 startPoint = Vector3.zero + circleOffset;
        float endPointX = Mathf.Cos(currentAInRadians);
        float endPointY = Mathf.Sin(currentAInRadians);
        Vector3 endPoint = new Vector3(endPointX, endPointY) * circleRadius + circleOffset;

        Debug.DrawLine(startPoint, endPoint, Color.white);
    }
}
