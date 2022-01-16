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

    void Start()
    {
        loginButton.onClick.AddListener(adminDetails);

    }

    // This is the dictionary of users ID and passwords
    // if we want to create a new user, we just have to add a new "{XXXX,"XXXXXX" }
    Dictionary<int, string> userData = new Dictionary<int, string>
    {
        {0000,"123456" },{0111,"123456" },{0122,"186571" },{0133,"123456" },{0144,"489371" },{0155,"856473" },
        {0166,"128658" },{0177,"946284" },{0188,"867535" },{0199,"194871" },{0200,"110471" },{0211,"476910" },
        {0222,"857104" },{0233,"573991" },{0244,"993716" },{0255,"374561" },{0266,"129572" },{0277,"956381" }
    };

    public void adminDetails()
    {
        int userName = Convert.ToInt32(userNameField.text);
        string password = passwordField.text;
        string foundPassword;
        if (userData.TryGetValue(userName, out foundPassword) && (foundPassword == password))
        {
            Debug.Log("User authenticated");
            SceneManager.LoadScene("Benvinguda"); // It loads the scene welcoming the user
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
        string path2 = Application.dataPath + "/Scores/Saved_Data_Games.csv";
    	//StreamWriter writer = new StreamWriter(path);
    	for (int i = 0; i < userID.Count; ++i)
        {
            //writer.WriteLine(userID[i] + "," + passwords[i] + "," + datetime[i]);
            using (StreamWriter sw = File.AppendText(path)) {
                 sw.WriteLine(userID[i] + "," + passwords[i] + "," + datetime[i]);
            }
            using (StreamWriter sw = File.AppendText(path2)) {
                 sw.WriteLine(userID[i]+","+datetime[i]+",,,");
            }
        }    
    }
}