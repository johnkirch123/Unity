using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameManager manager;
	public float moveSpeed;
	public GameObject deathParticles;
	public bool usesManager = true;
	
	private float maxSpeed = 7f;
	
	private Vector3 input;
	private Vector3 spawn;
	
	public AudioClip[] audioClip;

	void Start () {
		spawn = transform.position;
		if (usesManager)
		{
			manager = manager.GetComponent<GameManager>();
		}
	}
	
	void FixedUpdate () {
		input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		if(rigidbody.velocity.magnitude < maxSpeed)
		{
			// AddForce() will always bein one direction no matter the camera direction.
			rigidbody.AddRelativeForce(input * moveSpeed);
		}
		
		if(transform.position.y < -2)
		{
			Die ();
		}
		
		Physics.gravity = Physics.Raycast(transform.position, Vector3.down, .75f) ? Vector3.zero : new Vector3(0, -25f, 0);
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy")
		{
			Die ();
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Enemy")
		{
			Die();
		}
		if (other.transform.tag == "Goal")
		{
			PlaySound (1);
			Time.timeScale = 0f;
			manager.CompleteLevel();
		}
		if (other.transform.tag == "Coin")
		{
			if (usesManager)
			{
				manager.coinCount++;
			}
			PlaySound(0);
			Destroy(other.gameObject);
		}
	}
	
	void PlaySound(int clip)
	{
		audio.clip = audioClip[clip];
		audio.Play();
	}
	
	void Die()
	{
		Instantiate(deathParticles, transform.position, Quaternion.Euler(270, 0, 0));
		transform.position = spawn;
	}
}
