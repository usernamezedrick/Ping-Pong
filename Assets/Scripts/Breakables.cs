using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breakables : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtMessage;

    public static int numberOfBricks = 0; //variable that counts how many bricks are in the scene

    public int brickHP;
    public SpriteRenderer brickSprite;
    public Sprite sDamaged;

    private void Start()
    {
        numberOfBricks++; //counts how many game objects are present in the scene
        brickSprite = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D actor)
    {
        if (actor.gameObject.CompareTag("Ball"))
        {
            brickHP -= 1;
            brickSprite.sprite = sDamaged;
            if (brickHP <= 0)
            {
                Die();
            }
        }        
    }

    public void Die()
    {
        numberOfBricks--;

        if (numberOfBricks <= 0)
        {
            gameManager.isThereAnyBricks = true;
        }
        Destroy(this.gameObject);
    }
}
