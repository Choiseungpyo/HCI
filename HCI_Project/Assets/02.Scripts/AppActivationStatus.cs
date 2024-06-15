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
        
        if (!currentActivationStatus) // 현재 비활성화
        {
            AppIcon.GetComponent<Image>().color = Color.green;
            colorBlock.pressedColor = new Color(0, 0.7f, 0, 1); // 초록색보다 조금더 어둡게
        }

        else
        {
            AppIcon.GetComponent<Image>().color = Color.red;
            colorBlock.pressedColor = new Color(0.7f, 0, 0, 1); // 빨간색보다 조금더 어둡게
        }
        AppIcon.GetComponent<Button>().colors = colorBlock;
        currentActivationStatus = !currentActivationStatus;
    }

    void InitAppIconBtnColor()
    {
        AppIcon.GetComponent<Image>().color = Color.green;
        ColorBlock colorBlock = AppIcon.GetComponent<Button>().colors;
        colorBlock.pressedColor = new Color(0, 0.7f, 0, 1); // 초록색보다 조금더 어둡게
        AppIcon.GetComponent<Button>().colors = colorBlock;
    }
}
