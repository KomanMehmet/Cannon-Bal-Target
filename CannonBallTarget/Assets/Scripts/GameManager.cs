using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    InputManager inputManager;
    public BallCollision ballColision;
    public UIManager uiManager;
    public BallSpawner ballSpawner;
    public AudioSource ballSound;


    private void Start()
    {
        inputManager = GetComponent<InputManager>();

        

        //ballSpawner.player.gameObject.GetComponentInChildren<MeshRenderer>().material.color = ballSpawner.ball.GetComponent<MeshRenderer>().material.color;
    }

    private void Update()
    {
        inputManager.Player_Rotation();
        //inputManager.Ball_Shot();
        //uiManager.cointText.text = ballColision.coinPoint.ToString();




    }
}
