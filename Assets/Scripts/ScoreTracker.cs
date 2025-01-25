using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public GameManager gameManager;
    public Transform ballStartPosition; // Reference to the ball's starting position

    public int whatWall; // This identifies which wall the ball hits

    public void OnCollisionEnter2D(Collision2D actor)
    {
        // Check if the collision is with the ball
        if (actor.gameObject.CompareTag("Ball"))
        {
            switch (whatWall)
            {
                case 1:
                    gameManager.p1Score += 1;
                    break;
                case 2:
                    gameManager.p2Score += 1;
                    break;
            }

            // Reset the ball's position to the starting position
            actor.gameObject.transform.position = ballStartPosition.position;
        }
    }
}
