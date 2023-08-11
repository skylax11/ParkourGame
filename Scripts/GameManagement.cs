using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
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
    public void SetFps(int index)
    {
        if (index == 0)
        {
            Application.targetFrameRate = 30;
        }
        else if (index == 1)
        {
            Application.targetFrameRate = 60;
        }
        else if (index == 2)
        {
            Application.targetFrameRate = 144;
        }
        else if (index == 3)
        {
            Application.targetFrameRate = 165;
        }
        else if (index == 4)
        {
            Application.targetFrameRate = -1;
        }
    }
    private void Start()
    {
       
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        dropdown.value = 1;
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
