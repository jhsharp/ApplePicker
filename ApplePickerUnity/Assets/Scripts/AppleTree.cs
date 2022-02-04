/****
 * Created By: Jacob Sharp
 * Date Created Jan 31, 2022
 * 
 * Last Edited By: Jacob Sharp
 * Date Last Edited: Feb 3, 2022
 * 
 * Description: Controls the movement of the apple tree
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    /* Variables */
    [Header("SET IN INSPECTOR")]
    public float speed = 1f; // tree speed
    public float leftAndRightEdge = 10f; // distance where the tree turns around
    public GameObject applePrefab; // prefab for instantiating apples
    public float secondsBetweenAppleDrops = 1f; // time between apple drops
    public float changeToChangeDirection = 0.1f; // chance that the tree switches direction of movement

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f); // Call the DropApple function in 2 seconds
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab); // instantiate a new apple from the prefab
        apple.transform.position = transform.position; // move the new apple to the tree's location
        Invoke("DropApple", secondsBetweenAppleDrops); // create a new apple at the set interval
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position; // records the current position
        pos.x += speed * Time.deltaTime; // adds speed to x position
        transform.position = pos; // set new position

        // Change Direction
        if (Mathf.Abs(pos.x) > leftAndRightEdge) // switch direction at edges
        {
            speed *= -1;
            pos.x = leftAndRightEdge * Mathf.Sign(pos.x); // reset tree to edge
        }
    }

    // FixedUpdate is called on fixed intervals (50 times per second)
    private void FixedUpdate()
    {
        if (Random.value < changeToChangeDirection) // change directions at random
        {
            speed *= -1;
        }
    }
}
