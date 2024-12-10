using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour
{
    private bool hasKey = false;
    public GameObject KeyIcon;


    void Start(){
        KeyIcon = GameObject.Find("KeyHolder");
        if (KeyIcon != null){Debug.Log("NoKey");}
        KeyIcon.SetActive(true);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hasKey)
        {
            gameObject.SetActive(false); // Disable the door
            Debug.Log("Door unlocked and disabled!");
        }
    }

    public void PickUpKey()
    {
        hasKey = true;
        Debug.Log("Key picked up!");
        KeyIcon.SetActive(true);
    }
}
