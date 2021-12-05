using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class ChangeScene: MonoBehaviour {  
	public Button buttonGoScene2;
	/*
	public Button buttonGoScene2_3;
	public Button buttonGoScene3;
	public Button buttonGoScene3_4;
	public Button buttonGoScene4;
	public Button buttonGoScene4_5;
	public Button buttonGoScene5;
	*/
	
	void Start() {  

        Button btn2 = buttonGoScene2.GetComponent<Button>();
        btn2.onClick.AddListener(Scene2);
    }  

    void Scene2(){
    	SceneManager.LoadScene("Scene_Pirates");  
    }
    /*
    void Scene2_3(){
    	SceneManager.LoadScene("Pirates_MountainsFlying");  
    }
    void Scene3(){
    	SceneManager.LoadScene("Scene_MountainsFlying");  
    }
    void Scene3_4(){
    	SceneManager.LoadScene("MountainsFlying__Volcano");  
    }
    void Scene4(){
    	SceneManager.LoadScene("Scene_Volcano");  
    }
    void Scene4_5(){
    	SceneManager.LoadScene("Volcano__River");  
    }
    void Scene5(){
    	SceneManager.LoadScene("Scene_River");  
    }
    */
}   