using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    public float Speed = 4.5f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Destroy(this.gameObject,5);
    }
    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(Speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }


}
