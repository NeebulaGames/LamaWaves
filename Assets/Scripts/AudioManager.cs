using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

struct AudioStage
{
    public int time;
    public bool smash;

    internal AudioStage(int time, bool smash)
    {
        this.time = time;
        this.smash = smash;
    }
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private GameplayManager gameplay;
    private AudioSource source;
    private Queue<AudioStage> audioStages = new Queue<AudioStage>(0);
    private float delay = 0f;

    void Awake()
    {
        gameplay = GetComponent<GameplayManager>();
        source = GetComponent<AudioSource>();
        source.loop = false;
    }

    void Update()
    {
        if (delay > 0)
            delay -= Time.deltaTime;
        else
        {
            if (source.clip != null && !source.isPlaying)
                gameplay.EndGame();
            else if (audioStages.Count > 0 && audioStages.Peek().time <= (int) source.time)
            {
                AudioStage stage = audioStages.Dequeue();
                gameplay.smashMode = stage.smash;
                Debug.Log("Changed smash: " + gameplay.smashMode);
            }
        }
    }

    public void PlaySound(string sound, uint delay)
    {
        this.delay = delay;
        StartCoroutine(playSound(sound, delay));
        // TODO: Load audio stages from file
        createDummyStages();
    }

    public float TimeUntilNextStage()
    {
        return audioStages.Peek().time - source.time;
    }

    IEnumerator playSound(string sound, uint delay)
    {
        string path = "file:///" + Application.streamingAssetsPath + "/" + sound + ".ogg";
        Debug.Log("Playing file: " + path);
        WWW request = new WWW(path);

        yield return request;

        AudioClip clip = request.GetAudioClip(false, false);
        source.clip = clip;
        source.PlayDelayed(delay);

        yield return null;
    }

    private void createDummyStages()
    {
        audioStages = new Queue<AudioStage>();
        audioStages.Enqueue(new AudioStage(43, true));
        audioStages.Enqueue(new AudioStage(74, false));
        audioStages.Enqueue(new AudioStage(119, true));
        audioStages.Enqueue(new AudioStage(149, false));
        audioStages.Enqueue(new AudioStage(195, true));
        audioStages.Enqueue(new AudioStage(225, false));
    }
}
