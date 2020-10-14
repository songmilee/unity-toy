using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int totalItemCnt;
    public int gameStage;
    [SerializeField] private Text totalItems;
    [SerializeField] private Text userItems;

    private void Awake()
    {
        totalItemCnt = GameObject.FindGameObjectsWithTag("Item").Length;
        totalItems.text = "/ " + totalItemCnt;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Scenes/Level" + gameStage);
        }
    }

    public void SetUserItemText(int items)
    {
        userItems.text = items.ToString();
    }
}
