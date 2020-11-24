using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using WBmap;
using KanKikuchi.AudioManager;

public class StageSelectMG : MonoBehaviour
{
    [SerializeField]
    GameObject FadeCanvas;
    Fade _fade;

    //public string path => Application.dataPath + "/Resources/StageStar.json";
    public string path => Path.Combine(Application.dataPath, "StageStar.json");

    private void Awake()
    {
        //SaveSystemを使用してスコアのセーブをするときに使う　WEBGLではうまく動かないのでunityroom投稿では使用しない
        /*if (!File.Exists(path))
        {
            //SaveSystem.Instance.StarData.stageSterQuantity.Add(0);
            SaveSystem.Instance.Save();
            Debug.Log("ファイルを初期値でセーブしました。");
        }
        SaveSystem.Instance.Load();*/

        //Debug.Log(SaveSystem.Instance.StarData.stageSterQuantity[0]);
        //Debug.Log(SaveSystem.Instance.StarData.stageSterQuantity.Count);
    }
    // Start is called before the first frame update
    void Start()
    {
        FadeCanvas = GameObject.Find("FadeCanvas(Clone)");
        _fade = FadeCanvas.GetComponent<Fade>();

        _fade.FadeOut(0.5f, (() =>
        {
            //処理
        }));
    }

    public void CreateStageSelect()
    {
        SEManager.Instance.Play(SEPath.FANTASYCLICKSOUNDS1);
        //ここにさせたい処理を書く
        _fade.FadeIn(1.0f, (() =>
        {
            //処理
            SceneManager.LoadScene("CreateStageSelect");
        }));
    }
    public void NomalStageSelect()
    {
        SEManager.Instance.Play(SEPath.FANTASYCLICKSOUNDS1);
        //ここにさせたい処理を書く
        _fade.FadeIn(1.0f, (() =>
        {
            //処理
            SceneManager.LoadScene("StageSelect");
        }));
    }
    public void CreateStageIngame()
    {
        SEManager.Instance.Play(SEPath.FANTASYCLICKSOUNDS1);
        //ここにさせたい処理を書く
        _fade.FadeIn(1.0f, (() =>
        {
            //処理
            SceneManager.LoadScene("InGame_new");
        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
