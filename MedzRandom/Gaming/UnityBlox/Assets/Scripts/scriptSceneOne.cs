using UnityEngine;
using System.Collections;

public class scriptSceneOne : MonoBehaviour
{
	public GameObject sceneManager;
	scriptSceneManager manager;
	public GameObject enemyOne;
	// Use this for initialization
	void Start ()
	{
		if (sceneManager != null) {
			manager = GameObject.Find ("sceneManager").GetComponent ("scriptSceneManager") as scriptSceneManager;
		}
		
		for (int i=0; i<1; i++) {
			creatEnemyOne ();
		}
		lastTime = manager.gameTime;
		manager.gameEnabled=true;	
	}
	
	public float intervals = 10.0f;
	public float lastTime = 0f;
	
	// Update is called once per frame
	void Update ()
	{
		// Spawn one new enemy once every interval
		/*if (lastTime - manager.gameTime > intervals) {
			lastTime = manager.gameTime;
			creatEnemyOne ();
		}*/
	}
	
	void creatEnemyOne ()
	{
		int x = Random.Range ((int)manager.BorderLeft, (int)manager.BorderRight);
		int y = Random.Range ((int)manager.BorderBottom, (int)manager.BorderTop);
		Quaternion quat = new Quaternion (0.0f, 180.0f, 0.0f, 0.0f);
		GameObject enemy = (GameObject)Instantiate (enemyOne, new Vector3 (x, 0.0f, y), quat);
			
		enemy.GetComponent<scriptEnemy_One> ().EnemyMoveSpeed = 0.00f;
	}
}