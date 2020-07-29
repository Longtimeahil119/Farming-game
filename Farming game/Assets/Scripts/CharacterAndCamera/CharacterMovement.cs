using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 2f;

    CharacterController Player;

    public bool canMove;

    //public Camera cam;

    float moveFB;
    float moveLR;

    void Start()
    {
        canMove = true;
        Player = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove)
        {
            moveFB = Input.GetAxis("FB") * speed;
            moveLR = Input.GetAxis("LR") * speed;

            Vector3 movement = new Vector3(moveLR, 0, moveFB);

            movement = transform.rotation * movement;
            Player.Move(movement * Time.deltaTime);
        }
    }
}
