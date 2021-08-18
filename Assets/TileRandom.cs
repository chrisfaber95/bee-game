using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRandom : MonoBehaviour {
    public GameObject presetFlower;
    public GameObject presetBad;
    public GameObject presetStone;
    public bool initialize = false;
    public Transform baseGrid;
    // Use this for initialization
    void Start () {
        baseGrid = GameObject.FindGameObjectWithTag("Base").transform;
        while (!initialize)
        {
            var size = getGridSize(2);
           // Debug.Log(size);
            var length = getGridSize(1);
            var height = size / length;
            var tileList = new ArrayList();
            var p = baseGrid.transform.position.x;
            var h = 1;
            while (p <= size)
            {
                var obj = pickRandomSprite();
                tileList.Add(obj);
                if (obj <= 70)
                {
                    Instantiate(presetFlower, new Vector3(p, 0, h), Quaternion.identity);
                    break;
                }
                if (obj > 70 && obj <= 100)
                {
                    Instantiate(presetFlower, new Vector3(p, 0, h), Quaternion.identity);
                    break;
                }
                if (length * h > height)
                {
                    h++;
                }
                p++;
            }
            initialize = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
    }


    int pickRandomSprite()
    {
        var newTile = UnityEngine.Random.value;

        var tileNumber = Mathf.Round(newTile * 10);

        return (int)tileNumber;
    }

    // 0 for length, 1 for height, 2 for sqr.
    float getGridSize(int part)
    {
        float size = 0;
        if (part == 2)
        {
            size = baseGrid.position.sqrMagnitude;
            Debug.Log(size + "squared");
        }

        else if (part == 1)
        {
            size = baseGrid.position.magnitude;
            Debug.Log(size + "Length");
        }

        return size;
    }
}
