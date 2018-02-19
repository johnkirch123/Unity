using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour {

	public int damage = 50;
	public float distance;
	public float maxDistance = 1.5f;
	public Transform mace;
	
	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			// Attack Animation
			mace.animation.Play("Attack");
			//Attack function
			RaycastHit hit;
			if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit))
			{
				distance = hit.distance;
				if(distance < maxDistance)
				{
					hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		
		if(mace.animation.isPlaying == false)
		{
			mace.animation.CrossFade("Idle");
		}
		
		if(Input.GetKey(KeyCode.LeftShift)) 
		{
			mace.animation.CrossFade("Sprint");
		}
		
		if(Input.GetKeyUp(KeyCode.LeftShift)) 
		{
			mace.animation.CrossFade("Idle");
		}
	}
}
