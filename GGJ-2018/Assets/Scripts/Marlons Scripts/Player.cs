using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour
{   
	float accelerationTimeGrounded = .1f;
    public float moveSpeed = 6f;
    public float maxSpeed;
    public bool currentlySelected;
    public float sprintSpeed = 10f;
    public int stamina = 250;
    public Vector3 knockbackVelocity;

	Vector3 velocity;
    public Vector3 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }
	float velocityXSmoothing;
    float velocityYSmoothing;

	Controller2D controller;

	Vector2 directionalInput;
    public Vector2 DirectionalInput
    {
        get { return directionalInput; }
    }

	void Start()
    {
		controller = GetComponent<Controller2D> ();
    }

	void Update()
    {
		CalculateVelocity ();

        velocity += knockbackVelocity;
        knockbackVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift) && stamina >= 2)
        {
            stamina -= 2;
            moveSpeed = sprintSpeed;
        }
        else
        {
            if (stamina < 250)
                stamina++;

            moveSpeed = 6f;
        }

        if (currentlySelected)
        {          
            controller.Move(velocity * Time.deltaTime, directionalInput);
        }
            
    }

	public void SetDirectionalInput (Vector2 input)
    {
		directionalInput = input;
	}

	void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        float targetVelocityY = directionalInput.y * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeGrounded);
        velocity.y = Mathf.SmoothDamp(velocity.y, targetVelocityY, ref velocityYSmoothing, accelerationTimeGrounded);

        if (velocity.magnitude > 10f)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }
	}
}