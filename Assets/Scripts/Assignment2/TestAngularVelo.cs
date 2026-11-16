using UnityEngine;

public class TestAngularVelo : MonoBehaviour
{
    Rigidbody2D rb;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.angularVelocity = 180f;
    }
}
