using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

// this script defines the navigation from the "welcoming" interfaces to "all scenes" interface

public class Benvinguda: MonoBehaviour {  
	public Button button1;
	public GameObject benvinguda1;
	public GameObject benvinguda2;
	private string currentOption = "option 1";
	
	void Start() {  
		benvinguda1.SetActive(true);
        benvinguda2.SetActive(false);
        Button btn1 = button1.GetComponent<Button>();
        btn1.onClick.AddListener(myButtonClick);
    }  

    void myButtonClick()
     {
        switch (currentOption)
        {
            case "option 1":
                benvinguda2.SetActive(true);
        		benvinguda1.SetActive(false);
                currentOption = "option 2";
                break;
 
             case "option 2":
                SceneManager.LoadScene("AllScenes");  
                break;
        }
    }
}   