using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Create : MonoBehaviour
{
    public RectTransform contentRectTransform;
    public Button button;
    // ファイルパス
    private string _dataPath;

    // jsonのステージデータ
    [System.Serializable]
    private struct PositionData
    {
        public Vector3 position;
        public StageClass savestage;
        public int[] intlist;
        public string[] strlist;
    }

    public string stageLoad;
    public int btnQuantity;

    private void Awake()
    {
        // ファイルのパスを計算
        _dataPath = Path.Combine(Application.persistentDataPath, "Stage.json");
    }

    private void Start()
    {
        OnLoad();
        Debug.Log(btnQuantity);
        for (int i = 1; i <= btnQuantity; i++)
        {
            var obj = Instantiate(button, contentRectTransform);
            obj.GetComponentInChildren<Text>().text = i.ToString();
        }
    }

    // JSON形式をロードしてデシリアライズ
    private void OnLoad()
    {
        // 念のためファイルの存在チェック
        //if (!File.Exists(_dataPath)) return;

        // JSONデータとしてデータを読み込む
        //var json = File.ReadAllText(_dataPath);
        var json = Resources.Load<TextAsset>("Stage").ToString();

        // JSON形式からオブジェクトにデシリアライズ
        var obj = JsonUtility.FromJson<PositionData>(json);

        //
        btnQuantity = obj.strlist.Length;

    }
}
