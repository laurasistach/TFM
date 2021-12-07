using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Veler_Movement : MonoBehaviour
{
    public GameObject prota;
    public GameObject pirate;
    public GameObject message_inhale;
    public GameObject message_relax;
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
    private bool colision = false;
	public AudioSource audioSource;
	public AudioSource audioSourceEnd;
	private int ValueExhale = -36; //idealment hauria d'agafar-se de Calibration.maxValueInhale


    void Start()
    {
    	prota.GetComponent<Renderer>().enabled = true;
    	pirate.GetComponent<Renderer>().enabled = true;
    	bruixolaObj.GetComponent<Renderer>().enabled = true;
	    message_end.GetComponent<Renderer>().enabled = false;
        prota_celebrate.GetComponent<Renderer>().enabled = false;
        confeti.GetComponent<Renderer>().enabled = false;
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

	   if (col.gameObject.name == "bruixola") 
	   {
	   	end=true;
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
    	//if (end == false && Input.GetKeyDown(KeyCode.Space)){ 
    	if (end == false && db<1 && db > (ValueExhale + ValueExhale*0.3) ){
			Invoke("Move",0);
		}

		if (end){
			Invoke("End",0);
		}
	}

	void Move(){
		Vector3 position = prota.transform.position;
		position.x = position.x + 0.2f; //2
		prota.transform.position = position;
	}

	void End(){
		audioSourceEnd.Play();
		bruixolaObj.GetComponent<Renderer>().enabled = false;
	   	prota.GetComponent<Renderer>().enabled = false;
	   	veler.GetComponent<Renderer>().enabled = false;
        mapa.GetComponent<Renderer>().enabled = false;
    	pirate.GetComponent<Renderer>().enabled = false;
    	bomba.GetComponent<Renderer>().enabled = false;
	    message_end.GetComponent<Renderer>().enabled = true;
        prota_celebrate.GetComponent<Renderer>().enabled = true;
        confeti.GetComponent<Renderer>().enabled = true;
	}
		
	void ChangeSceneToPirates(){
		SceneManager.LoadScene("Scene_MountainsFlying");  
	}
	

}
