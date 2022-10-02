using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportArea : MonoBehaviour
{

    private bool IsStatusOK;
    private bool IsStatusButtonPressed;
    public GameObject statusbar;
    private TextAsset reportText;
    
    [SerializeField] private int id;
    private ButtonManager buttonManager;
    private Button[] buttonArray;
    private Button statusButton;
    private Button viewReportButton;
    private Button uploadReportButton;

    private Image[] imageArray;
    private Image reportImage;

    // Start is called before the first frame update
    void Awake()
    {
        IsStatusOK = false;
        IsStatusButtonPressed = false;

        buttonArray = GetComponentsInChildren<Button>();
        statusButton = buttonArray[0];
        viewReportButton = buttonArray[1];
        uploadReportButton = buttonArray[2];
        
        Debug.Log(statusButton);
        Debug.Log(viewReportButton);
        Debug.Log(uploadReportButton);
        
        //add button functions to their buttons respectively
        viewReportButton.onClick.AddListener(() => viewReportFunction(id));
        uploadReportButton.onClick.AddListener(() => uploadReportFunction(id));

        buttonManager = FindObjectOfType<ButtonManager>();
        imageArray = GetComponentsInChildren<Image>();
        // Debug.Log(imageArray.Length);
        
        // foreach (var image in imageArray)
        // {
        //     Debug.Log(image);
        // }
        
        //reportImage = imageArray[1]; //this is the actual map image that we want to replace
    }
    
    void Update()
    {
        if (IsStatusButtonPressed == false) {
            statusbar.GetComponent<Image>().color = Color.yellow; //yellow
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

    //passes id to button manager so it knows what id is calling it
    public void viewReportFunction(int id)
    {
        buttonManager.OpenViewButton(id);
    }
    
    public void uploadReportFunction(int id)
    {
        buttonManager.OpenWindowButton(id);
    }

    //replaces the sprite in the report image with the sprite created from the texture
    // public void replaceImage(Texture2D texture2D)
    // {
    //     reportImage.overrideSprite = Sprite.Create(texture2D,
    //           new Rect(0, 0,
    //               texture2D.width, texture2D.height), Vector2.zero);
    // }
    
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
