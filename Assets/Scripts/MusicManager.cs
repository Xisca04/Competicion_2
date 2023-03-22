using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] songs;
    public string[] nameArtist;
    public TextMeshProUGUI songText;
    public TextMeshProUGUI nameArtistText;

    private AudioSource _audioSource;
    private int currentSong;
    
    private void Start()
    {
        UpdateSong();
        UpdateNameArtist();
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySong() // Si vamos a crear un bot�n con esta funci�n solo puede tener y como mucho un par�metro
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
        UpdateSong();
        UpdateNameArtist();
    }

    public void PreviousSong()
    {
        currentSong--;

        if(currentSong < 0)
        {
            currentSong = songs.Length - 1;
        }

        PlaySong();
        UpdateSong();
        UpdateNameArtist();
    }

    public void RandomSong()
    {
        currentSong = Random.Range(0, songs.Length);
        PlaySong();
        UpdateSong();
        UpdateNameArtist();
    }

    private void UpdateSong()
    {
        songText.text = songs[currentSong].name;
    }

    private void UpdateNameArtist()
    {
        nameArtistText.text = nameArtist[currentSong];
    }
}
