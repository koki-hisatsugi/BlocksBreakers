using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class HowToPanel : MonoBehaviour
{

    public GameObject[] howToImage;
    public int pageNum;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < howToImage.Length; i++)
        {
            howToImage[i].SetActive(false);
        }
        pageNum = 0;
        howToImage[pageNum].SetActive(true);
    }

    public void RightButton()
    {
        SEManager.Instance.Play(SEPath.CLICKSOUNDS10);
        howToImage[pageNum].SetActive(false);
        pageNum++;
        if (pageNum >= howToImage.Length)
        {
            pageNum = 0;
        }
        howToImage[pageNum].SetActive(true);
    }

    public void LeftButton()
    {
        SEManager.Instance.Play(SEPath.CLICKSOUNDS10);
        howToImage[pageNum].SetActive(false);
        pageNum--;
        if (pageNum <0)
        {
            pageNum = howToImage.Length - 1;
        }
        howToImage[pageNum].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
