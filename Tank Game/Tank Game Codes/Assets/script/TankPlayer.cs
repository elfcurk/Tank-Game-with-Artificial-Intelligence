using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayer : MonoBehaviour {
    string movementAxis, turnAxis;
    float movementValue, turnValue;
    float moveSpeed, turnSpeed;
    Rigidbody rb;

	// Use this for initialization
	void Awake () {
        moveSpeed = 15f;
        turnSpeed = 200f;
        movementAxis = "Vertical";
        turnAxis = "Horizontal";
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        movementValue = Input.GetAxis(movementAxis);
        turnValue = Input.GetAxis(turnAxis);
        Move();
        Turn();
		
	}
    private void Turn()
    {
        float turn = turnValue * turnSpeed * Time.deltaTime;
        Quaternion rot = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(transform.rotation * rot);
    }

    private void Move()
    {
        Vector3 movePosition = transform.forward * movementValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movePosition);
    }
}
