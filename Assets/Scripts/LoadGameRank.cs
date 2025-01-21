using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameRank : MonoBehaviour
{
    public TMPro.TextMeshProUGUI BestPlayerName;

    //static variables for holding best player data
    private static int BestScore;
    private static string BestPlayer;

    private void Awake()
    {
        LoadGameRanks();
    }


    private void SetBestPlayer()
    {
        if (BestPlayer == null && BestScore == 0)
        {
            BestPlayerName.text = "No highscore yet.";
        }
        else
        {
            BestPlayerName.text = $"{BestPlayer} : {BestScore}";
        }

    }


    [System.Serializable]
    class SaveData
    {
        public int HighestScore;
        public string TheBestPlayer;
    }


    public void LoadGameRanks()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            BestPlayer = data.TheBestPlayer;
            BestScore = data.HighestScore;
            SetBestPlayer();
        }
    }

}
