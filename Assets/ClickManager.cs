using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Vector2 startPos;
    private float speed;
    Vector2 startDirection;
    public GameObject Arrow;



    // Start is called before the first frame update
    void Start()
    {
        Arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetMouseButton(0))
        {
            Arrow.SetActive(true);
            var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
            //var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
            //transform.localRotation = rotation;
            //Debug.Log(rotation);
            Debug.Log(gameObject.transform.forward);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Arrow.SetActive(false);
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

            GManager.instance.forward = gameObject.transform.rotation.z;
            GManager.instance.createBall_bool = true;
            GManager.instance.force = shotForward;

            GManager.instance.respornBool = false;
        }*/
    }
}
