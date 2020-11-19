using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointTextMG : MonoBehaviour
{
    public GameObject pointText;
    public TextMeshProUGUI pointTextMesh;
    // Start is called before the first frame update
    void Start()
    {
        pointTextMesh = pointText.GetComponent<TextMeshProUGUI>();
        setText(200 * GManager.instance.ChainScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(float p)
    {
        pointTextMesh.text = p.ToString();
    }
    public void destroyThisObject()
    {
        Destroy(this.gameObject);
    }
}
