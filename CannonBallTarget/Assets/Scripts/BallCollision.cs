using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCollision : MonoBehaviour
{
    GameManager gameManager;

    public bool coint = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (gameObject.transform.tag == other.transform.tag)
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            gameManager.ballSound.Play();
            coint = true;
        }
        
    }
}
