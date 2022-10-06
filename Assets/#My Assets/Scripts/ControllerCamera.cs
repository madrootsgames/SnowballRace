using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    public GameObject player;
    private GameObject playerSpawned;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //string nameOfSpawn = player.name + "/PlayerSphere";
        //playerSpawned = GameObject.Find(nameOfSpawn);
        playerSpawned = GameObject.Find("PlayerSphere");
        Debug.Log(playerSpawned);
        offset = transform.position - playerSpawned.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerSpawned.transform.position + offset;
        Debug.Log(playerSpawned.transform.position);
    }
}
