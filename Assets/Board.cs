using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public GameObject[] Block;
    private BlocksPos[,] blocksPos;
    private int[,] BlockFlag;

    public GameObject denText;
    // Start is called before the first frame update
    void Start()
    {
        denText.SetActive(false);
        testSetBlockFlag2();
        blocksPos = new BlocksPos[12,11];
        for(int i=0; i<12; i++)
        {
            for(int j=0; j<11; j++)
            {
                float x = -2.5f + (0.5f * j);
                float y = 2.5f + (-0.5f * i);
                blocksPos[i, j] = new BlocksPos(x, y);
                blocksPos[i, j].showPos();
            }
        }

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                //Debug.Log(i);
                if (BlockFlag[i, j] == 1)
                {
                    //Instantiate(Block, new Vector3(blocksPos[i, j].blockXpos, blocksPos[i, j].blockYpos), Quaternion.identity);
                    //blocksPos[i, j].createBlock();
                    blocksPos[i, j].myBlock= Instantiate(Block[0], new Vector3(blocksPos[i, j].blockXpos, blocksPos[i, j].blockYpos), Quaternion.identity);
                }
                else if(BlockFlag[i, j] == 2)
                {
                    blocksPos[i, j].myBlock = Instantiate(Block[1], new Vector3(blocksPos[i, j].blockXpos, blocksPos[i, j].blockYpos), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            downBlocks();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            testDownBlocks();
        }
    }

    void downBlocks()
    {
        for (int i = 11; i >= 0; i--)
        {
            for (int j = 0; j < 11; j++)
            {
                if (i > 0)
                {
                    if(blocksPos[i - 1, j].myBlock == null)
                    {
                        BlockFlag[i, j] = 0;
                    }
                    else
                    {
                        BlockFlag[i, j] = 1;
                    }

                    //BlockFlag[i, j] = BlockFlag[i - 1, j];
                }
                else
                {
                    BlockFlag[i, j] = 0;
                }
                
            }
        }

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (BlockFlag[i, j] == 1)
                {
                    if(blocksPos[i, j].myBlock == null)
                    {
                        blocksPos[i, j].myBlock = Instantiate(Block[0], new Vector3(blocksPos[i, j].blockXpos, blocksPos[i, j].blockYpos), Quaternion.identity);
                    }
                }
                else
                {
                    Destroy(blocksPos[i, j].myBlock);

                }
            }
        }
    }

    public void testDownBlocks()
    {
        for (int i = 11; i > 0; i--)
        {
            for (int j = 0; j < 11; j++)
            {
                if (blocksPos[i-1, j].myBlock == null)
                {
                    blocksPos[i, j].myBlock = null;
                }
                else if(blocksPos[i - 1, j].myBlock != null)
                {
                    blocksPos[i, j].myBlock = blocksPos[i - 1, j].myBlock;
                    blocksPos[i, j].setBlockPos();
                }

                else
                {
                    Destroy(blocksPos[i, j].myBlock);

                }
            }
        }
    }

    public void dengerCheck()
    {
        bool denger = false;
        for(int i=0; i<11; i++)
        {
            if (blocksPos[10, i].myBlock != null)
            {
                denger = true;
            }
        }

        if (denger)
        {
            denText.SetActive(true);
            StartCoroutine("delDenger");
        }
    }

    //デンジャーを消すコルーチン
    IEnumerator delDenger()
    {
        yield return new WaitForSeconds(1.0f);
        denText.SetActive(false);
    }

    void testSetBlockFlag()
    {
        BlockFlag = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,0,1},
            {1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,0,1},
            {1,1,1,1,0,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,0,1},
            {1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,0,1},
            {1,1,1,1,1,1,1,1,1,1,1},
            {0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,1,0,0,0,0,1,1},
            {0,0,0,0,0,0,0,0,0,0,1}
        };
    }

    void testSetBlockFlag2()
    {
        BlockFlag = new int[12, 11] {
            {0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,0,1,1,1,0,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {1,1,1,0,1,0,1,0,1,1,1},
            {1,1,1,1,1,0,1,1,1,1,1},
            {2,0,0,0,0,0,0,0,0,0,2},
            {0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0}
        };
    }
}
