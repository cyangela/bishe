using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Microscope_Manager : MonoBehaviour
{
    public static Microscope_Manager _Instance;

    private PlayableDirector playableDirector;

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void Stop()
    {
        playableDirector.Stop();
    }
    public void Play()
    {
        playableDirector.Play();
    }
}
