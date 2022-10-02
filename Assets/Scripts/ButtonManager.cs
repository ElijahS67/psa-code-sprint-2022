using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
//for handling buttons in the main menu, shop and settings screens only
{
    public GameObject uploadWindows; //this is for the uload
    public GameObject viewWindows;
    public ViewReportWindow viewReportWindow;
    
    private int currentID = -1;
    private ReportArea reportArea;
    private ReportAreaManager reportAreaManager;

    private Texture2D texture2D;
    public Texture2D[] imageArray; //when view, display from here
    public string[] textArray;

    public TMP_InputField textInput1; //for upload
    public TMP_InputField textInput2; //for viewing
    
    
    private void Awake()
    {
        uploadWindows.SetActive(false);
        viewWindows.SetActive(false);

        textInput2.readOnly = true; //viewing text input, non-editable

        reportArea = FindObjectOfType<ReportArea>();
        reportAreaManager = FindObjectOfType<ReportAreaManager>();
        //viewReportWindow = FindObjectOfType<ViewReportWindow>();
        
        imageArray = new Texture2D[3];
        textArray = new string[3];
    }

    private void Update()
    {

        if (textInput1.IsActive())
        {

            if (textInput1.text == "" && textArray[currentID] != "")
            {
                textInput1.text = textArray[currentID];
            }

            textArray[currentID] = textInput1.text;
        }

        if (textInput2.IsActive())
        {
            if (textArray[currentID] == "")
            {
                textInput2.text = "(Please enter some text under Upload)";
            }
            else
            {
                textInput2.text = textArray[currentID];
            }
        }
    }

    // opens the upload window when upload button is pressed
    //added via code, not using Unity UI
    public void OpenWindowButton(int id)
    {
        currentID = id;
        uploadWindows.SetActive(true);
        textInput1.text = "";
        // Debug.Log(id);
    }

    //closes the upload window
    public void CloseWindowButton()
    {
        uploadWindows.SetActive(false);
        textInput1.text = "";
    }

    //button functionality added into unity GUI
    public void UploadPicButton()
    {
        Texture2D texture = PickImageFromGallery(512); //picks image from gallery
        imageArray[currentID] = texture;
        //reportAreaManager.replaceImageAtID(currentID, texture); //replaces image at that specific report area
        //saveImageToGallery();
    }

    private Texture2D PickImageFromGallery(int maxSize)
    {
        Texture2D ans = null;
        
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
        {
            Debug.Log( "Image path: " + path );
            if( path != null )
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath( path, maxSize );
                if( texture == null )
                {
                    return;
                }

                ans = texture;
            }
        } );
        
        Debug.Log(ans == null ? "image is null" : "image not null");
        texture2D = ans; //save the texture to field
        return ans;
    }
    
    // public void saveImageToGallery() //call this
    // {
    //     StartCoroutine(saveImage());
    // }
	   //
    // private IEnumerator saveImage()
    // {
    //     yield return new WaitForEndOfFrame();
    //
    //     // Save the image to Gallery/Photos
    //     NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(
    //         texture2D, "GalleryTest", "Image.png", 
    //         ( success, path ) =>
    //             Debug.Log( "Media save result: " + success + " " + path ) );
    // }
    
    // public void saveImageToGallery() //call this
    // {
    //     StartCoroutine(saveImage());
    // }
	
    // private IEnumerator saveImage()
    // {
    //     yield return new WaitForEndOfFrame();
    //     
    //     // Save the image to Gallery/Photos
    //     NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(
    //         texture2D, "GalleryTest", "TEST1234567.png", 
    //         ( success, path ) =>
    //             Debug.Log( "Media save result: " + path ) );
    //
    //     // // Save the image to Gallery/Photos
    //     // NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(
    //     //     texture2D, "GalleryTest", "Image.png", 
    //     //     ( success, path ) =>
    //     //         Debug.Log( "Media save result: " + success + " " + path ) );
    // }
    
    //now here is the view report functionality

    //opens the view report window
    public void OpenViewButton(int id)
    {
        currentID = id;
        viewWindows.SetActive(true);
        viewReportWindow.replaceImage(imageArray[currentID]);
        //Debug.Log("is this null?" + viewReportWindow);
        // Debug.Log(id);
    }

//closes the view report window
    public void CloseViewButton()
    {
        viewWindows.SetActive(false);
    }
    

//closes the upload window only
    public void BackButton()
    {
        uploadWindows.SetActive(false);
    }
}