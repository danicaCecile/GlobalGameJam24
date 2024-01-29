using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{

    public AudioSource AudioManager;

    public int score = 0;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }


    private int numberOfClips = 5;

    public AudioClip[] audioClips;

    public int lastClip;



    public List<AudioClip> mp3Clips;




    public void playAudio(int i)
    {

        AudioManager.clip = audioClips[i];
        AudioManager.Play();
        lastClip = i;

    }

    private void InitSounds()
    {

        audioClips = new AudioClip[numberOfClips];

        LoadRandomAudioClips();

    }


    public void ReplaceSound(int index)
    {
        int randomIndex = Random.Range(0, mp3Clips.Count - 1);

        audioClips[index] = mp3Clips[randomIndex];


    }

    void LoadRandomAudioClips()
    {

        // Load a random .mp3 file into each index of the AudioClip array
        for (int i = 0; i < numberOfClips && i < mp3Clips.Count; i++)
        {

            audioClips[i] = mp3Clips[i];
            mp3Clips.RemoveAt(i);
        }

    }


    // Start is called before the first frame update
    void Start()
    {

        AudioManager = GameObject.Find("Audio Clip Player").GetComponent<AudioSource>();
        mp3Clips = GameObject.Find("Players").GetComponent<PlayerManager>().mp3Clips;
        InitSounds();

    }

}
