using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public Vector2 movement;

    private AudioSource audioSource;
    private bool isPlayingAudio = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        //Move
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        //Facing
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(-movement.x, movement.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        //Move audio
        if (movement.magnitude != 0 && !isPlayingAudio)
        {
            isPlayingAudio = true;
            audioSource.Play();
        }
        else if (movement.magnitude == 0 && isPlayingAudio)
        {
            audioSource.Stop();
            isPlayingAudio = false;
        }
        
    }

    private void Move()
    {
        //Move input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }
}
