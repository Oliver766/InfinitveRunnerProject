using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;
// script by oliver lancashire
// sid - 1901981
// script reference - coco  - https://www.youtube.com/watch?v=DQWYMfZyMNU
// script reference - coco  - https://www.youtube.com/watch?v=e2RXDso6fWU
public class PlayfabManager : MonoBehaviour
{
    [Header("Array")]
    public PlayerData[] _playerData;
    [Header("References")]
    public Score _score;
    public PlayerController controller;
    public PlayerDeathDescription description;

    private void Start()
    {
        Login(); // loggin to playfab client side
        // will not include loggin page as playfab sign in should be behind the scene
    
    }
    /// <summary>
    /// login function to be able to collect data
    /// </summary>
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginResult, onLoginFailure);
    }
    /// <summary>
    /// if login is successful
    /// </summary>
    /// <param name="result"></param>
    private void OnLoginResult(LoginResult result)
    {
        Debug.Log("Login Sucess");
        GetData();
    }
    /// <summary>
    /// if login failed then  run error report
    /// </summary>
    /// <param name="error"></param>
    private void onLoginFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    /// <summary>
    /// save data function that sent it to text file in playfab
    /// </summary>
    public void SaveData()
    {
        List<Data> playerDatas = new List<Data>();
        foreach(var item in _playerData)
        {
            playerDatas.Add(item.ReturnClass());
        }
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Datas", JsonConvert.SerializeObject(playerDatas) }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, onLoginFailure);
    }
    /// <summary>
    /// send leaderboard to playfab. sends score per playthrough
    /// </summary>
    /// <param name="score"></param>
    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
               new StatisticUpdate{
                   StatisticName = "Score",
                   Value = score
               }
           }

        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, onLoginFailure);
    }
    /// <summary>
    /// gets data saved
    /// </summary>
    public void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, onLoginFailure);
    }

    /// <summary>
    /// put data  in a list once recieve.
    /// </summary>
    /// <param name="result"></param>
    void OnDataRecieved(GetUserDataResult result)
    {
        Debug.Log("Recieved data");
        if (result.Data != null && result.Data.ContainsKey("Datas"))
        {
            List<Data> playerDatas = JsonConvert.DeserializeObject<List<Data>>(result.Data["Datas"].Value);
           
        } 
      
    }

    public void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successfull user data sent");
    }


    public void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult request)
    {
        Debug.Log("SuccessFull leaderBoard sent");
    }


    public void RecordEvent()
    {
        Debug.Log("Event Registered");

        WriteClientPlayerEventRequest request = new WriteClientPlayerEventRequest();
        request.EventName = "PlayerDeath";
        request.CustomTags = new Dictionary<string, string>();
        request.CustomTags.Add("playerScore", _score.score.ToString());
        request.CustomTags.Add("X", controller.x.ToString());
        request.CustomTags.Add("DeathDescription", description.OutputDescription);
        request.CustomTags.Add("Distance", controller.distance.ToString());
        request.CustomTags.Add("RunSpeed", controller.runSpeed.ToString());

        PlayFabClientAPI.WritePlayerEvent(request, OnSuccess, OnError);
    }

    private void OnSuccess(WriteEventResponse obj)
    {
        Debug.Log("Event Recorded");
    }

    private void OnError(PlayFabError obj)
    {
        Debug.Log("Event Failed");
        Debug.Log(obj.ErrorMessage);
    }


}
