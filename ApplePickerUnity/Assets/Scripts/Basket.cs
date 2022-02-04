/****
 * Created By: Jacob Sharp
 * Date Created Feb 3, 2022
 * 
 * Last Edited By: Jacob Sharp
 * Date Last Edited: Feb 3, 2022
 * 
 * Description: Controls the basket objects
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition; // Gets mouse position
        mousePos2D.z = -Camera.main.transform.position.z; // Camera's z position determines how far to push out the mouse position
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); // Convert the point from 2D space to the game world's 3D space
        this.transform.position = new Vector3(mousePos3D.x, this.transform.position.y, this.transform.position.z);  // Move the basket to the x position of the mouse
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Apple") // Destroy apples that collide with the basket
        {
            Destroy(collision.gameObject);
        }
    }
}
