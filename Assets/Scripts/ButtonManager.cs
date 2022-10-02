using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
//for handling buttons in the main menu, shop and settings screens only
{
    //for managind windows
    private bool isActive;
    public GameObject uploadWindows; //this is for the uload
    public GameObject viewWindows;
    private bool viewisActive;

    
    private void Awake()
    {
        this.isActive = false;
        this.viewisActive = false;
    }

    private void Update()
    {
        //for setting windows as ineactive
        if (this.isActive == false) {
            uploadWindows.SetActive(false);
        } else {
            uploadWindows.SetActive(true);
        }

        if (this.viewisActive == false) {
            viewWindows.SetActive(false);
        } else {
            viewWindows.SetActive(true);
        }
    }

    // opens the file window when upload button is pressed
    public void OpenWindowButton()
    {
        this.isActive = true;
    }

    //closes the window
    public void CloseWindowButton()
    {
        this.isActive = false;
    }

    public void UploadPicButton() {

    }

    public void UploadTextButton() {
        
    }

    //opens the view report window
    public void OpenViewButton()
    {
        this.viewisActive = true;
    }

//closes the view report window
    public void CloseViewButton()
    {
        this.viewisActive = false;
    }
    

//closes the upload window only
    public void BackButton()
    {
        this.isActive = false;
    }
}