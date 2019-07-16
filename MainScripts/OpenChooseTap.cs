using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChooseTap : MonoBehaviour
{
    public GameObject MiniGameTap;

    public void OpenMiniGameTap()
    {
        Debug.Log("!");
        MiniGameTap.SetActive(true);
    }
}
