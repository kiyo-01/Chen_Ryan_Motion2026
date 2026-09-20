using System.Threading;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public Vector3 stored;
    public float timer = 0f;
    public float pipelineLength = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        //store mousepos when button is pressed down
        if (Input.GetMouseButtonDown(0))
        {
            stored = mouseWorldPos;
            timer = 0f;
        }

        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            
            if (timer >= 0.1f)
            {
                mouseWorldPos.z = 0f;   

                //store new point
                Vector3 newStored = mouseWorldPos;

                //draw line between new and old
                Debug.DrawLine(stored, newStored, Color.gray, 10f);

                //calculate distance using distance formula via mathf.sqr
                float dx = newStored.x - stored.x;
                float dy = newStored.y - stored.y;
                //https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Mathf.Sqrt.html
                float partLength = Mathf.Sqrt(dx * dx + dy * dy); 

                //add to total
                pipelineLength += partLength;

                //reset timer and update stored point
                timer = 0f;
                stored = newStored;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //print total length of pipeline
            Debug.Log("Total pipeline length: " + pipelineLength);
           
        }
    }
}
