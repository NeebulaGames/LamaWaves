using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public const uint audioDelay = 1;
    public bool smashMode = false;
    public int numberOfPlayers;

    private LamaGameManager gameManager;
    private AudioManager gameAudio;
    private OnScreenButtonManager buttonsManager;

    void Awake()
    {
        gameManager = GetComponent<LamaGameManager>();
        gameAudio = GetComponent<AudioManager>();
        buttonsManager = GetComponent<OnScreenButtonManager>();
    }

    void Start()
    {
    }
    
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameAudio.PlaySound("HighFive", audioDelay);
        smashMode = false;
        gameAudio.enabled = true;
    }

    void GameReady()
    {
        buttonsManager.enabled = true;
        buttonsManager.Init();
    }

    public void EndGame()
    {
        Debug.Log("Game ended");
        buttonsManager.enabled = false;
        gameAudio.enabled = false;
        
        gameManager.EndGame();
    }

    void OnDisable()
    {
        buttonsManager.enabled = false;
        gameAudio.enabled = false;
    }
}
