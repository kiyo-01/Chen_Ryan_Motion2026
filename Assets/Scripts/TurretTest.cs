using UnityEngine;

public class TurretTest : MonoBehaviour
{
    public Transform target;
    public float turnSpeed = 90f;
    public float guardRadius = 5f;

    void Update()
    {
        //calc dist to target (player)
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= guardRadius)
        {
            //target in range, draw line (show active)
            Debug.DrawLine(transform.position, target.position, Color.red);
            
            Vector3 direction2Target = (target.position - transform.position).normalized; //direction to target normalized

            //check if the turret is already facing the target using dot prod
            float facingDot = Vector3.Dot(transform.forward, direction2Target);

            if (facingDot < 0.99f) //if not facing target
            {
                //reusing keely method
                bool shouldWeTurnRight = false;

                if (TestAngles.VectorDot(transform.forward, direction2Target) < 0)
                {
                    shouldWeTurnRight = true;
                }
                else 
                { 
                    shouldWeTurnRight = false;
                }

                //apply rotation
                if (shouldWeTurnRight)
                {
                    transform.eulerAngles += Vector3.forward * turnSpeed * Time.deltaTime;
                }
                else
                {
                    transform.eulerAngles -= Vector3.forward * turnSpeed * Time.deltaTime;
                }
            }
        }
        else
        {             
            //target out of range, draw line (show inactive)
            Debug.DrawLine(transform.position, target.position, Color.green);
        }
    }
}
