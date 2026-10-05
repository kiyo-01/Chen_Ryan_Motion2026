using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;


public class Looker : MonoBehaviour
{
    public List<Transform> targets;
    private int cTargetIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            cTargetIndex++;
            if (cTargetIndex >= targets.Count)
            {
                cTargetIndex = 0;
            }
        }

        Vector3 firstTarget = targets[cTargetIndex].position;

        Vector3 vector2FirstTarget = firstTarget - transform.position; //vector from OBJECT to TARGET rather than from the origin to the target

        float angleToFirstTarget = TestAngles.VectorToAngle(vector2FirstTarget);

        //we hve to set the whole vector (not just x) since its not a variable
        //transform.position = transform.position + new Vector3(1, 0, 0);

        //we have to set the WHOLE vector for eulers
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angleToFirstTarget);
    }
}
