using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveDisplay : MonoBehaviour
{
    Text waveText;
    SpawnController spawner;

    // Use this for initialization
    void Start()
    {
        this.waveText = GetComponent<Text>();
        spawner = FindObjectOfType<SpawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        int countdown = (int)(spawner.timeBetweenSpawn - spawner.elapsedTime);

        if (spawner.numberSpawned >= spawner.numberEnemyPerWave && countdown > 0)
        {
            this.waveText.text = "New wave in " + countdown.ToString() + " s";
            Debug.Log(this.waveText.text);
        } else if (countdown < 1)
        {
            this.waveText.text = "Beginning of new wave";
        } else
        {
            this.waveText.text = "";
        }
    }
}
