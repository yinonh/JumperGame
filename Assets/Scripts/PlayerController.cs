using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float graviryModify;
    public bool isOnGround;
    public bool gameOver = false;
    public float addSpeed = 0;
    private Animator playerAnimator;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jump;
    public AudioClip crash;
    private AudioSource camra;
    private AudioSource playerAudio;
    private bool secJump;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= graviryModify;
        playerAnimator = GetComponent<Animator>();
        isOnGround = true;
        playerAnimator.SetInteger("DeathType_int", 1);
        camra = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
    
    //dirt.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            count += 1;
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerAudio.PlayOneShot(jump, 1.0f);
                playerAnimator.SetTrigger("Jump_trig");
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                dirt.Stop();
                addSpeed += 0.2f;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !secJump)// Input.touchCount
            {
                playerAnimator.Rebind();
                playerAnimator.SetTrigger("Jump_trig");
                playerAudio.PlayOneShot(jump, 1.0f);
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                secJump = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                count += 1;
            }
            Debug.Log(count);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            secJump = false;
            dirt.Play();
        }
        else if (!gameOver)
        {
            playerAudio.PlayOneShot(crash, 1.0f);
            camra.Stop();
            dirt.Stop();
            explosion.Play();
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            Debug.Log("GameOver, your score: " + count);
        }
    }
}
