using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaterControl : MonoBehaviour
{
    public RawImage water;
    public RawImage Startline;
    public RawImage Endline;
    public Text textComponent;
    public int scale;
    int initialStartline;
    float baselineStart;
    float baselineEnd;
    float height;
    public delegate void Method();
    Method update;

    // Start is called before the first frame update
    void Start()
    {
        initialStartline = (int)water.transform.position.y;
        Startline.gameObject.SetActive(false);
        Endline.gameObject.SetActive(false);

        update = () =>
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartFlow();

                textComponent.text = "적정량에 도달했을 때 스페이스 바를 누르십시오.";

                Startline.gameObject.SetActive(true);
                Endline.gameObject.SetActive(true);

                baselineStart = Random.Range(100, 200);
                baselineEnd = baselineStart + Random.Range(30, 50);

                Startline.transform.position = new Vector3(Startline.transform.position.x,
                                                initialStartline + baselineStart,
                                                Startline.transform.position.z);

                Endline.transform.position = new Vector3(Endline.transform.position.x,
                                                initialStartline + baselineEnd,
                                                Endline.transform.position.z);
            }
        };    
    }

    // Update is called once per frame
    void Update()
    {
        update();
    }

    void StartFlow()
    {
        Method flood = () =>
        {
            height += Time.deltaTime * scale;
        };

        update = () =>
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                flood = () =>
                {

                };

                CheckHeight();
            }
            else if(baselineEnd < height)
            {
                Debug.Log("실패");
                //SceneManager.LoadScene("Main"); //메인으로 이동
            }

            flood();
            int ceilHeight = Mathf.CeilToInt(height);
            water.transform.localScale = new Vector3(1, ceilHeight, 1);
            water.transform.position = new Vector3(water.transform.position.x,
                                        initialStartline + ceilHeight / 2,
                                        water.transform.position.z);
        };
    }

    void CheckHeight()
    {
        if(baselineStart <= height && height <= baselineEnd)
        {
            Debug.Log("Success");
            CharacterManager.Get_instance().hungry += 30;
        }
        else
        {
            Debug.Log("Fail");
        }

        CharacterManager.EndGame();
    }
}
