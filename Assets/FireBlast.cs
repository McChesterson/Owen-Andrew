using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerDirection;

    
    void Start()
    {
        
    }
    

    void Update()
    {
        playerDirection = player.GetComponent<PlayerMovement>().movement;
    }
}
