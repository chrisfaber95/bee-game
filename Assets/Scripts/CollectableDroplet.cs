using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableDroplet : MonoBehaviour {
	static int playerscore = 0;
	public Text ShowScore;
	public PlayerHealth deadplayer;
    public PlayerController player;

	void Start () {
		deadplayer = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
	}

    void Update()
    {
        if (deadplayer.playerdeath)
        {
            playerscore = 0;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Player" && this.tag == "Collectible")
        {
            Destroy(gameObject);
            player.playerHoney += 10;
        }
    }
   
	
}
