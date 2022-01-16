
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System.Text;
using System.IO;

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
    public GameObject message;
    public int breathings_number;
    public Text breathings_number_text;
    private int attempts_number;
    public AudioSource audioSource;
    public AudioSource audioSourceEnd;
    public AudioSource audioSourceWrong;
    private float targetTime = 1f; // blow out time
    private float pauseTime = 2f; // rest time betweeen blowing - blowing
    private bool end = false;
    private int ValueExhale;
    public List<string> datetime = new List<string>();
    public List<string> scoreGame = new List<string>();
    public List<string> attemptsGame = new List<string>();
    public GameObject semaforverd;
    public GameObject semaforvermell;
    private float timer = 4; 
    private bool canBlow = true;

    void Start()
    {
        ValueExhale = PlayerPrefs.GetInt("ValueExhaleName");
        prota_normal.GetComponent<Renderer>().enabled = true;
        prota_blowing.GetComponent<Renderer>().enabled = false;
        prota_end.GetComponent<Renderer>().enabled = false;
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
        message.GetComponent<Renderer>().enabled = false;
        semaforverd.SetActive(true);
        semaforvermell.SetActive(false);

    }

    public IEnumerator PauseGame(){
        Time.timeScale = 0f;
        canBlow = false;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime){
            yield return 0;
            semaforverd.SetActive(false);
            semaforvermell.SetActive(true);
            prota_normal.GetComponent<Renderer>().enabled = true;
            prota_blowing.GetComponent<Renderer>().enabled = false;
            air.GetComponent<Renderer>().enabled = false;
        }
        Time.timeScale = 1f;
        canBlow = true;
        semaforverd.SetActive(true);
        semaforvermell.SetActive(false);
    }

    void Update()
    {
        float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));
        Debug.Log(targetTime);
        if(end == false && canBlow == true) {
            timer -= Time.deltaTime;
            if (db<1 && db > (ValueExhale*1.3)){
                Invoke("Blow",0);
                targetTime -= Time.deltaTime;
                if (targetTime <= 0.0f){
                    if (GameObject.Find("lava1") != null){
                        audioSource.Play(); StartCoroutine(PauseGame());
                        breathings_number++; breathings_number_text.text = breathings_number.ToString();
                        Destroy(GameObject.Find("lava1")); targetTime = 1;timer = 4;
                    }
                    else if (GameObject.Find("lava2")){
                        audioSource.Play(); StartCoroutine(PauseGame());
                        breathings_number++; breathings_number_text.text = breathings_number.ToString();
                        Destroy(GameObject.Find("lava2")); targetTime = 1;timer = 4;
                    }
                    else if (GameObject.Find("lava3")){
                        audioSource.Play(); StartCoroutine(PauseGame());
                        breathings_number++; breathings_number_text.text = breathings_number.ToString();
                        Destroy(GameObject.Find("lava3")); targetTime = 1;timer = 4;
                    }
                    else if (GameObject.Find("lava4")){
                        audioSource.Play(); StartCoroutine(PauseGame());
                        breathings_number++; breathings_number_text.text = breathings_number.ToString();
                        Destroy(GameObject.Find("lava4")); targetTime = 1;timer = 4;
                    }
                    else if (GameObject.Find("lava5")){
                        audioSource.Play(); StartCoroutine(PauseGame());
                        breathings_number++; breathings_number_text.text = breathings_number.ToString();
                        Destroy(GameObject.Find("lava5")); targetTime = 1;timer = 4;
                    }
                    else if (GameObject.Find("lava6")){
                        audioSource.Play(); StartCoroutine(PauseGame());
                        breathings_number++; breathings_number_text.text = breathings_number.ToString();
                        Destroy(GameObject.Find("lava6")); targetTime = 1;timer = 4;
                    }
                    else if (GameObject.Find("lava7")){
                        audioSource.Play(); StartCoroutine(PauseGame());
                        breathings_number++; breathings_number_text.text = breathings_number.ToString();
                        Destroy(GameObject.Find("lava7")); targetTime = 1;timer = 4;
                    }
                    else if (GameObject.Find("lava8")){
                        audioSource.Play(); StartCoroutine(PauseGame());
                        breathings_number++; breathings_number_text.text = breathings_number.ToString();
                        Destroy(GameObject.Find("lava8")); targetTime = 1;timer = 4;
                    }
                    else if (GameObject.Find("lava9")){
                        audioSource.Play(); StartCoroutine(PauseGame());
                        breathings_number++; breathings_number_text.text = breathings_number.ToString();
                        Destroy(GameObject.Find("lava9")); targetTime = 1;timer = 4;
                    }
                    else if (GameObject.Find("lava10")){
                    audioSourceEnd.Play();
                    audioSourceEnd.SetScheduledEndTime(AudioSettings.dspTime+(3f-0f));
                    breathings_number++; breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava10"));
                    Time.timeScale = 0f;
                    // Save Data
                    datetime.Add(DateTime.Now.ToString("dd/MM/yy    hh:mm tt"));
                    scoreGame.Add(breathings_number.ToString());
                    attemptsGame.Add(attempts_number.ToString());
                    string path = Application.dataPath + "/Scores/Saved_Data_Games.csv";
                        for (int i = 0; i < scoreGame.Count; ++i)
                        {
                            using (StreamWriter sw = File.AppendText(path)) {
                                 sw.WriteLine("user"+"," + datetime[i] + "," +"Scene4" +","+ scoreGame[i]+","+attemptsGame[i]);
                            }
                            
                        }   
                    prota_normal.GetComponent<Renderer>().enabled = false;
                    prota_blowing.GetComponent<Renderer>().enabled = false;
                    air.GetComponent<Renderer>().enabled = false;
                    prota_end.GetComponent<Renderer>().enabled = true;
                    }
                }
            }
            
            if (timer < 0){
                if (GameObject.Find("lava1") != null){
                    audioSourceWrong.Play(); message.GetComponent<Renderer>().enabled = true;attempts_number++; StartCoroutine(PauseGame());
                    Destroy(GameObject.Find("lava1")); targetTime = 1; timer = 4;message.GetComponent<Renderer>().enabled = false;
                }
                else if (GameObject.Find("lava2")){
                    audioSourceWrong.Play(); message.SetActive(true);attempts_number++; StartCoroutine(PauseGame());
                    Destroy(GameObject.Find("lava2")); targetTime = 1;timer = 4;message.SetActive(false);
                }
                else if (GameObject.Find("lava3")){
                    audioSourceWrong.Play(); message.SetActive(true);attempts_number++; StartCoroutine(PauseGame());
                    Destroy(GameObject.Find("lava3")); targetTime = 1;timer = 4;message.SetActive(false);
                }
                else if (GameObject.Find("lava4")){
                    audioSourceWrong.Play(); message.SetActive(true);attempts_number++; StartCoroutine(PauseGame());
                    Destroy(GameObject.Find("lava4")); targetTime = 1;timer = 4;message.SetActive(false);
                }
                else if (GameObject.Find("lava5")){
                    audioSourceWrong.Play(); message.SetActive(true);attempts_number++; StartCoroutine(PauseGame());
                    Destroy(GameObject.Find("lava5")); targetTime = 1;timer = 4;message.SetActive(false);
                }
                else if (GameObject.Find("lava6")){
                    audioSourceWrong.Play(); message.SetActive(true);attempts_number++; StartCoroutine(PauseGame());
                    Destroy(GameObject.Find("lava6")); targetTime = 1;timer = 4;message.SetActive(false);
                }
                else if (GameObject.Find("lava7")){
                    audioSourceWrong.Play(); message.SetActive(true);attempts_number++; StartCoroutine(PauseGame());
                    Destroy(GameObject.Find("lava7")); targetTime = 1;timer = 4;message.SetActive(false);
                }
                else if (GameObject.Find("lava8")){
                    audioSourceWrong.Play(); message.SetActive(true);attempts_number++; StartCoroutine(PauseGame());
                    Destroy(GameObject.Find("lava8")); targetTime = 1;timer = 4;message.SetActive(false);
                }
                else if (GameObject.Find("lava9")){
                    audioSourceWrong.Play(); message.SetActive(true);attempts_number++; StartCoroutine(PauseGame());
                    Destroy(GameObject.Find("lava9")); targetTime = 1;timer = 4;message.SetActive(false);
                }
                else if (GameObject.Find("lava10")){
                    audioSourceEnd.Play();
                    audioSourceEnd.SetScheduledEndTime(AudioSettings.dspTime+(3f-0f));
                    breathings_number++; breathings_number_text.text = breathings_number.ToString();
                    Destroy(GameObject.Find("lava10"));
                    Time.timeScale = 0f;
                    // Save Data
                    datetime.Add(DateTime.Now.ToString("dd/MM/yy    hh:mm tt"));
                    scoreGame.Add(breathings_number.ToString());
                    attemptsGame.Add(attempts_number.ToString());
                    string path = Application.dataPath + "/Scores/Saved_Data_Games.csv";
                        for (int i = 0; i < scoreGame.Count; ++i)
                        {
                            using (StreamWriter sw = File.AppendText(path)) {
                                 sw.WriteLine("user"+"," + datetime[i] + "," +"Scene4" +","+ scoreGame[i]+","+attemptsGame[i]);
                            }
                            
                        }   
                    prota_normal.GetComponent<Renderer>().enabled = false;
                    prota_blowing.GetComponent<Renderer>().enabled = false;
                    air.GetComponent<Renderer>().enabled = false;
                    prota_end.GetComponent<Renderer>().enabled = true;
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
		prota_normal.GetComponent<Renderer>().enabled = false;
        prota_blowing.GetComponent<Renderer>().enabled = false;
    	air.GetComponent<Renderer>().enabled = false;
        prota_end.GetComponent<Renderer>().enabled = true;
	}   
}
