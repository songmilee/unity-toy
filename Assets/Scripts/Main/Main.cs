using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            StartGame();
        });
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
}
