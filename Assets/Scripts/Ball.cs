using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed; // ball's movement speed
    public Rigidbody2D ballRB; // reference to the rb2d component
    public SpriteRenderer ballRenderer; // reference to the SpriteRenderer component

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        ballRenderer = GetComponent<SpriteRenderer>();

        // Determine the initial direction of the ball
        int rnd = Random.Range(0, 2);
        switch (rnd)
        {
            case 1:
                ballRB.velocity = Vector2.right * speed;
                break;
            default:
                ballRB.velocity = Vector2.left * speed;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D actor)
    {
        // Check if the collision is with PaddlePlayer1
        if (actor.gameObject.name == "PaddlePlayer1")
        {
            float y = calculatePosition(transform.position, actor.transform.position, actor.collider.bounds.size.y);
            Vector2 direction = new Vector2(1, y).normalized;
            ballRB.velocity = direction * speed;
        }

        // Check if the collision is with PaddlePlayer2
        if (actor.gameObject.name == "PaddlePlayer2")
        {
            float y = calculatePosition(transform.position, actor.transform.position, actor.collider.bounds.size.y);
            Vector2 direction = new Vector2(-1, y).normalized;
            ballRB.velocity = direction * speed;
        }

        // Change to a random color
        ballRenderer.color = new Color(Random.value, Random.value, Random.value);

        // Increase the speed of the ball by 0.1 units on each collision
        speed += 0.1f;
    }

    float calculatePosition(Vector2 ballPosition, Vector2 panelPosition, float panelHeight)
    {
        float value = (ballPosition.y * panelPosition.y) / panelHeight;
        return value;
    }
}
