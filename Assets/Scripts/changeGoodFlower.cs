using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGoodFlower : MonoBehaviour {

    public bool changeBad = false;
    public bool hasHoney = false;
    public GameObject Particle;
    public GameObject BadParticle;
    public GameObject Honey;
    public GameObject HoneyClone;
    public float xValue;
    public float zValue;


	// Use this for initialization
	void Start () {
        this.xValue = this.transform.position.x;
        this.zValue = this.transform.position.z;
        InvokeRepeating("changeFlower", 0, 2);
        InvokeRepeating("giveHoney", 0, 2);
    }
	
	// Update is called once per frame
	void Update () {
        
        
	}

    void changeFlower()
    {
        if (!changeBad) { 
            int r = Random.Range(0, 50);
            //Debug.Log(r + this.name);

            if (r > 45)
            {

                this.gameObject.tag = "BadFlower";
                BadParticle = Instantiate(Particle, new Vector3(xValue, 2, zValue), Quaternion.identity);
                BadParticle.transform.localEulerAngles = new Vector3(270, 0, 0);
                changeBad = true;
            }
        }
        else
        {
            int r = Random.Range(0, 50);
            //Debug.Log(r + this.name);

            if (r > 48)
            {

                this.gameObject.tag = "Flower";
                Destroy(this.BadParticle, 0); 
            }
        }
        
    }

    void giveHoney()
    {
        if (!hasHoney)
        {
            int r = Random.Range(0, 50);
            //Debug.Log(r + this.name);

            if (r > 40)
            {

                HoneyClone = Instantiate(Honey, new Vector3(xValue, 1.5f, zValue), Quaternion.identity);

                //Honey.transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.Euler(), 0);
                HoneyClone.transform.localEulerAngles = new Vector3(270, 0, 0);
                hasHoney = true;
            }
        }
    }
}
