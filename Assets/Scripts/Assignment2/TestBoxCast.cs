using UnityEngine;

public class TestBoxCast : MonoBehaviour
{
    public Vector2 boxSize = new Vector2(1f, 1f);
    public float maxDistance = 2f;

    void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f, transform.right, maxDistance);

        if (hit.collider != null)
        {
            Debug.Log("BoxCast hit: " + hit.collider.name);
        }
    }
}
