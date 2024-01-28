using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class roundManager : MonoBehaviour
{

    private AudioClip[] selectedClips;

    private PlayerManager playerManager;




    private int currentPlayer;
    public int CurrentPlayer
    {
        get { return currentPlayer; }
        set
        {

            currentPlayer = value;

            UpdateSoundButtons(currentPlayer);

            playerNumDisplay.text = (currentPlayer + 1).ToString();

        }
    }



    //GAME START CANVAS
    public GameObject gameStartCanvas;
    private Button playerUp, playerDown, roundUp, roundDown, submitStart;

    private TextMeshProUGUI playerNumSelector, roundNumSelector;

    //MAIN PICKING CANVAS
    public GameObject soundPickCanvas;
    private Button sound1, sound2, sound3, sound4, sound5, submit;

    private TextMeshProUGUI playerNumDisplay;

    //FINAL PICKING CANVAS
    public GameObject finalPickCanvas;
    private Button player1, player2, player3, player4, player5, submitWinner;

    //END CANVAS
    public GameObject winnerCanvas;
    private Button resetGame;

    public void startGameStart()
    {

        gameStartCanvas.SetActive(true);

        playerNumSelector = GameObject.Find("Player Display").GetComponent<TMPro.TextMeshProUGUI>();
        roundNumSelector = GameObject.Find("Round Display").GetComponent<TMPro.TextMeshProUGUI>();

        if (playerUp == null)
        {
            playerUp = GameObject.Find("PlayerUp").GetComponent<Button>();
        }
        if (playerDown == null)
        {
            playerDown = GameObject.Find("PlayerDown").GetComponent<Button>();
        }
        if (roundUp == null)
        {
            roundUp = GameObject.Find("RoundUp").GetComponent<Button>();
        }
        if (roundDown == null)
        {
            roundDown = GameObject.Find("RoundDown").GetComponent<Button>();
        }

        if (submitStart == null)
        {
            submitStart = GameObject.Find("SubmitStart").GetComponent<Button>();
        }


        playerUp.onClick.RemoveAllListeners();
        playerUp.onClick.AddListener(() => incrementPlayerCount());

        playerDown.onClick.RemoveAllListeners();
        playerDown.onClick.AddListener(() => decrementPlayerCount());

        roundUp.onClick.RemoveAllListeners();
        roundUp.onClick.AddListener(() => incrementRoundCount());

        roundDown.onClick.RemoveAllListeners();
        roundDown.onClick.AddListener(() => decrementRoundCount());


        submitStart.onClick.RemoveAllListeners();
        submitStart.onClick.AddListener(() => startSoundPickRounds());

    }

    public void incrementPlayerCount()
    {
        if (int.Parse(playerNumSelector.text) < 5)
        {
            playerNumSelector.text = (int.Parse(playerNumSelector.text) + 1).ToString();
        }

    }

    public void decrementPlayerCount()
    {
        if (int.Parse(playerNumSelector.text) > 3)
        {
            playerNumSelector.text = (int.Parse(playerNumSelector.text) - 1).ToString();
        }

    }

    public void incrementRoundCount()
    {
        if (int.Parse(roundNumSelector.text) < 15)
        {
            roundNumSelector.text = (int.Parse(roundNumSelector.text) + 1).ToString();
        }

    }

    public void decrementRoundCount()
    {
        if (int.Parse(roundNumSelector.text) > 1)
        {
            roundNumSelector.text = (int.Parse(roundNumSelector.text) - 1).ToString();
        }

    }

    public void startSoundPickRounds()
    {

        gameStartCanvas.SetActive(false);
        soundPickCanvas.SetActive(true);

        ///////////////////////////////////////////
        //MAIN PICK BUTTONS////////////////////////
        ///////////////////////////////////////////
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

        playerNumDisplay = GameObject.Find("PlayerNumberValue").GetComponent<TMPro.TextMeshProUGUI>();



        submit.onClick.AddListener(() => Submit());




        if (playerManager == null)
        {
            playerManager = GameObject.Find("Players").GetComponent<PlayerManager>();
        }


        playerManager.initPlayers(3);

        selectedClips = new AudioClip[playerManager.players.Length];

        CurrentPlayer = 0;

    }

    public void startFinalPickRound()
    {

        soundPickCanvas.SetActive(false);
        finalPickCanvas.SetActive(true);

    }

    public void startWinnerScreen()
    {

        finalPickCanvas.SetActive(false);
        winnerCanvas.SetActive(true);

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


        if(CurrentPlayer < playerManager.players.Length - 1)
        {

            selectedClips[currentPlayer] = GameObject.Find("Audio Clip Player").GetComponent<AudioSource>().clip;
            playerManager.players[currentPlayer].ReplaceSound(playerManager.players[currentPlayer].lastClip);

            CurrentPlayer = CurrentPlayer + 1;

        }
        else
        {

            Debug.Log("GAME END");


        }

    }




    // Start is called before the first frame update
    void Start()
    {

        startGameStart();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
