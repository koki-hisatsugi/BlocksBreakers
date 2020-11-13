using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    [SerializeField]private GameObject balls;

    bool stayBall = false;
    float createBallMax;
    float createBallCount;
    float createTimeCount;

    bool createBool;
    bool testCreate;

    // Start is called before the first frame update
    void Start()
    {
        createBallMax = 50;
        //Instantiate(balls);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        createBool = GManager.instance.createBall_bool;
        createTimeCount += Time.deltaTime;

        if (createBallCount<createBallMax && createTimeCount>0.05f &&createBool )
        {
            Instantiate(balls, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            createBallCount++;
            createTimeCount = 0;
            Debug.Log("インスタンシエート");
        }else if (createBallCount == 0 && createBool)
        {
            createBallCount = 0;
            GManager.instance.createBall_bool = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            stayBall = true;
        }
    }

}
