using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private PlayerActions playerActions;
    private new Rigidbody2D rigidbody2D = null;
    private Vector2 movement;
    private Animator animator = null;
    private SpriteRenderer sprite = null;

    private void Awake()
    {
        playerActions = new PlayerActions();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

    private void Update()
    {
        PlayerInput();
        SetPlayerFacing();
    }

    private void FixedUpdate()
    {
        MoveWithPyshics();
    }

    private void PlayerInput()
    {
        movement = playerActions.Movement.Move.ReadValue<Vector2>();
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
    }

    private void MoveWithPyshics()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * (speed * Time.fixedDeltaTime));
    }


    private void SetPlayerFacing()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mouseWorldPosition.x < transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
