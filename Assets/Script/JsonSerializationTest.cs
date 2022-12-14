using System.IO;
using UnityEngine;
using WBmap;

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
        //_dataPath = Path.Combine(Application.persistentDataPath, "Stage.json");
        _dataPath = Application.dataPath + "/Resources/Stage.json";
    }

    public StageClass teststage;

    private void Start()
    {
        Debug.Log(_dataPath);
        Debug.Log(Resources.Load("Stage.json"));
        Debug.Log(Application.dataPath+"/Resources");
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

        //3キー押下でsaveSystemを実行
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SaveSystem.Instance.StarData.stageSterQuantity.Add(3);
            Debug.Log(SaveSystem.Instance.StarData.stageSterQuantity);
            Debug.Log(SaveSystem.Instance.StarData.stageSterQuantity[0]);

            SaveSystem.Instance.Save();
        }

        //4キー押下でsaveSystemを実行
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SaveSystem.Instance.Load();
            Debug.Log(SaveSystem.Instance.StarData.stageSterQuantity);
            Debug.Log(SaveSystem.Instance.StarData.stageSterQuantity.Count);
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
            strlist = createStagesManual()

        };

        // JSON形式にシリアライズ
        var json = JsonUtility.ToJson(obj, false);

        // JSONデータをファイルに保存
        File.WriteAllText(_dataPath, json);

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

    //手作業でステージを作成する
    public string[] createStagesManual()
    {
        string[] outStr = new string[50];

        int[,] stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,1,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,1,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {1,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        string temp = null;
        for(int i = 0; i < 12; i++)
        {
            for(int j = 0; j < 11; j++)
            {
                temp += stage1[i, j];
            }
        }
        outStr[0] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,1,0,0,0,2,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,2,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,2,0,0,0,0},
            {0,0,0,0,0,0,0,0,1,0,0},
            {0,0,2,0,0,0,0,0,0,0,0},
            {1,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                temp += stage1[i, j];
            }
        }
        outStr[1] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {2,0,0,0,0,2,0,0,0,0,2},
            {1,1,0,0,0,0,0,0,0,1,1},
            {1,1,1,0,0,0,0,0,1,1,1},
            {1,1,1,0,0,0,0,0,1,1,1},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                temp += stage1[i, j];
            }
        }
        outStr[2] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,1,0,2,0,0,0,0},
            {0,0,0,0,1,0,2,0,0,0,0},
            {0,0,0,0,1,0,2,0,0,0,0},
            {0,0,0,0,1,0,2,0,0,0,0},
            {0,0,0,0,1,0,2,0,0,0,0},
            {0,0,0,0,1,0,2,0,0,0,0},
            {0,0,0,0,1,0,2,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                temp += stage1[i, j];
            }
        }
        outStr[3] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,3,2,1,1,1,1,1,2,3,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,1,1,2,1,1,0,0,0},
            {0,0,0,0,0,2,0,0,0,0,0},
            {0,0,0,0,0,2,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                temp += stage1[i, j];
            }
        }
        outStr[4] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,1,1,0,0,0,0,0,1,1,0},
            {0,1,0,1,0,0,0,1,0,1,0},
            {0,1,0,0,2,2,2,0,0,1,0},
            {0,0,1,0,0,4,0,0,1,0,0},
            {0,0,0,1,0,0,0,1,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                temp += stage1[i, j];
            }
        }
        outStr[5] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,3,0,0,0,0,0},
            {0,0,0,0,4,0,8,0,0,0,0},
            {0,0,0,0,0,5,0,8,0,0,0},
            {0,0,0,0,0,0,5,0,8,0,0},
            {0,0,0,0,0,0,0,5,0,8,0},
            {0,0,0,0,0,0,0,0,5,0,1},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                temp += stage1[i, j];
            }
        }
        outStr[6] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,1,1,1,1,1,1,1,0,0},
            {0,7,0,0,0,0,0,0,0,3,0},
            {2,0,2,2,2,2,2,2,2,0,0},
            {0,5,0,0,0,8,0,0,0,0,0},
            {0,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                temp += stage1[i, j];
            }
        }
        outStr[7] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,4,4,4,4,4,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,3,3,3,3,3,3,3,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,1,1,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                temp += stage1[i, j];
            }
        }
        outStr[8] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,3,3,0,0,0,4,4,0,0},
            {0,2,0,0,3,0,4,0,0,2,0},
            {0,0,1,0,0,0,0,0,1,0,0},
            {0,0,1,2,0,9,0,2,1,0,0},
            {0,0,1,0,2,0,2,0,1,0,0},
            {0,0,1,0,0,0,0,0,1,0,0},
            {0,0,1,0,0,0,0,0,1,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                temp += stage1[i, j];
            }
        }
        outStr[9] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,3,3,0,0,0,4,4,0,0},
            {0,2,0,0,3,0,4,0,0,2,0},
            {0,0,1,0,0,0,0,0,1,0,0},
            {0,0,1,2,0,9,0,2,1,0,0},
            {10,0,4,0,2,0,2,0,4,0,10},
            {10,0,4,4,4,0,4,4,4,0,10},
            {10,0,4,4,4,0,4,4,4,0,10},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if(stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }
                    

                }
            }
        }
        outStr[10] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,2,2,2,2,2,2,2,0,0},
            {0,0,2,2,2,2,2,2,2,0,0},
            {0,0,11,11,11,11,11,11,11,0,0},
            {0,0,2,2,2,2,2,2,2,0,0},
            {0,0,2,2,2,2,2,2,2,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[11] = temp;


        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,3,3,3,3,3,0,10,0,0},
            {0,0,3,3,3,3,3,0,10,0,0},
            {0,0,3,3,3,3,3,0,10,0,0},
            {0,0,4,3,3,3,3,0,0,0,0},
            {0,7,0,0,0,0,0,0,6,0,0},
            {4,0,4,4,4,0,3,3,0,0,0},
            {0,5,0,0,0,8,0,0,0,0,0},
            {0,0,4,4,4,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[12] = temp;
        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,3,3,3,0,4,4,4,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,1,1,1,9,2,2,2,0,0},
            {0,0,1,0,1,0,2,0,2,0,0},
            {0,0,1,1,1,0,2,2,2,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[13] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {3,3,3,3,3,10,4,4,4,4,4},
            {3,3,3,3,3,10,4,4,4,4,4},
            {3,3,3,3,3,10,4,4,4,4,4},
            {3,3,3,3,3,10,4,4,4,4,4},
            {3,3,3,3,3,10,4,4,4,4,4},
            {3,3,3,3,3,10,4,4,4,4,4},
            {3,3,3,3,3,10,4,4,4,4,4},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[14] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,4,0,0,0,0,0},
            {0,0,0,0,10,0,10,0,0,0,0},
            {0,0,0,10,0,1,0,10,0,0,0},
            {0,0,4,0,0,1,0,0,4,0,0},
            {0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0},
            {0,0,5,0,0,0,0,0,0,4,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[15] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,4,4,4,5,0,0,0},
            {5,0,0,6,0,0,0,0,5,0,0},
            {4,5,6,0,2,0,0,2,0,5,0},
            {3,7,8,0,0,0,0,0,0,7,0},
            {7,0,0,8,0,0,0,0,7,0,0},
            {0,0,0,0,3,3,3,7,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[16] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,7,8,0,0,0,7,8,0,0},
            {0,4,0,0,4,4,4,0,0,4,0},
            {0,8,0,0,0,0,0,0,0,7,0},
            {0,0,8,0,0,0,0,0,7,0,0},
            {0,0,0,8,0,9,0,7,0,0,0},
            {0,0,0,0,8,0,7,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[17] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,1,0,0,0,0,0},
            {0,7,0,0,0,0,0,4,0,8,0},
            {0,0,0,3,0,1,0,0,0,0,0},
            {0,0,0,3,0,0,0,4,0,0,0},
            {0,0,0,3,0,1,0,0,0,0,0},
            {0,0,0,3,0,0,0,4,0,0,0},
            {0,0,0,3,0,1,0,0,0,0,0},
            {0,0,0,3,0,0,0,4,0,0,0},
            {0,5,0,0,0,1,0,0,0,6,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[18] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,11,11,11,11,11,11,11,0,0},
            {0,0,4,4,4,4,4,4,4,0,0},
            {0,0,4,4,4,4,4,4,4,0,0},
            {0,0,4,4,4,4,4,4,4,0,0},
            {0,0,4,4,4,4,4,4,4,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[19] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,4,4,4,4,4,4,4,0,0},
            {0,4,11,11,11,11,11,11,0,4,0},
            {0,0,4,4,4,4,4,4,0,4,0},
            {0,4,0,0,0,0,0,0,0,4,0},
            {0,4,0,4,4,4,4,4,4,0,0},
            {0,4,0,0,0,0,0,0,0,4,0},
            {0,0,4,4,4,4,4,4,0,4,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[20] = temp;

        stage1 = new int[12, 11] {
            {0,3,3,3,3,3,3,3,3,0,0},
            {4,0,0,0,0,0,0,0,0,3,0},
            {0,4,4,4,4,4,4,9,4,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,7,0,0,0,0,0,6,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,5,0,0,0,8,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[21] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,5,0,4,4,4,0,7,0,0},
            {0,6,0,5,0,0,0,7,0,8,0},
            {0,0,6,0,5,0,7,0,8,0,0},
            {0,0,0,6,0,0,0,8,0,0,0},
            {0,0,0,0,6,9,8,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,4,4,0,0,10,0,0,4,4,0},
            {0,4,4,0,0,10,0,0,4,4,0},
            {0,4,4,0,0,10,0,0,4,4,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[22] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,2,2,2,0,0,0},
            {0,0,0,3,0,0,0,0,1,0,0},
            {0,0,0,3,3,3,0,1,0,0,0},
            {0,0,0,0,0,0,1,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,1,0,0,0,0,0,0},
            {0,0,0,1,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[23] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,1,0,1,0,0,0,0},
            {0,7,0,0,0,0,0,0,0,6,0},
            {0,0,0,1,0,0,0,1,0,0,0},
            {0,0,0,1,0,0,0,1,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,1,0,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[24] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,8,0,0},
            {0,0,0,0,0,0,0,0,8,0,0},
            {0,0,0,0,0,0,0,0,8,0,0},
            {0,7,0,1,0,2,0,3,0,4,0},
            {0,7,0,0,0,0,0,0,0,0,0},
            {0,7,0,0,0,0,0,0,0,0,0},
            {0,7,0,0,0,0,0,0,0,0,0},
            {0,7,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[25] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,6,2,2,2,2,2,2,5,0,0},
            {0,4,7,0,0,0,0,8,4,0,2},
            {0,4,0,3,3,3,0,0,4,0,2},
            {0,4,0,3,0,0,0,0,4,0,2},
            {0,4,0,3,0,0,0,6,4,0,2},
            {0,4,0,3,3,3,3,3,7,0,2},
            {0,4,5,0,0,0,0,0,0,6,2},
            {0,8,2,2,2,2,2,2,2,2,7},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[26] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,11,0,11,0,0,0,1,0,4,0},
            {1,1,1,1,0,0,0,1,0,4,0},
            {1,1,1,1,0,0,0,1,0,4,0},
            {11,0,11,0,0,0,0,1,0,4,0},
            {0,0,0,0,0,0,0,1,0,4,0},
            {0,0,0,0,0,0,0,1,0,4,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[27] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,4,4,4},
            {0,0,0,0,0,0,0,0,4,0,4},
            {0,0,0,0,0,0,0,7,0,4,4},
            {0,0,0,0,0,0,0,0,6,0,0},
            {0,0,0,4,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,4},
            {0,0,0,4,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,4},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[28] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {4,4,0,0,4,4,4,0,0,4,4},
            {0,0,0,9,0,0,0,9,0,0,0},
            {11,11,11,11,11,9,11,11,11,11,11},
            {1,1,1,1,1,0,1,1,1,1,1},
            {2,2,2,2,2,0,2,2,2,2,2},
            {0,0,0,0,0,0,0,0,0,0,0},
            {4,4,4,4,4,0,4,4,4,4,4},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[29] = temp;

        stage1 = new int[12, 11] {
            {4,4,0,0,4,4,4,0,0,4,4},
            {4,4,0,0,4,4,4,0,0,4,4},
            {0,0,0,9,0,0,0,9,0,0,0},
            {0,11,11,11,1,9,1,11,11,11,0},
            {1,1,1,1,1,0,1,1,1,1,1},
            {2,2,2,2,2,0,2,2,2,2,2},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[30] = temp;

        stage1 = new int[12, 11] {
            {0,0,4,4,4,4,4,4,0,0,0},
            {0,0,4,4,4,4,4,4,0,0,0},
            {12,12,12,0,0,4,4,0,12,0,0},
            {0,0,0,0,2,0,0,0,0,0,0},
            {0,12,0,2,0,12,0,4,0,0,0},
            {0,0,2,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,2,0,0,12,0,0},
            {0,0,12,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,2,2,2,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[31] = temp;

        stage1 = new int[12, 11] {
            {4,4,4,4,4,4,0,0,0,0,0},
            {3,3,3,3,3,3,0,0,7,12,12},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,7,12,0,12,0,12,6,0,0},
            {0,0,12,0,0,0,0,0,0,0,0},
            {0,0,5,12,0,8,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[32] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,0,4,0,0,0,0,0},
            {0,0,0,0,0,4,0,0,0,0,0},
            {0,0,0,5,0,0,0,0,0,0,0},
            {0,0,5,0,0,0,0,0,0,12,0},
            {0,5,0,0,0,0,0,0,0,0,3},
            {0,0,0,0,0,0,0,12,0,3,0},
            {0,0,0,0,12,0,12,0,3,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,4,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[33] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,9,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,12,12,12,12,0,0},
            {0,1,0,9,0,2,2,2,2,0,0},
            {1,1,1,0,0,3,3,3,3,0,0},
            {0,1,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,4,4,4,4,0,0},
            {0,0,1,0,0,0,0,0,0,0,0},
            {0,1,0,1,0,12,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[34] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,2,2,2,2,2,0,0,0},
            {0,0,0,1,1,1,1,1,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,7,8,0,0,0,0,0,7,8,0},
            {0,5,6,0,0,4,0,0,5,6,0},
            {0,0,0,0,0,4,0,0,0,0,0},
            {0,0,0,1,1,4,1,1,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[35] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,3,3,3,3,3,3,3,0,0},
            {0,4,4,4,4,4,4,4,4,4,0},
            {0,0,5,0,0,9,0,0,6,0,0},
            {0,0,0,5,0,12,0,6,0,0,0},
            {0,0,0,7,0,12,0,8,0,0,0},
            {0,0,7,0,0,12,0,0,8,0,0},
            {0,0,0,0,0,12,0,0,0,0,0},
            {0,0,0,0,0,12,0,0,0,0,0},
            {0,0,0,0,0,12,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[36] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,0,2,0,0,0},
            {0,0,0,0,0,1,0,2,0,0,0},
            {0,0,0,0,0,1,0,2,0,0,0},
            {0,0,0,0,0,1,0,2,0,0,0},
            {0,0,0,0,0,1,0,2,0,0,0},
            {0,0,0,0,0,1,0,0,2,0,0},
            {0,0,1,1,1,1,0,0,0,2,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[37] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,1,1,1,0,4,0,1,1,1,0},
            {0,0,0,0,6,0,5,0,0,0,0},
            {0,0,0,6,9,0,9,5,0,0,0},
            {0,0,6,0,0,9,0,0,5,0,0},
            {0,6,3,3,3,0,3,3,3,5,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[38] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0},
            {0,0,12,12,0,1,0,0,5,0,0},
            {0,0,12,12,0,0,0,0,0,0,0},
            {0,0,12,12,0,0,0,0,0,0,0},
            {0,0,1,1,1,0,0,0,6,0,0},
            {0,0,1,0,1,0,3,0,0,0,0},
            {0,0,1,0,1,0,0,0,4,0,0},
            {0,0,0,0,0,0,3,0,0,0,0},
            {0,0,0,0,0,0,0,0,4,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[39] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,3,3,7,2,0,0,0},
            {0,0,0,7,0,0,6,0,0,0,0},
            {0,0,0,0,4,4,0,0,0,0,0},
            {0,0,0,1,0,0,0,0,0,0,0},
            {0,0,1,0,8,0,0,0,0,0,0},
            {0,0,0,5,0,1,0,0,0,0,0},
            {0,0,0,1,0,1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[40] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,1,8,0,0,1,8,0,0},
            {0,0,7,12,12,8,7,12,12,8,0},
            {0,0,5,12,12,6,5,12,12,6,0},
            {0,0,0,5,6,0,0,5,6,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,4,0},
            {0,0,0,0,0,0,0,0,0,4,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[41] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {7,0,0,0,3,3,3,3,0,0,0},
            {5,0,0,0,3,3,3,3,0,0,0},
            {0,0,0,0,11,11,11,11,0,0,0},
            {0,0,0,0,12,12,12,0,0,0,0},
            {0,0,0,0,4,4,4,4,0,0,0},
            {0,0,0,0,4,4,4,4,10,4,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[42] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,3,0,11,11,11,0,3,0,0},
            {0,0,8,4,4,4,4,4,6,0,0},
            {0,0,0,8,0,0,0,6,0,0,0},
            {0,0,0,0,3,3,3,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,12,12,12,12,0,0,0,0},
            {0,0,0,12,12,12,12,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[43] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,2,2,2,2,0,0,0,0,0},
            {0,1,0,0,0,0,1,0,0,0,0},
            {0,1,5,9,9,6,1,0,0,0,0},
            {0,4,1,0,0,1,1,0,0,0,0},
            {0,4,4,0,0,4,4,0,0,0,0},
            {0,3,5,0,0,6,3,0,0,0,0},
            {0,8,3,0,0,3,7,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[44] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,2,0,0},
            {0,0,0,0,0,0,0,2,0,0,0},
            {0,0,0,0,0,0,2,0,0,0,0},
            {0,0,0,0,1,2,0,0,0,0,0},
            {0,0,0,1,2,0,4,0,0,0,3},
            {0,0,1,0,0,0,0,4,0,3,0},
            {0,1,0,0,0,0,0,0,4,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[45] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,1,1,0,0,0,0,1,1,0},
            {0,0,1,1,1,0,0,1,1,1,0},
            {0,0,1,1,1,12,12,1,1,1,0},
            {0,0,1,1,1,12,12,1,1,1,0},
            {0,0,1,1,1,0,0,1,1,1,0},
            {0,0,1,1,1,0,0,1,1,1,0},
            {0,0,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[46] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,2,0,0},
            {0,0,1,0,0,0,0,2,2,2,0},
            {0,1,1,1,0,0,0,0,2,0,0},
            {0,0,1,0,0,1,0,0,0,0,0},
            {0,0,0,0,1,1,1,0,0,0,0},
            {0,0,2,0,0,1,0,0,0,0,0},
            {0,2,2,2,0,0,0,0,0,12,0},
            {0,0,2,0,0,0,12,12,12,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[47] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,2,0,0,0,0,1,0,0},
            {0,0,0,2,0,0,0,0,1,0,0},
            {0,0,0,2,0,0,0,0,1,0,0},
            {0,0,0,2,0,0,0,0,1,0,0},
            {4,4,4,13,0,0,0,0,13,4,4},
            {0,0,0,3,0,0,0,0,0,0,0},
            {0,0,0,3,0,0,0,0,0,0,0},
            {0,0,0,3,0,0,0,0,0,0,0},
            {0,0,0,3,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[48] = temp;

        stage1 = new int[12, 11] {
            {0,0,0,4,0,0,4,0,0,0,0},
            {0,0,0,4,3,3,13,3,3,3,0},
            {0,0,0,4,0,0,0,0,0,0,0},
            {0,0,0,13,4,4,4,4,0,0,0},
            {0,0,0,12,0,0,0,0,0,0,0},
            {0,0,0,12,0,0,0,0,0,0,0},
            {0,0,0,12,0,0,0,0,0,0,0},
            {0,0,0,5,12,8,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
        temp = null;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (stage1[i, j] < 10)
                {
                    temp += stage1[i, j];
                }
                else
                {
                    string alpha;
                    switch (stage1[i, j])
                    {
                        case 10:
                            alpha = "a";
                            temp += alpha;
                            break;
                        case 11:
                            alpha = "b";
                            temp += alpha;
                            break;
                        case 12:
                            alpha = "c";
                            temp += alpha;
                            break;
                        case 13:
                            alpha = "d";
                            temp += alpha;
                            break;
                        case 14:
                            alpha = "e";
                            temp += alpha;
                            break;
                        case 15:
                            alpha = "f";
                            temp += alpha;
                            break;
                    }


                }
            }
        }
        outStr[49] = temp;

        return outStr;
    }
}