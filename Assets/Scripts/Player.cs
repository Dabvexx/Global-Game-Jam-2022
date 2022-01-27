using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            rb2D.velocity = new Vector2(1 * speed, rb2D.velocity.y);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            rb2D.velocity = new Vector2(-1 * speed, rb2D.velocity.y);
        }
    }
}
