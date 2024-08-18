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

    private void Awake()
    {
        playerActions = new PlayerActions();
        rigidbody2D = GetComponent<Rigidbody2D>();
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
    }

    private void FixedUpdate()
    {
        MoveWithPyshics();
    }

    private void PlayerInput()
    {
        this.movement = playerActions.Movement.Move.ReadValue<Vector2>();
    }

    private void MoveWithPyshics()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * (speed * Time.fixedDeltaTime));
    }
}
