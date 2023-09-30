using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CharacterController
    {
        private bool _grounded;

        public void Move(Transform orientation, Rigidbody rb,  Vector2 axises, float speed, float airMultiplier)
        {
            Vector3 moveDir = orientation.forward * axises.y + orientation.right * axises.x;
            if(_grounded)
                rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
            else
                rb.AddForce(moveDir.normalized * speed * 10f * airMultiplier, ForceMode.Force);

            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVel.magnitude > speed)
            {
                Vector3 limiteVel = flatVel.normalized * speed;
                rb.velocity = new Vector3(limiteVel.x, rb.velocity.y, limiteVel.z);
            }
        }

        public void Rotate(Transform orientation, Transform playerTransform, Transform playerBodyTransform, Transform cameraTransform, Rigidbody rb, Vector2 axises, float rotSpeed)
        {
            Vector3 viewDir = playerTransform.position - new Vector3(cameraTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
            orientation.forward = viewDir.normalized;

            Vector3 inputDir = orientation.forward * axises.y + orientation.right * axises.x;
            if (inputDir != Vector3.zero)
                playerBodyTransform.forward = Vector3.Slerp(playerBodyTransform.forward, inputDir.normalized, Time.deltaTime * rotSpeed);
        }

        public void GroundCheck(Rigidbody rb, Transform playerTransform, float playerHeight, float groundDrag, LayerMask groundMask)
        {
            _grounded = Physics.Raycast(playerTransform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundMask);

            if (_grounded)
                rb.drag = groundDrag;
            else
                rb.drag = 0;
        }

        public void Jump(Rigidbody rb, Transform playerTransform, float jumpForce)
        {
            if(_grounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(playerTransform.up * jumpForce, ForceMode.Impulse);
            }

        }
    }
}