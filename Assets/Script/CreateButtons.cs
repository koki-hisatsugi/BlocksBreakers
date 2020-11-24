using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButtons : MonoBehaviour
{
    public int buttonNumber;
    public GameObject createPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onBButton()
    {
        createPanel.GetComponent<BlockCreatePanel>().blockSet(buttonNumber);
    }
}
