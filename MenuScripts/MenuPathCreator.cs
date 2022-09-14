using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPathCreator : MonoBehaviour
{
    GameObject player;

    public GameObject parentOfTunnel;

    [SerializeField]
    private GameObject Tunnel;

    private Vector3 pathStartingPoint = new Vector3(0f, 0f, 0f);

    public float frequency;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(createPath());
    }

    IEnumerator createPath()
    {
        while (true)
        {
            yield return new WaitForSeconds(frequency);

            if (pathStartingPoint.z <= player.transform.position.z + 20)
            {
                pathStartingPoint.z += 4;
                GameObject partOfTunnel = Instantiate(Tunnel, pathStartingPoint, Quaternion.Euler(0f, 90f, 0f));
                partOfTunnel.transform.parent = parentOfTunnel.transform;
            }
        }
    }
}