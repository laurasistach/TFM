using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class Benvinguda: MonoBehaviour {  
	public Button button1;
	public Button button2;
	public GameObject benvinguda1;
	public GameObject benvinguda2;
	
	void Start() {  
		benvinguda1.SetActive(true);
        benvinguda2.SetActive(false);
        Button btn1 = button1.GetComponent<Button>();
        btn1.onClick.AddListener(Next);
        Button btn2 = button2.GetComponent<Button>();
        btn2.onClick.AddListener(GoAllScenes);
    }  

    void Next(){
    	benvinguda2.SetActive(true);
        benvinguda1.SetActive(false);
    }

    void GoAllScenes(){
    	SceneManager.LoadScene("AllScenes");  
    }

}   