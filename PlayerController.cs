using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text speedText;
    public Text distanceText;

    private Rigidbody playerRigidbody;
    public PathCreator PC;

    private Camera mainCamera;
    public GameObject ship;

    public float speed;
    private Vector3 moveForward = new Vector3(1f, 0f, 0f);

    public Vector3 shipOffset;

    public Transform[] transformsOfPlayer = new Transform[8];
    public int transformNumer = 0;

    public Transform[] transformsForShip;

    public float cameraRotate = 0f;

    public float acceleration;

    void Start()
    {
        StartCoroutine(speedUp());
        playerRigidbody = GetComponent<Rigidbody>();
        gameObject.transform.position = transformsOfPlayer[transformNumer].position;
        mainCamera = GetComponentInChildren<Camera>();
        transformsForShip = ship.GetComponent<Ship>().transformsOfShip;
        acceleration = GameObject.FindGameObjectWithTag("MenuSettings").GetComponent<MenuSettings>().speedSliderValue;
    }

    void Update()
    {
        playerRigidbody.velocity = moveForward * speed;

        if(transformNumer > 7)
        {
            transformNumer = 0;
        }

        if(transformNumer < 0)
        {
            transformNumer = 7;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transformNumer += 1;
            cameraRotate -= 45;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transformNumer -= 1;
            cameraRotate += 45;
        }

        mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, Quaternion.Euler(0, 90, cameraRotate), 8f * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, transformsOfPlayer[transformNumer].position, 8f * Time.deltaTime);
        // Zmienic wartosc Y przy "position" w "Positions" na -1

        speedText.text = "Speed: " + speed;
        distanceText.text = "" + Mathf.Round(transform.position.x * 10) / 10f;
    }

    IEnumerator speedUp()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            speed += acceleration;
            speed = Mathf.Round(speed * 100f) / 100f;
        }
    }
}