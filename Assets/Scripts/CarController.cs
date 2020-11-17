using UnityEngine;

public class CarController : MonoBehaviour {
	private Rigidbody2D _rb2d;

	public WheelJoint2D backWheel;
	public WheelJoint2D frontWheel;
	public float speed = 2000;
	public float rotationalSpeed = 1500;
	private float _movement;
	private float _rotation;
	private JointMotor2D _motor;

	void Start() {
		_motor = new JointMotor2D {maxMotorTorque = 10000};
		_rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update() {
		_movement = -Input.GetAxisRaw("Horizontal") * speed;
		_rotation = -Input.GetAxisRaw("Vertical") * rotationalSpeed;
	}

	private void FixedUpdate() {
		if (_movement == 0f) {
			backWheel.useMotor = false;
			frontWheel.useMotor = false;
		}
		else {
			backWheel.useMotor = true;
			frontWheel.useMotor = true;
			_motor.motorSpeed = _movement;
			backWheel.motor = _motor;
			frontWheel.motor = _motor;
		}

		_rb2d.AddTorque(_rotation * Time.fixedDeltaTime);
	}
}