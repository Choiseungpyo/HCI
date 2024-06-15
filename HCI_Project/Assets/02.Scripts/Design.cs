using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Design : MonoBehaviour
{
    // Type 관련
    public GameObject[] Type = new GameObject[3];
    public TMP_Text[] TypeTxt = new TMP_Text[3];

    public GameObject TestObj;
    public Transform Page;

    // Color 관련
    public Image[] OrininalImg = new Image[3];
    public Image[] CurrentImg = new Image[3];

    // Font 관련
    public TMP_Text[] OriginalTxt = new TMP_Text[3];
    public TMP_Text[] CurrentFontTxt = new TMP_Text[2];
    public TMP_Text TestFontTxt;
    string testFontName ="";

    private void Start()
    {
       
        SetTypeActivationStatus(0);

        // 텍스트
        SetTypeTxt(0);
        InitTestFontTxt();
    }

    public void SetType()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        int index = 0;

        if (obj.name.Contains("Background"))
            index = 0;
        else if (obj.name.Contains("Color"))
            index = 1;
        else if (obj.name.Contains("Font"))
            index = 2;
        else
            Debug.LogWarning(index);

        SetTypeActivationStatus(index);
        SetTypeTxt(index);
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

    // 색깔 관련 ------------------------------------------------------------------------------------------

    void SetTypeTxt(int index)
    {
        for(int i=0; i<TypeTxt.Length; i++)
        {
            if (i == index)
                TypeTxt[i].color = Color.black;
            else
                TypeTxt[i].color = Color.gray;
        }
    }

    void SetCurrentImage(int index, Color color)
    {
        CurrentImg[index].color = color;
    }

    void SetOriginalImg(int index, Color color)
    {
        OrininalImg[index].color = color;
    }


    public void ChangeCurrentColor()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        int index = 0;
        
        if (obj.transform.parent.parent.name.Equals("Icon"))
            index = 0;
        else if (obj.transform.parent.parent.name.Equals("Dir"))
            index = 1;
        else if (obj.transform.parent.parent.name.Equals("Content"))
            index = 2;
        else
            Debug.LogWarning(index);

        Debug.Log(obj.transform.parent.name);
        Color color = obj.GetComponent<Image>().color;
        SetCurrentImage(index, color);
        SetOriginalImg(index, color);
    }

    // 폰트 관련 ------------------------------------------------------------------------------------------

    public void CheckClickedFont()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        testFontName = obj.transform.GetChild(0).GetComponent<TMP_Text>().text;

        TestFontTxt.GetComponent<TextMeshProUGUI>().font = obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().font;
        TestFontTxt.text = testFontName + " 글씨체를\r\n확인하고 있습니다.";
    }

    void InitTestFontTxt()
    {
        TestFontTxt.text = "";
        testFontName = "";
    }

    public void SetCurrentFont()
    {
        if (testFontName.Equals(""))
            return;

        for(int i = 0; i < CurrentFontTxt.Length; i++)
            CurrentFontTxt[i].GetComponent<TextMeshProUGUI>().font = TestFontTxt.GetComponent<TextMeshProUGUI>().font;

        CurrentFontTxt[0].text = testFontName;
        CurrentFontTxt[1].text = "이 글씨는 현재 " + testFontName + "\r\n글씨체입니다.";

        for(int i=0; i<OriginalTxt.Length; i++)
            OriginalTxt[i].GetComponent<TextMeshProUGUI>().font = TestFontTxt.GetComponent<TextMeshProUGUI>().font;
    }    
}
