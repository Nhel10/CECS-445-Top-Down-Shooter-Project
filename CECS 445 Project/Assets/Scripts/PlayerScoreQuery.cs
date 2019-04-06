using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerScoreQuery : MonoBehaviour
{
    public GameObject scoreEntry;
    ScoreboardController scorectrl;
    int lastChangeCounter;

    // Start is called before the first frame update
    void Start()
    {
        scorectrl = GameObject.FindObjectOfType<ScoreboardController>();
        lastChangeCounter = scorectrl.getChangeCounter();
    }

    // Update is called once per frame
    void Update()
    {

        if(scorectrl.getChangeCounter() == lastChangeCounter)
        {
            return;
        }

        lastChangeCounter = scorectrl.getChangeCounter();

        while(this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }

        string[] names = scorectrl.GetPlayerNamesSorted();

        foreach(string name in names)
        {
            GameObject go = (GameObject)Instantiate(scoreEntry);
            go.transform.SetParent(this.transform);
            go.transform.Find("Username").GetComponent<Text>().text = name;
            go.transform.Find("Score").GetComponent<Text>().text = scorectrl.getScore(name).ToString();
        }
    }
}
