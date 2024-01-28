using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class roundManager : MonoBehaviour
{

    private Sprite[] sprites;
    private AudioClip[] selectedClips;
    private int[] selectedClipsOwners;
    private int selectedClipsi;

    private PlayerManager playerManager;


    private int lastPlayedClip;
    private int itPlayer;


    private int currentRound;
    public int CurrentRound
    {
        get { return currentRound; }
        set
        {

            currentRound = value;


        }
    }


    private int currentPlayer;
    public int CurrentPlayer
    {
        get { return currentPlayer; }
        set
        {

            if (value == itPlayer)
            {

                if(value+1 >= playerManager.players.Length)
                {

                    startFinalPickRound();


                }
                else
                {
                    currentPlayer = value + 1;

                    UpdateSoundButtons(currentPlayer);

                    playerNumDisplay.text = (currentPlayer + 1).ToString();
                }

            }
            else{


                currentPlayer = value;

                UpdateSoundButtons(currentPlayer);

                playerNumDisplay.text = (currentPlayer + 1).ToString();

            }




        }
    }

    private TextMeshProUGUI roundDisplay, itPlayerDisplay;

    //GAME START CANVAS
    public GameObject gameStartCanvas;
    private Button playerUp, playerDown, roundUp, roundDown, submitStart;

    private TextMeshProUGUI playerNumSelector, roundNumSelector;

    //MAIN PICKING CANVAS
    public GameObject soundPickCanvas;
    private Button sound1, sound2, sound3, sound4, sound5, submit;

    private TextMeshProUGUI playerNumDisplay;

    private Image imageComponent;

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
        if (int.Parse(playerNumSelector.text) < 6)
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
        finalPickCanvas.SetActive(false);
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
        roundDisplay = GameObject.Find("RoundNumberValuePicking").GetComponent<TMPro.TextMeshProUGUI>();
        itPlayerDisplay = GameObject.Find("ItPlayerValuePicking").GetComponent<TMPro.TextMeshProUGUI>();

        imageComponent = GameObject.Find("ImagePick").GetComponent<Image>();
        assigneRandomImage();

        if (roundDisplay != null)
        {

            roundDisplay.text = CurrentRound.ToString();

        }

        if (itPlayerDisplay != null)
        {

            itPlayerDisplay.text = (itPlayer + 1).ToString();

        }

        submit.onClick.RemoveAllListeners();
        submit.onClick.AddListener(() => Submit());




        if (playerManager == null)
        {
            playerManager = GameObject.Find("Players").GetComponent<PlayerManager>();
        }

        if (CurrentRound == 1)
        {

            playerManager.initPlayers(int.Parse(playerNumSelector.text));

        }

        selectedClips = new AudioClip[playerManager.players.Length];
        selectedClipsOwners = new int[playerManager.players.Length];
        selectedClipsi = 0;

        CurrentPlayer = 0;

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


        if (CurrentPlayer < playerManager.players.Length - 1)
        {

            selectedClips[selectedClipsi] = GameObject.Find("Audio Clip Player").GetComponent<AudioSource>().clip;
            selectedClipsOwners[selectedClipsi] = currentPlayer;
            selectedClipsi++;
            playerManager.players[currentPlayer].ReplaceSound(playerManager.players[currentPlayer].lastClip);


            CurrentPlayer = CurrentPlayer + 1;



        }
        else
        {

            selectedClips[selectedClipsi] = GameObject.Find("Audio Clip Player").GetComponent<AudioSource>().clip;
            selectedClipsOwners[selectedClipsi] = currentPlayer;
            selectedClipsi++;
            playerManager.players[currentPlayer].ReplaceSound(playerManager.players[currentPlayer].lastClip);
            startFinalPickRound();


        }

    }


    public void startFinalPickRound()
    {

        soundPickCanvas.SetActive(false);
        finalPickCanvas.SetActive(true);

        if (player1 == null)
        {
            player1 = GameObject.Find("FinalSound1").GetComponent<Button>();
        }

        if (player2 == null)
        {
            player2 = GameObject.Find("FinalSound2").GetComponent<Button>();
        }

        if (player3 == null)
        {
            player3 = GameObject.Find("FinalSound3").GetComponent<Button>();
        }

        if (player4 == null)
        {
            player4 = GameObject.Find("FinalSound4").GetComponent<Button>();
        }

        if (player5 == null)
        {
            player5 = GameObject.Find("FinalSound5").GetComponent<Button>();
        }

        if (submitWinner == null)
        {
            submitWinner = GameObject.Find("SubmitWinner").GetComponent<Button>();
        }

        roundDisplay = GameObject.Find("RoundNumberValueFinal").GetComponent<TMPro.TextMeshProUGUI>();
        itPlayerDisplay = GameObject.Find("ItPlayerValueFinal").GetComponent<TMPro.TextMeshProUGUI>();

        Sprite temp = imageComponent.sprite;

        imageComponent = GameObject.Find("ImageFinal").GetComponent<Image>();
        imageComponent.sprite = temp;

        if (roundDisplay != null)
        {

            roundDisplay.text = CurrentRound.ToString();

        }

        if (itPlayerDisplay != null)
        {

            itPlayerDisplay.text = (itPlayer + 1).ToString();

        }

        player1.onClick.RemoveAllListeners();
        player1.onClick.AddListener(() => playFinalSound(0));

        player2.onClick.RemoveAllListeners();
        player2.onClick.AddListener(() => playFinalSound(1));

        if (playerManager.players.Length >= 4)
        {
            player3.onClick.RemoveAllListeners();
            player3.onClick.AddListener(() => playFinalSound(2));
        }
        else { player3.gameObject.SetActive(false); }

        if (playerManager.players.Length >= 5)
        {
            player4.onClick.RemoveAllListeners();
            player4.onClick.AddListener(() => playFinalSound(3));
        }
        else { player4.gameObject.SetActive(false); }

        if (playerManager.players.Length >= 6)
        {
            player5.onClick.RemoveAllListeners();
            player5.onClick.AddListener(() => playFinalSound(4));
        }
        else { player5.gameObject.SetActive(false); }


        submitWinner.onClick.RemoveAllListeners();
        submitWinner.onClick.AddListener(() => submitWinnerEvent());

    }


    public void submitWinnerEvent()
    {

        if (CurrentRound < int.Parse(roundNumSelector.text))
        {

            playerManager.players[selectedClipsOwners[lastPlayedClip]].Score++;

            CurrentRound = CurrentRound + 1;
            itPlayer = (itPlayer + 1) % playerManager.players.Length;
            startSoundPickRounds();


        }
        else
        {

            playerManager.players[selectedClipsOwners[lastPlayedClip]].Score++;

            startWinnerScreen();


        }

    }


    public void playFinalSound(int i)
    {

        AudioSource AudioManager = GameObject.Find("Audio Clip Player").GetComponent<AudioSource>();
        AudioManager.clip = selectedClips[i];
        AudioManager.Play();
        lastPlayedClip = i;

    }


    public PlayerWins playerWins;

    public void startWinnerScreen()
    {
        int i = 0;
        int highestIndex = 0;
        int highestScore = 0;

        finalPickCanvas.SetActive(false);
        winnerCanvas.SetActive(true);
        
        foreach(Player player in playerManager.players){
            if(player.Score > highestScore){
                Debug.Log(player.Score);
                highestScore = player.Score;
                highestIndex = i;
                Debug.Log(highestIndex);
            }
            i++;
        }
        playerWins.displayWinningPlayer(highestIndex);

        AudioClip outro = Resources.Load<AudioClip>("Songs/WhistleOutro");

        GameObject.Find("Audio Clip Player").GetComponent<AudioSource>().clip = outro;
        GameObject.Find("Audio Clip Player").GetComponent<AudioSource>().loop = true;
        GameObject.Find("Audio Clip Player").GetComponent<AudioSource>().Play();

    }

    



    

    public void assigneRandomImage()
    {

        // Check if there are any sprites loaded
        if (sprites.Length > 0)
        {
            // Generate a random index to select a random sprite
            int randomIndex = Random.Range(0, sprites.Length);

            // Set the randomly selected sprite to the UI Image component
            imageComponent.sprite = sprites[randomIndex];
        }
        else
        {
            Debug.LogError("No sprites found in the specified folder: " + Application.dataPath + "/Resources/Images/");
        }

    }


    // Start is called before the first frame update
    void Start()
    {

        startGameStart();
        CurrentRound = 1;
        itPlayer = 0;

        // Load sprites from the specified folder one by one
        sprites = Resources.LoadAll<Sprite>("Images");



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
