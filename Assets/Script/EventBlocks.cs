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
            Mylaser = Instantiate(LaserSprite, transform.position, Quaternion.identity);
            Mylaser.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "ball")
        {
            if (gameObject.tag == "YEvent")
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

            if (gameObject.tag == "HEvent")
            {
                //LaserSprite.SetActive(true);
                Mylaser.transform.position = gameObject.transform.position;
                Mylaser.SetActive(true);
                //Mylaser =Instantiate(LaserSprite, transform.position,Quaternion.identity);
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            if (gameObject.tag == "HEvent")
            {
                //LaserSprite.SetActive(false);
                //Destroy(Mylaser);
                Mylaser.SetActive(false);
            }
        }
    }
}
