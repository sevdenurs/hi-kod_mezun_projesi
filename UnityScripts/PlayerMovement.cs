using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Karakterin hareket hýzý
    public float jumpForce = 5f; // Karakterin zýplama kuvveti

    private Rigidbody2D rb; // Karakterin fiziksel özelliklerini kontrol etmek için kullanýlacak bileþen
    private Animator anim; // Karakter animasyonlarýný kontrol etmek için kullanýlacak bileþen

    private bool isGrounded = false; // Karakterin yere temas edip etmediðini tutan deðiþken

    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Karakterin hareketi
        movement.x = Input.GetAxisRaw("Horizontal"); // A veya D, sol veya sað ok tuþlarýndan gelen input
  
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        
        // Karakterin animasyonu ve dönüþü
        if (movement.x > 0)
        {
            anim.SetBool("isRunning", true);
            transform.localScale = new Vector3(10, 10, 1); // Karakter saða bakýyor
        }
        else if (movement.x < 0)
        {
            anim.SetBool("isRunning", true);
            transform.localScale = new Vector3(-10, 10, 1); // Karakter sola bakýyor
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        // Karakterin zýplama iþlemi
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetTrigger("jump");
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Karakterin yere temas ettiðini kontrol etmek için collision kullanýlýyor.
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
    
    