using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTrigger : MonoBehaviour
{
    public Text txtMessage; //displays message on screen
    public GameObject ball; //reference to ball object
    public void OnCollisionEnter2D(Collision2D actor)
    {
        if (actor.gameObject.CompareTag("Ball"))
        {
            txtMessage.text = "Game Over";
            ball.gameObject.SetActive(false);
        }   
    }
}
