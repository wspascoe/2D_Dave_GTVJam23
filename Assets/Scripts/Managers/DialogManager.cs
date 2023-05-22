using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject textBox;
    //Need this to be able to find player since they start off Disabled
    //Otherwise it will cause a null reference on Start
    [SerializeField] HealthUI healthUI;

    Dialogue dialogue;

    private void Start()
    {
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
        player.MoveEnabled = true;
        textBox.SetActive(false);
    }
}
