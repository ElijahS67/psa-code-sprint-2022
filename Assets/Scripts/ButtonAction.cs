using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour //this is for one indiviudal panel
{
    private Transform trans;
    private Button[] buttonArray;
    private Button uploadButton;
    private Button viewButton;
    private SpriteRenderer spriteRenderer;
    
    private TextMeshProUGUI TMPtext;

    private bool hasUploaded;
    private bool isOK;

    [SerializeField] private int id;
    [SerializeField] private Image areaImage;

    void Awake()
    {
        trans = GetComponent<Transform>();
        buttonArray = trans.GetComponents<Button>();
        spriteRenderer = trans.GetComponent<SpriteRenderer>();
        uploadButton = buttonArray[0];
        viewButton = buttonArray[1];
        
        TMPtext = trans.GetComponentInChildren<TextMeshProUGUI>();
        areaImage = trans.GetComponent<Image>();

        hasUploaded = PlayerPrefs.GetInt("upload_" + id) == 1;
        isOK = PlayerPrefs.GetInt("ok_" + id) == 1;

        if (!hasUploaded)
        {
            spriteRenderer.color = Color.gray;
        }
        else if (isOK)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void uploadFunction()
    {
        PlayerPrefs.SetInt("currentID", id); //uses player prefs to send id info to next scene
        SceneManager.LoadScene("AddReport");
    }
    
    private void viewFunction()
    {
        PlayerPrefs.SetInt("currentID", id); //uses player prefs to send id info to next scene
        SceneManager.LoadScene("ViewReport");
    }
}
