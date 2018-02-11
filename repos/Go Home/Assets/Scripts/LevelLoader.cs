using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public int levelToLoad;
	public GameObject padlock;
	private string loadPrompt;
	private int completedLevel;
	private bool inRange;
	private bool canLoadLevel;
	
	void Start()
	{
		completedLevel = PlayerPrefs.GetInt("Level Completed");
		canLoadLevel = levelToLoad <= completedLevel ? true : false; 
		
		if (!canLoadLevel)
		{
			Instantiate (padlock, new Vector3(transform.position.x + 2, 0f, transform.position.z), Quaternion.identity);
		}
	}
	
	void Update()
	{
		if(canLoadLevel && Input.GetButtonDown("Action") && inRange)
		{
			Application.LoadLevel("Level_0" + levelToLoad.ToString());
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		inRange = true;
		loadPrompt = canLoadLevel ? "[E] to load level " + levelToLoad.ToString() : "Level " + levelToLoad.ToString() + " is locked.";
	}
	
	void OnTriggerExit()
	{
		inRange = false;
		loadPrompt = "";
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(30, Screen.height * .9f, 200, 40), loadPrompt);
	}
}
