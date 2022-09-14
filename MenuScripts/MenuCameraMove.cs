using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraMove : MonoBehaviour
{
    private Rigidbody moveRigidbody;
    private Vector3 moveForward = new Vector3(0f, 0f, 1f);

    void Start()
    {
        moveRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveRigidbody.velocity = moveForward * 10f;
    }
}