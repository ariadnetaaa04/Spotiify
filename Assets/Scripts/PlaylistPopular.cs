using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaylistPopular : MonoBehaviour
{
    public AudioClip[] popular;
    private GameManager songsScript;

    private void Awake()
    {
        songsScript._audioSource = GetComponent<AudioSource>(); //para obtener la componente de AudioSoure del game manager
    }
    // Start is called before the first frame update
    void Start()
    {
        songsScript= FindObjectOfType<GameManager>();
        songsScript.playButton.enabled = false;
        songsScript.currentSong = 0;
        UpdateSongName();
        songsScript._audioSource.clip = popular[songsScript.currentSong];
        songsScript._audioSource.Play();
    }
    public void PlaySong() //funcion para reproducir la cancion
    {
        songsScript._audioSource.clip = popular[songsScript.currentSong];
        songsScript._audioSource.Play();

    }
    public void PauseSong()
    {
        songsScript._audioSource.Pause();
        songsScript.playButton.enabled = true;
    }
    public void NextSong()
    {
        songsScript.currentSong++; //para pasar a la siguiente cancion
        if (songsScript.currentSong >= popular.Length) //para saber si estamos entre los limites del array
        {
            songsScript.currentSong = 0; //para volver al inicio si hemos terminado la lista
        }
        PlaySong(); //para reproducir la cancion
        UpdateSongName();
    }
    public void PreviousSong()
    {
        songsScript.currentSong--; //para pasar a la cancion anterior

        if (songsScript.currentSong <= 0) //para saber si estamos entre los limites del array
        {
            songsScript.currentSong = popular.Length - 1; //para volver al final si hemos terminado la lista
        }
        PlaySong(); //para reproducir la cancion
        UpdateSongName();
    }
    public void RandomSong()
    {
        songsScript.currentSong = Random.Range(0, popular.Length);
        UpdateSongName();
    }

    public void UpdateSongName()
    {
        songsScript.songText.text = popular[songsScript.currentSong].name;
    }
    public void RestartSong()
    {
        songsScript._audioSource.clip = popular[songsScript.currentSong];
        songsScript._audioSource.Play();
    }

}
