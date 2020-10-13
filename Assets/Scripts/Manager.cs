using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int totalItemCnt;
    public int gameStage;

    private void Awake()
    {
        gameStage = 1;
        totalItemCnt = GameObject.FindGameObjectsWithTag("Item").Length;
    }
}
