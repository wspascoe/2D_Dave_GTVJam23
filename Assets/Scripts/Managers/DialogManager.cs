using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject startPlayer;
    [SerializeField] GameObject textBox;
    //Need this to be able to find player since they start off Disabled
    //Otherwise it will cause a null reference on Start
    [SerializeField] HealthUI healthUI;

    Dialogue dialogue;

    private void Start()
    {
        player.SetActive(false);
        startPlayer.SetActive(true);
        textBox.SetActive(true);

        dialogue =  textBox.GetComponent<Dialogue>();
        dialogue.OnEnd += SetGameStart;

        dialogue.StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue.DisplayLine();
        }
    }

    private void SetGameStart()
    {
        player.SetActive(true);
        startPlayer.SetActive(false);
        textBox.SetActive(false);
        healthUI.SetupHealth();
    }
}
