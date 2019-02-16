using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GameState {
    Running,Pause
}
public class GameManager : MonoBehaviour {
    public static GameManager _instance;
    public int score = 0;//分数
    public Text scoreText;
    public GameState gameState = GameState.Running;//status is run by default



    private void Awake() {
        _instance = this;
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "Score:" + score;
    }
    public void transfromGameState() {//change game status
        if (gameState == GameState.Running) {
            PauseGame();
        }
        //if (gameState == GameState.Pause) {
        //    ContinueGame();
        //}
        else {

            ContinueGame();
        }
    }
    public void PauseGame() {
        gameState = GameState.Pause;
        Time.timeScale = 0;//time.delatTime = 0
    }
    public void ContinueGame() {
        gameState = GameState.Running;
        Time.timeScale = 1;
    }
}
