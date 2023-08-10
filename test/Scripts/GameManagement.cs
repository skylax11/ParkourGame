using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [SerializeField] AudioClip[] musics;
    [SerializeField] AudioSource audioSource;
    public static GameManagement Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void setVolume(float volume)
    {
        audioSource.volume = volume;
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        InvokeRepeating("setMusics", 1f, 5f);
    }
    public void setMusics()
    {
        if (audioSource.isPlaying) 
        {

        }
        else  // SET NEW MUSIC
        {
            int rand = Random.Range(0, musics.Length);
            audioSource.clip = musics[rand];
            audioSource.Play();
        }

    }
}
