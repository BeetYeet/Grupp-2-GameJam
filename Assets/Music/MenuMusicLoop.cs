using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicLoop : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayMusic()
    {
        //if (_audioSource.isPlaying) return;

        _audioSource.Play();
    }
    
    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
