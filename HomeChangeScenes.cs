using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

// This script defines the navigation through the "All Scenes" interface
// It offers the possibility to play any of the games and to calibrate the microphone

public class HomeChangeScenes: MonoBehaviour {  
	public Button buttonGoScene1;
	public Button buttonGoScene2;
	public Button buttonGoScene3;
	public Button buttonGoScene4;
	public Button buttonGoScene5;
	public Button buttonGoCalibration;

	void Start() {  

        Button btn1 = buttonGoScene1.GetComponent<Button>();
        btn1.onClick.AddListener(Scene1);
        Button btn2 = buttonGoScene2.GetComponent<Button>();
        btn2.onClick.AddListener(Scene2);
        Button btn3 = buttonGoScene3.GetComponent<Button>();
        btn3.onClick.AddListener(Scene3);
        Button btn4 = buttonGoScene4.GetComponent<Button>();
        btn4.onClick.AddListener(Scene4);
        Button btn5 = buttonGoScene5.GetComponent<Button>();
        btn5.onClick.AddListener(Scene5);
        Button btn6 = buttonGoCalibration.GetComponent<Button>();
        btn6.onClick.AddListener(SceneCalibration);
    }  

    void Scene1(){
    	SceneManager.LoadScene("Instructions1");  
    }
    void Scene2(){
    	SceneManager.LoadScene("Instructions2");  
    }
    void Scene3(){
    	SceneManager.LoadScene("Instructions3");  
    }
    void Scene4(){
    	SceneManager.LoadScene("Instructions4");  
    }
    void Scene5(){
    	SceneManager.LoadScene("Instructions5");  
    }
    void SceneCalibration(){
    	SceneManager.LoadScene("CalibrationScreen");  
    }
    
}   