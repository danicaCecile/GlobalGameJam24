using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class PlayerManager : MonoBehaviour
{

    public Player[] players;

    public List<string> mp3FilePaths = new List<string>();



    public void initPlayers(int numPlayers)
    {

        players = new Player[numPlayers];

        for (int i = 0; i < numPlayers; i++)
        {

            players[i] = gameObject.AddComponent<Player>();

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        // Get all .mp3 file paths from the resources folder
        mp3FilePaths = Directory.GetFiles(Application.dataPath + "/Resources/testMp3s", "*.mp3").ToList();

        // Shuffle the array to randomize the selection
        System.Random rnd = new System.Random();
        mp3FilePaths = mp3FilePaths.OrderBy(x => rnd.Next()).ToList();

        initPlayers(3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
