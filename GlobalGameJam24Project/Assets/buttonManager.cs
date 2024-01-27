using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{

    private PlayerManager playerManager;

    public Button sound1, sound2, sound3, sound4, sound5, submit;

    private int currentPlayer = 0;
    public int CurrentPlayer
    {
        get { return currentPlayer; }
        set
        {

            currentPlayer = value;

            UpdateSoundButtons(currentPlayer);
        
        }
    }


    private void UpdateSoundButtons(int newPlayer)
    {

        sound1.onClick.AddListener(() => playerManager.players[currentPlayer].playAudio(1));

    }

    // Start is called before the first frame update
    void Start()
    {

        if (sound1 == null)
        {
            sound1 = GameObject.Find("Sound1").GetComponent<Button>();
        }

        if (sound2 == null)
        {
            sound2 = GameObject.Find("Sound2").GetComponent<Button>();
        }

        if (sound3 == null)
        {
            sound3 = GameObject.Find("Sound3").GetComponent<Button>();
        }

        if (sound4 == null)
        {
            sound4 = GameObject.Find("Sound4").GetComponent<Button>();
        }

        if (sound5 == null)
        {
            sound5 = GameObject.Find("Sound5").GetComponent<Button>();
        }

        if (submit == null)
        {
            submit = GameObject.Find("Submit").GetComponent<Button>();
        }

        if (playerManager == null)
        {
            playerManager = GameObject.Find("Players").GetComponent<PlayerManager>();
        }

        CurrentPlayer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
