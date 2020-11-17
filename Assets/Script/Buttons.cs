using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using KanKikuchi.AudioManager;

public class Buttons : MonoBehaviour
{
    private GameObject myText;
    private Text buttonNum;
    // Start is called before the first frame update
    void Start()
    {
        myText = transform.GetChild(0).gameObject;
        buttonNum = myText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stageSelect()
    {
        GManager.instance.stageNum = int.Parse(buttonNum.text);
        SEManager.Instance.Play(SEPath.FANTASYCLICKSOUNDS1);
        SceneManager.LoadScene("InGame");
    }
}
