using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public RawImage coalBriquette;
    public GameObject startLine;
    public int speed;
    float lastInputAxis;
    Vector3 distance;
    bool hasCoalBriquette;

    void Awake()
    {
        lastInputAxis = 0;
        startLine.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        hasCoalBriquette = false;
        distance = transform.position - coalBriquette.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float inputAxis = Input.GetAxisRaw("Horizontal");

        if(inputAxis != lastInputAxis)
        {
            lastInputAxis = inputAxis;
            transform.Translate(speed * distance * (hasCoalBriquette ? 1 : -1) / 1000f);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.gameObject.tag == "Coal")
        {
            startLine.SetActive(true);
            hasCoalBriquette = true;
        }
        else if(collider.gameObject.tag == "Start")
        {
            CharacterManager.Get_instance().Temperature += 30;
            CharacterManager.EndGame();
        }
    }
}
