﻿using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class SoundGameManager : MonoBehaviour {

    public static int CircleNumber = 3;
    public static int TargetCountMax = 2;
    public GameObject TargetPrefab;

    private GameObject TargetEmitter;
    private GameObject[] Circle = new GameObject[CircleNumber];
    private float Timer = 0.0f;
    public float LimitTimer = 2.0f;

    private int[] TargetLine = new int[CircleNumber];

    void Start () {
        for(int index = 0; index < CircleNumber; index++)
        {
            Circle[index] = GameObject.Find("Circle" + index);
        }

        TargetEmitter = GameObject.Find("TargetEmitter");
    }

    void Update () {
        Timer += Time.deltaTime;
        if(Timer > LimitTimer)
        {
            Timer = 0.0f;
            
            for(int index = 0; index < CircleNumber; index++)
            {
                TargetLine[index] = index;
            }
            TargetLine = ArrayShuffle(TargetLine);


            int targetCount = UnityEngine.Random.Range(1,2 + 1);

            for(int index = 0; index < targetCount; index++)
            {
                int lineNumber = UnityEngine.Random.Range(0, CircleNumber);
                Instantiate(TargetPrefab, new Vector3(Circle[lineNumber].transform.position.x,
                    TargetEmitter.transform.position.y,
                    0.0f),
                    Quaternion.identity);
            }
        }
	}

    private int[] ArrayShuffle(int[] array)
    {
        //Fisher-Yatesアルゴリズムでシャッフルする
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int tmp = array[k];
            array[k] = array[n];
            array[n] = tmp;
        }
        return array;
    }

}