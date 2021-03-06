using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System.Text;
using System.IO;

// This script defines the avatar movement in the last game

public class JumpingRiver : MonoBehaviour
{
	public GameObject prota;
    public GameObject message_end;
    private bool colision_up = false;
    private bool colision_down = true;
    private bool end = false;
    private int breathings_number;
    public Text breathings_number_text;
    private float vel_jump = 0.01f; // jumping velocity 
    public AudioSource audioSourceCoin;
    public AudioSource audioSourceBoing;
    public AudioSource audioSourceEnd;
    private int ValueInhale;
    public List<string> datetime = new List<string>();
    public List<string> scoreGame = new List<string>();
    public GameObject semaforverd;
    public GameObject semaforvermell;

    void Start()
    {
        ValueInhale = PlayerPrefs.GetInt("ValueInhaleName");
        message_end.GetComponent<Renderer>().enabled = false;
        prota.GetComponent<Renderer>().enabled = true;
        semaforverd.SetActive(true);
        semaforvermell.SetActive(false);
        StartCoroutine(GamePauser());

    }

    public IEnumerator GamePauser(){
         Time.timeScale = 0;
         yield return new WaitForSecondsRealtime (1);
         Time.timeScale = 1;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        // each box is a coin
        if (col.gameObject.name == "box1" || col.gameObject.name == "box2"|| col.gameObject.name == "box3"|| col.gameObject.name == "box4"|| col.gameObject.name == "box5"|| col.gameObject.name == "box6"|| col.gameObject.name == "box7"|| col.gameObject.name == "box8"|| col.gameObject.name == "box9" || col.gameObject.name == "box10")
        {
        audioSourceCoin.Play();
        colision_up = true; 
        colision_down = false;
        breathings_number++; 
        breathings_number_text.text = breathings_number.ToString();
        Destroy(col.gameObject);
        semaforverd.SetActive(false);
        semaforvermell.SetActive(true);
        Invoke("Down",2);
       }

       if (col.gameObject.name == "rock1" || col.gameObject.name == "rock2"|| col.gameObject.name == "rock3"|| col.gameObject.name == "rock4"|| col.gameObject.name == "rock5"|| col.gameObject.name == "rock6"|| col.gameObject.name == "rock7"|| col.gameObject.name == "rock8"|| col.gameObject.name == "rock9")
        {
        colision_up = false;
        colision_down = true;
        Destroy(col.gameObject); 
        semaforverd.SetActive(true);
        semaforvermell.SetActive(false);
       }

       if (col.gameObject.name == "tresor") 
       {
        end=true;
        audioSourceEnd.Play();
        audioSourceEnd.SetScheduledEndTime(AudioSettings.dspTime+(3f-0f));
        datetime.Add(DateTime.Now.ToString("dd/MM/yy    hh:mm tt"));
        scoreGame.Add(breathings_number.ToString());
        string path = Application.dataPath + "/Scores/Saved_Data_Games.csv";
            for (int i = 0; i < scoreGame.Count; ++i)
            {
                using (StreamWriter sw = File.AppendText(path)) {
                     sw.WriteLine("user"+"," + datetime[i] + "," +"Scene5" +","+ scoreGame[i]);
                }
                
            }  
       }

    }

    void Update()
    {
        Vector3 position = prota.transform.position;
        
        float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));

        if (end == false && colision_up == false && colision_down == true && db<1 && db > (ValueInhale*1.3) ){
            Invoke("Jump",0); // avatar jumps to the coin
        }
 
        if (end == false && colision_up == true && colision_down == false){
            // avatar goes down immediately
            
        }

    }

    void Jump(){
        // it indicates the avatar to move from its position to the following coin	
        if (GameObject.Find("box1") != null)
        {
        Vector3 posbox1 = GameObject.Find("box1").transform.position;
        Vector3 startPosProta = prota.transform.position;
        prota.transform.position = Vector3.Lerp(startPosProta, posbox1,Time.deltaTime * 1/vel_jump);
        }
        else if (GameObject.Find("box2") != null)
        {
        Vector3 posbox2 = GameObject.Find("box2").transform.position;
        Vector3 startPosProta = prota.transform.position;
        prota.transform.position = Vector3.Lerp(startPosProta, posbox2,Time.deltaTime * 1/vel_jump);
        }
        else if (GameObject.Find("box3") != null)
        {
        Vector3 posbox3 = GameObject.Find("box3").transform.position;
        Vector3 startPosProta = prota.transform.position;
        prota.transform.position = Vector3.Lerp(startPosProta, posbox3,Time.deltaTime * 1/vel_jump);
        }

        else if (GameObject.Find("box4") != null)
        {
        Vector3 posbox4 = GameObject.Find("box4").transform.position;
        Vector3 startPosProta = prota.transform.position;
        prota.transform.position = Vector3.Lerp(startPosProta, posbox4,Time.deltaTime * 1/vel_jump);
        }

        else if (GameObject.Find("box5") != null)
        {
        Vector3 posbox5 = GameObject.Find("box5").transform.position;
        Vector3 startPosProta = prota.transform.position;
        prota.transform.position = Vector3.Lerp(startPosProta, posbox5,Time.deltaTime * 1/vel_jump);
        }
        else if (GameObject.Find("box6") != null)
        {
        Vector3 posbox6 = GameObject.Find("box6").transform.position;
        Vector3 startPosProta = prota.transform.position;
        prota.transform.position = Vector3.Lerp(startPosProta, posbox6,Time.deltaTime * 1/vel_jump);
        }
        else if (GameObject.Find("box7") != null)
        {
        Vector3 posbox7 = GameObject.Find("box7").transform.position;
        Vector3 startPosProta = prota.transform.position;
        prota.transform.position = Vector3.Lerp(startPosProta, posbox7,Time.deltaTime * 1/vel_jump);
        }

        else if (GameObject.Find("box8") != null)
        {
        Vector3 posbox8= GameObject.Find("box8").transform.position;
        Vector3 startPosProta = prota.transform.position;
        prota.transform.position = Vector3.Lerp(startPosProta, posbox8,Time.deltaTime * 1/vel_jump);
        }

        else if (GameObject.Find("box9") != null)
        {
        Vector3 posbox9 = GameObject.Find("box9").transform.position;
        Vector3 startPosProta = prota.transform.position;
        prota.transform.position = Vector3.Lerp(startPosProta, posbox9,Time.deltaTime * 1/vel_jump);
        }

        else if (GameObject.Find("box10") != null)
        {
        Vector3 posbox10 = GameObject.Find("box10").transform.position;
        Vector3 startPosProta = prota.transform.position;
        prota.transform.position = Vector3.Lerp(startPosProta, posbox10,Time.deltaTime * 1/vel_jump);
        }


    }

    void Down(){
        Vector3 position = prota.transform.position;
        if (colision_down==false && colision_up==true){ // avatar has not touched the rock but comes from the coin
            if (GameObject.Find("rock1") != null)
            {
            Vector3 posrock1 = GameObject.Find("rock1").transform.position;
            prota.transform.position = posrock1 - new Vector3 (1,-1,0);
            }
            else if (GameObject.Find("rock2") != null)
            {
            Vector3 posrock2 = GameObject.Find("rock2").transform.position;
            prota.transform.position = posrock2 - new Vector3 (1,-1,0);;
            }
            else if (GameObject.Find("rock3") != null)
            {
            Vector3 posrock3 = GameObject.Find("rock3").transform.position;
            prota.transform.position = posrock3 - new Vector3 (1,-1,0);
            }
            else if (GameObject.Find("rock4") != null)
            {
            Vector3 posrock4 = GameObject.Find("rock4").transform.position;
            prota.transform.position = posrock4 - new Vector3 (1,-1,0);
            }
            else if (GameObject.Find("rock5") != null)
            {
            Vector3 posrock5 = GameObject.Find("rock5").transform.position;
            prota.transform.position = posrock5 - new Vector3 (1,-1,0);
            }
            else if (GameObject.Find("rock6") != null)
            {
            Vector3 posrock6 = GameObject.Find("rock6").transform.position;
            prota.transform.position = posrock6 - new Vector3 (1,-1,0);
            }
            else if (GameObject.Find("rock7") != null)
            {
            Vector3 posrock7 = GameObject.Find("rock7").transform.position;
            prota.transform.position = posrock7 - new Vector3 (1,-1,0);
            }
            else if (GameObject.Find("rock8") != null)
            {
            Vector3 posrock8 = GameObject.Find("rock8").transform.position;
            prota.transform.position = posrock8 - new Vector3 (1,-1,0);
            }
            else if (GameObject.Find("rock9") != null)
            {
            Vector3 posrock9 = GameObject.Find("rock9").transform.position;
            prota.transform.position = posrock9 - new Vector3 (1,-1,0);
            }

            else if (GameObject.Find("tresor") != null)
            {
            Vector3 postresor = GameObject.Find("tresor").transform.position;
            prota.transform.position = postresor - new Vector3 (1,-1,0);
            Invoke("End",0.5f);
            }
        }
        if (colision_down) { // avatar touched the rock
            colision_up=false; // this will invoke Jump
        }
        
    }

    void End(){
        prota.GetComponent<Renderer>().enabled = false;
        message_end.GetComponent<Renderer>().enabled = true;
    }
}
