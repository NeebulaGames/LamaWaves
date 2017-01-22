using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamaGameManager : MonoBehaviour
{
    MainMenuManager mainMenu;
    private PlayerSelectorManager selector;
    GameplayManager gameplay;

    void Awake()
    {
        mainMenu = GetComponent<MainMenuManager>();
        selector = GetComponent<PlayerSelectorManager>();
        gameplay = GetComponent<GameplayManager>();

        gameplay.enabled = false;
    }

    public void BeginGame()
    {
        mainMenu.enabled = false;

        selector.enabled = true;
    }

    public void StartGame()
    {
        selector.enabled = false;
        gameplay.enabled = true;

        gameplay.StartGame(selector.associations);
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
