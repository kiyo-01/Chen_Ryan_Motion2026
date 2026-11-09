using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Forces : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forceStrength = 5f;

    public enum ProjectileType
    {
        Arrow, Cannonball, Fireball
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.right * 1f, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            worldMousePos.z = 0f;

            Vector3 forceDirection = worldMousePos - transform.position;

            rb.AddForce(forceDirection.normalized * forceStrength, ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Entered");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Stay");
    }

}
