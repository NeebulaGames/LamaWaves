using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public enum ScoreType
    {
        Miss,
        Bad,
        Ok,
        Good,
        Perfect
    }

    public AudioManager gameAudio;
    public const uint audioDelay = 1;
    public bool smashMode = false;

    private int[] scores = {0, 0, 0, 0};
    private int[] gauge = {0, 0, 0, 0};

    void Start ()
    {
        gameAudio.PlaySound("HighFive", audioDelay);
        smashMode = false;
    }
    
    void Update ()
    {
        
    }

    public void Score(int player, ScoreType type)
    {
        scores[player] = 50 * (int)type;
        gauge[player] = 2 * (int) type - 1;
    }

    public void EndGame()
    {
        Debug.Log("Game ended");
        // TODO: Call GameManager here to end game
    }
}
