using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckWinner : MonoBehaviour
{

    private TicTacToeBoard ticTacToeBoard;

    private void Start()
    {
        ticTacToeBoard = FindObjectOfType<TicTacToeBoard>();
    }




    /*To-Do
     * 
     * Receive a 2d coordinate
     * Check all available coordinates around the original coordinates
     * Save all available coordinates in an array
     * Check those AC for matching tokens
     * If a match is found, head to same direction to see if there is another match and boom found winner
     * !!This works only if the placed token is in the corners!!
     * 
     * Different Idea
     * Have a whole script just to check the whole board
    */


}
