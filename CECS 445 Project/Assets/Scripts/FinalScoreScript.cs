using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour
{

    public ScoreCounter sc;
    public Text result;
    public PlayerController player;
    public InputField usernameInput;
    string username;
    public ScoreboardController scorectrlFS;
    // Start is called before the first frame update
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        if (player == null)
        {
            sc = GameObject.FindObjectOfType<ScoreCounter>();
            result.text = "Your final score was: " + sc.getScore();
        }
    }
    public void getUsername()
    {
        username = usernameInput.text;
        scorectrlFS.setScore(username, sc.getScore());
    }
}
