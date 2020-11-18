using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using UnityEngine.SceneManagement;
using KanKikuchi.AudioManager;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    GameObject FadeCanvas;
    Fade _fade;

    private void Start()
    {
        //FadeCanvas = GManager.instance._FadeCanvas;
        FadeCanvas = GameObject.Find("FadeCanvas(Clone)");
        //DontDestroyOnLoad(FadeCanvas);
        _fade = FadeCanvas.GetComponent<Fade>();
    }

    // オブジェクトが有効化されたときに呼ばれる
    private void OnEnable()
    {
        // eventにイベントハンドラを登録する
        GetComponent<TapGesture>().Tapped += OnTapHandler;

    }

    // オブジェクトが無効化されたときに呼ばれる
    private void OnDisable()
    {
        // eventからイベントハンドラを削除する
        GetComponent<TapGesture>().Tapped -= OnTapHandler;
    }

    //タップのハンドラ
    private void OnTapHandler(object sender, System.EventArgs e)
    {
        //ここにさせたい処理を書く
        SEManager.Instance.Play(SEPath.CLICKSOUNDS10);
        _fade.FadeIn(1.0f, (() =>
        {
            //処理
            SceneManager.LoadScene("StageSelect");
        }));
    }
}
