using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportAreaManager : MonoBehaviour
{
    public ReportArea[] reportAreaArray;
    
    // Start is called before the first frame update
    void Awake()
    {
        reportAreaArray = GetComponentsInChildren<ReportArea>();
        Debug.Log(reportAreaArray.Length);
    }

    public ReportArea getReportArea(int i) {
        //get the report area
        return reportAreaArray[i];
    }

    //id starts from 0
    // public void replaceImageAtID(int id, Texture2D texture2D)
    // {
    //     Debug.Log("replacing in progress");
    //     reportAreaArray[id].replaceImage(texture2D);
    // }
}
