using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool pdeath;
    public static bool playerIsHit;
    private PlayerHealth playerhealth;
    public int playerHoney = 0;
    public float playerScore = 0;
    private ParticleSystem hitParticle;
    private MeshRenderer playerhitbody;
    

    void Start()
    {
        hitParticle = GameObject.Find("Player").GetComponent<ParticleSystem>();
        playerhitbody = GameObject.Find("Player").GetComponent<MeshRenderer>();
        hitParticle.Stop();
        playerIsHit = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (this.tag == "Player" && other.tag == "BadFlower" && !playerIsHit)
        {
            Invoke("GotHit", 0.01f);
            Debug.Log("Invoke got triggered!");

        }
        
    }
    
    void GotHit()
    {
        playerIsHit = true;
        hitParticle.Play();
        Debug.Log("GotHit is now triggered!");
        Invoke("ResetHit", 0.99f);
        playerhitbody.material.color = Color.red;
    }
    void ResetHit()
    {
        hitParticle.Stop();
        playerIsHit = false;
        Debug.Log("Reset!");
        playerhitbody.material.color = Color.white;
    }
}