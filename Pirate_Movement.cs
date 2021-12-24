using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate_Movement : MonoBehaviour
{
    public GameObject pirate;
    public GameObject prota;
    public AudioSource audioPirate;
    private int tmax = 10;


    void Start()
    {
       }

    void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.tag == "prota"){
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (col.gameObject.name == "box1"){
		Destroy(col.gameObject);
        audioPirate.Play();
        Invoke("NewBreathing",0.5f);
        }
        if (col.gameObject.name == "box2"){
		Destroy(col.gameObject);
        audioPirate.Play();
        Invoke("NewBreathing2",0.5f);
        }
        if (col.gameObject.name == "box3"){
        Destroy(col.gameObject);
        audioPirate.Play();
        Invoke("NewBreathing3",0.5f);
        }
        if (col.gameObject.name == "box4"){
        Destroy(col.gameObject);
        audioPirate.Play();
        Invoke("NewBreathing4",0.5f);
        }
        if (col.gameObject.name == "box5"){
        Destroy(col.gameObject);
        audioPirate.Play();
        Invoke("NewBreathing5",0.5f);
        }
        if (col.gameObject.name == "box6"){
        Destroy(col.gameObject);
        audioPirate.Play();
        Invoke("NewBreathing6",0.5f);
        }
        if (col.gameObject.name == "box7"){
        Destroy(col.gameObject);
        audioPirate.Play();
        Invoke("NewBreathing7",0.5f);
        }
        if (col.gameObject.name == "box8"){
        Destroy(col.gameObject);
        audioPirate.Play();
        Invoke("NewBreathing8",0.5f);
        }
        if (col.gameObject.name == "box9"){
        Destroy(col.gameObject);
        audioPirate.Play();
        Invoke("NewBreathin9",0.5f);
        }
        if (col.gameObject.name == "bruixola"){
        audioPirate.Play();
        }

	   
	}

    void Update()
    {
    	Vector3 position = pirate.transform.position; 
    	position.x = position.x + 0.01f;
    	pirate.transform.position = position;

        // Lerp cap a box1
    	if (GameObject.Find("box1") != null){
    		Vector3 posbox1 = GameObject.Find("box1").transform.position;
			Vector3 startPosPirate = pirate.transform.position;
    		pirate.transform.position = Vector3.Lerp(startPosPirate, posbox1,Time.deltaTime * 1/tmax);
        }
        // Lerp cap a box2
    	if (GameObject.Find("box1") == null && GameObject.Find("box2") != null){
    		Vector3 posbox2=  GameObject.Find("box2").transform.position;
			Vector3 startPosPirate = pirate.transform.position;
    		pirate.transform.position = Vector3.Lerp(startPosPirate, posbox2,Time.deltaTime * 1/tmax);
    	}
        // Lerp cap a box3
        if (GameObject.Find("box1") == null && GameObject.Find("box2") == null && GameObject.Find("box3") != null){
            Vector3 posbox3 = GameObject.Find("box3").transform.position;
            Vector3 startPosPirate = pirate.transform.position;
            pirate.transform.position = Vector3.Lerp(startPosPirate, posbox3,Time.deltaTime * 1/tmax);
        }
        // Lerp cap a box4
        if (GameObject.Find("box1") == null && GameObject.Find("box2") == null && GameObject.Find("box3") == null && GameObject.Find("box4") != null){
            Vector3 posbox4=  GameObject.Find("box4").transform.position;
            Vector3 startPosPirate = pirate.transform.position;
            pirate.transform.position = Vector3.Lerp(startPosPirate, posbox4,Time.deltaTime * 1/tmax);
        } 
        // Lerp cap a box5
        if (GameObject.Find("box1") == null && GameObject.Find("box2") == null && GameObject.Find("box3") == null && GameObject.Find("box4") == null && GameObject.Find("box5") != null){
            Vector3 posbox5=  GameObject.Find("box5").transform.position;
            Vector3 startPosPirate = pirate.transform.position;
            pirate.transform.position = Vector3.Lerp(startPosPirate, posbox5,Time.deltaTime * 1/tmax);
        }
        // Lerp cap a box6
        if (GameObject.Find("box1") == null && GameObject.Find("box2") == null && GameObject.Find("box3") == null && GameObject.Find("box4") == null && GameObject.Find("box5") == null && GameObject.Find("box6") != null){
            Vector3 posbox6=  GameObject.Find("box6").transform.position;
            Vector3 startPosPirate = pirate.transform.position;
            pirate.transform.position = Vector3.Lerp(startPosPirate, posbox6,Time.deltaTime * 1/tmax);
        }
        // Lerp cap a box7
        if (GameObject.Find("box1") == null && GameObject.Find("box2") == null && GameObject.Find("box3") == null && GameObject.Find("box4") == null && GameObject.Find("box5") == null && GameObject.Find("box6") == null && GameObject.Find("box7") != null){
            Vector3 posbox7=  GameObject.Find("box7").transform.position;
            Vector3 startPosPirate = pirate.transform.position;
            pirate.transform.position = Vector3.Lerp(startPosPirate, posbox7,Time.deltaTime * 1/tmax);
        }
        // Lerp cap a box8
        if (GameObject.Find("box1") == null && GameObject.Find("box2") == null && GameObject.Find("box3") == null && GameObject.Find("box4") != null && GameObject.Find("box5") == null && GameObject.Find("box6") == null && GameObject.Find("box7") == null && GameObject.Find("box8") != null){
            Vector3 posbox8=  GameObject.Find("box8").transform.position;
            Vector3 startPosPirate = pirate.transform.position;
            pirate.transform.position = Vector3.Lerp(startPosPirate, posbox8,Time.deltaTime * 1/tmax);
        }
        // Lerp cap a box9
        if (GameObject.Find("box1") == null && GameObject.Find("box2") == null && GameObject.Find("box3") == null && GameObject.Find("box4") != null && GameObject.Find("box5") == null && GameObject.Find("box6") == null && GameObject.Find("box7") == null && GameObject.Find("box8") == null && GameObject.Find("box9") != null){
            Vector3 posbox9=  GameObject.Find("box9").transform.position;
            Vector3 startPosPirate = pirate.transform.position;
            pirate.transform.position = Vector3.Lerp(startPosPirate, posbox9,Time.deltaTime * 1/tmax);
        }
        
    }

    void NewBreathing(){
        prota.transform.position = new Vector3(-66,6,0);
        pirate.transform.position = new Vector3(-66+5,3,0);
    }
    void NewBreathing2(){
        prota.transform.position = new Vector3(-26,0,0);
        pirate.transform.position = new Vector3(-26+5,0,0);
    }
    void NewBreathing3(){
        prota.transform.position = new Vector3(15,7,0);
        pirate.transform.position = new Vector3(15+5,7,0);
    }
    void NewBreathing4(){
        prota.transform.position = new Vector3(54,3,0);
        pirate.transform.position = new Vector3(54+5,3,0);
    }
    void NewBreathing5(){
        prota.transform.position = new Vector3(94,7,0);
        pirate.transform.position = new Vector3(94+5,7,0);
    }
    void NewBreathing6(){
        prota.transform.position = new Vector3(135,3,0);
        pirate.transform.position = new Vector3(135+5,3,0);
    }
    void NewBreathing7(){
        prota.transform.position = new Vector3(166,6,0);
        pirate.transform.position = new Vector3(166+5,6,0);
    }
    void NewBreathing8(){
        prota.transform.position = new Vector3(203,0,0);
        pirate.transform.position = new Vector3(203+5,0,0);
    }
    void NewBreathing9(){
        prota.transform.position = new Vector3(243,6,0);
        pirate.transform.position = new Vector3(243+5,6,0);
    }
}
