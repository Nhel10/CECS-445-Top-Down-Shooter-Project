using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreboardController : MonoBehaviour
{
    
    Dictionary<string, int> scoreboardData;
    int changeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        setScore("test1", 100);
        setScore("test2", 200);
        setScore("test3", 300);
        setScore("test4", 200);
        //setScore("test5", 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        if(scoreboardData != null)
        {
            return;
        }
        scoreboardData = new Dictionary<string, int>();
    }

    public int getScore(string username)
    {
        Init();
        if (scoreboardData.ContainsKey(username) == false)
        {
            return 0;
        }
        return scoreboardData[username];
    }
    public void setScore(string username, int score)
    {
        Init();
        changeCounter++;
        scoreboardData.Add(username, score);
    }
    public string[] GetPlayerNames()
    {
        Init();
        return scoreboardData.Keys.ToArray();
    }
    public string[] GetPlayerNamesSorted()
    {
        Init();
        return scoreboardData.Keys.OrderByDescending(n => getScore(n)).ToArray();
    }

    public int getChangeCounter()
    {
        return changeCounter;
    }
    /*
    public void saveBoard()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/scores.dat", FileMode.Open);
    }

    [System.Serializable]
    class BoardData : System.Object
    {
        public Dictionary<string, int> boarddata;
    }
    */
}
