using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowStat : MonoBehaviour
{
    public Image hungryGauge;
    public Image mentalGauge;
    public Image temperatureGauge;
    public Image houseQulityGauge;
    public Image tiredGauge;
    public Text day;

    delegate void Method();
    Method insertStat;

    void Start()
    {
        insertStat = method;
       
    }

    void Update()
    {
        insertStat();
    }

    void method()
    {
        hungryGauge.fillAmount = CharacterManager.Get_instance().hungry / 100f;
        mentalGauge.fillAmount = CharacterManager.Get_instance().mental / 100f;
        temperatureGauge.fillAmount = CharacterManager.Get_instance().Temperature / 100f;
        houseQulityGauge.fillAmount = CharacterManager.Get_instance().houseQuality / 100f;
        tiredGauge.fillAmount = CharacterManager.Get_instance().tired / 100f;
        day.text = CharacterManager.Get_instance().Day.ToString();
        insertStat = () => { };
    }
}
