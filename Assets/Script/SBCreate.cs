using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SBCreate : MonoBehaviour
{
    public RectTransform contentRectTransform;
    public Button button;


    public string stageLoad;
    public int btnQuantity;

    private void Start()
    {
        OnLoadPrefs();
        Debug.Log(btnQuantity);
        for (int i = 1; i <= btnQuantity; i++)
        {
            var obj = Instantiate(button, contentRectTransform);
            obj.GetComponentInChildren<Text>().text = i.ToString();
        }
    }

    //PlayerPrefsに保存してあるステージを呼び出し
    private void OnLoadPrefs()
    {
        int prefsNum = 0;
        //string tempStageData = PlayerPrefs.GetString("Create" + prefsNum.ToString(), "null");
        //Debug.Log(tempStageData);
        while (true)
        {
            if (!PlayerPrefs.HasKey("Create" + prefsNum.ToString()))
            {
                Debug.Log(prefsNum);
                break;
            }
            prefsNum++;
        }

        btnQuantity = prefsNum;

    }
}
