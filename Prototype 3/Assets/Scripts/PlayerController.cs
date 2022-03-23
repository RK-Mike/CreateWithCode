using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody prb;
    public float jumpForce;
    public float gravityModifier;

    private Animator playerAnim;

    public bool isOnGround = true;

    public bool gameOver = false;

    public ParticleSystem expolsionParticle;
    public ParticleSystem dirtyParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        prb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
                    prb.AddForce(Vector3.up *jumpForce, ForceMode.Impulse);
                    isOnGround = false;
                    playerAnim.SetTrigger("Jump_trig");
                    dirtyParticle.Stop();
                    playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
            if ( collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
            dirtyParticle.Play();

        } else if ( collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            expolsionParticle.Play();
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }


}
