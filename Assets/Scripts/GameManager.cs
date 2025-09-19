using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public float Timer = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        timerText.text = "Time" + Mathf.Floor(Timer);
        if (Timer <= 0)
        {
            Debug.Log("Game Ended");
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
            //End the Game
        }
        
        {
            scoreText.text = "Score: " + score;
        }
    }

}

