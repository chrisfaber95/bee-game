using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beehive : MonoBehaviour {
    public PlayerController player;
    public int Score;
    public Text ShowScore;
    public PlayerHealth deadplayer;
    public Scrollbar hivelive;
    public static int difficulty = 1;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        //hivelive = GameObject.Find("HiveLive").GetComponent<Scrollbar>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player.pdeath == false)
        {
            hivelive.value = hivelive.value - 0.001f;
        }
        if(hivelive.value == 0)
        {
            player.pdeath = true;

            Application.LoadLevel(3);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Beehive")
        {
            Debug.Log("hit");
            
            Score += player.playerHoney;
            player.playerScore = Score;
            updateHiveLive(player.playerHoney);
            player.playerHoney = 0;
            changeScore();

        }
    }
    
    void changeScore()
    {
        ShowScore.text = "Score : " + player.playerScore;
    }

    void updateHiveLive(int honey)
    {
        hivelive.value = hivelive.value + (honey * 0.04f / difficulty);
    }
}
