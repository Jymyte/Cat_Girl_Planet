using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    [SerializeField]  
    public List<AudioClip> songList;
    public AudioSource audioSource;

    private bool mute = false;
    
    void Awake() {
        MakeSingleton();
        audioSource = GetComponent<AudioSource> ();
    }

    public void PlayMusic(bool play) {
        if (play) {
            if(!audioSource.isPlaying) {
                mute = !play;
                audioSource.Play();
            }
        } else {
            if (audioSource.isPlaying) {
                mute = !play;
                audioSource.Stop();
            }
        }
    }

    public void PlayTrack(string track) {
        for (int i = 0; i < songList.Count; i++) {
            if (songList[i].name.Contains(track)) {
                audioSource.clip = songList[i];
                if (mute == false) {
                    audioSource.Play();
                }
            }
        }
    }

    void MakeSingleton() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
