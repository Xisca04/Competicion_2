using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] songs;
    public string[] nameArtist;
    public TextMeshProUGUI songText;
    public TextMeshProUGUI nameArtistText;

    private AudioSource _audioSource;
    private int currentSong;

    private MeshRenderer _meshRenderer;
    
    private void Start()
    {
        UpdateSong();
        UpdateNameArtist();

        StartCoroutine(FadeOut());

        _slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f); // Así se obtiene un valor
        AudioListener.volume = _slider.value;
        
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

    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        return new Color(r, g, b);
    }

    private IEnumerator FadeOut()  // hacerse transparente
    {
        Color color = _meshRenderer.material.color;
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            color = RandomColor();  // Cambio color a cada iteración
            color = new Color(color.r, color.g, color.b, i);
            _meshRenderer.material.color = color;
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Volume Slider

    public Slider _slider;
    public float sliderValue;
    public Image imageMute;

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = sliderValue;
        Mute();
    }

    public void Mute()
    {
        if(sliderValue == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled = false;
        }
    }
}
