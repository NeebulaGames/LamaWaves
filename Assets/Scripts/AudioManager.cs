using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] GameplayManager gameplay;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.loop = false;
    }

    void Update()
    {
        if (!source.isPlaying)
            gameplay.EndGame();
    }

    public void PlaySound(string sound, uint delay)
    {
        AudioClip clip = (AudioClip) Resources.Load(sound);
        source.clip = clip;
        source.Play(delay);
    }
}
