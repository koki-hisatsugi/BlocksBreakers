﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Create : MonoBehaviour
{
    public RectTransform contentRectTransform;
    public Button button;
    private void Start()
    {
        for (int i = 1; i <= 30; i++)
        {
            var obj = Instantiate(button, contentRectTransform);
            obj.GetComponentInChildren<Text>().text = i.ToString();
        }
    }
}
