using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpHeight = 5;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //name                   data type
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround == true)
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isOnGround = false;                       //adds force 1 time only
        }
    }

    private void OnCollisionEnter(Collision collision)
                                //parameter  variable name
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
        else if(collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
}
