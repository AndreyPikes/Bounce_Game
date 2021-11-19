using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bounce.Movement;
using Bounce.Inputs;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IExploding, IDamagable
{
    public event Action<string> Death;
    
    [SerializeField, Range(0, 100)] private float movementForce;
    [SerializeField, Range(0, 200)] private float jumpForce;
    [SerializeField, Range(0, 100)] private float movementMaxSpeed;

    [SerializeField] private InputUIButtons inputFromUI;

    private Rigidbody playerRigidbody;
    private InputKeyboard inputKeyboard;
    private PlayerMovement playerMovement;

    private Vector3 move;
    private bool jump;

    private bool dead;

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
        if (!dead)
        {
#if UNITY_ANDROID
        (jump, move) = inputFromUI.GetInput();
#endif
#if UNITY_STANDALONE_WIN || UNITY_WEBGL
        (jump, move) = inputKeyboard.GetInputMovement(); 
#endif
        }
    }

    private void FixedUpdate()
    {
        if (jump) playerMovement.Jump();
        playerMovement.Move(move);
        playerMovement.SpeedLimitter();
    }

    public void Explode()
    {
        if (!dead)
        {
            dead = true;
            Death?.Invoke("Died of an explosion!");
        }
    }
            

    public void Damage()
    {
        if (!dead)
        {
            dead = true;
            Death?.Invoke("Died of thorns!");
        }
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
