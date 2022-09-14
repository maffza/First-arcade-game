using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    PlayerController PC;

    private Rigidbody shipRigidbody;
    private Vector3 moveForward = new Vector3(1f, 0f, 0f);

    public Transform[] transformsOfShip = new Transform[8];

    void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        shipRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        shipRigidbody.velocity = moveForward * PC.speed;

        transform.position = Vector3.MoveTowards(transform.position, transformsOfShip[PC.transformNumer].position, 8f * Time.deltaTime);
    }
}