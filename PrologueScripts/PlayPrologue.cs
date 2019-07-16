using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPrologue : SceneScript
{
    public Text ment;
    public Sprite[] backgrounds;
    public Image background;
    public string[] texts;
    int text_indexNum=0;

    void Start()
    {
        ment.text = texts[text_indexNum];
        background.sprite = backgrounds[text_indexNum];
    }

    public void ProgressPrologue()
    {
        
        if (text_indexNum+2 > backgrounds.Length)
        {
            ChangeScene("Main");
        }

        ment.text = texts[text_indexNum+1];
        background.sprite = backgrounds[text_indexNum+1];
        text_indexNum += 1;

    }
}
 