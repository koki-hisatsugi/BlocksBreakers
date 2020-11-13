using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bwall : MonoBehaviour
{
    BallManager ballManager;

    void Start()
    {
        ballManager = GameObject.Find("inputController").GetComponent<BallManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突判定 ボールが戻ってきたことを伝える
        if (collision.gameObject.tag == "ball")
        {
            var ball = collision.gameObject;
            ballManager.BottomTouch(ball);
        }
    }
}
