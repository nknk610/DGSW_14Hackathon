using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dancing : MonoBehaviour
{
    public RawImage hand;
    public Image gauge;
    public Text leftTime;
    int time;

    // Start is called before the first frame update
    void Start()
    {
        time = 30;

        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        gauge.fillAmount -= 0.1f * Time.deltaTime;

        gauge.fillAmount += Mathf.Abs(Input.GetAxisRaw("Mouse X")) * Time.deltaTime / 100f;

        if(time == 0)
        {
            CharacterManager.Get_instance().mental += 30;
            CharacterManager.EndGame();
        }
        else if(gauge.fillAmount <= 0f)
        {
            CharacterManager.EndGame();
        }
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
}
