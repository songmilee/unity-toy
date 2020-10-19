using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rigid;
    private bool isJump;
    private AudioSource audio;
    [SerializeField] private float jumpPower = 10f;
    [SerializeField] public int itemScore;
    [SerializeField] private Manager manager;
    
    private void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //중복 점프 방지
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true; 
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v);
        
        rigid.AddForce(vec, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
            isJump = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemScore += 1;
            manager.SetUserItemText(itemScore);
            audio.Play();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Goal")
        {
            manager.SetUserItemText(0);
            
            if (itemScore != manager.totalItemCnt)
            {
                //Restart
                SceneManager.LoadScene("Scenes/Level" + manager.gameStage);
            }
            else
            {
                manager.gameStage += 1;

                //Game Clear!
                if (manager.gameStage > 2)
                    SceneManager.LoadScene("Scenes/Main");
                else
                    SceneManager.LoadScene("Scenes/Level" + manager.gameStage);
            }
        }
    }
}
