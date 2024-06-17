using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    // Type ����
    public GameObject[] Type = new GameObject[2];
    public TMP_Text[] TypeTxt = new TMP_Text[2];
    
    public GameObject[] Ex = new GameObject[2];



    int typeNum = 0;
    
    private void Start()
    {
        SetTypeActivationStatus(0);
        SetTypeTxt(0);
    }


    public void SetType() // Ȱ��ȭ, ��Ȱ��ȭ ���� 
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

    void ChangeActiveState(GameObject obj) // ��ư Ŭ���� �ش� �Ҹ� �������� Ȱ��ȭ/��Ȱ��ȭ
    {
        if (typeNum ==0)
        {
            string soundName = obj.transform.parent.GetChild(2).GetComponent<TMP_Text>().text;

            // ��� �� ȸ������ ���� �� ��Ȱ��ȭ
            obj.transform.parent.GetChild(0).GetComponent<Image>().color = new Color(0.77f, 0.77f, 0.77f, 1);
            obj.transform.parent.GetChild(0).GetComponent<Button>().enabled = false;

            // ������ ���� �� ���� �����ϰ�
            obj.transform.parent.GetChild(1).GetComponent<Image>().enabled = false;

            // �ؽ�Ʈ ����
            obj.transform.parent.GetChild(2).GetComponent<TMP_Text>().enabled = false;

            // 0���� 6�� �ڸ� ��ȯ
            Vector3 tmp = obj.transform.parent.transform.localPosition;
            obj.transform.parent.localPosition = Type[0].transform.GetChild(2).GetChild(6).transform.localPosition;
            Type[0].transform.GetChild(2).GetChild(6).transform.localPosition = tmp;


            Type[1].transform.GetChild(2).GetChild(7).GetChild(0).GetComponent<Image>().color = Color.white;
            Type[1].transform.GetChild(2).GetChild(7).GetChild(0).GetComponent<Button>().enabled = true;

            // ������ ���� �� ���� �����ϰ�
            Type[1].transform.GetChild(2).GetChild(7).GetChild(1).GetComponent<Image>().enabled = true;

            // �ؽ�Ʈ ����
            Type[1].transform.GetChild(2).GetChild(7).GetChild(2).GetComponent<TMP_Text>().enabled = true;
        }
        else
        {
            // ��� �� ȸ������ ���� �� ��Ȱ��ȭ
            obj.transform.parent.GetChild(0).GetComponent<Image>().color = new Color(0.77f, 0.77f, 0.77f, 1);
            obj.transform.parent.GetChild(0).GetComponent<Button>().enabled = false;

            // ������ ���� �� ���� �����ϰ�
            obj.transform.parent.GetChild(1).GetComponent<Image>().enabled = false;

            // �ؽ�Ʈ ����
            obj.transform.parent.GetChild(2).GetComponent<TMP_Text>().enabled = false;

            // 0���� 7�� �ڸ� ��ȯ
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
