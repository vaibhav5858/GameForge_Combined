using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;

    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;



    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(inputUp))
        {
            SetDirection(Vector2.up);
        } else if (Input.GetKeyDown(inputDown))
        {
            SetDirection(Vector2.down);
        } else if (Input.GetKeyDown(inputLeft))
        {
            SetDirection(Vector2.left);
        } else if (Input.GetKeyDown(inputRight))
        {
            SetDirection(Vector2.right);
        } else
        {
            SetDirection(Vector2.zero);
        }
    }


    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        
        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}
