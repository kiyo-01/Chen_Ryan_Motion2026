using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = starTransforms[0].position;
        Vector3 endPoint = starTransforms[1].position;

        for (int i = 0; i < starTransforms.Count; i++)
        {
            
        }

        //roast keely apparently
        //foreach (Transform starTransform in starTransforms)
        //{

        //}
    }

    public void DrawConstellation()
    {

    }
}
