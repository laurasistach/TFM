
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System.Text;
using System.IO;

public class Veler_Movement : MonoBehaviour
{
    public GameObject prota;
    public GameObject pirate;
    public GameObject bomba;
    private int breathings_number;
    public Text breathings_number_text;
    public GameObject message_end;
    public GameObject prota_celebrate;
    public GameObject confeti;
    public GameObject bruixolaObj;
    public GameObject veler;
    public GameObject mapa;
    private bool end=false;
    private bool canMove = true;
	public AudioSource audioSource;
	public AudioSource audioSourceEnd;
   	private int ValueExhale;
   	public List<string> datetime = new List<string>();
    public List<string> scoreGame = new List<string>();
    public List<string> attemptsGame = new List<string>();
    public GameObject semaforverd;
    public GameObject semaforvermell;

    void Start()
    {
    	ValueExhale = PlayerPrefs.GetInt("ValueExhaleName");
    	prota.GetComponent<Renderer>().enabled = true;
    	pirate.GetComponent<Renderer>().enabled = true;
    	bruixolaObj.GetComponent<Renderer>().enabled = true;
	    message_end.GetComponent<Renderer>().enabled = false;
        prota_celebrate.GetComponent<Renderer>().enabled = false;
        confeti.GetComponent<Renderer>().enabled = false;
        semaforverd.SetActive(true);
        semaforvermell.SetActive(false);
    }

  	void OnCollisionEnter2D(Collision2D col)
	{
	   if (col.gameObject.name == "box1" || col.gameObject.name == "box2"|| col.gameObject.name == "box3"|| col.gameObject.name == "box4"|| col.gameObject.name == "box5"|| col.gameObject.name == "box6"|| col.gameObject.name == "box7"|| col.gameObject.name == "box8"|| col.gameObject.name == "box9"|| col.gameObject.name == "bruixola")
	   {
		breathings_number++; 
		breathings_number_text.text = breathings_number.ToString();
		audioSource.Play();
		Destroy(col.gameObject);
		canMove= false;
		Invoke("Relax",0.1f);

	   }

	   if (col.gameObject.name == "bruixola") 
	   {
	   	end=true;
	   	audioSourceEnd.Play();
		audioSourceEnd.SetScheduledEndTime(AudioSettings.dspTime+(3f-0f));
		bruixolaObj.GetComponent<Renderer>().enabled = false;
	   	prota.GetComponent<Renderer>().enabled = false;
	   	veler.GetComponent<Renderer>().enabled = false;
        mapa.GetComponent<Renderer>().enabled = false;
    	pirate.GetComponent<Renderer>().enabled = false;
    	bomba.GetComponent<Renderer>().enabled = false;
	    message_end.GetComponent<Renderer>().enabled = true;
        prota_celebrate.GetComponent<Renderer>().enabled = true;
        confeti.GetComponent<Renderer>().enabled = true;

	   	// Save Data
        datetime.Add(DateTime.Now.ToString("dd/MM/yy    hh:mm tt"));
        scoreGame.Add(breathings_number.ToString());
        attemptsGame.Add(Pirate_Movement.attempts_number.ToString());
        string path = Application.dataPath + "/Scores/Saved_Data_Games.csv";
	    	for (int i = 0; i < scoreGame.Count; ++i)
	        {
	            using (StreamWriter sw = File.AppendText(path)) {
	                 sw.WriteLine("user"+"," + datetime[i] + "," +"Scene2" +","+ scoreGame[i]+","+attemptsGame[i]);
	            }
	            
	        }    
	   	}

	   if (col.gameObject.tag == "pirata")
	    {
	    	Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	    }
	}

    void Update()
    {
    	float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));

    	if (end==false) {
    	// Veler es mou sempre (lent)
	    	Vector3 position = prota.transform.position; 
	    	position.x = position.x + 0.01f;
	    	prota.transform.position = position;

    	}

    	// Quan bufa -> es mouen més ràpid
    	if (end == false && canMove == true && db<1 && db > (ValueExhale*1.3) ){
			Invoke("Move",0);

		}
	}

	void Move(){
		Vector3 position = prota.transform.position;
		position.x = position.x + 0.5f; //2
		prota.transform.position = position;
	}

	void Relax(){
        StartCoroutine(GamePauser());
	}

	public IEnumerator GamePauser(){
		semaforverd.SetActive(false);
        semaforvermell.SetActive(true);
	    Time.timeScale = 0;
	    yield return new WaitForSecondsRealtime (0);//3
	    Time.timeScale = 1;
	    semaforverd.SetActive(true);
        semaforvermell.SetActive(false);
        canMove = true;
        
   	}

		
	

}
