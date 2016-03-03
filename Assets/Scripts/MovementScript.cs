using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	//Maximum speed of the player (if they have an input button all the way down)
	public float maxSpeed = 10f;

	//Whether the player is facing left or right
	bool facingRight = true;

	//Amount of force to apply when jumping
	public float jumpForce = 300f;

	//Reference to Rigidbody2D, so we don't need to try and call GetComponent every frame and every physics timestep
	Rigidbody2D myRigidbody;

	//Whether we're on the ground or not
	bool grounded = false;

	private Animator anim;

	//The location where to check if the player has hit the ground (much like the canon, can not use the transform of the player)
	public Transform groundCheck;

	//How big the groundCheck should be
	float groundRadius = 0.2f;

	//Determining what things are the ground or not (for example, the player is not the ground
	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (grounded && Input.GetButtonDown ("Jump")) {
			ScoreManager.score -= 1;
			grounded = false;
			myRigidbody.AddForce (new Vector2 (0, jumpForce));
		}
	}

	// Update is called once per *physics timestep*
	void FixedUpdate() {

		//Determining if the ground check spot has hit anywhere (on the ground)
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		anim.SetBool ("grounded", grounded);

		//Get left / right movement from keyboard
		float move = Input.GetAxis ("Horizontal");
		//And apply it to our rigidbody (remember, we're only in 2D, so only 2 coordinates)
		myRigidbody.velocity = new Vector2 (move * maxSpeed, myRigidbody.velocity.y);

		//Perform the flip if we're not pointing the right direction
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

	}

	//Called when we want to flip our player from pointing one direction to the other (rather than making an artist draw two separate sets of animations)
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;

		// Flip the graphic using scale!
		theScale.x *= -1; // Augmented assignment, like in Python, equivalent to theScale.x = theScale.x * -1
		transform.localScale = theScale;
	}


	//Called when we hit powerups!
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Jump Higher") {
			ScoreManager.score += 10;

			GameObject spawnControllerGameObject = GameObject.Find ("SpawnController");
			SpawnController spawnController = spawnControllerGameObject.GetComponent<SpawnController> ();
			spawnController.SpawnObject ();

			this.jumpForce = 500;
			Destroy (other.gameObject);
		}
		if (other.gameObject.name.StartsWith ("arrow")) {
			ScoreManager.score -= 1;
		}
	}
}
