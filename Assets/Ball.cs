using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 100;
    Vector3 forceBall;

    Rigidbody2D rb;
    Vector3 force;

    float endX;
    float endY;
    bool onUG;
    Transform resPos;
    float smoothTime;
    //Vector2 velocity;

    bool smooth = false;
    Vector3 currentPos;
    Vector3 Destination;
    Vector3 velocity = Vector3.zero;

    public Vector2 Rpos;

    public Vector2 rbvelocity;
    public float backupYpos;
    public float backupXpos;
    public float horizontalcount;
    public float vaticalcount;
    private void Awake()
    {
        forceBall = GManager.instance.force;
    }

    // Start is called before the first frame update
    void Start()
    {
        //rigidbodyを取得
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        //力を設定
        force = new Vector3(1.5f, 0.5f, 0.0f) * speed;
        //力を加える
        //rb.AddForce(force);
        //rb.AddForce(forceBall*speed);
        Debug.Log(forceBall);
        onUG = false;
        smoothTime = 0.5f;
        //velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        rbvelocity = rb.velocity;
        rb.velocity = rbvelocity;
    }

    private void FixedUpdate()
    {
        if (onUG)
        {
            //transform.position = Vector2.SmoothDamp(transform.position, Rpos, ref velocity, smoothTime);
            
        }
        if (smooth)
        {
            if(Mathf.Abs(transform.position.x - Destination.x) > 1)
            {
                float dir = transform.position.x < Destination.x ? 0.1f : -0.1f;
                transform.position += new Vector3(dir, 0, 0);
            }
            if (Mathf.Abs(transform.position.y - Destination.y) > 1)
            {
                float dir = transform.position.y < Destination.y ? 0.1f : -0.1f;
                transform.position += new Vector3(0, dir, 0);
            }


            if (transform.position == Destination)
            {
                smooth = false;
            }
        }


    }

    public void setForce(Vector3 pos)
    {
        Debug.Log(pos);
        rb.AddForce(pos * speed);
        horizontalcount = 0;
    }

    public void forceZero()
    {
        rb.velocity = Vector3.zero;
    }

    public void setSmooth(Vector3 vec3)
    {
        smooth = true;
        currentPos = this.gameObject.transform.position;
        Destination = vec3;
    }

    public void setReturn(Vector3 vec)
    {
        //smooth = true;
        Destination = vec;
        rb.velocity = Vector3.zero;
        iTween.MoveTo(gameObject, iTween.Hash("x", vec.x, "y", vec.y));
        //transform.position = Destination;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //水平方向で位置が変わらないときの対策
        float gosaY = transform.position.y - backupYpos;
        float gosaAbsY = Mathf.Abs(gosaY);
        if (gosaAbsY>0.5f)
        {
            backupYpos = transform.position.y;

            horizontalcount = 0;
        }
        else
        {
            horizontalcount++;
        }

        if (horizontalcount == 10)
        {
            rb.velocity += new Vector2(0, -0.5f);
            horizontalcount = 0;
        }

        //垂直方向で位置が変わらないときの対策
        float gosaX = transform.position.x - backupXpos;
        float gosaAbsX = Mathf.Abs(gosaX);
        if (gosaAbsX > 0.5f)
        {
            backupXpos = transform.position.x;

            vaticalcount = 0;
        }
        else
        {
            vaticalcount++;
        }

        if (vaticalcount == 10)
        {
            rb.velocity += new Vector2(0.5f, 0);
            vaticalcount = 0;
        }
    }
}
