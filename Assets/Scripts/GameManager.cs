using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public AudioClip[] songs; //donde se encuentran todas las canciones
  
    private PlaylistHard hardStyle;
    private PlaylistPopular popular;
    private PlaylistTop50 top50;

    public int currentSong; //indice arrray
    public AudioSource _audioSource;
    public TextMeshProUGUI songText;
    public Button playButton;
    public Button pauseButton;
    
    // Start is called before the first frame update

    private void Awake()
    {
        _audioSource= GetComponent<AudioSource>(); //para obtener la componente de AudioSoure del game manager
        popular = FindObjectOfType<PlaylistPopular>();
        top50 = FindObjectOfType<PlaylistTop50>();
        hardStyle = FindObjectOfType<PlaylistHard>();
    }
    void Start()
    {
        playButton.enabled = false;
        currentSong = 0;
        UpdateSongName();
        _audioSource.clip = songs[currentSong];
        _audioSource.Play();

        
    }

    public void PlaySong() //funcion para reproducir la cancion
    {
        _audioSource.clip = songs[currentSong];
        _audioSource.Play();

        
    }
    
    public void PauseSong()
    {
        _audioSource.Pause();
        playButton.enabled = true;
    }
    public void NextSong()
    {
      currentSong++; //para pasar a la siguiente cancion
      if(currentSong >= songs.Length) //para saber si estamos entre los limites del array
        {
            currentSong = 0; //para volver al inicio si hemos terminado la lista
        }
        PlaySong(); //para reproducir la cancion
        UpdateSongName();
    }

    public void PreviousSong()
    {
        currentSong--; //para pasar a la cancion anterior
        
        if (currentSong <= 0) //para saber si estamos entre los limites del array
        {
            currentSong = songs.Length -1; //para volver al final si hemos terminado la lista
        }
        PlaySong(); //para reproducir la cancion
        UpdateSongName();
    }

    public void RandomSong()
    {
        currentSong = Random.Range(0, songs.Length);
        PlaySong();
        UpdateSongName();
    }

    public void UpdateSongName()
    {
        songText.text = songs[currentSong].name;
    }

    public void RestartSong()
    {
        _audioSource.clip = songs[currentSong];
        _audioSource.Play();
    }

    public void PlaylistTop50()
    {
        top50.PlaySong();
    }

    public void PlaylistPopular()
    {
        popular.PlaySong();
    }
    public void PlaylistHardStyle()
    {
        hardStyle.PlaySong();
    }

    public void PlayButtonFunction()
    {
        playButton.interactable = false;
        pauseButton.interactable = true;
    }
    public void PauseButtonFunction()
    {
        pauseButton.interactable = false;
        playButton.interactable = true;
    }

    public void PlayPauseButtonFunction(bool playButtonHasBeenPressed)
    {
        playButton.interactable = !playButtonHasBeenPressed; //false
        pauseButton.interactable = playButtonHasBeenPressed; //true
    }




}
