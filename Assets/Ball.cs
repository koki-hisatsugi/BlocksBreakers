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
        /*if (collision.gameObject.tag == "UnderGround")
        {
            if (!GManager.instance.respornBool)
            {
                GManager.instance.Rpos = gameObject.transform.position;
                rb.velocity = new Vector3(0, 0, 0);
                GManager.instance.respornPoint.transform.position = GManager.instance.Rpos;
                GManager.instance.respornPoint.SetActive(true);
                GManager.instance.respornBool = true;
                Destroy(gameObject);
            }
            else
            {
                resPos = GManager.instance.RespornPosition;
                Rpos = GManager.instance.Rpos;
                onUG = true;
                Destroy(gameObject);
            }

            
        }*/

        
    }
}
