using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateCube : MonoBehaviour
{
    public float speed = 10.0f;
    public int score = 0;
    public bool goalOpen = false;
    private bool gameWon = false;

    public GameObject ball;
    public GameObject goal;
    public Material goalMaterial;

    [Header("UI")]
    public GameObject winText;
    public Text scoreText;
    public Text timeText;

    void Update(){
        if(!gameWon){
            // use WASD to rotate the cube
            if (Input.GetKey(KeyCode.W)){
                transform.Rotate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S)){
                transform.Rotate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A)){
                transform.Rotate(Vector3.down * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D)){
                transform.Rotate(Vector3.up * speed * Time.deltaTime);
            }

            // use Q and E to rotate the cube
            if (Input.GetKey(KeyCode.Q)){
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E)){
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
            }

            // check score
            if(score == 5 && !goalOpen){
                OpenGoal();
            }

            // cheat code to win
            if(Input.GetKeyDown(KeyCode.Alpha0)){
                score = 5;
            }

            UpdateTime(Time.timeSinceLevelLoad);
        }

        // reset game
        if(Input.GetKey(KeyCode.R)){
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        
    }

    public void Win(){
        winText.SetActive(true);
        gameWon = true;
    }

    // open access to the goal window
    public void OpenGoal(){
        goal.GetComponent<Renderer>().material = goalMaterial;
        goal.GetComponent<BoxCollider>().isTrigger = true;
        goalOpen = true;
    }

    // show time in min:sec format
    public void UpdateTime(float time){
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
