/****
 * Created By: Jacob Sharp
 * Date Created Feb 3, 2022
 * 
 * Last Edited By: Jacob Sharp
 * Date Last Edited: Feb 7, 2022
 * 
 * Description: Controls the basket objects
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("SET DYNAMICALLY")]
    public Text scoreText;

    void Start()
    {
        GameObject scoreObject = GameObject.Find("Score Counter"); // find the score object
        scoreText = scoreObject.GetComponent<Text>(); // find the text component of the score object
        scoreText.text = "0"; // set the text
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition; // gets mouse position
        mousePos2D.z = -Camera.main.transform.position.z; // camera's z position determines how far to push out the mouse position
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); // convert the point from 2D space to the game world's 3D space
        this.transform.position = new Vector3(mousePos3D.x, this.transform.position.y, this.transform.position.z);  // move the basket to the x position of the mouse
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Apple") // destroy apples that collide with the basket and increment score
        {
            Destroy(collision.gameObject); // destroy apple

            int score = int.Parse(scoreText.text); // add to score
            score += 100;
            scoreText.text = score.ToString();
        }
    }
}
