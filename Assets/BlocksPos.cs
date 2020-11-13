using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksPos : MonoBehaviour
{
    public float blockXpos { get; set; }
    public float blockYpos { get; set; }
    //public GameObject OriginalBlock;
    public GameObject myBlock;

    public BlocksPos(float x,float y)
    {
        blockXpos = x;
        blockYpos = y;
    }

    public void showPos()
    {
        //Debug.Log("Xpos" + blockXpos + "Ypos" + blockYpos);
    }

    public void createBlock()
    {
        //myBlock= Instantiate(OriginalBlock, new Vector3(blockXpos, blockYpos), Quaternion.identity);
    }

    public void setBlockPos()
    {
        myBlock.GetComponent<Transform>().position = new Vector2(blockXpos, blockYpos);
    }
}
