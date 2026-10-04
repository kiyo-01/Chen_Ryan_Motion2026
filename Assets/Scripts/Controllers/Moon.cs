using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Moon : MonoBehaviour
{
    //variables for inspector
    public Transform orbitTarget;
    public float orbitRadius = 2f;
    public float orbitSpeed = 1f;

    float currentAngle = 0f;

    void Update()
    {
        OrbitalMotion(orbitRadius, orbitSpeed, orbitTarget);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        //move angle based on speed
        currentAngle += speed * Time.deltaTime;

        //trig to calc point on the circle
        float xOffset = Mathf.Cos(currentAngle) * radius;
        float yOffset = Mathf.Sin(currentAngle) * radius;

        //set moon pos based on target pos
        transform.position = target.position + new Vector3(xOffset, yOffset, 0f);
    }
}
