using UnityEngine;
using UnityEngine.InputSystem;

public class VectorMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //DrawSqu(currentMousePosition, 5f, Color.red, 0.5f);

        Vector3 upDirection = Vector3.up;

        float magnitudeOfUpDirection = upDirection.magnitude;
        Vector2 normalizedUpDirection = upDirection.normalized;

        float distanceFromUpDirection = Vector2.Distance(upDirection, Vector2.zero);
    }

    public static Vector2 GetNormal(Vector2 vector)
    {
        float sector = GetMag(vector);
        Vector2 normalVector = new Vector2(vector.x, vector.y)/sector;
        //treating vector as a right triangle; shrink it down while maintaining the same angles
        return normalVector;
    }


    public static float GetMag(Vector2 vec)
    {
        return Mathf.Sqrt(vec.x * vec.x + vec.y * vec.y);
    }

    public static void DrawSqu(Vector2 centerP, float size, Color col, float dur)
    {
        //top line
        Vector2 startP = centerP + new Vector2(-size, size);
        Vector2 endP = centerP + new Vector2(size, size);

        Debug.DrawLine(startP, endP, col, dur);
        
        //left line
        startP = centerP + new Vector2(-size, size);
        endP = centerP + new Vector2(-size, -size);

        Debug.DrawLine(startP, endP, col, dur);

        //right line
        startP = centerP + new Vector2(size, size);
        endP = centerP + new Vector2(size, -size);

        Debug.DrawLine(startP, endP, col, dur);

        //bottom line
        startP = centerP + new Vector2(-size, -size);
        endP = centerP + new Vector2(size, -size);

        Debug.DrawLine(startP, endP, col, dur);
    }    
}
