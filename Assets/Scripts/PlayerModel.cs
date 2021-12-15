using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bounce.Movement
{    
    public class PlayerModel
    {
        public event Action<string> Death;

        private bool dead = false;

        private Transform transform;
        private Rigidbody playerRigidbody;
        private float movementForce;
        private float jumpForce;
        private float movementMaxSpeed;        

        public PlayerModel(Transform transform, Rigidbody rigidbody, float movementForce, float jumpForce, float speedLimit)
        {
            this.transform = transform;
            this.playerRigidbody = rigidbody;
            this.movementForce = movementForce;
            this.jumpForce = jumpForce;
            this.movementMaxSpeed = speedLimit;
        }

        public void SpeedLimitter()
        {
            if (playerRigidbody.velocity.x > movementMaxSpeed) {
                playerRigidbody.velocity -= new Vector3(playerRigidbody.velocity.x - movementMaxSpeed, 0, 0);
            }
            if (playerRigidbody.velocity.x < -movementMaxSpeed) {
                playerRigidbody.velocity -= new Vector3(playerRigidbody.velocity.x + movementMaxSpeed, 0, 0);
            }
        }

        public void Move(Vector3 movement)
        {
            if (!dead)
            {
                playerRigidbody.AddForce(movement * movementForce);
            }
        }

        public void Jump()
        {
            if (!dead)
            {   
                if (CheckIfGrounded())
                
                {                    
                    playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                }
            }
        }

        public void Kill(string message)
        {
            if (!dead)
            {
                dead = true;
                Death?.Invoke(message);
            }
        }

        private bool CheckIfGrounded()
        {
            if ((playerRigidbody.velocity.y < 0.01f) && (playerRigidbody.velocity.y > -0.01f))
            {
                Vector3 rayStart = transform.position;
                float radius = transform.localScale.y / 2 - 0.01f;
                float rayLenghth = 0.03f;
                return Physics.SphereCast(rayStart, radius, Vector3.down, out RaycastHit hitInfo, rayLenghth);
            }
            else return false;
        }
    }
}


