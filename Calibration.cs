using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;  
using System.Linq;


public class Calibration : MonoBehaviour
{
	public Button Exhale;
	public Button Inhale;
	private bool buttonExhalePressed;
	private bool buttonInhalePressed;
	public float timer1 = 3; 
	public float timer2 = 3; 
	private List<float> ValuesExhale = new List<float>();
	private List<float> ValuesInhale = new List<float>();
	public Text maxValueExhale_text;
	public Text maxValueInhale_text;
	public static int ValueExhale;
	public static int ValueInhale;

    /* private void OnDestroy(){ //Called when changing scenes, if object not set to DontDestroyOnLoad.
    	PlayerPrefs.SetInt("ValueInhaleName",ValueInhale);
    	PlayerPrefs.SetInt("ValueExhaleName",ValueExhale);
    	//PlayerPrefs.SetInt("ValueInhaleName",-36);
    	//PlayerPrefs.SetInt("ValueExhaleName",-58);
    	PlayerPrefs.Save();
    }*/
    
    public void AddToListExhale(float value)
    {
        ValuesExhale.Add(value);
    }

    public void AddToListInhale(float value)
    {
        ValuesInhale.Add(value);
    }

    void Start()
    {
    	Button btnEx = Exhale.GetComponent<Button>();
        btnEx.onClick.AddListener(CalibrationExhale);
        Button btnInh = Inhale.GetComponent<Button>();
        btnInh.onClick.AddListener(CalibrationInhale);
        //ValueExhale = PlayerPrefs.GetInt("ValueExhaleName",-36); 
        //ValueInhale = PlayerPrefs.GetInt("ValueInhaleName",-58); 
    }

     void CalibrationInhale(){
    	buttonInhalePressed = true;
    }


    void CalibrationExhale(){
    	buttonExhalePressed = true;
    }

    void Update()
    {
    	// Exhale
    	if (buttonExhalePressed == true){
			timer1 -= Time.deltaTime;
    	}
    	if (timer1 >= 0.0f)
		{
		    float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));
		    AddToListExhale(db);
		}

		if (timer1 <=0){
			timer1 = 0;
			float maxValueExhale = 0;
			string result = "List dbs: ";
			foreach (float value in ValuesExhale){
				if (value >-1000){
				    maxValueExhale += value;
				    result += value.ToString() + ", ";
				}
			}
			maxValueExhale /= ValuesExhale.Count;
			maxValueExhale_text.text = Mathf.Round(maxValueExhale).ToString();
			int ValueExhale = Mathf.RoundToInt(maxValueExhale);
			PlayerPrefs.SetInt("ValueExhaleName",ValueExhale);
			PlayerPrefs.Save();
		}

		// Inhalació
		if (buttonInhalePressed == true){
			timer2 -= Time.deltaTime;
    	}
    	if (timer2 >= 0.0f)
		{
		    float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));
		    AddToListInhale(db);
		}

		if (timer2 <=0){
			timer2 = 0;
			float maxValueInhale = 0;
			string result = "List dbs: ";
			foreach (float value in ValuesInhale){
				if (value >-1000){
				    maxValueInhale += value;
				    result += value.ToString() + ", ";
				}
			}
			maxValueInhale /= ValuesInhale.Count;
			maxValueInhale_text.text = Mathf.Round(maxValueInhale).ToString();
			int ValueInhale = Mathf.RoundToInt(maxValueInhale);
			PlayerPrefs.SetInt("ValueInhaleName",ValueInhale);
			PlayerPrefs.Save();
		}
    }

    


}
