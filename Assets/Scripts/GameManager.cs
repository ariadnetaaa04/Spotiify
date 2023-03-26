using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public AudioClip[] songs; //donde se encuentran las canciones
    private int currentSong; //indice arrray
    private AudioSource _audioSource;
    public TextMeshProUGUI songText;
    // Start is called before the first frame update

    private void Awake()
    {
        _audioSource= GetComponent<AudioSource>(); //para obtener la componente de AudioSoure del game manager
    }
    void Start()
    {
        currentSong = 0;
        UpdateSongName();
    }

    public void PlaySong() //funcion para reproducir la cancion
    {
        _audioSource.clip = songs[currentSong];
        _audioSource.Play();
        
    }
    // Update is called once per frame
    void Update()
    {
        
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






}
