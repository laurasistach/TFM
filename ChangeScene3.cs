using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class ChangeScene3: MonoBehaviour {  
	public Button buttonGoScene;
	
	void Start() {  

        Button btn = buttonGoScene.GetComponent<Button>();
        btn.onClick.AddListener(Scene4);
    }  

    void Scene4(){
    	SceneManager.LoadScene("Instructions4");  
    }

}   