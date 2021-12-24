﻿using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class Instruct2: MonoBehaviour {  
	public Button button1;
	public GameObject intruction1;
	public GameObject intruction2;
    public GameObject intruction3;
	private string currentOption = "SEGÜENT";
	
	void Start() {  
		intruction1.SetActive(true);
        intruction2.SetActive(false);
        Button btn1 = button1.GetComponent<Button>();
        btn1.onClick.AddListener(myButtonClick);
        setButtonText(currentOption);
    }  

    void myButtonClick()
    {
        switch (currentOption)
        {
            case "SEGÜENT":
                intruction2.SetActive(true);
        		intruction1.SetActive(false);
                currentOption = "COMENÇAR!";
                setButtonText(currentOption);
                break;
 
            case "COMENÇAR!":
                SceneManager.LoadScene("Scene_Pirates");  
                break;
        }
    }
    void setButtonText(string buttonText)
    {
        button1.transform.GetChild(0).GetComponent<Text>().text = buttonText;
    }
}   