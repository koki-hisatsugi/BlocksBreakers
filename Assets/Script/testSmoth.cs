using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSmoth : MonoBehaviour
{

    public Vector3 currentPos = new Vector3(0,0,0);
    public Vector3 Destination = new Vector3(1, 1, 0);
    public Vector3 velocity;
    public float smoothTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        //iTween.MoveTo(gameObject, iTween.Hash("x", Destination.x));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.position = Vector3.SmoothDamp(currentPos, Destination, ref velocity, smoothTime);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", Destination.x, "y", Destination.y));
            //iTween.MoveTo(gameObject, iTween.Hash(Destination.x, Destination.y));
        }

    }

    
}
