using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blowing_Volcano : MonoBehaviour
{
    public GameObject prota_normal;
    public GameObject prota_blowing;
    public GameObject prota_end;
    public GameObject air;
    public GameObject lava1;
    public GameObject lava2;
    public GameObject lava3;
    public GameObject lava4;
    public GameObject lava5;
    public GameObject lava6;
    public GameObject lava7;
    public GameObject lava8;
    public GameObject lava9;
    public GameObject lava10;
    public GameObject message_blow;
    public GameObject message_relax;
    public int breathings_number;
    public Text breathings_number_text;
    public AudioSource audioSource;
    public AudioSource audioSourceEnd;
    private int ValueExhale = -36; //idealment hauria d'agafar-se de Calibration.maxValueInhale
    private float targetTime = 1.0f; // 3; temps de bufada; --> canviarho a tot arreu!!!!
    private float pauseTime = 1.0f; // 3; temps de descans entre blowing i blowing
    public Text targetTime_text;
    private bool end = false;

   
    void Start()
    {
        prota_normal.GetComponent<Renderer>().enabled = true;
        prota_blowing.GetComponent<Renderer>().enabled = false;
        prota_end.GetComponent<Renderer>().enabled = false;
        message_blow.GetComponent<Renderer>().enabled = true;
        air.GetComponent<Renderer>().enabled = false;
        lava1.GetComponent<Renderer>().enabled = true;
        lava2.GetComponent<Renderer>().enabled = true;
        lava3.GetComponent<Renderer>().enabled = true;
        lava4.GetComponent<Renderer>().enabled = true;
        lava5.GetComponent<Renderer>().enabled = true;
        lava6.GetComponent<Renderer>().enabled = true;
        lava7.GetComponent<Renderer>().enabled = true;
        lava8.GetComponent<Renderer>().enabled = true;
        lava9.GetComponent<Renderer>().enabled = true;
        lava10.GetComponent<Renderer>().enabled = true;
        message_relax.GetComponent<Renderer>().enabled = false;

    }

    public IEnumerator PauseGame(){
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime){
            yield return 0;
            message_blow.GetComponent<Renderer>().enabled = false;
            message_relax.GetComponent<Renderer>().enabled = true;
            prota_normal.GetComponent<Renderer>().enabled = true;
            prota_blowing.GetComponent<Renderer>().enabled = false;
            air.GetComponent<Renderer>().enabled = false;
        }
        Time.timeScale = 1f;
        message_blow.GetComponent<Renderer>().enabled = true;
        message_relax.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {

        float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));
        //if(Input.GetKeyDown(KeyCode.Space))
        if(end == false && db<1 && db > (ValueExhale + ValueExhale*0.3))
        {
            Invoke("Blow",0);
            targetTime -= Time.deltaTime;
            targetTime_text.text = Mathf.Round(targetTime).ToString();

            if (targetTime <= 0.0f)
            {
                if (GameObject.Find("lava1") != null){
                    audioSource.Play();
                    StartCoroutine(PauseGame());
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava1"));
                    targetTime = 1;
                    
                }
                else if (GameObject.Find("lava2")){
                    audioSource.Play();
                    StartCoroutine(PauseGame());
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava2"));
                    targetTime = 1;
                    
                }
                else if (GameObject.Find("lava3")){
                    StartCoroutine(PauseGame());
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava3"));
                    targetTime = 1;
                }
                else if (GameObject.Find("lava4")){
                    audioSource.Play();
                    StartCoroutine(PauseGame());
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava4"));
                    targetTime = 1;
                }
                else if (GameObject.Find("lava5")){
                    audioSource.Play();
                    StartCoroutine(PauseGame());
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava5"));
                    targetTime = 1;
                }
                else if (GameObject.Find("lava6")){
                    audioSource.Play();
                    StartCoroutine(PauseGame());
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava6"));
                    targetTime = 1;
                }
                else if (GameObject.Find("lava7")){
                    audioSource.Play();
                    StartCoroutine(PauseGame());
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava7"));
                    targetTime = 1;
                }
                else if (GameObject.Find("lava8")){
                    audioSource.Play();
                    StartCoroutine(PauseGame());
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava8"));
                    targetTime = 1;
                }
                else if (GameObject.Find("lava9")){
                    audioSource.Play();
                    StartCoroutine(PauseGame());
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava9"));
                    targetTime = 1;
                }
                else if (GameObject.Find("lava10")){
                    audioSourceEnd.Play();
                    audioSourceEnd.SetScheduledEndTime(AudioSettings.dspTime+(3f-0f));
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava10"));
                    targetTime_text.text = "0";
                    Time.timeScale = 0f;
                    Debug.Log("end of the game");
                    Invoke("End",2);
                }
            }
        }

        
	}

	void Blow(){
		prota_normal.GetComponent<Renderer>().enabled = false;
        prota_blowing.GetComponent<Renderer>().enabled = true;
    	air.GetComponent<Renderer>().enabled = true;
	}

	 
    void End(){
		message_blow.GetComponent<Renderer>().enabled = false;
		message_relax.GetComponent<Renderer>().enabled = false;
		prota_normal.GetComponent<Renderer>().enabled = false;
        prota_blowing.GetComponent<Renderer>().enabled = false;
    	air.GetComponent<Renderer>().enabled = false;
        prota_end.GetComponent<Renderer>().enabled = true;
	}
    

    
}
