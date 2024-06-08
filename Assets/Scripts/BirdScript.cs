using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BirdsScript Start");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, 400));
        }
    }
}
