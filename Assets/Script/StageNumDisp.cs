using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNumDisp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = "STAGE  " + GManager.instance.stageNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
