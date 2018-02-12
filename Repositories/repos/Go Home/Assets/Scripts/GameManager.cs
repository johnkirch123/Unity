using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Count
	public int currentScore;
	public int highScore;
	public int coinCount;
	private int totalCoinCount;
	public static int currentLevel = 1;
	public int unlockedLevel;
	
	//Timer Variables
	public Rect timerRect;
	public Color warningColorTimer;
	public Color defaultColorTimer;
	public float startTime;
	private string currentTime;
	
	//GUI Skin
	public GUISkin skin;
	
	//References
	public GameObject coinParent;
	
	private bool completed = false;
	private bool showWinScreen = false;
	public int winScreenWidth, winScreenHeight;
	
	void Update()
	{
		if (!completed)
		{
			startTime -= Time.deltaTime;
			currentTime = string.Format("{0:0.0}",startTime);
			if (startTime <= 0)
			{
				startTime = 0;
				currentLevel = 1;
				//Application.LoadLevel("Main_Menu");
			}
		}
		
	}
	
	public void Start()
	{
		totalCoinCount = coinParent.transform.childCount;
		if (PlayerPrefs.GetInt ("Level Completed") > 1)
		{
			currentLevel = PlayerPrefs.GetInt ("Level Completed");
		} else {
			currentLevel = 1;
		}
		//DontDestroyOnLoad(gameObject);
	}
	
	public void CompleteLevel()
	{
		showWinScreen = true;
		completed = true;
	}
	
	void LoadNextLevel()
	{
		Time.timeScale = 1f;
		if(currentLevel < 4)
		{
			currentLevel += 1;
			SaveGame();
			Application.LoadLevel(currentLevel);	
		} else {
			Debug.Log ("You win!");
		}
	}
	
	void SaveGame()
	{
		PlayerPrefs.SetInt("Level Completed", currentLevel);
		PlayerPrefs.SetInt("Level " + currentLevel.ToString() + " Score", currentScore);
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		if (startTime < 10)
		{
			skin.GetStyle("Timer").normal.textColor = warningColorTimer;
		} else {
			skin.GetStyle("Timer").normal.textColor = defaultColorTimer;
		}
		GUI.Label(timerRect, currentTime, skin.GetStyle("Timer"));
		GUI.Label(new Rect(45, 100, 200, 200), coinCount.ToString() + " / " + totalCoinCount.ToString());
		
		if (showWinScreen == true)
		{
			//Rect winScreenRect = new Rect(Screen.width/2 - (winScreenWidth/2), Screen.height/2 - winScreenHeight/2, winScreenWidth, winScreenHeight);
			Rect winScreenRect = new Rect(Screen.width/2 - (Screen.width * .5f/2), Screen.height/2 - (Screen.height * .5f/2), Screen.width * .5f, Screen.height * .5f);
			GUI.Box (winScreenRect, "Next Level");
			
			int gameTime = (int)startTime;
			currentScore = gameTime * coinCount;
			
			if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - 170, winScreenRect.y + winScreenRect.height - 60, 150, 40), "Continue"))
			{
				LoadNextLevel();
			}
			if (GUI.Button(new Rect(winScreenRect.x + 20, winScreenRect.y + winScreenRect.height - 60, 100, 40), "Quit"))
			{
				Application.LoadLevel("Main_Menu");
				Time.timeScale = 1f;
			}
			
			GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), currentScore.ToString() + " Score");
			GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 70, 300, 40), "Completed Level " + currentLevel);
		}
	}
}









