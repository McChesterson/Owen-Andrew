using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : MonoBehaviour
{
    public GameObject player;
    public Vector3 fireDirection;

    
    
    void Start()
    {
        
    }
    

    void Update()
    {
        fireDirection = player.GetComponent<PlayerMovement>().playerDirection;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
    }
}
