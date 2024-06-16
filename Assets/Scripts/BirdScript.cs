using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI passedLabel;
    [SerializeField]
    private GameObject alert;
    [SerializeField]
    private TMPro.TextMeshProUGUI alertLabel;
 
    private int score;
    private Rigidbody2D rigidBody;
    private Rigidbody2D rigidBeak;
    private bool needClear;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BirdsScript Start");
        rigidBody = GetComponent<Rigidbody2D>();
        score = 0;
        needClear = false;
        HideAlert();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, 300) * Time.timeScale);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (alert.activeSelf)
            {
                HideAlert();
            }
            else
            {
                ShowAlert("Paused!");
            }
        }
       

       
       
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("Collision!! " + other.gameObject.name);
            needClear = true;
            ShowAlert("OOOPS!");

        }
      
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pass"))
        {
            Debug.Log("+1");
            score++;
            passedLabel.text = score.ToString("D3");
        }
    }
    private void ShowAlert(string message)
    {
        alert.SetActive(true);
        alertLabel.text = message;
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);

    }
    public void HideAlert()
    {
        alert.SetActive(false);
        Time.timeScale = 1f;
        if (needClear)
        {
            foreach(var pipe in GameObject.FindGameObjectsWithTag("Pass"))
            {
                GameObject.Destroy(pipe);
            }
             needClear = false;
        }
       
    }



}
