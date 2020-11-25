using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using KanKikuchi.AudioManager;
using WBmap;

public class CreateStgBtn : MonoBehaviour
{
    private GameObject myText;
    private Text buttonNum;

    //シーン遷移のフェード格納
    [SerializeField]
    GameObject FadeCanvas;
    Fade _fade;
    GameObject lockImg;
    [SerializeField]
    GameObject[] frontStarImg;
    [SerializeField]
    GameObject btnStarPanel;
    // Start is called before the first frame update
    void Start()
    {
        myText = transform.GetChild(0).gameObject;
        buttonNum = myText.GetComponent<Text>();
        FadeCanvas = GameObject.Find("FadeCanvas(Clone)");
        _fade = FadeCanvas.GetComponent<Fade>();

        for (int i = 0; i < frontStarImg.Length; i++)
        {
            frontStarImg[i].SetActive(false);
        }
        var starCount = PlayerPrefs.GetInt("createstar" + int.Parse(buttonNum.text).ToString(), 0);
        if (starCount == 0)
        {
            btnStarPanel.SetActive(false);
        }
        else
        {
            for (int i = 0; i < starCount; i++)
            {
                frontStarImg[i].SetActive(true);
            }
        }

        btnStarPanel.SetActive(true);

        //PlayerPrefsを使用してスコア判定をする
        /*var saveScore = PlayerPrefs.GetInt("createstar" + (int.Parse(buttonNum.text) - 1).ToString(), 0);
        if (saveScore == 0)
        {
            if (int.Parse(buttonNum.text) == 1)
            {
                gameObject.GetComponent<Button>().interactable = true;
                btnStarPanel.SetActive(true);
                Debug.Log("キー解除");
            }
            else
            {
                gameObject.GetComponent<Button>().interactable = false;
                Debug.Log("キー解除なし");
            }
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
            btnStarPanel.SetActive(true);
            Debug.Log("キー解除");
        }*/

        //SaveSystemを使用してスコアのセーブをするときに使う　WEBGLではうまく動かないのでunityroom投稿では使用しない
        /*
        if (int.Parse(buttonNum.text)-1 <= SaveSystem.Instance.StarData.stageSterQuantity.Count)
        {
            //lockImg.SetActive(false);
            gameObject.GetComponent<Button>().interactable = true;
            Debug.Log("キー解除");
        }
        else
        {
            //lockImg.SetActive(true);
            gameObject.GetComponent<Button>().interactable = false;
            Debug.Log("キー解除なし");
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateStageSelect()
    {
        GManager.instance.stageNum = int.Parse(buttonNum.text);
        GManager.instance.setStageState(2);
        SEManager.Instance.Play(SEPath.FANTASYCLICKSOUNDS1);
        //ここにさせたい処理を書く
        _fade.FadeIn(1.0f, (() =>
        {
            //処理
            SceneManager.LoadScene("InGame");
        }));
    }
}
