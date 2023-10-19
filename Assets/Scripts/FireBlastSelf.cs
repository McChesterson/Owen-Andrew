using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlastSelf : MonoBehaviour
{
    public bool hasStarted = false;
    public GameObject player;
    public Vector3 playerPosition;
    public float range;

    void Start()
    {
        player = GameObject.Find("Player");
        playerPosition = player.transform.position;
    }

    void Update()
    {
        if ((playerPosition - gameObject.transform.position).magnitude > range)
        {
            Destroy(gameObject);
        }
    }
}
