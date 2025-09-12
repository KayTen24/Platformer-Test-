using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public float Timer = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
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

