using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RowGeneration : MonoBehaviour
{
    //ui references
    public TMP_InputField squareNumberInput;
    public Button generateButton;

    //square settings
    public float squareSize = 1f; //width and height of each square
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()    
    {
        //checks whether button is pressed
        //forgot how exactly to do this: https://docs.unity3d.com/6000.5/Documentation/ScriptReference/Events.UnityEvent.AddListener.html
        if (generateButton != null)
        {
            generateButton.onClick.AddListener(OnButtonClicked);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        //parse the input field value to a number, then activate the generator
        //https://www.dotnetperls.com/parse
        int count = int.Parse(squareNumberInput.text);
        GenerateSquareRow(count);
    }

    public void GenerateSquareRow(int count)
    {
        //logic for generating squares based on count
        for (int i = 0; i < count; i++)
        {
            //prevent overlap by horizontally offsetting each square by its width
            float hOffset = i * squareSize;

            //create points for the four corners
            Vector3 bottomLeft = Vector3.zero + new Vector3(hOffset, 0f, 0f);
            Vector3 bottomRight = Vector3.zero + new Vector3(hOffset + squareSize, 0f, 0f);
            Vector3 topLeft = Vector3.zero + new Vector3(hOffset, squareSize, 0f);
            Vector3 topRight = Vector3.zero + new Vector3(hOffset + squareSize, squareSize, 0f);

            //draw lines between the four corners to form a square
            Debug.DrawLine(bottomLeft, bottomRight, Color.gray, 2f);
            Debug.DrawLine(bottomRight, topRight, Color.gray, 2f);
            Debug.DrawLine(topRight, topLeft, Color.gray, 2f);
            Debug.DrawLine(topLeft, bottomLeft, Color.gray, 2f);
        }
    }
}
