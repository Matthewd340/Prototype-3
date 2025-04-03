using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float startingSpeed = 30;
    public float boostSpeed = 60;
    public float speed;
    private PlayerController playerControllerScript;
    public float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //finds player game object in project and gets PlayerController script component
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 60;
        }

        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = 30;
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
