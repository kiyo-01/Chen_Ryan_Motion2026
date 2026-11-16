using UnityEngine;

public class TestClosestP : MonoBehaviour
{
    public Rigidbody2D targetRB;
    // Update is called once per frame
    void Update()
    {
        Vector2 closestPoint = targetRB.ClosestPoint(transform.position);
        transform.position = closestPoint;
    }
}
