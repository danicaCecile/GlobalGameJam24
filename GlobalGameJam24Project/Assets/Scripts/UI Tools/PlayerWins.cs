using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWins : MonoBehaviour
{
    public List<GameObject> numbers = new List<GameObject>();

    // Start is called before the first frame update

    void Start()
    {
    }

    public void displayWinningPlayer(int winningPlayerID)
    {
        numbers[winningPlayerID].SetActive(true);
    }
}
