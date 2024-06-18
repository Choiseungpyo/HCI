using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button[] IconBtn = new Button[4];
    public TMP_Text[] IconNameTxt = new TMP_Text[4];
    public GameObject[] TypeObj= new GameObject[4];

    private void Start()
    {
        SetTypeActivationStatus(0);
        SetIconBtnColor(0);
        SetIconNameTxtColor(0);
    }

    // 메뉴에서 아이콘을 클릭할 때 동작
    public void SetIconData()
    {
        GameObject clickedObj = EventSystem.current.currentSelectedGameObject;

        int index = 0;
        switch (clickedObj.name)
        {
            case "HomeBtn":
                index = 0;
                break;
            case "DesignBtn":
                index = 1;
                break;
            case "SoundBtn":
                index = 2;
                break;
            case "VibrationBtn":
                index = 3;
                break;
            default:
                Debug.LogWarning(clickedObj.name);
                break;
        }
        SetIconBtnColor(index);
        SetIconNameTxtColor(index);
        SetTypeActivationStatus(index);
    }

    void SetIconBtnColor(int index)
    {
        for(int i=0; i< IconBtn.Length;i++)
        {
            if(i == index)
                IconBtn[i].GetComponent<Image>().color = Color.black;
            else
                IconBtn[i].GetComponent<Image>().color = Color.white;
        }
    }

    void SetIconNameTxtColor(int index)
    {
        for (int i = 0; i < IconBtn.Length; i++)
        {
            if (i == index)
                IconNameTxt[i].color = Color.black;
            else
                IconNameTxt[i].color = Color.gray;
        }
    }

    void SetTypeActivationStatus(int index)
    {
        for (int i = 0; i < IconBtn.Length; i++)
        {
            if (i == index)
                TypeObj[i].SetActive(true);
            else
                TypeObj[i].SetActive(false);
        }
    }
}
