using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    // Type 관련
    public GameObject[] Type = new GameObject[2];
    public TMP_Text[] TypeTxt = new TMP_Text[2];
    
    public GameObject[] Ex = new GameObject[2];



    int typeNum = 0;
    
    private void Start()
    {
        SetTypeActivationStatus(0);
        SetTypeTxt(0);
    }


    public void SetType() // 활성화, 비활성화 선택 
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        if (obj.name.Contains("Able"))
            typeNum = 0;
        else if (obj.name.Contains("Disable"))
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

    void ChangeActiveState(GameObject obj) // 버튼 클릭시 해당 소리 아이콘을 활성화/비활성화
    {
        if (typeNum ==0)
        {
            string soundName = obj.transform.parent.GetChild(2).GetComponent<TMP_Text>().text;

            // 배경 원 회색으로 변경 및 비활성화
            obj.transform.parent.GetChild(0).GetComponent<Image>().color = new Color(0.77f, 0.77f, 0.77f, 1);
            obj.transform.parent.GetChild(0).GetComponent<Button>().enabled = false;

            // 아이콘 제거 및 색깔 투명하게
            obj.transform.parent.GetChild(1).GetComponent<Image>().enabled = false;

            // 텍스트 제거
            obj.transform.parent.GetChild(2).GetComponent<TMP_Text>().enabled = false;

            // 0번과 6번 자리 교환
            Vector3 tmp = obj.transform.parent.transform.localPosition;
            obj.transform.parent.localPosition = Type[0].transform.GetChild(2).GetChild(6).transform.localPosition;
            Type[0].transform.GetChild(2).GetChild(6).transform.localPosition = tmp;


            Type[1].transform.GetChild(2).GetChild(7).GetChild(0).GetComponent<Image>().color = Color.white;
            Type[1].transform.GetChild(2).GetChild(7).GetChild(0).GetComponent<Button>().enabled = true;

            // 아이콘 제거 및 색깔 투명하게
            Type[1].transform.GetChild(2).GetChild(7).GetChild(1).GetComponent<Image>().enabled = true;

            // 텍스트 제거
            Type[1].transform.GetChild(2).GetChild(7).GetChild(2).GetComponent<TMP_Text>().enabled = true;
        }
        else
        {
            // 배경 원 회색으로 변경 및 비활성화
            obj.transform.parent.GetChild(0).GetComponent<Image>().color = new Color(0.77f, 0.77f, 0.77f, 1);
            obj.transform.parent.GetChild(0).GetComponent<Button>().enabled = false;

            // 아이콘 제거 및 색깔 투명하게
            obj.transform.parent.GetChild(1).GetComponent<Image>().enabled = false;

            // 텍스트 제거
            obj.transform.parent.GetChild(2).GetComponent<TMP_Text>().enabled = false;

            // 0번과 7번 자리 교환
            Vector3 tmp = obj.transform.parent.transform.localPosition;
            obj.transform.parent.localPosition = Type[1].transform.GetChild(2).GetChild(7).transform.localPosition;
            Type[1].transform.GetChild(2).GetChild(7).transform.localPosition = tmp;


            Type[0].transform.GetChild(2).GetChild(7).GetChild(0).GetComponent<Image>().color = Color.white;
            Type[0].transform.GetChild(2).GetChild(7).GetChild(0).GetComponent<Button>().enabled = true;
            Type[0].transform.GetChild(2).GetChild(7).GetChild(1).GetComponent<Image>().enabled = true;
            Type[0].transform.GetChild(2).GetChild(7).GetChild(2).GetComponent<TMP_Text>().enabled = true;

            tmp = Type[0].transform.GetChild(2).GetChild(7).transform.localPosition;
            Type[0].transform.GetChild(2).GetChild(7).transform.localPosition = Type[0].transform.GetChild(2).GetChild(0).transform.localPosition;
            Type[0].transform.GetChild(2).GetChild(0).transform.localPosition = tmp;
        }
    }
  

    public void ClickSoundIcon()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        ChangeActiveState(obj);
    }

}
