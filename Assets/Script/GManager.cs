﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //GameManagerのインスタンスをnullにする
    public static GManager instance = null;

    //ボールの初期位置
    public GameObject ballBornPoint;

    //ステージの番号記録変数
    public int stageNum;

    public enum GameState
    {
        PlayerTurn,
        BlocksTurn,
        GameOver,
        Pause,
    }
    [SerializeField] private GameState gameState;

    private void Awake()
    {
        gameState = GameState.PlayerTurn;
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
        gameState = GameState.PlayerTurn;
        //respornPoint = GameObject.Find("RespornPoint");
        Debug.Log(Screen.width);
        //Init();
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

    public void setState(string setKey)
    {
        switch (setKey)
        {
            case "PlayerTurn":
                gameState = GameState.PlayerTurn;
                break;
            case "BlocksTurn":
                gameState = GameState.BlocksTurn;
                break;
            case "Pause":
                gameState = GameState.Pause;
                break;
            case "GameOver":
                gameState = GameState.GameOver;
                break;
        }
    }

    public GameState getState()
    {
        return gameState;
    }
}