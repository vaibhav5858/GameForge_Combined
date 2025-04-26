using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    private Vector2 direction = Vector2.zero;
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
        direction = Vector2.zero; // Reset direction every frame

        if (Input.GetKey(inputUp))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(inputDown))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(inputLeft))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(inputRight))
        {
            direction += Vector2.right;
        }

        direction = direction.normalized; // Prevent faster diagonal movement
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }
}
