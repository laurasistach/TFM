using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System.Text;
using System.IO;

public class Diver2 : MonoBehaviour
{
	public GameObject prota;
	public GameObject prota_end;
    //public GameObject message_start;
    public GameObject message_end;
    private bool colision_up = false;
    private bool colision_down = true;
    private bool end = false;
    private int breathings_number;
    public Text breathings_number_text;
    public AudioSource audioSource;
    public AudioSource audioSourceEnd;
    private int ValueInhale;
    public List<string> scoreGame = new List<string>();
    public List<string> datetime = new List<string>();
    public GameObject semaforverd;
    public GameObject semaforvermell;

    void Start()
    {
        ValueInhale = PlayerPrefs.GetInt("ValueInhaleName");
        //message_start.GetComponent<Renderer>().enabled = true;
        message_end.GetComponent<Renderer>().enabled = false;
        semaforverd.SetActive(true);
        semaforvermell.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "box1" || col.gameObject.name == "box2"|| col.gameObject.name == "box3"|| col.gameObject.name == "box4"|| col.gameObject.name == "box5"|| col.gameObject.name == "box6"|| col.gameObject.name == "box7"|| col.gameObject.name == "box8"|| col.gameObject.name == "box9" || col.gameObject.name == "box10")
        {
        audioSource.Play();
        colision_up = true;
        colision_down = false;
        breathings_number++; 
        breathings_number_text.text = breathings_number.ToString();
        Destroy(col.gameObject);
        semaforverd.SetActive(false);
        semaforvermell.SetActive(true);
    	}

       if (col.gameObject.name == "rock1" || col.gameObject.name == "rock2"|| col.gameObject.name == "rock3"|| col.gameObject.name == "rock4"|| col.gameObject.name == "rock5"|| col.gameObject.name == "rock6"|| col.gameObject.name == "rock7"|| col.gameObject.name == "rock8"|| col.gameObject.name == "rock9")
        {
        colision_up = false;
        colision_down = true;
        Destroy(col.gameObject); 
        semaforverd.SetActive(true);
        semaforvermell.SetActive(false);
       }
       
       if (col.gameObject.name == "map") 
       {
        end=true;
        audioSourceEnd.Play();
        audioSourceEnd.SetScheduledEndTime(AudioSettings.dspTime+(3f-0f));

        // Save Data
        datetime.Add(DateTime.Now.ToString("dd/MM/yy    hh:mm tt"));
        scoreGame.Add(breathings_number.ToString());
        string path = Application.dataPath + "/Scores/Saved_Data_Games.csv";
	    	//StreamWriter writer = new StreamWriter(path);
	    	//writer.WriteLine("userID,datetime,scoreGame1");
	    	for (int i = 0; i < scoreGame.Count; ++i)
	        {
	            using (StreamWriter sw = File.AppendText(path)) {
	                sw.WriteLine("user"+"," + datetime[i] + "," +"Scene1" +","+ scoreGame[i]);
	            }
	            
	        }    
	        //writer.Flush();
	        //writer.Close();
       	}

    }

    void Update()
    {
        Vector3 position = prota.transform.position;
        
        float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));

        if (end == false && colision_up == false && colision_down == true && db<1 && db > (ValueInhale*1.3) ){
            //message_start.GetComponent<Renderer>().enabled = false;
            Invoke("Swim",0);
        }
 
        if (end == false && colision_up == true && colision_down == false){
            Invoke("Down",0);
            
        }

        if (end){
            Invoke("End",0);
        }
    }

    void Swim(){
        if (GameObject.Find("box1") != null)
        {
        Vector3 position = prota.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
        }
        else if (GameObject.Find("box2") != null)
        {
       	Vector3 position = prota.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
        }
        else if (GameObject.Find("box3") != null)
        {
        Vector3 position = prota.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
        }
        else if (GameObject.Find("box4") != null)
        {
        Vector3 position = prota.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
        }
        else if (GameObject.Find("box5") != null)
        {
        Vector3 position = prota.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
        }
        else if (GameObject.Find("box6") != null)
        {
        Vector3 position = prota.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
        }
        else if (GameObject.Find("box7") != null)
        {
        Vector3 position = prota.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
        }
        else if (GameObject.Find("box8") != null)
        {
        Vector3 position = prota.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
        }
        else if (GameObject.Find("box9") != null)
        {
        Vector3 position = prota.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
        }
        else if (GameObject.Find("box10") != null)
        {
        Vector3 position = prota.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		prota.transform.position = position;
        }

    }

    void Down(){
    	StartCoroutine(GamePauser());
        if (colision_down==false && colision_up==true){ //no ha tocat la sorra pero sí la superficie
            if (GameObject.Find("rock1") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock1 = GameObject.Find("rock1").transform.position;
			prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock1.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("rock2") != null)
            {
            Vector3 position = prota.transform.position;
			Vector3 posrock2 = GameObject.Find("rock2").transform.position;
			prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock2.y, Time.deltaTime * 1),position.z);
            
            }
            else if (GameObject.Find("rock3") != null)
            {
            Vector3 position = prota.transform.position;
			Vector3 posrock3 = GameObject.Find("rock3").transform.position;
			prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock3.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("rock4") != null)
            {
            Vector3 position = prota.transform.position;
			Vector3 posrock4 = GameObject.Find("rock4").transform.position;
			prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock4.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("rock5") != null)
            {
            Vector3 position = prota.transform.position;
			Vector3 posrock5 = GameObject.Find("rock5").transform.position;
			prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock5.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("rock6") != null)
            {
            Vector3 position = prota.transform.position;
			Vector3 posrock6 = GameObject.Find("rock6").transform.position;
			prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock6.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("rock7") != null)
            {
            Vector3 position = prota.transform.position;
			Vector3 posrock7 = GameObject.Find("rock7").transform.position;
			prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock7.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("rock8") != null)
            {
            Vector3 position = prota.transform.position;
			Vector3 posrock8 = GameObject.Find("rock8").transform.position;
			prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock8.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("rock9") != null)
            {
            Vector3 position = prota.transform.position;
			Vector3 posrock9 = GameObject.Find("rock9").transform.position;
			prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock9.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("map") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 postresor = GameObject.Find("map").transform.position;
            prota.transform.position = postresor;
            Invoke("End",0.5f);
            }
            
        }
        if (colision_down) { // ha tocat la pedra 
            colision_up=false; // aixi s'invocarà Jump
        }
        
    }

   	public IEnumerator GamePauser(){
	     //Debug.Log ("Inside PauseGame()");
	     float db=10;
	     Time.timeScale = 0;
	     yield return new WaitForSecondsRealtime (2);
	     //Debug.Log("Done with my pause");
	     Time.timeScale = 1;
   	}

    void End(){
        //audioSourceEnd.Play();
        //audioSourceEnd.SetScheduledEndTime(AudioSettings.dspTime+(2f-0f));
        prota.GetComponent<Renderer>().enabled = false;
        prota_end.GetComponent<Renderer>().enabled = true;
        Debug.Log("end!!");
        //message_end.GetComponent<Renderer>().enabled = true;
    }
}
