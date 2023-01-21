using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool isDead;
    public float velocity = 1f;
    public Rigidbody2D rb2D;
    public GameManager managerGame;
    public float speed; 
    public float time;

    private bool isJumping = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isJumping) //t�klamay� al
        {
            rb2D.velocity = Vector2.up * velocity; //vekt�r 2 y�n�nde yukar� do�ru z�plat
            isJumping = true;
        }

        float horizontal = Input.GetAxis("Horizontal");
        HorizantalMove(horizontal);
    }
    private void HorizantalMove(float horizontal){

        rb2D.velocity = new Vector2(speed*horizontal,rb2D.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)//�arp��mas� yeterli
    {
        if (collision.gameObject.TryGetComponent(out IJumpable jumpable))
        {
            isJumping = false;
        }
    }
    
}

