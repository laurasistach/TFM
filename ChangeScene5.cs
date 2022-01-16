using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

// This script defines how to change from "All scenes" interface to the intructions of the fifth game

public class ChangeScene5: MonoBehaviour {  
	public Button buttonGoScene;
	
	void Start() {  

        Button btn = buttonGoScene.GetComponent<Button>();
        btn.onClick.AddListener(Scene);
    }  

    void Scene(){
    	SceneManager.LoadScene("Instructions5");  
    }

}   