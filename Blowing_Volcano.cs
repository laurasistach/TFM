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
    	if (Input.GetKeyDown(KeyCode.Space)) { //if db > -30
    		Invoke("Blow",0);
        	
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) { //if db > -30
    		Invoke("Lava1Disappear",0);
        	
		}
		//Invoke("Lava1Disappear",3f);


		
	}

	void Blow(){
		prota_normal.GetComponent<Renderer>().enabled = false;
        prota_blowing.GetComponent<Renderer>().enabled = true;
    	air.GetComponent<Renderer>().enabled = true;

	}

	void Lava1Disappear(){
		lava1.GetComponent<Renderer>().enabled = false;
		message_blow.GetComponent<Renderer>().enabled = false;
		message_relax.GetComponent<Renderer>().enabled = true;
		prota_normal.GetComponent<Renderer>().enabled = true;
        prota_blowing.GetComponent<Renderer>().enabled = false;
    	air.GetComponent<Renderer>().enabled = false;
	}

	
}
