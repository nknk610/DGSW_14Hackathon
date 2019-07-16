using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public Text textComponent;
    public RawImage redZone;
    public RawImage greenZone;
    public RawImage pin;
    public RawImage house;
    public Texture2D newHouse;
    public Image gauge;
    public int speed;
    int direction;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        direction = 1;
      
        InitZone();
        redZone.gameObject.SetActive(true);
        greenZone.gameObject.SetActive(true);        
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();

        MovingPin();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            string state = pin.GetComponent<PinControl>().CheckPin();

            if(state == "green")
            {
                score += 10;
            }
            else if(state == "red")
            {
                score += 30;
            }
            else
            {
                score -= 50;
            }

            score =  Mathf.Clamp(score, -1, 100);

            if(score == 100)
            {
                CharacterManager.Get_instance().houseQuality += 30;
                CharacterManager.EndGame();
            }
            else if(score < 0)
            {
                CharacterManager.EndGame();
            }

            InitZone();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        direction *= -1;
    }

    void ShowScore()
    {
        gauge.fillAmount = score / 100f;
    } 

    void InitZone()
    {
        Vector3 vec = new Vector3(Random.Range(-825, 825), transform.position.y, 0);
        redZone.transform.position = vec;
        greenZone.transform.position = vec;
    }

    void MovingPin()
    {
        pin.transform.Translate(direction * Mathf.Max(score, 50) / 10 * speed * Time.deltaTime, 0, 0);
    }
}
