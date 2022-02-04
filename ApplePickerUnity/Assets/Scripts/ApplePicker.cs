/****
 * Created By: Jacob Sharp
 * Date Created Feb 3, 2022
 * 
 * Last Edited By: Jacob Sharp
 * Date Last Edited: Feb 3, 2022
 * 
 * Description: Handles game management and object instantiation
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header("SET IN INSPECTOR")]
    public GameObject basketPrefab; // Prefab used to create baskets
    public int numBaskets = 3; // Number of baskets to spawn in
    public float basketBottomY = -14f; // y position of bottom basket
    public float basketSpacingY = 2f; // space between baskets

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject newBasket = Instantiate<GameObject>(basketPrefab); // Create a new basket object
            newBasket.transform.position = new Vector3(0, basketBottomY + basketSpacingY * i, 0); // Set the new basket's y position
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
