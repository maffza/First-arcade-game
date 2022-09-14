using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    private PlayerController PC;
    GameObject player;
    public GameObject parentOfTunnel;

    [SerializeField]
    private GameObject[] TunnelVariations;

    private Vector3 pathStartingPoint = new Vector3(4f, 5f, 0f);

    public float frequency;

    int randomNumber;

    public byte r = 255;
    public byte g = 0;
    public byte b = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PC = player.GetComponent<PlayerController>();

        StartCoroutine(createPath());
    }

    void Update()
    {

    }

    IEnumerator createPath()
    {
        for (int i = 0; i <= 10; i++)
        {
            pathStartingPoint.x += 4;
            ColorChanger();
            GameObject partOfTunnel = Instantiate(TunnelVariations[0], pathStartingPoint, Quaternion.identity);

            for(int a = 0; a < partOfTunnel.transform.childCount; ++a)
            {
                partOfTunnel.transform.GetChild(a).GetComponent<Renderer>().material.color = new Color32(r, g, b, 255);
            }

            //partOfTunnel.GetComponent<Renderer>().material.color = new Color32(r, g, b, 255);
            partOfTunnel.transform.parent = parentOfTunnel.transform;
        }

        while (true)
        {
            yield return new WaitForSeconds(frequency);

            randomNumber = Mathf.RoundToInt(Random.Range(0, 9));

            if(pathStartingPoint.x <= player.transform.position.x + 100)
            {
                pathStartingPoint.x += 4;
                ColorChanger();
                GameObject partOfTunnel = Instantiate(TunnelVariations[randomNumber], pathStartingPoint, Quaternion.identity);

                for (int a = 0; a < partOfTunnel.transform.childCount; ++a)
                {
                    partOfTunnel.transform.GetChild(a).GetComponent<Renderer>().material.color = new Color32(r, g, b, 255);
                }

                //partOfTunnel.GetComponent<Renderer>().material.color = new Color32(r, g, b, 255);
                partOfTunnel.transform.parent = parentOfTunnel.transform;
            }
        }
    }

    void ColorChanger()
    {
        if (r >= 255 && g == 0)
        {
            r = 255;
            g = 0;
            b += 5;
        }

        if(b >= 255 && g == 0)
        {
            r -= 5;
            g = 0;
            b = 255;
        }

        if(r <= 0 && b == 255)
        {
            r = 0;
            g += 5;
            b = 255;
        }

        if(g >= 255 && r == 0)
        {
            r = 0;
            g = 255;
            b -= 5;
        }

        if(b <= 0 && g == 255)
        {
            r += 5;
            g = 255;
            b = 0;
        }

        if(r >= 255 && b == 0)
        {
            r = 255;
            g -= 5;
            b = 0;
        }



        if(r <= 0)
        {
            r = 0;
        }

        if (g <= 0)
        {
            g = 0;
        }

        if (b <= 0)
        {
            b = 0;
        }
    }
}