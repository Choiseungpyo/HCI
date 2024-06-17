using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Vibration : MonoBehaviour
{
    // Type ����
    public GameObject[] Type = new GameObject[2];
    public TMP_Text[] TypeTxt = new TMP_Text[2];

    public Sprite[] SelectedTypeImg = new Sprite[2];

    public Slider[] VolumeSlider = new Slider[2];

    int typeNum = 0;


    void Start()
    {
        SetTypeActivationStatus(0);
        SetTypeTxt(0);
    }

    public void SetType() // �Ҹ� �νĽ�, �� ���� ����
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        if (obj.name.Contains("SoundPerception"))
            typeNum = 0;
        else if (obj.name.Contains("AppInner"))
            typeNum = 1;
        else
            Debug.LogWarning(typeNum);


        SetTypeActivationStatus(typeNum);
        SetTypeTxt(typeNum);
    }

    void SetTypeActivationStatus(int index)
    {
        for (int i = 0; i < Type.Length; i++)
        {
            if (i == index)
                Type[i].SetActive(true);
            else
                Type[i].SetActive(false);
        }
    }

    void SetTypeTxt(int index)
    {
        for (int i = 0; i < TypeTxt.Length; i++)
        {
            if (i == index)
                TypeTxt[i].color = Color.black;
            else
                TypeTxt[i].color = Color.gray;
        }
    }

    public void SelectVibrationKind() // ���� ������ �����Ѵ�. 
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        string clickedObjName = obj.transform.parent.name;
        for (int i = 0; i < 8; i++)
        {
            if (!clickedObjName.Equals(i.ToString()))
            {
                obj.transform.parent.parent.GetChild(2 + i).GetChild(1).GetComponent<Image>().sprite = SelectedTypeImg[0];
                continue;
            }
        }

        obj.GetComponent<Image>().sprite = SelectedTypeImg[1];
        if (VolumeSlider[typeNum].value > 0)
        {
            obj.GetComponent<AudioSource>().volume = VolumeSlider[typeNum].value;
            obj.GetComponent<AudioSource>().Play();
        }
    }

}
