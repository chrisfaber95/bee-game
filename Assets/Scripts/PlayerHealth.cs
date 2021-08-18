using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	[SerializeField]
	public int playerStartHealth = 3;
	public static int playerCurrentHealth;
	public bool playerdeath;
	[SerializeField]
	public int ingameHpPressH;
	public BoxCollider playerbox;
	public GameObject player;
    public static bool playerIsHit;


    void Awake () {
		playerdeath = false;
		playerCurrentHealth = playerStartHealth;
		ingameHpPressH = playerStartHealth;
		playerbox = gameObject.GetComponent<BoxCollider> ();
        player = GameObject.Find("Player").GetComponent<GameObject>();
        playerIsHit = GameObject.Find("Player").GetComponent<PlayerController>();
    }

	void Update () {
		if (playerCurrentHealth >= 3) {
			playerCurrentHealth = 3;
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			playerCurrentHealth = ingameHpPressH;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			Debug.Log ("Player health is " + playerCurrentHealth);
		}
		if (playerCurrentHealth <= 0) {
			playerdeath = true;
		}
		if (playerCurrentHealth >= 1) {
			playerdeath = false;
		}
		if (playerdeath == true) {
			playerbox.enabled = false;
            Application.LoadLevel(3);
            playerIsHit = false;
        }		
	}
}