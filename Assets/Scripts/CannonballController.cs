using UnityEngine;

public class CannonballController : MonoBehaviour
{
    public float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        //After lifespan seconds, this object will be destroyed
        Destroy(gameObject, lifespan);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //the clark method
        //if (collision.collider.CompareTag("CannonBall"))
        //{
        //    Destroy(gameObject);
        //}
        if(collision.gameObject.GetComponent<CannonballController>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
