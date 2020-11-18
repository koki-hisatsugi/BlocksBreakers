using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPanelManager : MonoBehaviour
{
    public GameObject[] StarFlontImage;

    // Start is called before the first frame update
    void Start()
    {
        /*for(int i = 0; i < StarFlontImage.Length; i++)
        {
            StarFlontImage[i].SetActive(false);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        for (int i = 0; i < StarFlontImage.Length; i++)
        {
            StarFlontImage[i].SetActive(false);
        }
        MathStarDisplay();
        Debug.Log("イネーブル");
    }

    public void MathStarDisplay()
    {
        Debug.Log("イネーブル0");
        if (GManager.instance.stageScore >= GManager.instance.stageScoreMax)
        {
            //Debug.Log("イネーブル1");
            for (int i = 0; i < StarFlontImage.Length; i++)
            {
                StarFlontImage[i].SetActive(true);
                Debug.Log("イネーブル1");
            }
        }else if(GManager.instance.stageScore >= (GManager.instance.stageScoreMax * (2 / 3)))
        {
            //Debug.Log("イネーブル2");
            for (int i = 0; i < StarFlontImage.Length-1; i++)
            {
                StarFlontImage[i].SetActive(true);
                Debug.Log("イネーブル2");
            }
        }
        else if (GManager.instance.stageScore >= (GManager.instance.stageScoreMax * (1 / 3)))
        {
            //Debug.Log("イネーブル3");
            for (int i = 0; i < StarFlontImage.Length - 2; i++)
            {
                StarFlontImage[i].SetActive(true);
                Debug.Log("イネーブル1");
            }
        }

    }
}
