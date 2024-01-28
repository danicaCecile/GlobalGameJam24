using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titlefadeinaudio : MonoBehaviour
{

    public GameObject title1, title2, title3;
    public AudioClip audio1, audio2, audio3, audio4;
    public AudioSource AudioSource;

    public float fadeInDuration = 2.0f; // Duration of the fade-in effect

    private Image image;
    private Color originalColor;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {

        AudioSource = GameObject.Find("Audio").GetComponent<AudioSource>();

        audio1 = Resources.Load<AudioClip>("testMp3s/Intro1");
        audio2 = Resources.Load<AudioClip>("testMp3s/Intro2");
        audio3 = Resources.Load<AudioClip>("testMp3s/Intro3");
        audio4 = Resources.Load<AudioClip>("testMp3s/Intro4");

        title1 = GameObject.Find("TitleAnimation");
        title2 = GameObject.Find("TitleAnimation2");
        title3 = GameObject.Find("TitleAnimation3");




        fade1();





    }

    private void fade1()
    {
        image = title1.GetComponent<Image>();
        originalColor = image.color;
        startTime = Time.time;


        AudioSource.clip = audio1;
        AudioSource.Play();

        // Fade in the object over the duration of the audio clip
        InvokeRepeating("FadeIn1", 0.0f, 0.05f);

    }

    private void fade2() {

        image = title2.GetComponent<Image>();
        originalColor = image.color;
        startTime = Time.time;


        AudioSource.clip = audio2;
        AudioSource.Play();

        // Fade in the object over the duration of the audio clip
        InvokeRepeating("FadeIn2", 0.0f, 0.05f);

    }

    private void fade3() {

        image = title3.GetComponent<Image>();
        originalColor = image.color;
        startTime = Time.time;


        AudioSource.clip = audio3;
        AudioSource.Play();

        // Fade in the object over the duration of the audio clip
        InvokeRepeating("FadeIn3", 0.0f, 0.05f);
    }
    

    void FadeIn1()
    {
        // Calculate the elapsed time since the start of the fade-in effect
        float elapsedTime = Time.time - startTime;

        // Calculate the alpha value based on the elapsed time and fade-in duration
        float alpha = Mathf.Clamp01(elapsedTime / fadeInDuration);

        // Set the object's material color with the adjusted alpha value
        Color newColor = originalColor;
        newColor.a = alpha;
        image.color = newColor;

        // Stop the fade-in effect when the audio clip finishes playing
        if (!AudioSource.isPlaying && alpha == 1)
        {
            CancelInvoke("FadeIn1");
            fade2();
        }
    }

    void FadeIn2()
    {
        // Calculate the elapsed time since the start of the fade-in effect
        float elapsedTime = Time.time - startTime;

        // Calculate the alpha value based on the elapsed time and fade-in duration
        float alpha = Mathf.Clamp01(elapsedTime / fadeInDuration);

        // Set the object's material color with the adjusted alpha value
        Color newColor = originalColor;
        newColor.a = alpha;
        image.color = newColor;

        // Stop the fade-in effect when the audio clip finishes playing
        if (!AudioSource.isPlaying && alpha == 1)
        {
            CancelInvoke("FadeIn2");
            fade3();
        }
    }

    void FadeIn3()
    {
        // Calculate the elapsed time since the start of the fade-in effect
        float elapsedTime = Time.time - startTime;

        // Calculate the alpha value based on the elapsed time and fade-in duration
        float alpha = Mathf.Clamp01(elapsedTime / fadeInDuration);

        // Set the object's material color with the adjusted alpha value
        Color newColor = originalColor;
        newColor.a = alpha;
        image.color = newColor;

        // Stop the fade-in effect when the audio clip finishes playing
        if (!AudioSource.isPlaying && alpha == 1)
        {
            CancelInvoke("FadeIn3");

            AudioSource.clip = audio4;
            AudioSource.loop = true;
            AudioSource.Play();

        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
