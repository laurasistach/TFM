using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System.Text;
using System.IO;

public class Balloon_Movement : MonoBehaviour
{
    public GameObject prota;
    public GameObject message_end;
    public GameObject confeti;
    private int breathings_number;
    public Text breathings_number_text;
    public GameObject prota_celebrate;
    private bool cel=true;
    private bool terra=false;
    private bool end=false;
    private bool colision = false;
	public AudioSource audioSource;
	public AudioSource audioSourceEnd;
	private int ValueInhale;
	public List<string> datetime = new List<string>();
    public List<string> scoreGame = new List<string>();
    public List<string> attemptsGame = new List<string>();
    public GameObject semaforverd;
    public GameObject semaforvermell;


    void Start()
    {
    	ValueInhale = PlayerPrefs.GetInt("ValueInhaleName");
    	prota.GetComponent<Renderer>().enabled = true;
        prota_celebrate.GetComponent<Renderer>().enabled = false;
        confeti.GetComponent<Renderer>().enabled = false;
        message_end.GetComponent<Renderer>().enabled = false;
        semaforverd.SetActive(false);
        semaforvermell.SetActive(true);
    }

  	void OnCollisionEnter2D(Collision2D col)
	{
		// each box is one diamond
	   if (col.gameObject.name == "box1" || col.gameObject.name == "box2"|| col.gameObject.name == "box3"|| col.gameObject.name == "box4"|| col.gameObject.name == "box5"|| col.gameObject.name == "box6"|| col.gameObject.name == "box7"|| col.gameObject.name == "box8"|| col.gameObject.name == "box9"|| col.gameObject.name == "last")
	   {
	   	prota_celebrate.GetComponent<Renderer>().enabled = false;
	   	colision = true;
		breathings_number++; 
		breathings_number_text.text = breathings_number.ToString();
		audioSource.Play();
		Destroy(col.gameObject);
		semaforverd.SetActive(false);
        semaforvermell.SetActive(true);
	   }

	   // Next colliders restrict the balloon to move only between "barra_cel" and "barra_terra"
	   // barra_cel is a transparent bar that indicates the limit to which the balloon can go up
	   // barra_terra is a transparent bar that indicates the limit to which the balloon can go down

	   if (col.gameObject.name == "barra_cel") 
	   {
	   	cel = true;
	   	terra = false;
	   }

	   if (col.gameObject.name == "barra_terra") 
	   {
	    cel=false;
	    terra = true;
	    semaforverd.SetActive(true);
        semaforvermell.SetActive(false);
	   }
	   

	   if (col.gameObject.name == "last") // last diamond
	   {
	   	end=true;
	   	audioSourceEnd.Play();
        audioSourceEnd.SetScheduledEndTime(AudioSettings.dspTime+(3f-0f));
	   	// Save Data
        datetime.Add(DateTime.Now.ToString("dd/MM/yy    hh:mm tt"));
        scoreGame.Add(breathings_number.ToString());
        attemptsGame.Add(Pirate_Movement.attempts_number.ToString());
        string path = Application.dataPath + "/Scores/Saved_Data_Games.csv";
	    	for (int i = 0; i < scoreGame.Count; ++i)
	        {
	            using (StreamWriter sw = File.AppendText(path)) {
	                 sw.WriteLine("user"+"," + datetime[i] + "," +"Scene3" +","+ scoreGame[i]+","+attemptsGame[i]);
	            }
	            
	        }    
	   }

	}

    void Update()
    {
    	float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));

    	if (end==false) {
    	// Balloon is always going down
    		Invoke("Down",0);
    	}    	

    	// When the balloon has touched the floor AND the player blows in, and the balloon goes up
    	if (end == false && db<1 && db > ValueInhale*1.3 && terra == true && cel == false){
			Invoke("Move",0);
		}

		if (end){
			Invoke("End",0);
		}
	}

	void Move(){ // this defines the balloon going up (player blows in)
		Vector3 position = prota.transform.position;
		position.y = position.y + 0.2f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
	}

	void Down(){ // this defines the balloon going down (player does nothing)
		Vector3 position = prota.transform.position; 
	    position.y = position.y - 0.03f; 
	    position.x = position.x + 0.02f; 
	    prota.transform.position = position;
	}

	void End(){
	   	prota.GetComponent<Renderer>().enabled = false;
        prota_celebrate.GetComponent<Renderer>().enabled = true;
        confeti.GetComponent<Renderer>().enabled = true;
        message_end.GetComponent<Renderer>().enabled = true;
	}

	

}
