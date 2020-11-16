using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonTestClass : MonoBehaviour
{
    // Use this for initialization
    public int HP = 1;
    public int ATK = 3;
    public string name = "hello";

    void Start()
    {
        /*Debug.Log(JsonUtility.ToJson(this));
        //JsonClass jsonClass = Instantiate(JsonClass);
        string jsonString = JsonUtility.ToJson(this);
        JsonUtility.FromJsonOverwrite(jsonString, this);
        Debug.Log(this.ATK);
        Debug.Log(this.name);
        Debug.Log(this.HP);
        jsonString = "{\"HP\":12,\"ATK\":6,\"name\":\"asdf\"}";
        JsonUtility.FromJsonOverwrite(jsonString, this);
        Debug.Log(this.ATK);
        Debug.Log(this.name);
        Debug.Log(this.HP);*/



    }

    // Update is called once per frame
    void Update()
    {

    }
}
