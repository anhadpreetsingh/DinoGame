using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] float jumpVelocity = 5f;
    [SerializeField] float extraRaycastLength = 0.1f;
    [SerializeField] CapsuleCollider2D capsuleCollider2D;
    [SerializeField] LayerMask floorLayerMask;
    [SerializeField] Canvas GameOverCanvas;
    
    

    Rigidbody2D rb;
    Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSource1;
    
    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(IsGrounded())
            {
                rb.velocity = new Vector2(0, jumpVelocity);
                audioSource.Play();
                
            }
            
        }

        if(rb.velocity.y != 0)
        {
            animator.SetBool("isJumping", true);
        }

        else
        {
            animator.SetBool("isJumping", false);
        }

     

    }

    

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, capsuleCollider2D.bounds.extents.y + extraRaycastLength, floorLayerMask);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            
            GameOver();
        }
    }

    private void GameOver()
    {
        audioSource1.Play();
        Time.timeScale = 0f;
        GameOverCanvas.gameObject.SetActive(true);
    }
}
