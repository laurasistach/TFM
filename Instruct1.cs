using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

// This script defines how to visualize instructions of the first game and load the game itself

public class Instruct1: MonoBehaviour {  
	public Button button1;
	public GameObject intruction1;
	public GameObject intruction2;
	private string currentOption = "option 1";
	
	void Start() {  
		intruction1.SetActive(true);
        intruction2.SetActive(false);
        Button btn1 = button1.GetComponent<Button>();
        btn1.onClick.AddListener(myButtonClick);
    }  

    void myButtonClick()
     {
        switch (currentOption)
        {
            case "option 1":
                intruction2.SetActive(true);
        		intruction1.SetActive(false);
                currentOption = "option 2";
                break;
 
             case "option 2":
                SceneManager.LoadScene("Scene_UnderTheSea");  
                break;
        }
    }
}   