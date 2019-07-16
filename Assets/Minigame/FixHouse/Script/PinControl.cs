using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinControl : MonoBehaviour
{
    bool green = false;
    bool red = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "green")
        {
            green = true;
        }
        if (collider.tag == "red")
        {
            red = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "green")
        {
            green = false;
        }
        if (collider.tag == "red")
        {
            red = false;
        }
    }

    public string CheckPin()
    {
        if (red)
        {
            return "red";
        }
        else if (green)
        {
            return "green";
        }

        return "";
    }
}
