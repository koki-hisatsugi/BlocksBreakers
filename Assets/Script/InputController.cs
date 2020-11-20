using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using TouchScript.Gestures.TransformGestures;

public class InputController : MonoBehaviour
{

    //弾道予測スクリプト
    Estimation estimation;
    //タッチされている座標
    private Vector3 releasePoint;
    BallManager ballManager;

    private GameObject Twall;

    //シーン遷移のフェード格納
    [SerializeField]
    GameObject FadeCanvas;
    Fade _fade;

    //タッチが行われた判定
    bool isTouth;
    
    void Start()
    {
        //フェードの格納
        FadeCanvas = GameObject.Find("FadeCanvas(Clone)");
        _fade = FadeCanvas.GetComponent<Fade>();
        //フェードアウト処理
        _fade.FadeOut(0.5f, (() =>
        {}));

        estimation = GetComponent<Estimation>();
        ballManager = GetComponent<BallManager>();
        Twall = GameObject.Find("Twall");
    }

    // オブジェクトが有効化されたときにeventにメソッドを登録する
    private void OnEnable()
    {
        GetComponent<PressGesture>().Pressed += OnPress;
        GetComponent<TransformGesture>().Transformed += OnTransformed;
        GetComponent<ReleaseGesture>().Released += OnRelease;
    }

    // オブジェクトが無効化されたときにeventからメソッドを削除する
    private void OnDisable()
    {
        GetComponent<PressGesture>().Pressed -= OnPress;
        GetComponent<TransformGesture>().Transformed -= OnTransformed;
        GetComponent<ReleaseGesture>().Released -= OnRelease;
    }

    // タッチすると呼ばれる
    private void OnPress(object sender, System.EventArgs e)
    {
        if (Time.timeScale == 0) { return; }
        if (!ballManager.isShooting && (GManager.instance.getState() == GManager.GameState.PlayerTurn))
        {
            //点を可視化
            estimation.Visualaization();
            // PressGesture型にキャスト
            var gesture = sender as PressGesture;
            Vector3 point = gesture.ScreenPosition;
            LineUpdate(point);
        }
    }

    //　離した時に呼ばれる
    private void OnRelease(object sender, System.EventArgs e)
    {
        if (Time.timeScale == 0) { return; }
        if (!ballManager.isShooting && !ballManager.aggregation &&(GManager.instance.getState()== GManager.GameState.PlayerTurn))
        {
            Transform ballbornpoint = estimation.getBallBornPoint();
            if (releasePoint.y - 0.1f >= ballbornpoint.position.y)
            {
                //点を不可視化
                estimation.Misunderstanding();
                //Debug.Log(releasePoint);
                ballManager.Shooting(releasePoint);
                
            }
        }
        //点を不可視化
        estimation.Misunderstanding();
    }

    // スワイプすると呼ばれる
    private void OnTransformed(object sender, System.EventArgs e)
    {
        if (Time.timeScale == 0) { return; }
        if (!ballManager.isShooting && (GManager.instance.getState() == GManager.GameState.PlayerTurn))
        {
            // TransformGesture型にキャスト
            var gesture = sender as TransformGesture;
            //タッチされているスクリーン座標を得る
            Vector3 point = gesture.ScreenPosition;
            LineUpdate(point);
        }
        /*//スクリーン座標を得ワールド座標に変換
        Vector3 point = gesture.ScreenPosition;
        point.z = Camera.main.transform.position.y;
        Vector3 p = Camera.main.ScreenToWorldPoint(point);
        //エスティメーション更新
        estimation.SetPoint(p);*/
    }

    // タッチされている座標が有効ならestimationへ渡す
    void LineUpdate(Vector3 point)
    {
        //Debug.Log(point);
        //point.z = Camera.main.transform.position.y;
        //Debug.Log(point);
        releasePoint = Camera.main.ScreenToWorldPoint(point);
        Transform ballbornpoint = estimation.getBallBornPoint();
        if (releasePoint.y - 0.1f >= ballbornpoint.position.y && releasePoint.y<= Twall.transform.position.y)
        {
            //エピタフ更新
            estimation.SetPoint(releasePoint);
            estimation.Visualaization();
        }
        else
        {
            //点を不可視化
            estimation.Misunderstanding();
        }
    }
}
