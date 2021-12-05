
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  


public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;


    void Start(){
            
    }

    public void Update(){
    }

    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6){
            messageText.text = "Password too short!";
            return;
        } 

        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
        messageText.text = "Registered and logged in!";
        SceneManager.LoadScene("game");  
    }

    void OnError(PlayFabError error){
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result){
        messageText.text = "Successful login!";
        SceneManager.LoadScene("game");  
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest {
            Email = emailInput.text,
            TitleId = "E7911"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result){
        messageText.text = "Password reset mail sent!";
    }

    public void SendLeaderboard (int finalScore)
    {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "PlatformScore",
                    Value = finalScore
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("Sucessfull leaderboard sent.");
    }

    public void save_user_data(int finalScore)
    {
        Debug.Log ("Saving player data...");
        UpdateUserDataRequest request = new UpdateUserDataRequest ();
        Dictionary<string, string> playerData = new Dictionary<string, string>();
        playerData.Add("balloons", finalScore.ToString());
        PlayFabClientAPI.UpdateUserData (request, OnAddDataSuccess, OnAddDataError);
        
    }

    void OnAddDataSuccess(UpdateUserDataResult result) 
    {
        Debug.Log("Player data succesfully updated");
    }

    void OnAddDataError(PlayFabError error)
    {
        Debug.Log("Add data error: " + error.Error + " " + error.ErrorMessage);
    }

    
}


