using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public float attackInterval;
    public float horizontalForce = 8;
    public float verticalForce = 15;
    private float destroyTime = 1;    
    
    private float nextAttack;
    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        ani.SetTrigger("attack");
        nextAttack = Time.time + attackInterval;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().enabled = false;
            
            BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();
            
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;                
            }

            if(other.transform.position.x < transform.position.x)
            {
                horizontalForce *= -1;
            }

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce, verticalForce), ForceMode2D.Impulse);
            
            Destroy(other.gameObject, destroyTime);
        }
    }

}
