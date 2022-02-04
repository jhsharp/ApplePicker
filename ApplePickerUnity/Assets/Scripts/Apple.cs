/****
 * Created By: Jacob Sharp
 * Date Created Feb 3, 2022
 * 
 * Last Edited By: Jacob Sharp
 * Date Last Edited: Feb 3, 2022
 * 
 * Description: Manages the falling apples
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f; // bottom limit for apple to fall to

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY) // destroy apples if they fall off the screen
        {
            Destroy(this.gameObject);
        }
    }
}
