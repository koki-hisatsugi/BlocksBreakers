using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using KanKikuchi.AudioManager;

public class Buttons : MonoBehaviour
{
    private GameObject myText;
    private Text buttonNum;

    //シーン遷移のフェード格納
    [SerializeField]
    GameObject FadeCanvas;
    Fade _fade;
    // Start is called before the first frame update
    void Start()
    {
        myText = transform.GetChild(0).gameObject;
        buttonNum = myText.GetComponent<Text>();
        FadeCanvas = GameObject.Find("FadeCanvas(Clone)");
        _fade = FadeCanvas.GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stageSelect()
    {
        GManager.instance.stageNum = int.Parse(buttonNum.text);
        SEManager.Instance.Play(SEPath.FANTASYCLICKSOUNDS1);
        //ここにさせたい処理を書く
        _fade.FadeIn(1.0f, (() =>
        {
            //処理
            SceneManager.LoadScene("InGame");
        }));
    }
}
