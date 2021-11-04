using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{  
    private Rigidbody2D rig;
    private Animator ani;

    public float Speed;

    public Transform rightCheck;
    public Transform LeftCheck;

    private bool colliding;

    public LayerMask layer;
    

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        rig.velocity = new Vector2(Speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCheck.position, LeftCheck.position, layer);

        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            Speed *= -1f;

        }
    }
}
