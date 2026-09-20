using UnityEngine;

public class SquareSpawner : MonoBehaviour

{
    public SpriteRenderer square;
    public float scrollValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //update scroll value based on mouse scroll wheel input
        scrollValue = 0 + Input.mouseScrollDelta.y;

        //turn mouse position values into a vector
        Vector3 mouseScreenPos = Input.mousePosition;

        //convert into screen point and create middle point to build add and subtract around for other points
        Vector3 center = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        if (Input.GetMouseButtonDown(0))
        {
            //define where the four corners of the square are relative to the center
            Vector3 topLeft = new Vector3(center.x - (0.5f + scrollValue), center.y + (0.5f + scrollValue), 0);
            Vector3 topRight = new Vector3(center.x + (0.5f + scrollValue), center.y + (0.5f + scrollValue), 0);
            Vector3 bottomLeft = new Vector3(center.x - (0.5f + scrollValue), center.y - (0.5f + scrollValue), 0);
            Vector3 bottomRight = new Vector3(center.x + (0.5f + scrollValue), center.y - (0.5f + scrollValue), 0);

            //draw lines in between the four corners
            Debug.DrawLine(topLeft, topRight, Color.gray, 2f);
            Debug.DrawLine(topRight, bottomRight, Color.gray, 2f);
            Debug.DrawLine(bottomRight, bottomLeft, Color.gray, 2f);
            Debug.DrawLine(bottomLeft, topLeft, Color.gray, 2f);
        }

        //updates position of the square based on mouse position
        transform.position = new Vector3(center.x, center.y, 0f);

        //updates scale of the square based on scroll value
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x + scrollValue, scale.y + scrollValue, 1f);
    }
}
