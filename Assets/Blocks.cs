using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Blocks : MonoBehaviour
{
    public int blockHP = 30;
    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh.text = blockHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "ball")
        {
            if (blockHP > 0)
            {
                blockHP--;
                textMesh.text = blockHP.ToString();
                if (blockHP == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
    }
}
