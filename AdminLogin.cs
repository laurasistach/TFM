using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  
using System.Text;
using System.IO;


public class AdminLogin : MonoBehaviour
{

    public InputField userNameField;
    public InputField passwordField;
    public Button loginButton;

    public List<string> userID = new List<string>();
    public List<string> passwords = new List<string>();
    public List<string> datetime = new List<string>();
    public List<string> scoreGame1 = new List<string>();
    public List<string> scoreGame2 = new List<string>();
    public List<string> scoreGame3 = new List<string>();
    public List<string> scoreGame4 = new List<string>();
    public List<string> scoreGame5 = new List<string>();

    void Start()
    {
        //Subscribe to onClick event
        loginButton.onClick.AddListener(adminDetails);

    }

    Dictionary<int, string> userData = new Dictionary<int, string>
    {
        {001,"123456" },
        {002,"123456" },
        {003,"123456" }
    };

    public void adminDetails()
    {
        int userName = Convert.ToInt32(userNameField.text);
        string password = passwordField.text;
        string foundPassword;
        if (userData.TryGetValue(userName, out foundPassword) && (foundPassword == password))
        {
            Debug.Log("User authenticated");
            SceneManager.LoadScene("AllScenes");  
            userID.Add(userNameField.text);
            passwords.Add(password);
            datetime.Add(DateTime.Now.ToString("dd/MM/yy    hh:mm tt"));
        }
        else
        {
            Debug.Log("Invalid password");
        }

    }

    void Update(){
    	string path = Application.dataPath + "/Saved_Data.csv";
    	//StreamWriter writer = new StreamWriter(path);
    	//writer.WriteLine("userID,passwords,datetime,scoreGame1,scoreGame2,scoreGame3,scoreGame4,scoreGame5");
    	for (int i = 0; i < userID.Count; ++i)
        {
            //writer.WriteLine(userID[i] + "," + passwords[i] + "," + datetime[i]);
            using (StreamWriter sw = File.AppendText(path)) {
                 sw.WriteLine(userID[i] + "," + passwords[i] + "," + datetime[i]);
            }
        }    
        //writer.Flush();
        //writer.Close();
    }
}