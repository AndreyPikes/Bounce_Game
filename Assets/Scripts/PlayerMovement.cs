using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        [SerializeField, Range(0, 100)] private float movementForce;
        [SerializeField, Range(0, 100)] private float movementMaxSpeed;
        [SerializeField, Range(0, 200)] private float jumpForce;
        
        private bool isCollided = false;


        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            if (playerRigidbody == null) Debug.Log("null");
        }

        private void FixedUpdate()
        {
            if (playerRigidbody.velocity.x > movementMaxSpeed)
            {
                playerRigidbody.velocity -= new Vector3(playerRigidbody.velocity.x - movementMaxSpeed, 0, 0);
            }
            if (playerRigidbody.velocity.x < -movementMaxSpeed)
            {
                playerRigidbody.velocity -= new Vector3(playerRigidbody.velocity.x + movementMaxSpeed, 0, 0);
            }
            
        }

        public void MoveCharacter(Vector3 movement)
        {
            playerRigidbody.AddForce(movement * movementForce);
        }

        public void Jump()
        {
            if ((playerRigidbody.velocity.y < 0.01f)
                && (playerRigidbody.velocity.y > -0.01f)
                && isCollided)
            {                
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            isCollided = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            isCollided = false;
        }





#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues()
        {
            movementForce = 2;
        }
#endif
    }
}


