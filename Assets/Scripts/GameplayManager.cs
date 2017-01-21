using Steamworks;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public const uint audioDelay = 1;
    public bool smashMode = false;
    public int numberOfPlayers;

    private AudioManager gameAudio;
    private OnScreenButtonManager buttonsManager;

    void Awake()
    {
        gameAudio = GetComponent<AudioManager>();
        buttonsManager = GetComponent<OnScreenButtonManager>();
        buttonsManager.enabled = true;
    }

    void Start()
    {
        gameAudio.PlaySound("HighFive", audioDelay);
        buttonsManager.Init();
        smashMode = false;
    }
    
    void Update()
    {
        
    }

    public void EndGame()
    {
        Debug.Log("Game ended");
        buttonsManager.enabled = false;
        gameAudio.enabled = false;
        // TODO: Call GameManager here to end game
    }
}
