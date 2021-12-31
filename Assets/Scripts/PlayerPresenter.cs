using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bounce.Movement;
using Bounce.Inputs;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerPresenter : MonoBehaviour, IExploding, IDamagable
{
    [SerializeField] private PlayerInputUI playerInputUI;

    [SerializeField, Range(0, 100)] private float movementForce;
    [SerializeField, Range(0, 200)] private float jumpForce;
    [SerializeField, Range(0, 100)] private float movementMaxSpeed;

    private Rigidbody playerRigidbody;
    private InputKeyboard inputKeyboard;
    [HideInInspector]public PlayerModel playerModel;

    private Vector3 move;
    private bool jump;

    

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        inputKeyboard = new InputKeyboard();
        playerModel = new PlayerModel(transform, playerRigidbody, movementForce, jumpForce, movementMaxSpeed);
    }

    void Update()
    { 
#if UNITY_ANDROID || UNITY_IOS
        (jump, move) = playerInputUI.GetInput();
#endif
#if UNITY_STANDALONE_WIN || UNITY_WEBGL
        (jump, move) = inputKeyboard.GetInputMovement(); 
#endif
    }

    private void FixedUpdate()
    {
        
        if (jump) playerModel.Jump();
        inputKeyboard.SetJumpingFlagFalse();//костылек для улучшения отзывчивости
        playerInputUI.SetJumpingFlagFalse();        
        playerModel.Move(move);
        playerModel.SpeedLimitter();
        
    }

    public void Explode()
    {
        playerModel.Kill("Bomb killed you!");       
    }
            

    public void Damage()
    {
        playerModel.Kill("Thorns killed you!");        
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
