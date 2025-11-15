using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boby : MonoBehaviour
{
     public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar;
     public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
 private Animator anim;
    void Start()
    {
       anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame

    void Update()
    {
        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));//////lab2 parameter speed حطيتها حته يمشي////////
        anim.SetFloat("Hight", GetComponent<Rigidbody2D>().velocity.y);//////////lab2 حته يقفز///////////
        anim.SetBool("Grounded", grounded);
         if(Input.GetKeyDown(Spacebar)&& grounded){///////احط grounded حته ينط مرة وحدة وليس عدة نطات//////////lab1///////
            jump();
        }
        if(Input.GetKey(L)){///////////lab1//////////
            GetComponent<Rigidbody2D>().velocity=new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            if(GetComponent<SpriteRenderer>()!=null){/////شخصية تتجه يمين/////////
                GetComponent<SpriteRenderer>().flipX=true;
            }
        }
         if(Input.GetKey(R)){/////////lab1///////////
            GetComponent<Rigidbody2D>().velocity=new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
             if(GetComponent<SpriteRenderer>()!=null){///////شخصيه تتجه يسار/////////
                GetComponent<SpriteRenderer>().flipX=false;
            }
        }

        
    }
     void jump(){/////lab1////////////
        GetComponent<Rigidbody2D>().velocity=new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
    }
    void FixedUpdate(){//////////lab1////////////
        grounded=Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
    }

}
