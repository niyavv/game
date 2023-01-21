using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed;

    private float _multiplier = 1;
    void Update()
    {
        // float horizontal = Input.GetAxis("Horizontal");
        HorizantalMove(1);
    }
    private void HorizantalMove(float horizontal){

        rb2D.velocity = new Vector2(speed*_multiplier*horizontal,rb2D.velocity.y);
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        _multiplier = multiplier;
    }

    
    
}

