using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppActivationStatus : MonoBehaviour
{
    public GameObject AppIcon;

    bool currentActivationStatus = true;

    void Start()
    {
        InitAppIconBtnColor();
    }

    public void SetAppIconBtnColor()
    {
        ColorBlock colorBlock = AppIcon.GetComponent<Button>().colors;
        
        if (!currentActivationStatus) // ���� ��Ȱ��ȭ
        {
            AppIcon.GetComponent<Image>().color = Color.green;
            colorBlock.pressedColor = new Color(0, 0.7f, 0, 1); // �ʷϻ����� ���ݴ� ��Ӱ�
        }

        else
        {
            AppIcon.GetComponent<Image>().color = Color.red;
            colorBlock.pressedColor = new Color(0.7f, 0, 0, 1); // ���������� ���ݴ� ��Ӱ�
        }
        AppIcon.GetComponent<Button>().colors = colorBlock;
        currentActivationStatus = !currentActivationStatus;
    }

    void InitAppIconBtnColor()
    {
        AppIcon.GetComponent<Image>().color = Color.green;
        ColorBlock colorBlock = AppIcon.GetComponent<Button>().colors;
        colorBlock.pressedColor = new Color(0, 0.7f, 0, 1); // �ʷϻ����� ���ݴ� ��Ӱ�
        AppIcon.GetComponent<Button>().colors = colorBlock;
    }
}
