using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform targetT;
    public float rotationSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.red);

        Vector3 direction2Target = targetT.position - transform.position;

        //shoudl we turn left or right
        bool shouldWeTurnRight = false;

        //dot product DOES NOT CARE about the order of the two
        if (TestAngles.VectorDot(transform.right, direction2Target) > 0)
        {
            shouldWeTurnRight = true;
        }
        else
        {
            shouldWeTurnRight = false;
        }

        //rotation is opposite of the direction we want to turn, so we need to reverse the sign of the rotation speed
        if (shouldWeTurnRight)
        {
            transform.eulerAngles -= Vector3.forward * rotationSpeed * Time.deltaTime;
        }
        else
        {
            transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
        }



        Debug.Log(shouldWeTurnRight);
    }
}
