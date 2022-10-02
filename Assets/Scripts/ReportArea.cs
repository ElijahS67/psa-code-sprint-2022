using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportArea : MonoBehaviour
{
    private Image reportImage;
    private bool IsStatusOK;
    private bool IsStatusButtonPressed;
    public GameObject statusbar;
    private TextAsset reportText;

    // Start is called before the first frame update
    void Awake()
    {
        IsStatusOK = false;
        IsStatusButtonPressed = false;
    }
    
    void Update()
    {
        if (IsStatusButtonPressed == false) {
            statusbar.GetComponent<Image>().color = new Color32(254, 224, 0, 255); //yellow
        }
        else {
            if (IsStatusOK == true) 
            {
                statusbar.GetComponent<Image>().color = new Color32(0, 254, 111, 255); //green if is ok
            }
            else
            {
                statusbar.GetComponent<Image>().color = new Color32(254, 9, 0, 255); //red if is not ok
            }
        }
    }
    public Image getImage() {
        return this.reportImage;
    }

    public void setStatusButton() {
        IsStatusOK = !IsStatusOK;
        IsStatusButtonPressed = true;
    }
    public TextAsset getReportText() {
        return this.reportText;
    }
    public bool getStatus() {
        return this.IsStatusOK;

    }


}
