using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBButton : MonoBehaviour
{
    [SerializeField]
    public GameObject[] createBlocks;
    public GameObject createPanel;
    GameObject myBlock;
    int blockSetNum;

    public int childNum;
    // Start is called before the first frame update
    void Start()
    {
        //createPanel = GameObject.Find("BlockCreatePanel");
    }

    public void onClickPlusButton()
    {
        Debug.Log(childNum);
        createPanel.SetActive(true);
        createPanel.GetComponent<BlockCreatePanel>().onBButton = this.gameObject;
    }

    public void setChildNum(int num)
    {
        childNum = num;
    }

    public void setBlocks(int blockNum)
    {
        Destroy(myBlock);
        myBlock = Instantiate(createBlocks[blockNum], transform.position, Quaternion.identity);
        myBlock.transform.parent = this.transform;
        blockSetNum = blockNum+1;
    }

    public void noneBlock()
    {
        Destroy(myBlock);
        blockSetNum = 0;
    }

    public int getBlockSetNum()
    {
        return blockSetNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
