using System.IO;
using UnityEngine;

// JSON形式のデータ読み書きテスト
public class JsonSerializationTest : MonoBehaviour
{
    // 位置データ
    [System.Serializable]
    private struct PositionData
    {
        //public Vector3 position;
        //public int[] intlist;
        public string[] strlist;
    }

    // ファイルパス
    private string _dataPath;

    private void Awake()
    {
        // ファイルのパスを計算
        //_dataPath = Path.Combine(Application.persistentDataPath, "position.json");
        _dataPath = Path.Combine(Application.persistentDataPath, "Stage.json");
    }

    public StageClass teststage;

    private void Start()
    {
        Debug.Log(_dataPath);
        int[,] stage=new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,0,1},
            {1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,0,1},
            {1,1,1,1,0,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,0,1},
            {1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,0,1},
            {1,1,1,1,1,1,1,1,1,1,1},
            {0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,1,1},
            {0,0,0,0,0,0,0,0,0,0,1}
        };
        
        teststage = new StageClass(stage);
    }
    private void Update()
    {
        // 1キー押下で現在位置をセーブする
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnSave();
        }

        // 2キー押下で現在位置をロードする
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnLoad();
        }

        // 方向キーで移動できるようにしておく
        transform.position = transform.position + new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")) * Time.deltaTime;
    }

    // JSON形式にシリアライズしてセーブ
    private void OnSave()
    {
        // シリアライズするオブジェクトを作成
        var obj = new PositionData
        {
            //position = transform.position,
            //intlist = new int[] { 1, 2, 3, 4, 5 },
            strlist = createStages(300)

        };

        // JSON形式にシリアライズ
        var json = JsonUtility.ToJson(obj, false);

        // JSONデータをファイルに保存
        File.WriteAllText(_dataPath, json);
    }

    // JSON形式をロードしてデシリアライズ
    private void OnLoad()
    {
        // 念のためファイルの存在チェック
        if (!File.Exists(_dataPath)) return;

        // JSONデータとしてデータを読み込む
        var json = File.ReadAllText(_dataPath);

        // JSON形式からオブジェクトにデシリアライズ
        var obj = JsonUtility.FromJson<PositionData>(json);

        // Transformにオブジェクトのデータをセット
        //transform.position = obj.position;

    }

    public string[] createStages(int num)
    {
        string[] outStr = new string[num];
        //Random randNum=new System.Random() ;
        for(int stages=0; stages < num; stages++)
        {
            string tempStr = null;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i < 9)
                    {
                        tempStr += Random.Range(0, 8);
                    }
                    else
                    {
                        tempStr += 0;
                    }
                }
            }
            outStr[stages] = tempStr;
        }

        return outStr;
    }
}