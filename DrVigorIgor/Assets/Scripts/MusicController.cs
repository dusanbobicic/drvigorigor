using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    private AudioSource _audioSource;
    private static MusicController instance = null;
    public static MusicController Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        _audioSource = GetComponent<AudioSource>();
        bool music = !PlayerPrefs.HasKey("Music") || PlayerPrefs.GetInt("Music") == 1 ? true : false;
        Debug.Log(music);
        if (music)
        {
            Play();
        }
    }

    public void Play()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
        PlayerPrefs.SetInt("Music", 1);
        
    }

    public void Stop()
    {
        _audioSource.Stop();
        PlayerPrefs.SetInt("Music", 0);
    }
}
