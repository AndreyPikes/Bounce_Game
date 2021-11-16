using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movementHorizontal;
        private PlayerMovement playerMovement;
        private bool jumping = false;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }




        void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            movementHorizontal = new Vector3(-horizontal, 0, 0).normalized; //единичные

            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);
            bool jump = Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON);

            jumping |= (jump || vertical > 0); //логическое или оставляет левую часть true до конца Update, даже если нажатие закончилось!
            
        }

        

        private void FixedUpdate()
        {
            if (movementHorizontal != Vector3.zero) playerMovement.MoveCharacter(movementHorizontal);

            if (jumping) playerMovement.Jump();

            jumping = false;
        }

        


    }
}


