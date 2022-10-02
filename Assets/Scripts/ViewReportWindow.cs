using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewReportWindow : MonoBehaviour
{
    private ButtonManager buttonManager;
    private ReportAreaManager reportAreaManager;
    private Image[] imageArray;
    private Image image;
    
    // Start is called before the first frame update
    void Awake()
    {
        buttonManager = FindObjectOfType<ButtonManager>();
        reportAreaManager = FindObjectOfType<ReportAreaManager>();
        imageArray = GetComponentsInChildren<Image>();
        Debug.Log(imageArray.Length);
        
        foreach (var i in imageArray)
        {
            Debug.Log(i);
        }

        image = imageArray[1];
    }

    public void replaceImage(Texture2D texture2D)
    {
  
        if (texture2D == null)
        {
            image.color = Color.black;
            return;
        }
        
        image.color = Color.white;
        image.sprite = Sprite.Create(texture2D,
              new Rect(0, 0,
                  texture2D.width, texture2D.height), Vector2.zero);
    }
    
}
