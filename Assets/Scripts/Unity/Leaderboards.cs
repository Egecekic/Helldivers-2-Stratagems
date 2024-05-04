using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UnityEngine;

public class Leaderboards : MonoBehaviour
{
    const string LeaderboardId = "HellDivers";

    string VersionId { get; set; }
    int Offset { get; set; }
    int Limit { get; set; }
    int RangeLimit { get; set; }
    List<string> FriendIds { get; set; }

    public static Leaderboards instance;
    public double LeaderboardScore;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;

    }
    

    public async void deneme()
    {
        var scoreResponse =
            await LeaderboardsService.Instance.GetPlayerScoreAsync(LeaderboardId);
        if (scoreResponse != null)
        {
            LeaderboardScore = scoreResponse.Score;
        }
    }


    public async void AddScore()
    {
        var scoreResponse = await LeaderboardsService.Instance.AddPlayerScoreAsync(LeaderboardId, PointManager.Instance.Point);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }

    public async void GetScores()
    {
        var scoresResponse =
            await LeaderboardsService.Instance.GetScoresAsync(LeaderboardId);
        Debug.Log(JsonConvert.SerializeObject(scoresResponse));
    }

    public async void GetPaginatedScores()
    {
        Offset = 10;
        Limit = 10;
        var scoreResponse =
            await LeaderboardsService.Instance.GetScoresAsync(LeaderboardId, new GetScoresOptions { Offset = Offset, Limit = Limit });
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }

    public async void GetPlayerScore()
    {
        var scoreResponse =
            await LeaderboardsService.Instance.GetPlayerScoreAsync(LeaderboardId);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }

    public async void GetVersionScores()
    {
        var versionScoresResponse =
            await LeaderboardsService.Instance.GetVersionScoresAsync(LeaderboardId, VersionId);
        Debug.Log(JsonConvert.SerializeObject(versionScoresResponse));
    }
}
