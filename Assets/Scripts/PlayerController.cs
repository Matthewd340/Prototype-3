using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpHeight = 5;
    public float jumps = 2;
    public float score = 0;
    public float gravityModifier;
    private bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //name                   data type
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        //audio can be .mp3, .ogg, .waw
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnim.SetFloat("Speed_f", 65);
        }

        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            playerAnim.SetFloat("Speed_f", 25);
        }


        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0 && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isOnGround = false;                       //adds force 1 time only
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            jumps -= 1;
        }

        Debug.Log("Score: " + score);
    }

    private void OnCollisionEnter(Collision collision)
                                //parameter  variable name
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            jumps = 2;
            dirtParticle.Play();
        }
        else if(collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        score += 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            score += 1;
        }
    }
}
