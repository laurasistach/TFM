using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

// This script defines how to change from "Welcome" interface to "All scenes" interface

public class ChangeScene0: MonoBehaviour {  
	public Button buttonGoScene;
	
	void Start() {  

        Button btn = buttonGoScene.GetComponent<Button>();
        btn.onClick.AddListener(Scene1);
    }  

    void Scene1(){
    	SceneManager.LoadScene("AllScenes");  
    }

}   