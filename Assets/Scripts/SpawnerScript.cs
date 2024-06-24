using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pipeFrefab;

    private float spawnPeriod = 5f;
    private float timeLeft;

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
            timeLeft = spawnPeriod;
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        var pipe = GameObject.Instantiate(pipeFrefab);
        pipe.transform.position = this.transform.position + Vector3.up * Random.Range(-1f, 1f);

    }
}
