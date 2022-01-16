using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

// This script defines how to change from "All scenes" interface to the "End" interface

public class ChangeSceneEnd: MonoBehaviour {  
	public Button buttonGoScene;
	
	void Start() {  

        Button btn = buttonGoScene.GetComponent<Button>();
        btn.onClick.AddListener(SceneEnd);
    }  

    void SceneEnd(){
    	SceneManager.LoadScene("Scene_End");  
    }

}   