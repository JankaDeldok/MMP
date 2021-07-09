using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float walkSpeed;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;

    public Rigidbody2D rbCircle;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
        
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        rbCircle.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rbCircle.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
