using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //GameManagerのインスタンスをnullにする
    public static GManager instance = null;
    //ボールの生成判定
    public bool createBall_bool = false;

    //ボールの初期位置
    public GameObject ballBornPoint;

    //クリックした位置の正面
    public float forward;
    public Vector3 force;

    //
    public Transform RespornPosition = null;
    public Vector2 Rpos;
    public GameObject respornPoint;
    public bool respornBool;

    private enum GameState
    {
        Idle,
        PieceMove,
        MatchCheck,
        DeletePiece,
        FillPiece,
    }
    [SerializeField] private GameState gameState;

    private void Awake()
    {
        gameState = GameState.Idle;
        //GameManagerを一つのみ存在するようにする
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //respornPoint = GameObject.Find("RespornPoint");
    }
    // Start is called before the first frame update
    void Start()
    {
        respornPoint = GameObject.Find("RespornPoint");
        Debug.Log(Screen.width);
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {
        GameObject Bwall = GameObject.Find("Bwall");
        //下の壁に当たる位置 + ボールの半径分だけ初期位置を上に設定
        float _z = Bwall.transform.position.z + Bwall.transform.lossyScale.z / 2 + 0.4f;
        ballBornPoint.transform.position = transform.position = new Vector3(0, 0, _z);
    }
}
