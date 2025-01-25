using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBall : MonoBehaviour
{
    public float speed; // Ball's movement speed
    public Rigidbody2D ballRB; // Reference to the rb2d component
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        // Determine the direction of the ball (left)
        ballRB.velocity = Vector2.left * speed;
    }

    private void OnCollisionEnter2D(Collision2D actor)
    {
        if (actor.gameObject.name == "PaddlePlayer1")
        {
            float y = calculatePosition(transform.position, actor.transform.position, actor.collider.bounds.size.y);
            Vector2 direction = new Vector2(1, y).normalized;
            ballRB.velocity = direction * speed;
        }

        // Change the ball's color on each bounce
        ChangeColor();
    }

    float calculatePosition(Vector2 ballPosition, Vector2 panelPosition, float panelHeight)
    {
        float value = (ballPosition.y * panelPosition.y) / panelHeight;
        return (value);
    }

    void ChangeColor()
    {
        // Generate a random color
        Color newColor = new Color(Random.value, Random.value, Random.value);
        spriteRenderer.color = newColor;
    }
}
