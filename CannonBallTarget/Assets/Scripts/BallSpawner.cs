using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public InputManager inputManager;

    [SerializeField] GameObject followPosition;



    public Transform defaultSpawnPosition;
    public GameObject[] ballPrefabs;
    public GameObject player;
    public int siranumarasi = 0;
    public  GameObject ball;
    [SerializeField] private float pushForce;


    private void Start()
    {
        
        
    }

    public void Spawn_Ball()
    {
        StartCoroutine(Create_Balls());
        Player_Color_Changer();


        
        /*ball = Instantiate(ballPrefab, defaultSpawnPosition.position , Quaternion.identity);
        
        //player.GetComponentInChildren<MeshRenderer>().material.color = ball.GetComponent<MeshRenderer>().material.color;
        ball.transform.Rotate(inputManager.xPosition, inputManager.yPosition, 0f);*/
    }

    public void Push_Ball()
    {
        ball.GetComponent<Rigidbody>().AddForce(player.transform.forward * pushForce, ForceMode.Impulse);
    }

    public IEnumerator Create_Balls()
    {
        while (inputManager.isMove)
        {
            ball = Instantiate(ballPrefabs[Random.Range(0, ballPrefabs.Length)], 
                defaultSpawnPosition.position, Quaternion.identity);


            inputManager.isMove = false;
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    private void Player_Color_Changer()
    {
        player.GetComponentInChildren<MeshRenderer>().material.color = ball.GetComponent<MeshRenderer>().sharedMaterial.color;
    }

}
