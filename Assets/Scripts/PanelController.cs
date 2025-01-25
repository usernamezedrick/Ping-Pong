using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public float speed; // Movement speed
    public float boundY; // Y-axis boundary limit

    public Rigidbody2D playerPanel; // Reference to the Rigidbody2D component

    public int wcPlayer; // Identifies the player (1 for Player, 2 for AI)

    public Transform ball; // Reference to the ball's transform
    public Rigidbody2D ballRB; // Reference to the ball's Rigidbody2D

    public float reactionDistance = 5f; // Distance at which the AI starts reacting
    public float resetSpeed = 2f; // Speed at which the AI returns to the center
    public float centerY = 0f; // The Y position where the AI should reset

    private void Start()
    {
        playerPanel = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var panelVelocity = playerPanel.velocity;

        // P1 Controller
        if (wcPlayer == 1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                panelVelocity.y = speed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                panelVelocity.y = -speed;
            }
            else
            {
                panelVelocity.y = 0;
            }
        }

        // AI for P2
        if (wcPlayer == 2)
        {
            if (IsBallApproaching() && IsBallClose())
            {
                // Move towards predicted ball position
                float predictedY = PredictBallY();
                float direction = predictedY - transform.position.y;

                if (Mathf.Abs(direction) > 0.1f)
                {
                    panelVelocity.y = Mathf.Sign(direction) * speed;
                }
                else
                {
                    panelVelocity.y = 0;
                }
            }
            else
            {
                // Reset position towards center when not reacting
                float direction = centerY - transform.position.y;

                if (Mathf.Abs(direction) > 0.1f)
                {
                    panelVelocity.y = Mathf.Sign(direction) * resetSpeed;
                }
                else
                {
                    panelVelocity.y = 0;
                }
            }
        }

        playerPanel.velocity = panelVelocity;

        // This is for the bounds limit
        var panelPos = transform.position;
        if (panelPos.y > boundY)
        {
            panelPos.y = boundY;
        }
        else if (panelPos.y < -boundY)
        {
            panelPos.y = -boundY;
        }
        transform.position = panelPos;
    }

    // Predicts where the ball will land at the AI paddle's X position
    float PredictBallY()
    {
        float timeToReachPaddle = Mathf.Abs((transform.position.x - ball.position.x) / ballRB.velocity.x);
        float predictedY = ball.position.y + ballRB.velocity.y * timeToReachPaddle;
        return Mathf.Clamp(predictedY, -boundY, boundY);
    }

    // Check if the ball is approaching the AI paddle
    bool IsBallApproaching()
    {
        return (ballRB.velocity.x > 0 && wcPlayer == 2) || (ballRB.velocity.x < 0 && wcPlayer == 1);
    }

    // Check if the ball is within the reaction distance
    bool IsBallClose()
    {
        return Mathf.Abs(transform.position.x - ball.position.x) <= reactionDistance;
    }
}
