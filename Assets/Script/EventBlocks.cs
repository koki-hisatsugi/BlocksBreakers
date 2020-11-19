using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBlocks : MonoBehaviour
{
    private bool passed;
    public GameObject LaserSprite;
    GameObject Mylaser;
    float DestroyCount;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "HEvent")
        {
            //LaserSprite = transform.GetChild(1).gameObject;
            //LaserSprite.SetActive(false);
            Mylaser = Instantiate(LaserSprite, new Vector3(0,transform.position.y,0), Quaternion.identity);
            Mylaser.SetActive(false);
        }else if(gameObject.tag == "VEvent")
        {
            Mylaser = Instantiate(LaserSprite, new Vector3(transform.position.x, 0, 0), Quaternion.identity);
            Mylaser.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GManager.instance.trunCount > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "ball")
        {
            /*if (gameObject.tag == "YEvent")
            {
                if (DestroyCount > 100)
                {
                    Destroy(gameObject);
                }
                DestroyCount++;
                if (passed)
                {
                    collision.GetComponent<Ball>().setEventForce(new Vector3(0.5f, 0.5f, 0).normalized);
                    passed = false;
                }
                else
                {
                    collision.GetComponent<Ball>().setEventForce(new Vector3(-0.5f, 0.5f, 0).normalized);
                    passed = true;

                }
            }*/

            if (gameObject.tag == "HEvent")
            {
                //LaserSprite.SetActive(true);
                Mylaser.transform.position = new Vector3(0, transform.position.y, 0);
                Mylaser.SetActive(true);
                //Mylaser =Instantiate(LaserSprite, transform.position,Quaternion.identity);
                
            }else if(gameObject.tag == "VEvent")
            {
                Mylaser.transform.position = new Vector3(transform.position.x, 0, 0);
                Mylaser.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            if (gameObject.tag == "HEvent" || gameObject.tag == "VEvent")
            {
                //LaserSprite.SetActive(false);
                //Destroy(Mylaser);
                Mylaser.SetActive(false);
            }

            else if (gameObject.tag == "YEvent")
            {
                if (DestroyCount > 100)
                {
                    Destroy(gameObject);
                }
                DestroyCount++;
                if (passed)
                {
                    collision.GetComponent<Ball>().setEventForce(new Vector3(0.5f, 0.5f, 0).normalized);
                    passed = false;
                }
                else
                {
                    collision.GetComponent<Ball>().setEventForce(new Vector3(-0.5f, 0.5f, 0).normalized);
                    passed = true;

                }
            }
        }
    }
}
