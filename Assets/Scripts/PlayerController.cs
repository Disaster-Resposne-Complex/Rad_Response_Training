using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //should be the player
    [Tooltip("The game object with all the pick-ups as children")]
    //public GameObject pickUpsLevel1; //should be the cubes

    float speed;
    float maxSpeed = .5f;
    //public Text countText; //on the canvas, should be the text "Count: "
    //public Text winText; // in the canvas, should be the "Level Complete" text
    //public AudioClip powerUp; //sound when player picks up cubes
    //public AudioClip bounce; //sound when player hits a wall
    //float Timer = 150f;
    //public Button mainMenuButton;
    private AudioSource audioSource;
    
    
    private void Start()
    {
        //maxSpeed = InputController.maximumSpeed;
        rb = GetComponent<Rigidbody>();
        //SetCountText();
        //winText.gameObject.SetActive(false);
        //mainMenuButton.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>(); //initiate audioSource (important step)
    }

    /*private void Update()
    {
        //check if ball has fallen off the table
        if (transform.position.y < -10f)
        {
            //mainMenuButton.gameObject.SetActive(true);
        }
    }*/
    
    //Called just before any Physics calculations
    void FixedUpdate()
    {
        MoveWithArrowKeys();//This was in the if statement below, but the if statement is applicable only with options available in input controller (not applicable here)
        //ControlSettings.arrowKeySetting = true;
        //bool arrowKeySetting = ControlSettings.arrowKeySetting;
        /*if (InputController.arrowKeySetting) //true is arrows, false is mouse
        {
            MoveWithArrowKeys();
        }
        else
        {
            MoveWithMousePosition();
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        //FOR REFERENCE; THIS WAS DEVELOPED FOR A ROLL-A-BALL TUTORIAL IN UNITY

        /*Makes a bouncey noise when ball collides with Walls
        if (other.gameObject.CompareTag("Walls"))
        {
            Debug.Log("hit wall");
            //audioSource.volume = (speed / maxSpeed);
            //AudioSource.PlayClipAtPoint(bounce, rb.position);
        }

        if (other.gameObject.CompareTag("Pick-up"))
        {
            AudioSource.PlayClipAtPoint(powerUp, rb.position);
            other.gameObject.SetActive(false);
            count = count + 1;
            //SetCountText();


            if (count == pickUpsLevel1.transform.childCount)
            {
                winText.gameObject.SetActive(true);
                mainMenuButton.gameObject.SetActive(true);
            }
            else { mainMenuButton.gameObject.SetActive(false); } //If you don't put the "else" in, 
                                                                //it will be executed independently and will undo the if statement
            if (Input.GetKey(KeyCode.Return))
            {
                winText.text = " ";
            }
        }*/
    }

    void MoveWithMousePosition()
    {

        float mouseX = Input.mousePosition.x - (Screen.width) / 2f;
        float mouseY = Input.mousePosition.y - (Screen.height) / 2f;

        float dampInput = .025f;
        float moveHorizontal = (mouseX - gameObject.transform.position.x) * dampInput;
        float moveVertical = (mouseY - gameObject.transform.position.y) * dampInput;

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        //Math Function to make speed increase exponentially as you get farther away from (0,0)
        speed = Mathf.Exp( Mathf.Sqrt(Mathf.Pow(moveVertical,2) + Mathf.Pow(moveHorizontal,2)) / 30f);
        //if statement to cap maximum speed
        if (speed <= maxSpeed)
        {
            rb.AddForce(movement * speed);
        }
        else rb.AddForce(movement * maxSpeed);
    }

    void MoveWithArrowKeys()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(0f, 0f, moveVertical*maxSpeed);
        transform.Rotate(0f, moveHorizontal, 0f);
    }



}
