/****
 * Created By: Jacob Sharp
 * Date Created Feb 7, 2022
 * 
 * Last Edited By: Jacob Sharp
 * Date Last Edited: Feb 7, 2022
 * 
 * Description: Tracks and displays the high score
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000; // tracks the high score

    void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore")) // if a high score already exists, get it
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", score); // set high score in PlayerPrefs
    }

    // Update is called once per frame
    void Update()
    {
        Text scoreText = this.GetComponent<Text>(); // display the high score
        scoreText.text = "High Score: " + score;

        if (score > PlayerPrefs.GetInt("HighScore")) // set the new high score in PlayerPrefs if necessary
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
