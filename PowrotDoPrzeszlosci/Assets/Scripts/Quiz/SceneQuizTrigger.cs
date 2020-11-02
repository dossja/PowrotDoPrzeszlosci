﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneQuizTrigger : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject questionMenu;
    [SerializeField]
    private GameObject heartsUI;
    [SerializeField]
    private GameObject buttonUI;
    [SerializeField]
    private GameObject joystickUI;
    [SerializeField]
    private Button button;
    private bool entered;
    private GameObject board;

    void Start()
    {
        board = this.gameObject;
        entered = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.gameObject.name == "Player")
        {
            entered = true;
        }
        Debug.Log(entered);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            entered = false;
        }
        Debug.Log(entered);
    }

    public void ButtonPressed()
    {
        if(entered)
        {
            heartsUI.SetActive(false);
            buttonUI.SetActive(false);
            joystickUI.SetActive(false);
            questionMenu.SetActive(true);
            button.gameObject.SetActive(false);
            Time.timeScale = 0.0f;

            Destroy(board);
        }
    }
}
