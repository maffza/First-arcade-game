using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardPos : MonoBehaviour
{
    PlayerController PC;

    private Rigidbody moveRigidbody;
    private Vector3 moveForward = new Vector3(1f, 0f, 0f);

    void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        moveRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveRigidbody.velocity = moveForward * PC.speed;
    }
}