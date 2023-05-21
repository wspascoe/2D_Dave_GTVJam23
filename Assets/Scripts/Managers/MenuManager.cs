using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Canvas newGameCanvas;
    [SerializeField] Canvas startCanvas;
    [SerializeField] private int gameScene;

    private void Start()
    {
        startCanvas.gameObject.SetActive(false);
        newGameCanvas.gameObject.SetActive(true);
    }

    public void ShowStartCanvas()
    {
        startCanvas.gameObject.SetActive(true);
        newGameCanvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
