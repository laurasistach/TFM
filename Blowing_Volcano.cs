using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blowing_Volcano : MonoBehaviour
{
    public GameObject prota_normal;
    public GameObject prota_blowing;
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
    private float targetTime = 3.0f;


   
    void Start()
    {
        prota_normal.GetComponent<Renderer>().enabled = true;
        prota_blowing.GetComponent<Renderer>().enabled = false;
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

    void Update()
    {

        float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));
        //if(Input.GetKeyDown(KeyCode.Space))
        if(db<1 && db > (ValueExhale + ValueExhale*0.3))
        {
            Invoke("Blow",0);
            targetTime -= Time.deltaTime;
            Debug.Log(targetTime);

            if (targetTime <= 0.0f)
            {
                Invoke("Relax",0);
                if (GameObject.Find("lava1") != null){
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava1"));
                    targetTime = 3;
                    // AFEGIR TEMPS DE DESCANS

                }
                else if (GameObject.Find("lava2")){
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava2"));
                    targetTime = 3;
                    // AFEGIR TEMPS DE DESCANS
                }
                else if (GameObject.Find("lava3")){
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava3"));
                    targetTime = 3;
                }
                else if (GameObject.Find("lava4")){
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava4"));
                }
                else if (GameObject.Find("lava5")){
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava5"));
                }
                else if (GameObject.Find("lava6")){
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava6"));
                }
                else if (GameObject.Find("lava7")){
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava7"));
                }
                else if (GameObject.Find("lava8")){
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava8"));
                }
                else if (GameObject.Find("lava9")){
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava9"));
                }
                else if (GameObject.Find("lava10")){
                    breathings_number++;
                    breathings_number_text.text = breathings_number.ToString();
                    audioSource.Play();
                    Destroy(GameObject.Find("lava10"));
                    Debug.Log("end of the game");
                }
            }
        }
	}

	void Blow(){
		prota_normal.GetComponent<Renderer>().enabled = false;
        prota_blowing.GetComponent<Renderer>().enabled = true;
    	air.GetComponent<Renderer>().enabled = true;
	}

	void Relax(){
		message_blow.GetComponent<Renderer>().enabled = false;
		message_relax.GetComponent<Renderer>().enabled = true;
		prota_normal.GetComponent<Renderer>().enabled = true;
        prota_blowing.GetComponent<Renderer>().enabled = false;
    	air.GetComponent<Renderer>().enabled = false;
	}

    
}
