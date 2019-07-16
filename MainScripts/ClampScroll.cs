using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampScroll : MonoBehaviour
{
    

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -200, 400), transform.position.y);
        }
        

    }
}
