using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bounce.Movement
{
    
    public class PlayerMovement
    {
        private Rigidbody playerRigidbody;
        private float movementForce;
        private float jumpForce;
        private float movementMaxSpeed;        

        public PlayerMovement(Rigidbody rigidbody, float movementForce, float jumpForce, float speedLimit)
        {
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
            playerRigidbody.AddForce(movement * movementForce);
        }

        public void Jump()
        {
            if ((playerRigidbody.velocity.y < 0.01f)
                && (playerRigidbody.velocity.y > -0.01f))
            {
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }
    }
}


