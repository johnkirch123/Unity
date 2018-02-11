using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUISkin skin;

	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Label(new Rect(10, 10, 400, 75), "Go Home!");
		if (PlayerPrefs.GetInt("Level Completed") > 1)
		{
			if (GUI.Button(new Rect(10f, 100f, 100f, 45f), "Continue"))
			{
				//Application.LoadLevel(PlayerPrefs.GetInt("Level Completed"));
				Application.LoadLevel(5);
			}
		}
		
		if (GUI.Button(new Rect(10f, 155f, 100f, 45f), "New Game"))
		{
			PlayerPrefs.SetInt("Level Completed", 1);
			Application.LoadLevel(1);
		}
		if (GUI.Button(new Rect(10f, 210f, 100f, 45f), "Quit"))
		{
			Application.Quit();
		}
		
	}
}
