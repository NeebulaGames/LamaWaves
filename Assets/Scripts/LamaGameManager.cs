using System.Collections;
using System.Collections.Generic;
using LamaWaves.Scripts;
using UnityEngine;

public class LamaGameManager : MonoBehaviour
{
    MainMenuManager mainMenu;
    private PlayerSelectorManager selector;
    GameplayManager gameplay;
    private EndMenuManager endMenu;

    void Awake()
    {
        mainMenu = GetComponent<MainMenuManager>();
        selector = GetComponent<PlayerSelectorManager>();
        gameplay = GetComponent<GameplayManager>();
        endMenu = GetComponent<EndMenuManager>();

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
        endMenu.enabled = true;

        PlayerManager pm = gameplay.playerManager;
		endMenu.SetInfo(pm.playerList, pm.scores, pm.misses, pm.hits);
    }

    public void EndScores()
    {
        endMenu.enabled = false;
        mainMenu.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
