using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLostScript : MonoBehaviour
{
    public GameObject endGamePanel;
    public Text score;

    public Camera mainCamera;
    public GameObject player;

    public PlayerController PC;
    public Ship S;

    void Start()
    {
        endGamePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameLost();
    }

    void GameLost()
    {
        Debug.Log("Collide");
        StartCoroutine(CameraShake(0.15f, 0.4f));

        endGamePanel.SetActive(true);
        score.text = PC.distanceText.text;

        gameObject.GetComponent<Rigidbody>().Sleep();
        player.GetComponent<Rigidbody>().Sleep();

        PC.enabled = false;
        S.enabled = false;

        Cursor.visible = true;
    }

    IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 pos = mainCamera.transform.localPosition;

        float timer = 0.0f;

        while(timer < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            mainCamera.transform.localPosition = new Vector3(x, y, pos.z);

            timer += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.localPosition = pos;

        yield return new WaitForEndOfFrame();

        Destroy(gameObject);
    }
}