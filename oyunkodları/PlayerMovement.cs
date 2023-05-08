using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Karakterin hareket h�z�
    public float jumpForce = 5f; // Karakterin z�plama kuvveti

    private Rigidbody2D rb; // Karakterin fiziksel �zelliklerini kontrol etmek i�in kullan�lacak bile�en
    private Animator anim; // Karakter animasyonlar�n� kontrol etmek i�in kullan�lacak bile�en

    private bool isGrounded = false; // Karakterin yere temas edip etmedi�ini tutan de�i�ken

    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Karakterin hareketi
        movement.x = Input.GetAxisRaw("Horizontal"); // A veya D, sol veya sa� ok tu�lar�ndan gelen input
  
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        
        // Karakterin animasyonu ve d�n���
        if (movement.x > 0)
        {
            anim.SetBool("isRunning", true);
            transform.localScale = new Vector3(10, 10, 1); // Karakter sa�a bak�yor
        }
        else if (movement.x < 0)
        {
            anim.SetBool("isRunning", true);
            transform.localScale = new Vector3(-10, 10, 1); // Karakter sola bak�yor
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        // Karakterin z�plama i�lemi
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetTrigger("jump");
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Karakterin yere temas etti�ini kontrol etmek i�in collision kullan�l�yor.
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
    
    