using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Balloon_Movement : MonoBehaviour
{
    public GameObject prota;
    public GameObject message_inhale;
    public GameObject message_relax;
    private int breathings_number;
    public Text breathings_number_text;
    public GameObject message_end;
    public GameObject prota_celebrate;
    private bool cel=false;
    private bool terra=false;
    private bool end=false;
    private bool colision = false;
	public AudioSource audioSource;
	public AudioSource audioSourceEnd;
	private int ValueInhale = -36; //idealment hauria d'agafar-se de Calibration.maxValueInhale


    void Start()
    {
    	prota.GetComponent<Renderer>().enabled = true;
	    message_end.GetComponent<Renderer>().enabled = false;
        prota_celebrate.GetComponent<Renderer>().enabled = false;
    }

  	void OnCollisionEnter2D(Collision2D col)
	{
	   if (col.gameObject.name == "box1" || col.gameObject.name == "box2"|| col.gameObject.name == "box3"|| col.gameObject.name == "box4"|| col.gameObject.name == "box5"|| col.gameObject.name == "box6"|| col.gameObject.name == "box7"|| col.gameObject.name == "box8"|| col.gameObject.name == "box9")
	   {
	   	colision = true;
		breathings_number++; 
		breathings_number_text.text = breathings_number.ToString();
		audioSource.Play();
		Destroy(col.gameObject);
		Debug.Log(breathings_number);
	   }

	   if (end ==false && col.gameObject.name == "barra_cel")
	   {
	    Invoke("Down",0);
	    Debug.Log("no hauria de pujar mes");
	   }

	   if (col.gameObject.name == "barra_terra")
	   {
	    cel=false;
	    terra = true;
	    Debug.Log("no hauria de baixar mes");
	   }
	   

	   if (col.gameObject.name == "last") 
	   {
	   	end=true;
	   }

	}

    void Update()
    {
    	float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));

    	if (end==false) {
    	// Globus cau sempre (lent)
    		Invoke("Down",0);
    		/*
	    	Vector3 position = prota.transform.position; 
	    	position.y = position.y - 0.005f;
	    	position.x = position.x + 0.005f;
	    	prota.transform.position = position;
	    	*/


    	}

    	// Quan inhala -> es mouen més ràpid
    	//if (end == false && Input.GetKeyDown(KeyCode.Space)){ 
    	if (end == false && db<1 && db > (ValueInhale + ValueInhale*0.3) ){
			Invoke("Move",0);
		}

		if (end){
			Invoke("End",0);
		}
	}

	void Move(){
		Vector3 position = prota.transform.position;
		position.y = position.y + 0.2f; //2
		position.x = position.x + 0.1f; //2
		prota.transform.position = position;
	}

	void Down(){
		Vector3 position = prota.transform.position; 
	    position.y = position.y - 0.005f;
	    position.x = position.x + 0.005f;
	    prota.transform.position = position;
	}

	void End(){
		audioSourceEnd.Play();
	   	prota.GetComponent<Renderer>().enabled = false;
	    message_end.GetComponent<Renderer>().enabled = true;
        prota_celebrate.GetComponent<Renderer>().enabled = true;
	}
		
	void ChangeSceneToPirates(){
		SceneManager.LoadScene("Scene_MountainsFlying");  
	}
	

}
