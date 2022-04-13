using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float velocityX = 5;
    public float jumpForce = 100;

    public GameObject BalaPrefab;

    // Start is called before the first frame update

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    //constantes

    private const int WALK = 0;
    private const int JUMP = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(WALK);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(WALK);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(JUMP);
        }
   

        if (Input.GetKeyUp(KeyCode.X))
        {
            Disparar();
        }

    }

    private void Disparar()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var bulletGO = Instantiate(BalaPrefab, new Vector2(x, y), Quaternion.identity) as GameObject;
        if (sr.flipX)
        {
            var controller = bulletGO.GetComponent<BalaController>();
            controller.Speed *= -1;

        }
       
    }
    
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}