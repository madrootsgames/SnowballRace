using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : NetworkBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    [Tooltip("Speed of the player")]
    public float speed = 0;

    private void Start()
    {
        if (!IsOwner) return;
        player = GameObject.Find("PlayerSphere");
        rb = player.GetComponent<Rigidbody>();
        //rb = GetComponent<Rigidbody>();
        Material playerMaterial = Resources.Load("Materials/red", typeof(Material)) as Material;
        var renderer = player.GetComponents<MeshRenderer>()[0].material = playerMaterial;
    }

    private void OnMovement(InputValue movementValue)
    {
        if (!IsOwner) return;
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //Called just before a physics update, physics code goes here
    private void FixedUpdate()
    {
        if (!IsOwner) return;
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
}
