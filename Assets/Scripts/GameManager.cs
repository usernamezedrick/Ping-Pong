using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string levelName;

    // Variables that hold the score values
    public int p1Score;
    public int p2Score;

    // These variables will display the score on screen
    public Text txtT1Score;
    public Text txtT2Score;

    public bool isThereAnyBricks;
    public Text txtMessage;

    // Flag to prevent the message from being displayed multiple times
    private bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (levelName == "Pong")
        {
            txtT1Score.text = p1Score.ToString();
            txtT2Score.text = p2Score.ToString();

            if (!gameEnded)
            {
                if (p1Score >= 3)
                {
                    txtMessage.text = "Player 1 Wins!";
                    EndGame();
                }
                else if (p2Score >= 3)
                {
                    txtMessage.text = "Player 2 Wins!";
                    EndGame();
                }
            }
        }

        if (levelName == "Ricochet")
        {
            if (isThereAnyBricks && !gameEnded)
            {
                txtMessage.text = "You Win!";
                EndGame();
            }
        }
    }

    // Method to handle ending the game
    void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0; // Freeze the game
    }
}
