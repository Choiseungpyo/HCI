using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    

    // Color 관련
    public Image[] OrininalImg = new Image[3];
    public Image[] CurrentImg = new Image[3];

    // Font 관련
    public TMP_Text[] OriginalTxt = new TMP_Text[3];
    public TMP_Text[] CurrentFontTxt = new TMP_Text[2];
    public TMP_Text TestFontTxt;
    public Transform Page;
    public GameObject UnusedObj;
    public GameObject TestBox;
    public GameObject Ex;
    public TMP_Text PageNumTxt;
    string testFontName ="";
    Vector3[] pagePos = new Vector3[2];
    int pageNum =0;


    private void Start()
    {
       
        SetTypeActivationStatus(0);
        SetTypeBtnTxtColor(0);

        // 텍스트
        SetTypeTxt(0);
        InitTestFontTxt();

        InitPageNum();
        InitPagePos();
        InitTestData();
        SetPageBtn();
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

        SetTypeBtnTxtColor(index);
        SetTypeActivationStatus(index);
        SetTypeTxt(index);
    }

    void SetTypeBtnTxtColor(int index)
    {
        for(int i=0; i<Type.Length; i++)
        {
            if(i== index)
                Type[i].transform.parent.GetChild(index+1).GetChild(0).GetComponent<TMP_Text>().color = Color.black;
            else
                Type[i].transform.parent.GetChild(index+1).GetChild(0).GetComponent<TMP_Text>().color = Color.gray;
        }
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
        ChangeBeforeColor(obj, CurrentImg[index].color);
        SetCurrentImage(index, color);
        SetOriginalImg(index, color);
       
    }

    public void ChangeBeforeColor(GameObject obj, Color color)
    {
        obj.transform.parent.GetChild(7).GetComponent<Image>().color = color;
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

    public void TestFont()
    {
        if (TestBox.activeSelf) // 현재 테스트 이용중인 경우
        {
            UnusedObj.SetActive(true);
            TestBox.SetActive(false);
            Page.localPosition = pagePos[1];
        }
        else 
        {
            UnusedObj.SetActive(false);
            TestBox.SetActive(true);
            Page.localPosition = pagePos[0];
        }
        Debug.Log(Page.localPosition);
    }

    void InitTestData()
    {
        UnusedObj.SetActive(true);
        TestBox.SetActive(false);
        Page.localPosition = pagePos[1];
    }

    void InitPagePos()
    {
        pagePos[0] = new Vector3(-380, -250, 0);
        pagePos[1] = new Vector3(-380, -540, 0);
    }

    void InitPageNum()
    {
        pageNum = 1;
    }

    void SetPageNumTxt()
    {
        PageNumTxt.text = pageNum.ToString();
    }

    void SetPageBtn()
    {
        if (pageNum == 1)
        {
            Page.GetChild(0).gameObject.SetActive(false);
            Page.GetChild(1).gameObject.SetActive(true);
        }
        else if (pageNum == 10)
        {
            Page.GetChild(0).gameObject.SetActive(true);
            Page.GetChild(1).gameObject.SetActive(false);
        }
        else if(pageNum == 2 || pageNum == 9)
        {
            Page.GetChild(0).gameObject.SetActive(true);
            Page.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void MovePage()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;

        if (obj.name.Contains("Next"))
            pageNum++;
        else if (obj.name.Contains("Previous"))
            pageNum--;
        else
            Debug.LogWarning(obj.name);

        SetPageNumTxt();
        SetPageBtn();
        ChangeIndividualPos();
    }

    void ChangeIndividualPos()
    {
        Vector3 tmp = Vector3.zero;
        
        for(int i=0; i<10; i+=2)
        {
            if (i>=6)
            {
                tmp = Ex.transform.GetChild(6).GetChild(i - 6).localPosition;
                Ex.transform.GetChild(6).GetChild(i-6).localPosition = Ex.transform.GetChild(6).GetChild(i - 5).localPosition;
                Ex.transform.GetChild(6).GetChild(i-5).localPosition = tmp;
            }
            else
            {
                tmp = Ex.transform.GetChild(i).transform.localPosition;
                Ex.transform.GetChild(i).localPosition = Ex.transform.GetChild(i+1).transform.localPosition;
                Ex.transform.GetChild(i + 1).localPosition = tmp;
            }
        }
    }
}
