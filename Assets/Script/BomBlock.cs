using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using KanKikuchi.AudioManager;

public class BomBlock : MonoBehaviour
{
    public int blockHP = 30;
    public TextMeshProUGUI textMesh;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject board;

    public GameObject pointText;
    public GameObject myPointText;
    public GameObject blast;

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
                    Debug.Log(this.transform.position);
                    GManager.instance.ChainScore++;
                    GManager.instance.stageScore += 200 * GManager.instance.ChainScore;
                    myPointText = Instantiate(pointText, this.transform.position, Quaternion.identity);
                    //myPointText.GetComponent<PointTextMG>().setText(200 * GManager.instance.ChainScore);
                    board.GetComponent<Board>().blockDestroyCheck();
                    //Blast発生
                    var blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                    blastPrefab.GetComponent<BlastMG>().addForce(Vector3.up);
                    blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                    blastPrefab.GetComponent<BlastMG>().addForce(Vector3.left);
                    blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                    blastPrefab.GetComponent<BlastMG>().addForce(Vector3.right);
                    blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                    blastPrefab.GetComponent<BlastMG>().addForce(Vector3.down);
                    //ゲームオブジェクト削除
                    Destroy(gameObject);

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
                    GManager.instance.ChainScore++;
                    GManager.instance.stageScore += 200 * GManager.instance.ChainScore;
                    myPointText = Instantiate(pointText, this.transform.position, Quaternion.identity);
                    //Blast発生
                    var blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                    blastPrefab.GetComponent<BlastMG>().addForce(Vector3.up);
                    blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                    blastPrefab.GetComponent<BlastMG>().addForce(Vector3.left);
                    blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                    blastPrefab.GetComponent<BlastMG>().addForce(Vector3.right);
                    blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                    blastPrefab.GetComponent<BlastMG>().addForce(Vector3.down);
                    //ゲームオブジェクト削除
                    Destroy(gameObject);

                }
            }
        }

        if (collision.gameObject.tag == "Blast")
        {
            if (blockHP > 0)
            {
                SEManager.Instance.Play(SEPath.POPSOUNDS3);
                board.GetComponent<Board>().blockDestroyCheck();
                GManager.instance.ChainScore++;
                GManager.instance.stageScore += 200 * GManager.instance.ChainScore;
                myPointText = Instantiate(pointText, this.transform.position, Quaternion.identity);
                //Blast発生
                var blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                blastPrefab.GetComponent<BlastMG>().addForce(Vector3.up);
                blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                blastPrefab.GetComponent<BlastMG>().addForce(Vector3.left);
                blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                blastPrefab.GetComponent<BlastMG>().addForce(Vector3.right);
                blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
                blastPrefab.GetComponent<BlastMG>().addForce(Vector3.down);
                //ゲームオブジェクト削除
                Destroy(gameObject);
            }
        }

    }


    IEnumerator dengerCheckCol()
    {
        yield return new WaitForSeconds(0.1f);
        board.GetComponent<Board>().dengerCheck();
    }

    public void animend()
    {
        animator.SetBool("blockDamage", false);
    }

    /*private void OnDestroy()
    {
        var blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
        blastPrefab.GetComponent<BlastMG>().addForce(Vector3.up);
        blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
        blastPrefab.GetComponent<BlastMG>().addForce(Vector3.left);
        blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
        blastPrefab.GetComponent<BlastMG>().addForce(Vector3.right);
        blastPrefab = Instantiate(blast, transform.position, Quaternion.identity);
        blastPrefab.GetComponent<BlastMG>().addForce(Vector3.down);
    }*/
}