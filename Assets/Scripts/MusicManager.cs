using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] songs;
    public int currentSong;

    private AudioSource _audioSource;

    private void Start()
    {
        NextSong();
        PreviousSong();
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySong() // Si vamos a crear un botón con esta función solo puede tener y como mucho un parámetro
    {
        _audioSource.clip = songs[currentSong];
        _audioSource.Play();
    }

    public void NextSong()
    {
        currentSong++;
        
        if(currentSong >= songs.Length)
        {
            currentSong = 0;
        }
        
        PlaySong();
    }

    public void PreviousSong()
    {
        currentSong--;

        if(currentSong < 0)
        {
            currentSong = songs.Length - 1;
        }

        PlaySong();
    }

}
