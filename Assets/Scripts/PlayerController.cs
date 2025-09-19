using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    Rigidbody2D rb;
    public float jumpForce;
    public float speed;

    //Ground Check
    public bool isGrounded;

    Animator anim;
    public bool moving;

    public GameManager gm;

    public AudioSource soundEffects;
    public AudioClip[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        //variables to mirror the player
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x); //take absolute value of the current x scale, this is always positive


        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
            moving = true;
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += speed;
            newScale.x = currentScale;
            moving = true;
        }

        if (Input.GetKey("w") && isGrounded)
        {
            soundEffects.PlayOneShot(sounds[0], .7f);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            moving = false;
        }

        anim.SetBool("isMoving", moving);
        anim.SetBool("isGrounded", isGrounded);
        transform.position = newPosition;
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded= true;
        }

        if (collision.gameObject.tag.Equals("Cake"))
        {
            gm.score+=3;
            soundEffects.PlayOneShot(sounds[2], .7f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Donut"))
        {
            gm.score += 2;
            soundEffects.PlayOneShot(sounds[2], .7f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Cookie"))
        {
            gm.score ++;
            soundEffects.PlayOneShot(sounds[2], .7f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Finish"))
        {
            Debug.Log("Game Ended");
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
            //End the Game
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded= false;
        }
    }
}
