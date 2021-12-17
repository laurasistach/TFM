using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Diver_Movement : MonoBehaviour
{
    public GameObject diver_swim;
    //public GameObject diver_breath;
    public GameObject diver_happy;
    public GameObject confeti;
    public GameObject message_inhale;
    public GameObject message_relax;
    public GameObject message_end;
    public GameObject mapaobj;
    public int breathings_number;
    public Text breathings_number_text;
    private bool superficie;
    private bool sorra;
    private bool mapa;   
    public AudioSource audioSource;
    public AudioSource audioSourceEnd;
    //private int ValueInhale = -59; //idealment hauria d'agafar-se de Calibration.maxValueInhale
   	private int ValueInhale;


    void Start()
    {
    	ValueInhale = PlayerPrefs.GetInt("ValueInhaleName");
    	Debug.Log("ValueInhale new scene"+ValueInhale);
        //diver_breath.GetComponent<Renderer>().enabled = false;
        //diver_swim.GetComponent<Renderer>().enabled = true;
        message_inhale.GetComponent<Renderer>().enabled = true;
        message_relax.GetComponent<Renderer>().enabled = false;
        message_end.GetComponent<Renderer>().enabled = false;
        diver_happy.GetComponent<Renderer>().enabled = false;
        confeti.GetComponent<Renderer>().enabled = false;
        mapaobj.GetComponent<Renderer>().enabled = true;

    }
	void OnCollisionEnter2D(Collision2D col)
	{
	   if (col.gameObject.name == "barra")
	   {
	    superficie=true;
	    sorra = false;
	    breathings_number++; 
		breathings_number_text.text = breathings_number.ToString();
		audioSource.Play();
	   }
	   if (col.gameObject.name == "barra_sorra")
	   {
	    sorra=true;
	    superficie = false;
	   }
	   if (col.gameObject.name == "map")
	   {
	    mapa=true;
	   }
	}

    void Update()
    {
        float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));
    	Vector3 position = diver_swim.transform.position;
    	// Si encara no ha arribat a la superficie i esta respirant
    	// agafem el 30% maximal effort
    	if (superficie==false && db<1 && db > (ValueInhale + ValueInhale*0.3) ){
		//if (superficie==false && Input.GetKeyDown(KeyCode.Space)){ 
			Invoke("Swim",0);
		}
		if (superficie==true && sorra ==false){ //ha tocat la superficie i NO segueix respirant ////////////////////////////////
			db = 0;
    		Invoke("Breath",0f);
    		Invoke("Down",2); 
		}

		if (breathings_number > 3) {
			Vector3 position_mess = new Vector3(23, -6,0);
			message_inhale.transform.position = position_mess;
			message_relax.transform.position = position_mess;
		}

		if (breathings_number > 6) {
			Vector3 position_mess2 = new Vector3(50, -6,0);
			message_inhale.transform.position = position_mess2;
			message_relax.transform.position = position_mess2;
		}

		if (mapa) {
			Invoke("EndScene1",0);
		}
	}
	
	void Swim(){
		//sorra = false;
		//diver_swim.GetComponent<Renderer>().enabled = true;
		//diver_breath.GetComponent<Renderer>().enabled = false;
		Vector3 position = diver_swim.transform.position;
		position.y = position.y + 0.1f; 
		position.x = position.x + 0.1f; 
		diver_swim.transform.position = position;
	}

	void Breath(){
		message_inhale.GetComponent<Renderer>().enabled = false;
		message_relax.GetComponent<Renderer>().enabled = true;
		//diver_swim.GetComponent<Renderer>().enabled = false;
		//diver_breath.GetComponent<Renderer>().enabled = true;
		Vector3 position = diver_swim.transform.position; //obtenim posicio nedador
		diver_swim.transform.position = position; //quedat quiet
		//diver_breath.transform.position = position; //que el respirador tingui la posicio del nedador
	}

	void Down(){
		//diver_breath.GetComponent<Renderer>().enabled = false; //desapareix respirador
		//diver_swim.GetComponent<Renderer>().enabled = true; //apareix nedador
		Vector3 position = diver_swim.transform.position;

		if (sorra==false && superficie==true){ //no ha tocat la sorra pero sí la superficie
			position.y = position.y - 0.2f; 
			//diver_swim.transform.position = position;
			diver_swim.transform.position = Vector3.Lerp(diver_swim.transform.position, position,Time.deltaTime * 100);

		}
		if (sorra) { // ha tocat la sorra 
			superficie=false; // aixi s'invocarà Swim
			message_inhale.GetComponent<Renderer>().enabled = true;
			message_relax.GetComponent<Renderer>().enabled = false;
		}

	}
	
	void EndScene1(){
		Destroy(GameObject.Find("cranc"));
		Destroy(GameObject.Find("missatge_respira"));
		Destroy(GameObject.Find("missatge_descansa"));
		audioSourceEnd.Play();
        audioSourceEnd.SetScheduledEndTime(AudioSettings.dspTime+(2f-0f));
		//message_inhale.GetComponent<Renderer>().enabled = false;
		mapaobj.GetComponent<Renderer>().enabled = false;
		diver_swim.GetComponent<Renderer>().enabled = false;
		//diver_breath.GetComponent<Renderer>().enabled = false;
		diver_happy.GetComponent<Renderer>().enabled = true;
		message_end.GetComponent<Renderer>().enabled = true;
		confeti.GetComponent<Renderer>().enabled = true;
	}

	

}
