using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ontrigger1団目");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Blocks")
        {
            Debug.Log("ontrigger2団目");
            collision.gameObject.GetComponent<Blocks>().Damage();
        }
    }
}
