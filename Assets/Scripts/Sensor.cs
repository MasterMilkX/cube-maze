using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public string sensorName = "Coin";
    private RotateCube rotateCube;

    void Start(){
        rotateCube = GameObject.Find("MainCube").GetComponent<RotateCube>();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Ball"){
            if(sensorName == "coin"){       // uh oh.. this will cause an error and the coin won't be able to be collected!
                Coin();
            }
            else if(sensorName == "Goal"){
                Goal();
            }
            else if(sensorName == "Killzone"){
                Reset();
            }
            
        }
    }

    private void Coin(){
        rotateCube.score += 1;
        rotateCube.scoreText.text = "Keys Left: " + (8-rotateCube.score).ToString();
        Destroy(gameObject);
    }

    private void Goal(){
        rotateCube.Win();
    }

    private void Reset(){
        if(rotateCube.goalOpen){
            Goal();
        }else{
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
