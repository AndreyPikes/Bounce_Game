using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bounce.Movement;
using Bounce.Inputs;


[RequireComponent(typeof(Rigidbody))]
public class PlayerFacade : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField, Range(0, 100)] private float movementForce;
    [SerializeField, Range(0, 200)] private float jumpForce;
    [SerializeField, Range(0, 100)] private float movementMaxSpeed;
    
    private InputKeyboard inputKeyboard;
    private PlayerMovement playerMovement;

    private Vector3 move;
    private bool jump;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        inputKeyboard = new InputKeyboard();
        playerMovement = new PlayerMovement(playerRigidbody, movementForce, jumpForce, movementMaxSpeed);
    }

    void Update()
    {
        (jump, move) = inputKeyboard.GetInput();
    }

    private void FixedUpdate()
    {
        if (jump) playerMovement.Jump();
        playerMovement.Move(move);
        playerMovement.SpeedLimitter();
    }



#if UNITY_EDITOR
    [ContextMenu("Reset values")]
    public void ResetValues()
    {
        movementForce = 53;
        jumpForce = 17;
        movementMaxSpeed = 5;
    }
#endif
}
