using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
        string name = "Mr A";
        int health = 5;
        health = health - 2;
        health -= 2;
        health++;
        float critChance = 0.6f;
        bool alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
