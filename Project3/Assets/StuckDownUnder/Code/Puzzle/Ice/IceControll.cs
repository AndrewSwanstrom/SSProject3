using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceControll : MonoBehaviour
{
    public GameObject penguinCharacter;
    public GameObject notifyText;
    Penguin penguin;
    bool playerRange;
    // Start is called before the first frame update
    void Start()
    {
        penguin = penguinCharacter.GetComponent<Penguin>();
        notifyText.SetActive(false);
        playerRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if player is in range of the mechanic
        if(playerRange)
        {
            //notification shows up
            notifyText.SetActive(true);
            //if press F the puzzle will begin
            if(Input.GetKey(KeyCode.F))
            {
                penguin.penguinMove = true;
            }
        }
        else
        {
            notifyText.SetActive(false);
        }
    }

    //if player is in range the trigger will show true
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerRange = true;
        }
    }

    //shows false once the player exits the range
    void OnTriggerExit(Collider other)
    {
        if(other.tag =="Player")
        {
            playerRange = false;
        }
    }
}
