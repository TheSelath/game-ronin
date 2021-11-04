using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Attack"))
        {
            ani.SetTrigger("die_Enemy");
            Destroy(gameObject);
        }
    }

    
}
        
    
