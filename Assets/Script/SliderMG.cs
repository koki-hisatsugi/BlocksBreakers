using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMG : MonoBehaviour
{
    Slider scoreSlider;
    // Start is called before the first frame update
    void Start()
    {
        scoreSlider = GetComponent<Slider>();

        scoreSlider.maxValue = GManager.instance.stageScoreMax;
        scoreSlider.value = GManager.instance.stageScore;
    }

    // Update is called once per frame
    void Update()
    {
        scoreSlider.maxValue = GManager.instance.stageScoreMax;
        scoreSlider.value = GManager.instance.stageScore;
    }
}
