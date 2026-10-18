using UnityEngine;

public class SearchLight : MonoBehaviour
{
    public Transform targetT; //usually the player

    public float turnSpeed = 30f; //speed of the sweep
    public float detectionRange = 5f; //length of search line
    public float alertFollowSpeed = 120f; //speed of the searchlight when following the player

    private bool isAlerted = false; //whether the searchlight is alerted to/seen the player

    void Update()
    {
        float distance2Target = Vector3.Distance(transform.position, targetT.position);
        Vector3 direction2Target = (targetT.position - transform.position).normalized;

        //is target in front of our laser?
        float alignmentDot = Vector3.Dot(transform.up, direction2Target);

        //if you are in range and standing in the path of the line
        if (distance2Target <= detectionRange && alignmentDot > 0.95f)
        {
            isAlerted = true;
        }
        else if (distance2Target > detectionRange + 2f) //turn off once you get a bit furhter away
        {
            isAlerted = false;
        }

        //behavior
        if (isAlerted)
        {
            //lock on: interupt spin and snap/turn to follow player 
            //check if already pointing
            float facingDot = Vector3.Dot(transform.up, direction2Target);

            if (facingDot < 0.999f)
            {
                bool shouldTurnRight = false;

                if (TestAngles.VectorDot(transform.right, direction2Target) > 0)
                {
                    shouldTurnRight = true;
                }


                //apply rotation
                if (shouldTurnRight)
                {
                    transform.eulerAngles -= Vector3.forward * alertFollowSpeed * Time.deltaTime;
                }
                else
                {
                    transform.eulerAngles += Vector3.forward * alertFollowSpeed * Time.deltaTime;
                }
            }

            Debug.DrawLine(transform.position, targetT.position, Color.red);
        }
        else
        {
            //patrol spin
            transform.eulerAngles += Vector3.forward * turnSpeed * Time.deltaTime;
            Debug.DrawLine(transform.position, transform.position + transform.up * detectionRange, Color.green);
        }
    }
}
