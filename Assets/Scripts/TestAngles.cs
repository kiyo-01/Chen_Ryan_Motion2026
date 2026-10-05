using UnityEngine;

public class TestAngles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float firstAngle = 45f;
        //float secondAngle = 225f;

        //float firstVectorX = Mathf.Cos(firstAngle * Mathf.Deg2Rad);
        //float secondVectorX = Mathf.Cos(secondAngle * Mathf.Deg2Rad);

        //float firstAngleAgain = Mathf.Acos(firstVectorX);
        //float secondAngleAgain = Mathf.Acos(secondVectorX);

        //Debug.Log($"First Angle: {firstAngle}, First Vector X: {firstVectorX}, First Angle Again: {firstAngleAgain * Mathf.Rad2Deg}");
        //Debug.Log($"Second Angle: {secondAngle}, Second Vector X: {secondVectorX}, Second Angle Again: {secondAngleAgain * Mathf.Rad2Deg}");

    //    float x = 0.7f;
    //    float y = 0.7f;

    //    float angle = Mathf.Atan(y / x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //convert public to angle based around x-axis
    public static float VectorToAngle(Vector3 inVector)
    {
        float angle = Mathf.Atan2(inVector.y, inVector.x) * Mathf.Rad2Deg;
        return angle - 90f;
    }

    //for normalized vectors, if theyre pointing in the same direction, the product is 1, if theyre pointing in opposite directions, the product is -1, if theyre perpendicular, the product is 0
    //for non-normalized vectors, the product is the length of the two vectors multiplied 
    public static float VectorDot(Vector3 a, Vector3 b)
    {
        float dotProduct = a.x * b.x + a.y * b.y;
        return dotProduct;
    }
}
