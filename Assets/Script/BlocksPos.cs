using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksPos : MonoBehaviour
{
    public float blockXpos { get; set; }
    public float blockYpos { get; set; }
    //public GameObject OriginalBlock;
    public GameObject myBlock;
    bool Downblock;

    public BlocksPos(float x,float y)
    {
        blockXpos = x;
        blockYpos = y;
    }

    public void showPos()
    {
        Debug.Log("Xpos" + blockXpos + "Ypos" + blockYpos);
    }

    public void createBlock()
    {
        //myBlock= Instantiate(OriginalBlock, new Vector3(blockXpos, blockYpos), Quaternion.identity);
    }

    public void setBlockPos()
    {
        Downblock = true;
        //myBlock.GetComponent<Transform>().position = new Vector2(blockXpos, blockYpos);
        iTween.MoveTo(myBlock, iTween.Hash("x", blockXpos, "y", blockYpos));
    }

    private void FixedUpdate()
    {
        /*if (Downblock)
        {
            myBlock.transform.position = new Vector3(myBlock.transform.position.x, myBlock.transform.position.y- 0.1f, myBlock.transform.position.z);
            if(myBlock.transform.position.y== blockYpos)
            {
                Downblock = false;
            }
        }*/
    }


}
