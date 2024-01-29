using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class PlayerManager : MonoBehaviour
{

    public Player[] players;

    public List<AudioClip> mp3Clips;



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


        mp3Clips = Resources.LoadAll<AudioClip>("testMp3s").ToList();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
