using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{

    public AudioSource AudioManager;

    private int score = 0;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }


    private int numberOfClips = 5;

    public AudioClip[] audioClips;

    public int lastClip;



    public List<string> mp3FilePaths;




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
        int randomIndex = Random.Range(0, mp3FilePaths.Count - 1);
        string filePath = "file://" + mp3FilePaths[randomIndex]; // Unity requires "file://" prefix for local files
        StartCoroutine(LoadRandomAudioClip(filePath, index));
        mp3FilePaths.RemoveAt(randomIndex);

    }

    void LoadRandomAudioClips()
    {

        // Load a random .mp3 file into each index of the AudioClip array
        for (int i = 0; i < numberOfClips && i < mp3FilePaths.Count; i++)
        {
            string filePath = "file://" + mp3FilePaths[i]; // Unity requires "file://" prefix for local files
            StartCoroutine(LoadRandomAudioClip(filePath, i));
            mp3FilePaths.RemoveAt(i);
        }

    }

    IEnumerator LoadRandomAudioClip(string filePath, int index)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(filePath, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                audioClips[index] = clip;
                Debug.Log("Loaded AudioClip: " + clip.name);
            }
            else
            {
                Debug.LogError("Failed to load AudioClip from path: " + filePath + ", Error: " + www.error);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        AudioManager = GameObject.Find("Audio Clip Player").GetComponent<AudioSource>();
        mp3FilePaths = GameObject.Find("Players").GetComponent<PlayerManager>().mp3FilePaths;
        InitSounds();

    }

}
