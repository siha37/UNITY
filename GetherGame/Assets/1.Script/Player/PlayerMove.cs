using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform tf;
    SpriteRenderer Sprite;
    public float speed;
    RaycastHit2D hit;
    public float RayCastDistance;
    Animator anim;
    float h;
    private void Start()
    {
        Sprite = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
        tf = this.transform;
    }
    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        Move();
        Debug.DrawRay(tf.position, Vector3.right * RayCastDistance,Color.red);
    }
    private void Move()
    {
        if(h != 0)
        {
            if (h > 0)
            {
                hit = Physics2D.Raycast(tf.position,Vector3.right, RayCastDistance, LayerMask.GetMask("FLOOT"));
                if(!hit)
                {
                    Sprite.flipX = false;
                    tf.Translate(Vector3.right * speed * Time.deltaTime);
                    anim.SetBool("MOVE", true);
                }
                else
                {
                    anim.SetBool("MOVE", false);
                }
            }
            else
            {
                hit = Physics2D.Raycast(tf.position, Vector3.left, RayCastDistance,LayerMask.GetMask("FLOOT"));
                if (!hit)
                {
                    Sprite.flipX = true;
                    tf.Translate(Vector3.left * speed * Time.deltaTime);
                    anim.SetBool("MOVE", true);
                }
                else
                {
                    anim.SetBool("MOVE", false);
                }
            }
        }
        else
        {
            anim.SetBool("MOVE", false);
        }
    }
}
