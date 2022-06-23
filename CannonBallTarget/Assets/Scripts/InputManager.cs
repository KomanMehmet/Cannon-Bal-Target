using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    public BallSpawner ballSpawner;


    public Touch touch;

    //[Range(10, 20)]
    [SerializeField] private int rotationSpeed = 10;


    public float xPosition;
    public float yPosition;
    float rotationX = 0;
    float rotationY = 0;    
    float positionPerRotation = 20f;

    public bool isMove = false;


   


    public void Update_RotationX(float input)
    {
        float initialRotaion = rotationX;
        float rotationCount = input / positionPerRotation;
        rotationX += rotationCount;
        rotationX = Mathf.Clamp(rotationX, -50, 0);
        transform.Rotate(rotationX - initialRotaion, 0, 0);
    }

    public void Update_RotationY(float input)
    {
        float initialRotaion = rotationY;
        float rotationCount = input / positionPerRotation;
        rotationY += rotationCount;
        rotationY = Mathf.Clamp(rotationY, -25, 25);
        transform.Rotate(0, rotationY - initialRotaion, 0);
    }

    public void Player_Rotation()
    {
        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ballSpawner.Spawn_Ball();
            }
            

            if (touch.phase == TouchPhase.Moved)
            {
                xPosition = touch.deltaPosition.y * rotationSpeed * Time.deltaTime;
                yPosition = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;

                Update_RotationX(xPosition);
                Update_RotationY(yPosition);
                
            }
                         

            if (touch.phase == TouchPhase.Ended)
            {
                isMove = true;
                
                Debug.Log("Push");

                //ballSpawner.Spawn_Ball();
                ballSpawner.Push_Ball();
            }
        }
    }
}
