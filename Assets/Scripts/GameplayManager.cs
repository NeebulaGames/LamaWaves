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
        // TODO: Call GameManager here to end game
    }
}
