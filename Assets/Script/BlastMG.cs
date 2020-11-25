using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastMG : MonoBehaviour
{
    Rigidbody2D myRD2D;
    public float speed = 100;
    public GameObject Twall;
    public GameObject Bwall;
    public GameObject Lwall;
    public GameObject Rwall;
    // Start is called before the first frame update
    void Start()
    {
        Twall = GameObject.Find("Twall");
        Rwall = GameObject.Find("Rwall");
        Lwall = GameObject.Find("Lwall");
        Bwall = GameObject.Find("Bwall");
        myRD2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > Rwall.transform.position.x)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < Lwall.transform.position.x)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > Twall.transform.position.y)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < Bwall.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

    public void addForce(Vector3 force)
    {
        //myRD2D.velocity = force * speed;
        this.GetComponent<Rigidbody2D>().velocity = force * speed;
        Debug.Log(force);
    }
}
