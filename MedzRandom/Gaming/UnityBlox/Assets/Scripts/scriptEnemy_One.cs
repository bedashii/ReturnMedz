using UnityEngine;
using System.Collections;

public class scriptEnemy_One : MonoBehaviour
{
	
	public float enemyWaitTime = 0.1f;
	Vector3 direction = Vector3.left;
	public float EnemyMoveSpeed = 0.1f;
	public GameObject sceneManager;
	scriptSceneManager manager;
	
	// Use this for initialization
	void Start ()
	{
		if (sceneManager != null) {
			manager = GameObject.Find ("sceneManager").GetComponent ("scriptSceneManager") as scriptSceneManager;
		}
		
		EnemyMoveSpeed *= 100;
		
		int dir = Random.Range (1, 4);
		switch (dir) {
		case 1:
			direction = Vector3.left;
			break;
		case 2:
			direction = Vector3.up;
			break;
		case 3:
			direction = Vector3.right;
			break;
		case 4:
			direction = Vector3.down;
			break;
		}
		
		//transform.Rotate (90.0f, 0.0f, 0.0f);
		//transform.Rotate (0.0f, 180.0f, 0.0f);
		Debug.Log(renderer.bounds.size);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log(transform.position);
		if (!manager.gameEnabled) {
			
		}
		
		Vector3 newPosition = Vector3.zero;
		if (direction == Vector3.left) {
			newPosition = new Vector3 (transform.position.x - EnemyMoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		} else if (direction == Vector3.up) {
			newPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z + EnemyMoveSpeed * Time.deltaTime);
		} else if (direction == Vector3.right) {
			newPosition = new Vector3 (transform.position.x + EnemyMoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		} else if (direction == Vector3.down) {
			newPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z - EnemyMoveSpeed * Time.deltaTime);
		}
		
		//newPosition *= Time.deltaTime;
		transform.position = newPosition;
		
		borderCheck ();
	}
	
	public void CollisionDetected (GameObject otherGameObject)
	{
		if (otherGameObject.tag == "Player") {
			resetPosition ();
			manager.RemoveLife ();
			
			/*if (explosion != null) {
				Instantiate (explosion, transform.position, transform.rotation);
				if (playerDamageAudio != null) {
					audio.clip = playerDamageAudio;
					audio.Play ();
				}
			}
			resetPosition ();	*/
		}
		
		/*if (other.gameObject.tag == "Shield") {
			if (explosion != null) {
				Instantiate (explosion, transform.position, transform.rotation);
				if (shieldExplosionAudio != null) {
					audio.clip = shieldExplosionAudio;
					audio.Play ();
				}
			}
			
			resetPosition ();	
		}*/
	}
	
	void resetPosition ()
	{
		
		int dir = Random.Range (1, 4);
		switch (dir) {
		case 1:
			direction = Vector3.left;
			transform.position = new Vector3 (manager.BorderRight + renderer.bounds.size.x / 2, transform.position.y, Random.Range (manager.BorderBottom, manager.BorderTop));
			break;
		case 2:
			direction = Vector3.up;
			
			transform.position = new Vector3 (Random.Range (manager.BorderBottom, manager.BorderTop), transform.position.y, manager.BorderBottom - renderer.bounds.size.z / 2);
			break;
		case 3:
			direction = Vector3.right;
			
			transform.position = new Vector3 (manager.BorderLeft - renderer.bounds.size.x / 2, transform.position.y, Random.Range (manager.BorderBottom, manager.BorderTop));
			break;
		case 4:
			direction = Vector3.down;
			
			transform.position = new Vector3 (Random.Range (manager.BorderBottom, manager.BorderTop), transform.position.y, manager.BorderTop + renderer.bounds.size.z / 2);
			break;
		}
		
		enabled = false;
		Invoke ("ReEnable", enemyWaitTime);
	}
	
	void ReEnable ()
	{
		enabled = true;
	}
	
	void borderCheck ()
	{
		/*if (transform.position.x - renderer.bounds.size.x / 2 > BorderRight) {
			transform.position = new Vector3 (BorderLeft - renderer.bounds.size.x / 2, transform.position.y, transform.position.z);
		} else if (transform.position.x + renderer.bounds.size.x / 2 < BorderLeft) {
			transform.position = new Vector3 (BorderRight + renderer.bounds.size.x / 2, transform.position.y, transform.position.z);
		}
		
		if (transform.position.y - renderer.bounds.size.z / 2 > BorderTop) {
			transform.position = new Vector3 (transform.position.x, BorderBottom - renderer.bounds.size.z / 2, transform.position.z);
		} else if (transform.position.y + renderer.bounds.size.z / 2 < BorderBottom) {
			transform.position = new Vector3 (transform.position.x, BorderTop + renderer.bounds.size.z / 2, transform.position.z);
		}*/
		if (transform.position.x - renderer.bounds.size.x / 2 > manager.BorderRight) {
			resetPosition ();
		} else if (transform.position.x + renderer.bounds.size.x / 2 < manager.BorderLeft) {
			resetPosition ();
		} else if (transform.position.y - renderer.bounds.size.z / 2 > manager.BorderTop) {
			resetPosition ();
		} else if (transform.position.y + renderer.bounds.size.z / 2 < manager.BorderBottom) {
			resetPosition ();
		}
	}
}