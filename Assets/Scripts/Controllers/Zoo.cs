using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Zoo : MonoBehaviour
{

    public List<string> animals;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animals.Add("Penguin");
        animals.Add("Triceratops");
        animals.Add("Shark");

        animals.Remove("Triceratops");

        //lists are 0-indexed, this is the identifier that says where this item is in the list
        //Tiger [0]
        //Penguin [1]
        //Shark [2]

        foreach(string currentAnimal in animals)
        {
            Debug.Log("Our next animal is: " + currentAnimal);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
