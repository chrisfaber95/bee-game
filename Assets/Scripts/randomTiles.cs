using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class startUpScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        startUpdate();
    }

    public Transform presetFlower;
    public Transform presetBad;
    public Transform presetStone;
    // Use this for initialization
    void startUpdate()
    {
        var size = getGridSize(2);
        Debug.Log(size);
        var length = getGridSize(1);
        var height = size / length;
        var tileList = new ArrayList();
        var p = 0;
        var h = 1;
        while (p <= size)
        {
            var obj = pickRandomSprite();
            tileList.Add(obj);
            if (obj <= 70)
            {
                Instantiate(presetFlower, new Vector3(p * 2.0F, 0, h), Quaternion.identity);
                break;
            }
            if (obj > 70 && obj <= 100)
            {
                Instantiate(presetStone, new Vector3(p * 2.0F, 0, h), Quaternion.identity);
                break;
            }
            if (length * h > height)
            {
                h++;
            }
            p++;
        }

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
        var baseGrid = GameObject.FindGameObjectWithTag("Base").transform;
        if (part == 2)
        {
            size = baseGrid.position.sqrMagnitude;
        }

        else if (part == 1)
        {
            size = baseGrid.position.magnitude;
        }

        return size;
    }


}