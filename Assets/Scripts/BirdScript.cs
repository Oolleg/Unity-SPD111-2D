using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.EventSystems;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private bool needClear;
    private int lifeCount;
    private GameObject lifeTemp;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BirdsScript Start");
        rigidBody = GetComponent<Rigidbody2D>();
        score = 0;
        needClear = false;
        lifeCount = 3;
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

            string lifeName = $"Life{lifeCount}";
            if (lifeCount > 1)
            {
                GameObject life = GameObject.FindGameObjectWithTag(lifeName);
                lifeTemp = life;
                lifeTemp.SetActive(false);
                ShowAlert("OOOPS!");
                lifeCount--;

            }
            else if (lifeCount == 1)
            {
                GameObject life = GameObject.FindGameObjectWithTag(lifeName);
                 ShowAlert("Game Over");
            }
        }

        if (other.gameObject.CompareTag("Balloon"))
        {
            
            if (lifeCount >= 1 && lifeCount < 3)
            {
                lifeTemp.SetActive(true);
                lifeCount++;   
            }
               

            Debug.Log("Get Life " + other.gameObject.name + "---"+lifeCount);
            GameObject.Destroy(other.gameObject);
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
        if(alertLabel.text == "Game Over")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }
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
