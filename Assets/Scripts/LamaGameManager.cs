using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamaGameManager : MonoBehaviour
{
    MainMenuManager mainMenu;
    GameplayManager gameplay;

    void Awake()
    {
        mainMenu = GetComponent<MainMenuManager>();
        gameplay = GetComponent<GameplayManager>();

        gameplay.enabled = false;
    }

    public void BeginGame()
    {
        mainMenu.enabled = false;

    }

    public void StartGame()
    {
        gameplay.enabled = true;

        gameplay.StartGame();
    }

    public void EndGame()
    {
        gameplay.enabled = false;

        // TODO: Activate endgame with scores
    }

    public void EndScores()
    {
        mainMenu.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
