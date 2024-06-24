using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.8f;
    private float speedVertical = 0.5f; 
    private bool flag = true;
    private int count = 240;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.Translate(speed * Time.deltaTime * Vector3.left);
        if (count == 0)
        {
            count = 300;
            if (flag) flag = false;
            else flag = true;
        }

        if (flag == true)
        {
            this.transform.Translate(speedVertical * Time.deltaTime * Vector3.up);
            count--;

        }
        if (flag == false)
        {
            this.transform.Translate(speedVertical * Time.deltaTime * Vector3.down);
            count--;

        }



    }
}
