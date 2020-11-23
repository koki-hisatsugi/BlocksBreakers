using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using KanKikuchi.AudioManager;
using WBmap;

public class NewBoard : MonoBehaviour
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

    public string stageLoad;

    public GameObject inputController;
    //ステージの点数を計算用
    public float MathPoint;
    public float MaxPoint;

    //public string path => Application.dataPath + "/Resources/StageStar.json";
    public string path => Path.Combine(Application.dataPath, "StageStar.json");

    private void Awake()
    {
        //SaveSystemを使用してスコアのセーブをするときに使う　WEBGLではうまく動かないのでunityroom投稿では使用しない
        /*if (!File.Exists(path))
        {
            SaveSystem.Instance.StarData.stageSterQuantity.Add(0);
            SaveSystem.Instance.Save();
            Debug.Log("ファイルを初期値でセーブしました。");
        }
        SaveSystem.Instance.Load();*/

        // ファイルのパスを計算
        _dataPath = Path.Combine(Application.persistentDataPath, "Stage.json");
    }
    // Start is called before the first frame update
    void Start()
    {
        //フェードの格納
        FadeCanvas = GameObject.Find("FadeCanvas(Clone)");
        _fade = FadeCanvas.GetComponent<Fade>();

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
                blocksPos[i, j].myBlock = Instantiate(Block[0], new Vector3(blocksPos[i, j].blockXpos, blocksPos[i, j].blockYpos), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update(){ }



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
        StopAllCoroutines();
        SEManager.Instance.Play(SEPath.CLICKSOUNDS10);
        _fade.FadeIn(1.0f, (() =>
        {
            //処理
            SceneManager.LoadScene("StageSelect");
        }));
        
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
        if (stageNum <= obj.strlist.Length)
        {
            stageLoad = obj.strlist[stageNum - 1];
        }
        else
        {
            stageLoad = obj.strlist[obj.strlist.Length-1];
        }

    }
}
