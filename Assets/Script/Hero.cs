using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float Speed;
    public float JumpPower;

    public bool isJumping;
    public bool doubleJumping;

    private Rigidbody2D rig;
    private Animator ani;    
    
    // Start is called before the first frame update
    void Start()
    {        
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {  
        Move();
        Jump();                            
        
    }

    void Move()
    {
        Vector3 moviment = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += moviment * Time.deltaTime * Speed;
        
        if(Input.GetAxis("Horizontal") > 0f)
        {
            ani.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);            
        }
        if(Input.GetAxis("Horizontal") < 0f)
        {
            ani.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);            
        }
        if(Input.GetAxis("Horizontal") == 0f)
        {
            ani.SetBool("run", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpPower), ForceMode2D.Impulse);                           
                doubleJumping = true;
                ani.SetBool("jump", true);
            }
            else
            {
                if(doubleJumping)
                {
                    rig.AddForce(new Vector2(0f, JumpPower), ForceMode2D.Impulse);                           
                    doubleJumping = false;
                }
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isJumping = false;
            ani.SetBool("jump", false);
        }

        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
            ani.SetBool("jump", false);
        }

        if(collision.gameObject.tag == "Spike")
        {
            ani.SetTrigger("die");
            GameController.instance.ShowGameOver();            
            Destroy(gameObject);
        }        
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isJumping = true;
        }
    }
    
}
