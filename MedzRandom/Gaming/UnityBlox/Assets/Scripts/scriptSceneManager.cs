using UnityEngine;
using System.Collections;

public class scriptSceneManager : MonoBehaviour
{
	public float gameTime = 60;
	public static int score = 0;
	public static int lives = 3;
	public int startLives = 3;
	
	public float BorderTop = 3.0f;
	public float BorderBottom = -3.0f;
	public float BorderLeft = -4.15f;
	public float BorderRight = 4.15f;
	
	private float startGameTime;
	// Use this for initialization
	void Start ()
	{
		startGameTime=gameTime;
	InvokeRepeating ("countDown", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (lives <= 0) {
			//Application.LoadLevel ("sceneScreenLose");
			removeAllEnemies();
			PlayerPrefs.SetInt ("PlayerScore", score);
			
			score = 0;
			lives = startLives;
		}
		
		if (gameTime <= 0) {
			//Application.LoadLevel ("sceneScreenWin");
			removeAllEnemies();
			PlayerPrefs.SetInt ("PlayerScore", score);
			
			score = 0;
			lives = startLives;
		}
	}

	void removeAllEnemies ()
	{
		GameObject go = GameObject.Find("prefabEnemy_One(Clone)");
		while(go!=null)
		{
			GameObject.Destroy(go);
			go = GameObject.Find("prefabEnemy_One");
		}
		
		gameEnabled=false;
		gameTime=startGameTime;
	}
	
	public bool gameEnabled=false;
	
	public void AddScore ()
	{
		score += 1;	
	}
	
	public void RemoveLife ()
	{
		lives -= 1;
	}
	
	void OnGUI ()
	{
		GUI.Label (new Rect (10f, 10f, 100f, 100f), "Score: " + score);
		GUI.Label (new Rect (10f, 25f, 100f, 100f), "Lives: " + lives);
		GUI.Label (new Rect (Screen.width / 2, 10f, 100f, 100f), "Timer: " + gameTime);
	}
	
	void countDown ()
	{
		if (gameTime <= 0) {
			CancelInvoke ("countDown");
		} else {
			gameTime -= 1;
		}
	}
}