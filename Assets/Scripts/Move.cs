using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed; 
    void Update()
    {
        // float horizontal = Input.GetAxis("Horizontal");
        HorizantalMove(1);
    }
    private void HorizantalMove(float horizontal){

        rb2D.velocity = new Vector2(speed*horizontal,rb2D.velocity.y);

    }

    
    
}

