/****
 * Created By: Jacob Sharp
 * Date Created Feb 3, 2022
 * 
 * Last Edited By: Jacob Sharp
 * Date Last Edited: Feb 7, 2022
 * 
 * Description: Handles game management and object instantiation
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("SET IN INSPECTOR")]
    public GameObject basketPrefab; // prefab used to create baskets
    public int numBaskets = 3; // number of baskets to spawn in
    public float basketBottomY = -14f; // y position of bottom basket
    public float basketSpacingY = 2f; // space between baskets
    public List<GameObject> basketList; // list of all basket game objects

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>(); // create basket list
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject newBasket = Instantiate<GameObject>(basketPrefab); // create a new basket object
            newBasket.transform.position = new Vector3(0, basketBottomY + basketSpacingY * i, 0); // set the new basket's y position
            basketList.Add(newBasket); // add new basket to list
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleDestroyed() // called when an apple falls off the screen
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple"); // destroy all apples on screen
        foreach (GameObject apple in appleArray)
        {
            Destroy(apple);
        }

        int basketIndex = basketList.Count - 1; // destroy a basket
        GameObject basket = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basket);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene-00");
        }
    }
}
