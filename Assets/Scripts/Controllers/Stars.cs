using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime = 0.5f;

    //track which seg is being drawn as time elapsed
    private int currentIndex = 0;
    private float currentTimer = 0f;


    // Update is called once per frame
    void Update()
    {
        //check if the list has enouhg stars to draw a line (2)
        if (starTransforms == null || starTransforms.Count < 2) return;

        DrawConstellation();
    }

    public void DrawConstellation()
    {
        //increment timer to track drawing process
        currentTimer += Time.deltaTime;

        //once line is completely drawn, draw next
        if (currentTimer >= drawingTime)
        {
            currentTimer = 0f;
            currentIndex++;

            //repeat until end of list, then start from the top (line requires two points so -1)
            if (currentIndex >= starTransforms.Count - 1)
            {
                currentIndex = 0;
            }
        }

        Vector3 startPoint = starTransforms[currentIndex].position;
        Vector3 endPoint = starTransforms[currentIndex + 1].position;

        Vector3 currentDrawPoint = Vector3.Lerp(startPoint, endPoint, currentTimer / drawingTime);
        Debug.DrawLine(startPoint, endPoint, Color.white);
    }
}
