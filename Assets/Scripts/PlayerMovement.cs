using UnityEngine;
using System.Collections;

// PlayerScript requires the GameObject to have a Rigidbody2D component

[RequireComponent (typeof (Rigidbody))]

public class PlayerMovement : MonoBehaviour {

	public GameObject player;
	public float turnspeed=180f;
	public float speed = 2.75F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;


	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		// is the controller on the ground?
		if (controller.isGrounded) {
			//Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			//Multiply it by speed.
			moveDirection *= speed;
			//Jumping
			if (moveDirection != Vector3.zero){
				if(Vector3.Angle (transform.forward, moveDirection) > 179){
					moveDirection = transform.TransformDirection (new Vector3(.02f, 0, -1));
				}
				player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation (moveDirection), turnspeed * Time.deltaTime * 2f);
			}
		}
		//Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * speed * Time.deltaTime);
	}
/*
    void OnCollisionEnter(Collision wall)
    {
        if(wall.gameObject.tag == "Wall")
        {
            Debug.Log("Hit a wall");
            speed = 0;
        }
    }*/
}