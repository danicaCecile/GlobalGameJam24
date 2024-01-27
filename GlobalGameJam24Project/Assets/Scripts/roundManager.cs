using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class roundManager : MonoBehaviour
{

    private PlayerManager playerManager;

    public Button sound1, sound2, sound3, sound4, sound5, submit;

    private int currentPlayer;
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
        sound1.onClick.RemoveAllListeners();
        sound1.onClick.AddListener(() => playerManager.players[newPlayer].playAudio(0));

        sound2.onClick.RemoveAllListeners();
        sound2.onClick.AddListener(() => playerManager.players[newPlayer].playAudio(1));

        sound3.onClick.RemoveAllListeners();
        sound3.onClick.AddListener(() => playerManager.players[newPlayer].playAudio(2));

        sound4.onClick.RemoveAllListeners();
        sound4.onClick.AddListener(() => playerManager.players[newPlayer].playAudio(3));

        sound5.onClick.RemoveAllListeners();
        sound5.onClick.AddListener(() => playerManager.players[newPlayer].playAudio(4));

    }

    public void Submit()
    {

        if(CurrentPlayer <= playerManager.players.Length - 1)
        {



            CurrentPlayer = CurrentPlayer + 1;

        }
        else
        {

            Debug.Log("GAME OVER");

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        playerManager = GameObject.Find("Players").GetComponent<PlayerManager>();

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

        submit.onClick.AddListener(() => Submit());



        playerManager.initPlayers(3);

        CurrentPlayer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
