using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigidBody;

    public float forwardForce = 2000f;
    public float leftwardForce = -2000f;
    public float rightwardForce = 2000f;
    public float backwardForce = -2000f;
    public List<string> movementKeys = new List<string>() { "w","a","s","d"};

    // Start is called before the first frame update
    void Start()
    {

    }

    // FixedUpdate is called once per frame
    // NOTE: FixedUpdate is better for physics (as opposed to Update) 
    void FixedUpdate()
    {
        movePlayer();
        //add forward force on the z axis
        //playerRigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);
    }

    // moves player object forward continuously 
    // checks for wasd user input 
    // if wasd input is found, adds force in the appropriate direction
    void movePlayer()
    {
        var keysPressed = getKeyboardInput(movementKeys);

        playerRigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (keysPressed.Count > 0)
        {
            foreach (string key in keysPressed)
            {
                addForceToPlayer(key);
            }
        }
    }

    //checks keyboard input from the user
    //takes a list of keys to check for 
    //iterates through the list checking the input value for each key
    //returns a list of all the keys being pressed
    //NOTE: Input.GetKey() is not the best method for handling input
    //  doesn't allow smoothing movement or alternate control schemes/input sources
    //  research optimization options for handling user input
    List<string> getKeyboardInput(List<string> keysToCheck)
    {
        var keysPressed = new List<string>();

        foreach (string key in keysToCheck)
        {
            if (Input.GetKey(key) == true)
                keysPressed.Add(key);
        }

        return keysPressed;

    }

    //adds force to the player object in the direction specified by the input key
    //uses standard wasd format
    void addForceToPlayer(string inputKey)
    {
        switch (inputKey)
        {
            case "w" :
                playerRigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);
                break;
            case "a" :
                playerRigidBody.AddForce(leftwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                break;
            case "s" :
                playerRigidBody.AddForce(0, 0, backwardForce * Time.deltaTime);
                break;
            case "d":
                playerRigidBody.AddForce(rightwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                break;
        }

    }
}
