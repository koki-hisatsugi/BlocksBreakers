using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using KanKikuchi.AudioManager;

public class Blocks : MonoBehaviour
{
    public int blockHP = 30;
    public TextMeshProUGUI textMesh;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject board;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("Board");
        textMesh.text = blockHP.ToString();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ball")
        {
            if (blockHP > 0)
            {
                blockHP--;
                textMesh.text = blockHP.ToString();
                animator.SetBool("blockDamage", false);
                animator.SetBool("blockDamage", true);

                SEManager.Instance.Play(SEPath.POPSOUNDS3);
                if (blockHP == 0)
                {
                    board.GetComponent<Board>().blockDestroyCheck();
                    Destroy(gameObject);
                    GManager.instance.ChainScore++;
                    GManager.instance.stageScore += 200 * GManager.instance.ChainScore;
                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Laser")
        {
            if (blockHP > 0)
            {
                blockHP--;
                textMesh.text = blockHP.ToString();
                animator.SetBool("blockDamage", false);
                animator.SetBool("blockDamage", true);
                SEManager.Instance.Play(SEPath.POPSOUNDS3);
                if (blockHP == 0)
                {
                    board.GetComponent<Board>().blockDestroyCheck();
                    Destroy(gameObject);
                    GManager.instance.ChainScore++;
                    GManager.instance.stageScore += 200 * GManager.instance.ChainScore;
                }
            }
        }

    }


    IEnumerator dengerCheckCol()
    {
        yield return new WaitForSeconds(0.1f);
        board.GetComponent<Board>().dengerCheck();
    }

    /*使ってません
    public void Damage()
    {
        if (blockHP > 0)
        {
            blockHP--;
            textMesh.text = blockHP.ToString();
            animator.SetBool("blockDamage", false);
            animator.SetBool("blockDamage", true);
            SEManager.Instance.Play(SEPath.POPSOUNDS3);
            if (blockHP == 0)
            {
                Destroy(gameObject);
            }
        }
    }*/

    public void animend()
    {
        animator.SetBool("blockDamage", false);
    }
}
