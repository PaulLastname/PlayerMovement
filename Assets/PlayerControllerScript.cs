using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
   public CharacterController controller;
   public Transform cam;

   public float speed = 6f;
   float turnSmoothTime = 0.1f;
   float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horiz, 0f, vert).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle,0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

        } 
    }
}
