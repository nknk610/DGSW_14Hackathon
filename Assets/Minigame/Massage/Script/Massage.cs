using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Massage : MonoBehaviour
{
    public RawImage back;
    public Image gauge;
    public Text leftTime;
    public Button shoulder;
    int time;

    // Start is called before the first frame update
    void Start()
    {
        shoulder.onClick.AddListener(Touching);

        time = 30;

        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if(time == 0)
        {
            CharacterManager.Get_instance().tired += 30;
            EndGame();
        }
        else if(gauge.fillAmount < 0f)
        {
            EndGame();
        }

        gauge.fillAmount -= 0.1f * Time.deltaTime;
    }

    IEnumerator Timer()
    {
        while(time != 0)
        {
            time--;
            leftTime.text = "남은 시간 : " + time;
            yield return new WaitForSeconds(1);
        }
    }

    void Touching()
    {
        gauge.fillAmount += 0.01f;
    }

    void EndGame()
    {
        //SceneManager.LoadScene("Main"); //메인으로 이동
    }
}
