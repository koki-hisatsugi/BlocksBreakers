using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Blocks : MonoBehaviour
{
    public int blockHP = 30;
    public TextMeshProUGUI textMesh;
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        textMesh.text = blockHP.ToString();
        animator = GetComponent<Animator>();
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
                animator.SetBool("blockDamage", false);
                animator.SetBool("blockDamage", true);
                if (blockHP == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
    }

    public void animend()
    {
        animator.SetBool("blockDamage", false);
    }
}
