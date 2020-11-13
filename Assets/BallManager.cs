using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    //Ballプレハブ
    GameObject ball;
    public GameObject ballPre;
    public Transform ballBornPoint;
    public float speed = 1f;
    //ボールの初期位置
    private Vector3 origin;
    //最大ボールの量
    [SerializeField]
    int MaxBall;
    //現在のボールの量
    private List<GameObject> balls = new List<GameObject>();
    //[System.NonSerialized]
    //撃ってる最中か
    public bool isShooting;

    //戻ってきたボールの数
    int returnBall;

    public float waitSec=0.1f;

    public bool aggregation;

    GameObject Board;

    void Start()
    {
        isShooting = false;
        BallBorn();
        aggregation = false;
        Board = GameObject.Find("Board");
    }

    //足りない分リストに追加
    void BallBorn()
    {
        while (MaxBall > balls.Count)
        {
            var ob = Instantiate(ballPre, ballBornPoint.position, Quaternion.identity) as GameObject;
            balls.Add(ob);
        }
    }

    //発射 InputControllerから呼ばれる
    public void Shooting(Vector3 vec)
    {
        isShooting = true;
        returnBall = 0;
        Vector3 shotForward = Vector3.Scale((vec - ballBornPoint.position), new Vector3(1, 1, 0)).normalized;
        //Vector3 pos = vec - ballBornPoint.position;
        //ベクトルの大きさを1にする
        //pos.Normalize();
        //GManager.instance.force = pos;
        //Vector3 normalPos= pos.normalized;
        StartCoroutine("shoot", shotForward);
    }
    IEnumerator shoot(Vector3 vec)
    {
        foreach (GameObject obj in balls)
        {
            //Rigidbody2D rig = obj.GetComponent<Rigidbody2D>();
            //rig.velocity = vec * speed;
            if (aggregation)
            {
                yield break;
            }
            obj.GetComponent<Ball>().setForce(vec);
            yield return new WaitForSeconds(waitSec);
        }

    }

    public void BottomTouch(GameObject ball)
    {
        //ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        ball.GetComponent<Ball>().forceZero();
        //最初に帰ってきたボールなら
        if (returnBall == 0)
        {
            ballBornPoint.position = ball.transform.position;
        }
        //それ以外は移動
        else
        {
            //StartCoroutine("setPos", ball);
            ball.GetComponent<Ball>().setReturn(ballBornPoint.position);
        }
        returnBall += 1;
        if (returnBall == MaxBall)
        {
            isShooting = false;
            StartCoroutine("downBlocks");
            //Board.GetComponent<Board>().testDownBlocks();
        }
    }

    //集合コルーチン
    IEnumerator setPos(GameObject ball)
    {
        //集合ポイントより離れていれば
        while (Mathf.Abs(ball.transform.position.x - ballBornPoint.position.x) > 1)
        {
            //右か左か
            int dir = ball.transform.position.x < ballBornPoint.position.x ? 1 : -1;
            ball.transform.position += new Vector3(dir, 0, 0);
            yield return new WaitForSeconds(waitSec);
        }
        ball.transform.position = ballBornPoint.position;
    }

    public void setPosSuspention()
    {
        for(int i=0; i<balls.Count; i++)
        {
            //balls[i].GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //StartCoroutine("setPos", balls[i]);
            balls[i].GetComponent<Ball>().setReturn(ballBornPoint.position);
        }
        returnBall = MaxBall;
        isShooting = false;
        aggregation = true;
        StopCoroutine("shoot");
        StartCoroutine("downBlocks");
        //Board.GetComponent<Board>().testDownBlocks();
    }

    //ブロック下げるコルーチン
    IEnumerator downBlocks()
    {
        yield return new WaitForSeconds(1.0f);
        Board.GetComponent<Board>().testDownBlocks();
        yield return new WaitForSeconds(0.5f);
        Board.GetComponent<Board>().dengerCheck();
    }


    public void tst()
    {
        Vector3 pos = new Vector3(3, 4, 5);
        Vector3 nlz = pos.normalized;
        Debug.Log(nlz);
    }

    public bool aggregationCheck()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            if (!(balls[i].transform.position== ballBornPoint.position))
            {
                return false;
            }
        }

        return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            setPosSuspention();
        }

        if (aggregation)
        {
            aggregation = aggregationCheck();
        }
    }
}
