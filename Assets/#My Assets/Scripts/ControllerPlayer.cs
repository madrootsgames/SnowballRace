using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;

    private void Start()
    {
        player = GameObject.Find("PlayerSphere");        
        rb = player.GetComponent<Rigidbody>();
        //rb = GetComponent<Rigidbody>();
        Material playerMaterial = Resources.Load("Materials/red", typeof(Material)) as Material;
        var renderer = player.GetComponents<MeshRenderer>()[0].material = playerMaterial;
    }

    private void OnMovement(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //Called just before a physics update, physics code goes here
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
}
