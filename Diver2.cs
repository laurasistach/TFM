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
    private int attempts_number;
    public Text breathings_number_text;
    public AudioSource audioSource;
    public AudioSource audioSourceEnd;
    private int ValueInhale;
    public List<string> scoreGame = new List<string>();
    public List<string> datetime = new List<string>();
    public List<string> attemptsGame = new List<string>();
    public GameObject semaforverd;
    public GameObject semaforvermell;
    public AudioSource audioSourceWrong;
    private float timer = 6f; 
    public Text timer_text;

    void Start()
    {
        ValueInhale = PlayerPrefs.GetInt("ValueInhaleName");
        message_end.GetComponent<Renderer>().enabled = false;
        semaforverd.SetActive(true);
        semaforvermell.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "box1" || col.gameObject.name == "box2"|| col.gameObject.name == "box3"|| col.gameObject.name == "box4"|| col.gameObject.name == "box5"|| col.gameObject.name == "box6"|| col.gameObject.name == "box7"|| col.gameObject.name == "box8"|| col.gameObject.name == "box9" || col.gameObject.name == "box10")
        {
            if (GameObject.Find("wrongrock1") != null) {Destroy(GameObject.Find("wrongrock1"));}
            else if (GameObject.Find("wrongrock2") != null) {Destroy(GameObject.Find("wrongrock2"));}
            else if (GameObject.Find("wrongrock3") != null) {Destroy(GameObject.Find("wrongrock3"));}
            else if (GameObject.Find("wrongrock4") != null) {Destroy(GameObject.Find("wrongrock4"));}
            else if (GameObject.Find("wrongrock5") != null) {Destroy(GameObject.Find("wrongrock5"));}
            else if (GameObject.Find("wrongrock6") != null) {Destroy(GameObject.Find("wrongrock6"));}
            else if (GameObject.Find("wrongrock7") != null) {Destroy(GameObject.Find("wrongrock7"));}
            else if (GameObject.Find("wrongrock8") != null) {Destroy(GameObject.Find("wrongrock8"));}
            else if (GameObject.Find("wrongrock9") != null) {Destroy(GameObject.Find("wrongrock9"));}
            else if (GameObject.Find("wrongrock10") != null) {Destroy(GameObject.Find("wrongrock10"));} 
        timer = 6;
        timer_text.text = Mathf.Round(timer).ToString();
        audioSource.Play();
        colision_up = true;
        colision_down = false;
        breathings_number++; 
        breathings_number_text.text = breathings_number.ToString();
        Destroy(col.gameObject);
        semaforverd.SetActive(false);
        semaforvermell.SetActive(true);
        }
       if (col.gameObject.name == "barra_inf")
        {
        colision_up = false;
        colision_down = true;
        semaforverd.SetActive(true);
        semaforvermell.SetActive(false);
       }

        if (col.gameObject.name == "wrongrock1" || col.gameObject.name == "wrongrock2"|| col.gameObject.name == "wrongrock3"|| col.gameObject.name == "wrongrock4"|| col.gameObject.name == "wrongrock5"|| col.gameObject.name == "wrongrock6"|| col.gameObject.name == "wrongrock7"|| col.gameObject.name == "wrongrock8"|| col.gameObject.name == "wrongrock9" || col.gameObject.name == "wrongrock10")
        {
        attempts_number++; 
        }
       
       if (col.gameObject.name == "map") 
       {
        end=true;
        audioSourceEnd.Play();
        audioSourceEnd.SetScheduledEndTime(AudioSettings.dspTime+(3f-0f));
        // Save Data
        datetime.Add(DateTime.Now.ToString("dd/MM/yy    hh:mm tt"));
        scoreGame.Add(breathings_number.ToString());
        attemptsGame.Add(attempts_number.ToString());
        string path = Application.dataPath + "/Scores/Saved_Data_Games.csv";
            for (int i = 0; i < scoreGame.Count; ++i)
            {
                using (StreamWriter sw = File.AppendText(path)) {
                    sw.WriteLine("user"+"," + datetime[i] + "," +"Scene1" +","+ scoreGame[i]+","+attemptsGame[i]);
                } 
            }    
        }

    }

    void Update()
    {
        Vector3 position = prota.transform.position;
        
        float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));

        if (end == false && colision_up == false && colision_down == true){
            timer -= Time.deltaTime;
            timer_text.text = Mathf.Round(timer).ToString();
            if (db<1 && db > (ValueInhale*1.3)){
                Invoke("Swim",0);
            }
            if (db<1 && db < (ValueInhale*1.3)){ //BUFADA INEFECTIVA
                Invoke("Down2",0.1f);
            }

            if (timer < 0){
                if (GameObject.Find("box1") != null) {Destroy(GameObject.Find("box1"));Destroy(GameObject.Find("wrongrock1"));audioSourceWrong.Play();}
                else if (GameObject.Find("box2") != null) {Destroy(GameObject.Find("box2"));Destroy(GameObject.Find("wrongrock2"));audioSourceWrong.Play();}
                else if (GameObject.Find("box3") != null) {Destroy(GameObject.Find("box3"));Destroy(GameObject.Find("wrongrock3"));audioSourceWrong.Play();}
                else if (GameObject.Find("box4") != null) {Destroy(GameObject.Find("box4"));Destroy(GameObject.Find("wrongrock4"));audioSourceWrong.Play();}
                else if (GameObject.Find("box5") != null) {Destroy(GameObject.Find("box5"));Destroy(GameObject.Find("wrongrock5"));audioSourceWrong.Play();}
                else if (GameObject.Find("box6") != null) {Destroy(GameObject.Find("box6"));Destroy(GameObject.Find("wrongrock6"));audioSourceWrong.Play();}
                else if (GameObject.Find("box7") != null) {Destroy(GameObject.Find("box7"));Destroy(GameObject.Find("wrongrock7"));audioSourceWrong.Play();}
                else if (GameObject.Find("box8") != null) {Destroy(GameObject.Find("box8"));Destroy(GameObject.Find("wrongrock8"));audioSourceWrong.Play();}
                else if (GameObject.Find("box9") != null) {Destroy(GameObject.Find("box9"));Destroy(GameObject.Find("wrongrock9"));audioSourceWrong.Play();}
                else if (GameObject.Find("box10") != null) {Destroy(GameObject.Find("box10"));Destroy(GameObject.Find("wrongrock10"));audioSourceWrong.Play();}
                timer = 6;
            }
        }
 
        if (end == false && colision_up == true && colision_down == false){
            timer = 6;
            Invoke("Down",0);
            
        }

        if (end){
            Invoke("End",0);
            timer = 6;
        }
    }

    void Swim(){
        if (GameObject.Find("box1") != null)
        {
        Vector3 position = prota.transform.position;
        Vector3 posbox1 = GameObject.Find("box1").transform.position;
        prota.transform.position = new Vector3(Mathf.Lerp(position.x, posbox1.x, Time.deltaTime * 2), Mathf.Lerp(position.y, posbox1.y, Time.deltaTime * 2f),position.z);

        }
        else if (GameObject.Find("box2") != null)
        {
        
        Vector3 position = prota.transform.position;
        Vector3 posbox2 = GameObject.Find("box2").transform.position;
        prota.transform.position = new Vector3(Mathf.Lerp(position.x, posbox2.x, Time.deltaTime * 2), Mathf.Lerp(position.y, posbox2.y, Time.deltaTime * 2),position.z);

        }
        else if (GameObject.Find("box3") != null)
        {
        Vector3 position = prota.transform.position;
        Vector3 posbox3 = GameObject.Find("box3").transform.position;
        prota.transform.position = new Vector3(Mathf.Lerp(position.x, posbox3.x, Time.deltaTime * 2), Mathf.Lerp(position.y, posbox3.y, Time.deltaTime * 2),position.z);

        }
        else if (GameObject.Find("box4") != null)
        {
        Vector3 position = prota.transform.position;
        Vector3 posbox4 = GameObject.Find("box4").transform.position;
        prota.transform.position = new Vector3(Mathf.Lerp(position.x, posbox4.x, Time.deltaTime * 2), Mathf.Lerp(position.y, posbox4.y, Time.deltaTime * 2),position.z);

        }
        else if (GameObject.Find("box5") != null)
        {
        Vector3 position = prota.transform.position;
        Vector3 posbox5 = GameObject.Find("box5").transform.position;
        prota.transform.position = new Vector3(Mathf.Lerp(position.x, posbox5.x, Time.deltaTime * 2), Mathf.Lerp(position.y, posbox5.y, Time.deltaTime * 2),position.z);

        }
        else if (GameObject.Find("box6") != null)
        {
        Vector3 position = prota.transform.position;
        Vector3 posbox6 = GameObject.Find("box6").transform.position;
        prota.transform.position = new Vector3(Mathf.Lerp(position.x, posbox6.x, Time.deltaTime * 2), Mathf.Lerp(position.y, posbox6.y, Time.deltaTime * 2),position.z);

        }
        else if (GameObject.Find("box7") != null)
        {
        Vector3 position = prota.transform.position;
        Vector3 posbox7 = GameObject.Find("box7").transform.position;
        prota.transform.position = new Vector3(Mathf.Lerp(position.x, posbox7.x, Time.deltaTime * 2), Mathf.Lerp(position.y, posbox7.y, Time.deltaTime * 2),position.z);

        }
        else if (GameObject.Find("box8") != null)
        {
        Vector3 position = prota.transform.position;
        Vector3 posbox8 = GameObject.Find("box8").transform.position;
        prota.transform.position = new Vector3(Mathf.Lerp(position.x, posbox8.x, Time.deltaTime * 2), Mathf.Lerp(position.y, posbox8.y, Time.deltaTime * 2),position.z);

        }
        else if (GameObject.Find("box9") != null)
        {
        Vector3 position = prota.transform.position;
        Vector3 posbox9 = GameObject.Find("box9").transform.position;
        prota.transform.position = new Vector3(Mathf.Lerp(position.x, posbox9.x, Time.deltaTime * 2), Mathf.Lerp(position.y, posbox9.y, Time.deltaTime * 2),position.z);

        }
        else if (GameObject.Find("box10") != null)
        {
        Vector3 position = prota.transform.position;
        Vector3 posbox10 = GameObject.Find("box10").transform.position;
        prota.transform.position = new Vector3(Mathf.Lerp(position.x, posbox10.x, Time.deltaTime * 2), Mathf.Lerp(position.y, posbox10.y, Time.deltaTime * 2),position.z);
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
            }
            
        }
        if (colision_down) { // ha tocat la pedra 
            colision_up=false; // aixi s'invocarà Jump
        }
        
    }

    public IEnumerator GamePauser(){
        timer = 6;
        float db=10;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime (2);
        Time.timeScale = 1;
    }

    void End(){
        prota.GetComponent<Renderer>().enabled = false;
        prota_end.GetComponent<Renderer>().enabled = true;
    }

    void Down2(){
            if (GameObject.Find("wrongrock1") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock1 = GameObject.Find("wrongrock1").transform.position;
            prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock1.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("wrongrock2") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock2 = GameObject.Find("wrongrock2").transform.position;
            prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock2.y, Time.deltaTime * 1),position.z);
            
            }
            else if (GameObject.Find("wrongrock3") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock3 = GameObject.Find("wrongrock3").transform.position;
            prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock3.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("wrongrock4") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock4 = GameObject.Find("wrongrock4").transform.position;
            prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock4.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("wrongrock5") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock5 = GameObject.Find("rock5").transform.position;
            prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock5.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("wrongrock6") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock6 = GameObject.Find("wrongrock6").transform.position;
            prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock6.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("wrongrock7") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock7 = GameObject.Find("wrongrock7").transform.position;
            prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock7.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("wrongrock8") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock8 = GameObject.Find("wrongrock8").transform.position;
            prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock8.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("wrongrock9") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock9 = GameObject.Find("wrongrock9").transform.position;
            prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock9.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("wrongrock10") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 posrock10 = GameObject.Find("wrongrock10").transform.position;
            prota.transform.position = new Vector3(position.x, Mathf.Lerp(position.y, posrock10.y, Time.deltaTime * 1),position.z);
            }
            else if (GameObject.Find("map") != null)
            {
            Vector3 position = prota.transform.position;
            Vector3 postresor = GameObject.Find("map").transform.position;
            prota.transform.position = postresor;
            }
    }
}



