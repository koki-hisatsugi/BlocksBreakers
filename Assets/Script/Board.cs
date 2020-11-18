﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using KanKikuchi.AudioManager;

public class Board : MonoBehaviour
{
    // jsonのステージデータ
    [System.Serializable]
    private struct PositionData
    {
        public Vector3 position;
        public StageClass savestage;
        public int[] intlist;
        public string[] strlist;
    }
    //シーン遷移のフェード格納
    [SerializeField]
    GameObject FadeCanvas;
    Fade _fade;

    // ファイルパス
    private string _dataPath;

    public GameObject[] Block;
    private BlocksPos[,] blocksPos;
    private int[,] BlockFlag;

    public GameObject denText;
    public GameObject GOPanel;
    public GameObject ClearPanel;

    public string stageLoad;

    public GameObject inputController;
    //ステージの点数を計算用
    public float MathPoint;
    public float MaxPoint;

    private void Awake()
    {
        // ファイルのパスを計算
        _dataPath = Path.Combine(Application.persistentDataPath, "Stage.json");
    }
    // Start is called before the first frame update
    void Start()
    {
        //フェードの格納
        FadeCanvas = GameObject.Find("FadeCanvas(Clone)");
        _fade = FadeCanvas.GetComponent<Fade>();

        GManager.instance.trunCount = 0;
        denText.SetActive(false);
        GOPanel.SetActive(false);
        ClearPanel.SetActive(false);
        inputController = GameObject.Find("inputController");
        //testSetBlockFlag2();
        if (GManager.instance.stageNum > 0)
        {
            OnLoad(GManager.instance.stageNum);
        }
        else
        {
            OnLoad(1);
        }
        
        testSetBlockFlagJson(stageLoad);
        //testSetBlockFlag();
        blocksPos = new BlocksPos[12,11];
        for(int i=0; i<12; i++)
        {
            for(int j=0; j<11; j++)
            {
                float x = -2.5f + (0.5f * j);
                float y = 2.5f + (-0.5f * i);
                blocksPos[i, j] = new BlocksPos(x, y);
                blocksPos[i, j].showPos();
            }
        }

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if(BlockFlag[i, j] > 0)
                {
                    blocksPos[i, j].myBlock = Instantiate(Block[(BlockFlag[i, j] - 1)], new Vector3(blocksPos[i, j].blockXpos, blocksPos[i, j].blockYpos), Quaternion.identity);
                    MathPoint++;
                }
            }
        }

        MathMaxPoint();
    }

    public void MathMaxPoint()
    {
        GManager.instance.stageScoreMax = 0;
        GManager.instance.stageScore = 0;
        GManager.instance.ChainScore = 0;
        if (MathPoint > 30)
        {
            MaxPoint = 15000;
        }
        else if (MathPoint > 25)
        {
            MaxPoint = 8000;
        }
        else if (MathPoint > 20)
        {
            MaxPoint = 6000;
        }else if(MathPoint > 15)
        {
            MaxPoint = 5000;
        }
        else if (MathPoint > 10)
        {
            MaxPoint = 4000;
        }
        else if (MathPoint > 5)
        {
            MaxPoint = 3000;
        }
        else
        {
            MaxPoint = 1500;
        }
        GManager.instance.stageScoreMax = MaxPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            downBlocks();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            testDownBlocks();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Pauser.Pause();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Pauser.Resume();
        }
    }

    void downBlocks()
    {
        for (int i = 11; i >= 0; i--)
        {
            for (int j = 0; j < 11; j++)
            {
                if (i > 0)
                {
                    if(blocksPos[i - 1, j].myBlock == null)
                    {
                        BlockFlag[i, j] = 0;
                    }
                    else
                    {
                        BlockFlag[i, j] = 1;
                    }

                    //BlockFlag[i, j] = BlockFlag[i - 1, j];
                }
                else
                {
                    BlockFlag[i, j] = 0;
                }
                
            }
        }

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (BlockFlag[i, j] == 1)
                {
                    if(blocksPos[i, j].myBlock == null)
                    {
                        blocksPos[i, j].myBlock = Instantiate(Block[0], new Vector3(blocksPos[i, j].blockXpos, blocksPos[i, j].blockYpos), Quaternion.identity);
                    }
                }
                else
                {
                    Destroy(blocksPos[i, j].myBlock);

                }
            }
        }
    }

    public void testDownBlocks()
    {
        for (int i = 11; i > 0; i--)
        {
            for (int j = 0; j < 11; j++)
            {
                if (blocksPos[i-1, j].myBlock == null)
                {
                    blocksPos[i, j].myBlock = null;
                }
                else if(blocksPos[i - 1, j].myBlock != null)
                {
                    blocksPos[i, j].myBlock = blocksPos[i - 1, j].myBlock;
                    blocksPos[i, j].setBlockPos();
                    blocksPos[i - 1, j].myBlock = null;
                }

                else
                {
                    Destroy(blocksPos[i, j].myBlock);

                }
            }
            GManager.instance.trunCount++;
            GManager.instance.ChainScore = 0;
        }
    }

    public void blockDestroyCheck()
    {
        StartCoroutine("destroyCheck");
    }
    //クリアーチェックのコルーチン
    IEnumerator destroyCheck()
    {
        yield return new WaitForSeconds(0.1f);
        bool clear = false;//クリアのbool定義
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (blocksPos[i, j].myBlock != null)
                    {
                        yield break;
                    }
                    clear = true;
                }
            }
        if (clear)
        {
            inputController.GetComponent<BallManager>().clearPosSuspention();
            StartCoroutine("ClearActive");
        }
    }


    public void dengerCheck()
    {
        bool denger = false;//注意喚起用のbool定義
        bool gameover = false;//ゲームオーバーのbool定義
        bool clear = false;//クリアのbool定義
        Debug.Log("デンジャーチェック");
        for (int i = 0; i < 11; i++)
        {
            if (blocksPos[11, i].myBlock != null)
            {
                gameover = true;
                break;
            }
        }
        if (!gameover)
        {
            for (int i = 0; i < 11; i++)
            {
                if (blocksPos[10, i].myBlock != null)
                {
                    denger = true;
                    GManager.instance.setState("BlocksTurn");
                    break;
                }
            }
        }
        if (!gameover && !denger)
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (blocksPos[i, j].myBlock != null)
                    {
                        return;
                    }
                    clear = true;
                }
            }
        }
        if (denger)
        {
            denText.SetActive(true);
            StartCoroutine("delDenger");
        }else if (gameover)
        {
            StartCoroutine("GameOverActive");
        }else if (clear)
        {
            Debug.Log("クリアーフラグ");
            inputController.GetComponent<BallManager>().clearPosSuspention();
            StartCoroutine("ClearActive");
        }
    }

    //デンジャーを消すコルーチン
    IEnumerator delDenger()
    {
        yield return new WaitForSeconds(1.0f);
        denText.SetActive(false);
        GManager.instance.setState("PlayerTurn");
        //SEManager.Instance.Stop(SEPath.ALERTSOUNDS5);
    }

    //ゲームオーバーコルーチン
    IEnumerator GameOverActive()
    {
        yield return new WaitForSeconds(0.2f);
        GOPanel.SetActive(true);
        SEManager.Instance.Play(SEPath.LOSESOUND7);
        Time.timeScale = 0;
    }

    //クリアーコルーチン
    IEnumerator ClearActive()
    {
        yield return new WaitForSeconds(0.2f);
        ClearPanel.SetActive(true);
        SEManager.Instance.Play(SEPath.WINSOUND24);
        Time.timeScale = 0;
    }

    public void SceneReload()
    {
        SEManager.Instance.Play(SEPath.CLICKSOUNDS10);
        _fade.FadeIn(1.0f, (() =>
        {
            //処理
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }));
        Time.timeScale = 1;

    }

    public void NextScene()
    {
        Time.timeScale = 1;
        SEManager.Instance.Play(SEPath.CLICKSOUNDS10);
        GManager.instance.stageNum++;
        _fade.FadeIn(1.0f, (() =>
        {
            //処理
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }));
    }

    public void ReturnSelectScene()
    {
        Time.timeScale = 1;
        SEManager.Instance.Play(SEPath.CLICKSOUNDS10);
        _fade.FadeIn(1.0f, (() =>
        {
            //処理
            SceneManager.LoadScene("StageSelect");
        }));
        
    }

    void testSetBlockFlag()
    {
        BlockFlag = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,1,1,2,0,2,1,0,2,0,1},
            {0,0,1,2,0,2,0,0,0,1,2},
            {1,0,2,2,0,2,2,1,1,0,2},
            {1,1,1,2,2,0,1,0,1,0,0},
            {2,1,1,2,0,0,2,2,1,1,2},
            {2,1,2,2,2,2,2,1,2,1,2},
            {2,2,2,2,0,1,1,1,1,2,2},
            {1,1,1,2,1,2,0,1,1,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
    }

    void testSetBlockFlag2()
    {
        BlockFlag = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,0,1,1,1,0,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {1,1,1,0,1,0,1,0,1,1,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {2,0,0,0,0,0,0,0,0,0,2},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
    }

    void testSetBlockFlagJson(string s)
    {
        BlockFlag = new int[12, 11];
        int testNum = 0;
        for(int i=0; i < 12; i++)
        {
            for(int j=0; j<11; j++)
            {
                string temp = s.Substring(testNum, 1);
                switch (temp)
                {
                    case "a":
                        temp = "10";
                        break;
                    case "b":
                        temp = "11";
                        break;
                    case "c":
                        temp = "12";
                        break;
                    case "d":
                        temp = "13";
                        break;
                    case "e":
                        temp = "14";
                        break;
                    case "f":
                        temp = "15";
                        break;
                    default:
                        break;
                }
                BlockFlag[i, j] = int.Parse(temp);
                testNum++;
            }
        }
    }

    // JSON形式をロードしてデシリアライズ
    private void OnLoad(int stageNum)
    {
        // 念のためファイルの存在チェック
        //if (!File.Exists(_dataPath)) return;

        // JSONデータとしてデータを読み込む
        //var json = File.ReadAllText(_dataPath);
        var json = Resources.Load<TextAsset>("Stage").ToString();

        // JSON形式からオブジェクトにデシリアライズ
        var obj = JsonUtility.FromJson<PositionData>(json);

        // Transformにオブジェクトのデータをセット
        //transform.position = obj.position;

        //ステージの文字列を現在のステージにインポート
        stageLoad = obj.strlist[stageNum-1];

    }
}
