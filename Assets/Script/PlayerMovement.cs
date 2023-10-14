using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 6; //Put here the number of pickups you have.
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    public void Start()
    {
        count = 0;
        winText.text = "";
        //SetCountText ();
    }

    //save the value received as input (WASD or arrow keys
    void OnMove(InputValue value) {
        moveValue = value.Get<Vector2>();

    }

    void FixedUpdate()
    {
        //vector with the direction the ball should move
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }

    //function when player is colliding with pick-up
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false); //hiding the cubes
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickups)
        {
            winText.text = "You win!";
        }
    }
}
