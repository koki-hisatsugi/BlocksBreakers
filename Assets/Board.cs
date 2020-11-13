using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public GameObject Block;
    private BlocksPos[,] blocksPos;
    private int[,] BlockFlag;
    // Start is called before the first frame update
    void Start()
    {
        testSetBlockFlag();
        blocksPos = new BlocksPos[11,9];
        for(int i=0; i<11; i++)
        {
            for(int j=0; j<9; j++)
            {
                float x = -2 + (0.5f * j);
                float y = 2.5f + (-0.5f * i);
                blocksPos[i, j] = new BlocksPos(x, y);
                blocksPos[i, j].showPos();
            }
        }

        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                //Debug.Log(i);
                if (BlockFlag[i, j] == 1)
                {
                    //Instantiate(Block, new Vector3(blocksPos[i, j].blockXpos, blocksPos[i, j].blockYpos), Quaternion.identity);
                    //blocksPos[i, j].createBlock();
                    blocksPos[i, j].myBlock= Instantiate(Block, new Vector3(blocksPos[i, j].blockXpos, blocksPos[i, j].blockYpos), Quaternion.identity);
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

        if (Input.GetKeyDown(KeyCode.X))
        {
            testDownBlocks();
        }
    }

    void downBlocks()
    {
        for (int i = 10; i >= 0; i--)
        {
            for (int j = 0; j < 9; j++)
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

        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (BlockFlag[i, j] == 1)
                {
                    if(blocksPos[i, j].myBlock == null)
                    {
                        blocksPos[i, j].myBlock = Instantiate(Block, new Vector3(blocksPos[i, j].blockXpos, blocksPos[i, j].blockYpos), Quaternion.identity);
                    }
                }
                else
                {
                    Destroy(blocksPos[i, j].myBlock);

                }
            }
        }
    }

    void testDownBlocks()
    {
        for (int i = 10; i > 0; i--)
        {
            for (int j = 0; j < 9; j++)
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

    void testSetBlockFlag()
    {
        BlockFlag = new int[11, 9] {
            {0,0,0,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,0,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1 },
            {0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,1,0,0,0,0 }
        };
    }
}
