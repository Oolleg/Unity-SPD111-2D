using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    [SerializeField]
    GameObject balloonPrefab;

    private float balloonPeriod = 6f;
    private float timeLeft;
    private GameObject ballonObject;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0f)
        {
            timeLeft = balloonPeriod;
            BalloonSpawn();
        }
    }

    private void BalloonSpawn()
    {
        if ((ballonObject == null) || !ballonObject.activeSelf)
        {
            var balloon = GameObject.Instantiate(balloonPrefab);
            ballonObject = balloon;
            balloon.transform.position = this.transform.position + Vector3.up * Random.Range(-1f, 1f);
        }
       
    }
}
