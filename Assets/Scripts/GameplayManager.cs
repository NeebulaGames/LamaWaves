using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    public AudioManager gameAudio;
    public const uint audioDelay = 1;
    public bool smashMode = false;
    public int numberOfPlayers;

    void Start ()
    {
        gameAudio.PlaySound("HighFive", audioDelay);
        smashMode = false;
    }
    
    void Update ()
    {
        
    }

    public void EndGame()
    {
        Debug.Log("Game ended");
        // TODO: Call GameManager here to end game
    }
}
