using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreatePanel : MonoBehaviour
{
    public RectTransform contentRectTransform;
    public GameObject[] createButtons;
    public GameObject onBButton;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < createButtons.Length; i++)
        {
            var obj = Instantiate(createButtons[i], contentRectTransform);
            obj.GetComponent<CreateButtons>().createPanel = this.gameObject;
        }
    }

    public void closePanel()
    {
        Debug.Log(onBButton);
        Debug.Log(onBButton.GetComponent<NewBButton>().childNum);
        gameObject.SetActive(false);
    }

    public void blockSet(int num)
    {
        if (num == 100)
        {
            onBButton.GetComponent<NewBButton>().noneBlock();
        }
        else
        {
            onBButton.GetComponent<NewBButton>().setBlocks(num);
        }
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
