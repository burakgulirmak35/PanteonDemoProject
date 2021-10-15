using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placement : MonoBehaviour
{

    public GameObject Cp;
    public GameObject CheckpointHolder;

    public GameObject[] Players;
    public Transform[] CheckpointPositions;
    public GameObject[] CheckpointForEachPlayer;

    private int totalPlayers;
    private int totalCheckpoints;

    public Text PositionTxt;

    void Start()
    {
        totalPlayers = Players.Length;
        totalCheckpoints = CheckpointHolder.transform.childCount;

        setCheckpoints();
        setPlayerPosition();
    }

    void setCheckpoints()
    {
        CheckpointPositions = new Transform[totalCheckpoints];

        for (int i = 0; i < totalCheckpoints; i++)
        {
            CheckpointPositions[i] = CheckpointHolder.transform.GetChild(i).transform;
        }
        CheckpointForEachPlayer = new GameObject[totalPlayers];

        for (int i = 0; i < totalPlayers; i++)
        {
            CheckpointForEachPlayer[i] = Instantiate(Cp, CheckpointPositions[0].position,CheckpointPositions[0].rotation);
            CheckpointForEachPlayer[i].name = "CP" + i;
            CheckpointForEachPlayer[i].layer = 8 + i;
        }
    }

    void setPlayerPosition()
    {
        for (int i = 0; i < totalPlayers; i++)
        {
            Players[i].GetComponent<PlayerCpManager>().PlayerPosition = i + 1;
            Players[i].GetComponent<PlayerCpManager>().PlayerNumber = i;
        }
    }

    public void PlayerCollectedCp(int playerNumber,int cpNumber)
    {
        CheckpointForEachPlayer[playerNumber].transform.position = CheckpointPositions[cpNumber].transform.position;
        CheckpointForEachPlayer[playerNumber].transform.rotation = CheckpointPositions[cpNumber].transform.rotation;

        comparePositions(playerNumber);
    }

    void comparePositions(int playerNumber)
    {
        if (Players[playerNumber].GetComponent<PlayerCpManager>().PlayerPosition > 1)
        {
            GameObject currentPlayer = Players[playerNumber];
            int currentPlayerPos = currentPlayer.GetComponent<PlayerCpManager>().PlayerPosition;
            int currentPlayerCp = currentPlayer.GetComponent<PlayerCpManager>().cpCrossed;

            GameObject playerInFront = null;
            int playerInFrontPos = 0;
            int playerInFrontCp = 0;

            for (int i = 0; i < totalPlayers; i++)
            {
                if(Players[i].GetComponent<PlayerCpManager>().PlayerPosition == currentPlayerPos - 1)
                {
                    playerInFront = Players[i];
                    playerInFrontCp = playerInFront.GetComponent<PlayerCpManager>().cpCrossed;
                    playerInFrontPos = playerInFront.GetComponent<PlayerCpManager>().PlayerPosition;
                    break;
                }
            }

            if (currentPlayerCp > playerInFrontCp)
            {
                currentPlayer.GetComponent<PlayerCpManager>().PlayerPosition = currentPlayerPos - 1;
                playerInFront.GetComponent<PlayerCpManager>().PlayerPosition = playerInFrontPos + 1;
            }
            PositionTxt.text = " " + Players[0].GetComponent<PlayerCpManager>().PlayerPosition + "/" + totalPlayers;
        }
    }
    void Update()
    {
        
    }
}
