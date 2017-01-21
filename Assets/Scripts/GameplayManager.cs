using LamaWaves.Scripts;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public const uint audioDelay = 1;
    public bool smashMode = false;
    public int numberOfPlayers;

    private LamaGameManager gameManager;
    private AudioManager gameAudio;
    private OnScreenButtonManager buttonsManager;
	private PlayerManager playerManager;

    void Awake()
    {
        gameManager = GetComponent<LamaGameManager>();
        gameAudio = GetComponent<AudioManager>();
        buttonsManager = GetComponent<OnScreenButtonManager>();
		playerManager = GetComponent<PlayerManager>();

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
		playerManager.enabled = true;
    }

    public void GameReady()
    {
        buttonsManager.enabled = true;
        buttonsManager.Init();
    }

    public void EndGame()
    {
        Debug.Log("Game ended");
        buttonsManager.enabled = false;
        gameAudio.enabled = false;
		playerManager.enabled = false;
        
        gameManager.EndGame();
    }

    void OnDisable()
    {
        buttonsManager.enabled = false;
        gameAudio.enabled = false;
    }
}
