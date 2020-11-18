using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectMG : MonoBehaviour
{
    [SerializeField]
    GameObject FadeCanvas;
    Fade _fade;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
