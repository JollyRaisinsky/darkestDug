using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator doorAnimator;
    private bool isDoorOpen = false;
    private bool isDoorInteractable = false; //Determined by player in range or not

    void Start() {
        doorAnimator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //get into the interactible range
            isDoorInteractable = true;
            Debug.Log("Close enough! Press E key to open/close the door");
        }
    }
    //Update is executed on every frame. Think of it as always doing
    void Update() {
        if(isDoorInteractable == true) {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleDoor();
            }
        }
    }
    //ToggleDoor: Toggle the isDoorOpen flag and inform the animator the new state
    void ToggleDoor() {
        Debug.Log("Toggling the door!");
        isDoorOpen = !isDoorOpen;
        doorAnimator.SetBool("IsOpen", isDoorOpen);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //get into the interactible range
            Debug.Log("Player left the door");
            isDoorInteractable = false;
        }
    }
}
