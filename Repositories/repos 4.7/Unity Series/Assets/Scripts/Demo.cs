using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour {
	public int health;
	
	public enum WeaponType {
		Sword,
		Staff,
		Dagger,
		Mace
	}
	
	public WeaponType weaponType;
	
	public string[] arrayString;
	
	void Start() 
	{
		
		arrayString = new string[5];
		arrayString[0] = "Sword";
		arrayString[1] = "Potion";
		arrayString[2] = "Bow";
		arrayString[3] = "Pick Axe";
		arrayString[4] = "Shield";
		
		for(int i = 0; i < arrayString.Length; i++)
		{
			print(arrayString[i]);
		}
	}
	
	void Update() 
	{
		switch(weaponType)
		{
			case WeaponType.Dagger:
				print("Dagger");
				break;	
			case WeaponType.Sword:
				print("Sword");
				break;	
			case WeaponType.Staff:
				print("Staff");
				break;	
			case WeaponType.Mace:
				print("Mace");
				break;
			default:
				print("Something weird happened");
				break;
		}
	
		DamagePlayer(1);
		if (health <= 0)
		{
			//health = 0;
			//Destroy (gameObject, 5f);
		}
		
		//print(arrayString[0]);
	}
	
	public void DamagePlayer(int damage)
	{
		health -= damage;
	}
}
