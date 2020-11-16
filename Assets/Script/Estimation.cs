using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estimation : MonoBehaviour
{

    [SerializeField]
    private GameObject dummyObjPref;

    [SerializeField]
    private Transform dummyObjParent;

    //玉が生み出される位置情報
    [SerializeField]
    private Transform ballBornPoint;

    [SerializeField]
    private int dummyCount;

    [SerializeField]
    private float secInterval;

    [SerializeField]
    private float offsetSpeed = 0.5f;

    //壁の位置情報
    float LOverLine, ROverLine;

    //タッチされているか
    private bool isTouch;

    //タッチされているスクリーン座標
    private Vector3 touchPos;
    private float offset;
    private List<GameObject> dummySphereList = new List<GameObject>();
    private Rigidbody rigid;

    void Start()
    {
        ballBornPoint = GameObject.Find("BallBornPoint").GetComponent<Transform>();
        dummyObjParent = GameObject.Find("BallBornPoint").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody>();
        if (!rigid)
            rigid = gameObject.AddComponent<Rigidbody>();
        rigid.isKinematic = true;
        for (int i = 0; i < dummyCount; i++)
        {
            var obj = (GameObject)Instantiate(dummyObjPref, dummyObjParent);
            dummySphereList.Add(obj);
        }
        //壁の位置を取得して反転座標を設定
        GameObject Rwall = GameObject.Find("Rwall");
        GameObject Lwall = GameObject.Find("Lwall");
        ROverLine = Rwall.transform.position.x - Rwall.transform.lossyScale.x / 2;
        LOverLine = Lwall.transform.position.x + Lwall.transform.lossyScale.x / 2;
        isTouch = false;
    }

    void Update()
    {
        //タッチされているなら
        if (isTouch)
        {
            //Debug.Log(touchPos);
            offset = Mathf.Repeat(Time.time * offsetSpeed, secInterval);
            //弾道予測の更新
            for (int i = 0; i < dummyCount; i++)
            {
                float t = (i * secInterval) + offset;
                float x = 0;
                float z = 0;
                float y = t * 1.5f;
                //角度の更新
                Vector3 anglePoint = touchPos - ballBornPoint.position;
                ballBornPoint.rotation = Quaternion.LookRotation(Vector3.forward,anglePoint);
                //一旦更新する
                dummySphereList[i].transform.localPosition = new Vector3(x, y, z);
                //壁を超えていたら
                float curentX = dummySphereList[i].transform.position.x;
                //右にオーバーの場合
                if (curentX > ROverLine)
                {
                    float pos = Mathf.Abs(curentX - ROverLine) * -2;
                    //補正用Vector3作成
                    Vector3 offsetPos = new Vector3(pos, 0, 0);
                    //座標を補正
                    dummySphereList[i].transform.position += offsetPos;
                    //左にオーバーの場合
                }
                else if (curentX < LOverLine)
                {
                    float pos = Mathf.Abs(curentX - LOverLine) * 2;
                    Vector3 offsetPos = new Vector3(pos, 0, 0);
                    dummySphereList[i].transform.position += offsetPos;
                }
            }
        }
    }
    //タッチされている座標が入ってくる
    public void SetPoint(Vector3 p)
    {
        touchPos = p;
    }

    //OFF 点を非アクティブ化
    public void Misunderstanding()
    {
        foreach (var obj in dummySphereList)
        {
            obj.SetActive(false);
        }
        isTouch = false;
    }
    //ON 点をアクティブ化
    public void Visualaization()
    {
        foreach (var obj in dummySphereList)
        {
            obj.SetActive(true);
        }
        isTouch = true;
    }

    public Transform getBallBornPoint()
    {
        return ballBornPoint;
    }
}

