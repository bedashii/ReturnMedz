using UnityEngine;
using System.Collections;

public class scriptPlayer : MonoBehaviour
{
	public float PlayerMoveSpeed = 1.0f;
	Vector3 velocity = Vector3.zero;
	public GameObject sceneManager;
	scriptSceneManager manager;
	
	// Use this for initialization
	void Start ()
	{
		if (sceneManager != null) {
			manager = GameObject.Find ("sceneManager").GetComponent ("scriptSceneManager") as scriptSceneManager;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Move Player Based On Input
		float transV = Input.GetAxis ("Vertical") * PlayerMoveSpeed * Time.deltaTime;
		float transH = Input.GetAxis ("Horizontal") * PlayerMoveSpeed * Time.deltaTime;
		
		transform.Translate (transH, 0f, transV);
		
		detectCollision ();
		
		/*CharacterController controller = GetComponent<CharacterController> ();
		
		var velocity = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0.0f);
		
		controller.Move (velocity * PlayerMoveSpeed * Time.deltaTime);*/
		
		borderCheck ();
	}

	void detectCollision ()
	{
		// check all directions if objects are within half the players distance
		// what about edges?
		detectCollision (Vector3.forward);
		detectCollision (Vector3.back);
		detectCollision (Vector3.left);
		detectCollision (Vector3.right);
	}
	
	void detectCollision (Vector3 direction)
	{
		Plane plane = new Plane(transform.position,Vector3.zero);
		//Debug.Log ("detectCollision");
		//Debug.Log("MyPostion " +transform.position);
		Ray ray = new Ray (transform.position, direction);
		Debug.DrawRay (transform.position, direction);
		RaycastHit hit = new RaycastHit ();
		if (plane.Raycast (ray, out hit, (renderer.bounds.size.y))) {
			//if (hit.collider.tag != "player")
			{
				// Do something if hit
				if (direction.x != 0) {
					if (direction.x < 0)
						Debug.Log ("Left " + hit.collider);
					else
						Debug.Log ("Right " + hit.collider);
				} else {
					if (direction.y < 0)
						Debug.Log ("Down " + hit.collider);
					else
						Debug.Log ("Up " + hit.collider);
				}
			}
		}
	}

	void borderCheck ()
	{
		/*if (transform.position.x - renderer.bounds.size.x / 2 > BorderRight) {
			transform.position = new Vector3 (BorderLeft - renderer.bounds.size.x / 2, transform.position.y, transform.position.z);
		} else if (transform.position.x + renderer.bounds.size.x / 2 < BorderLeft) {
			transform.position = new Vector3 (BorderRight + renderer.bounds.size.x / 2, transform.position.y, transform.position.z);
		}
		
		if (transform.position.y - renderer.bounds.size.y / 2 > BorderTop) {
			transform.position = new Vector3 (transform.position.x, BorderBottom - renderer.bounds.size.y / 2, transform.position.z);
		} else if (transform.position.y + renderer.bounds.size.y / 2 < BorderBottom) {
			transform.position = new Vector3 (transform.position.x, BorderTop + renderer.bounds.size.y / 2, transform.position.z);
		}*/
		
		if (transform.position.x - renderer.bounds.size.x / 2 > manager.BorderRight) {
			transform.position = new Vector3 (manager.BorderRight, transform.position.y, transform.position.z);
		} else if (transform.position.x + renderer.bounds.size.x / 2 < manager.BorderLeft) {
			transform.position = new Vector3 (manager.BorderLeft, transform.position.y, transform.position.z);
			
		}
		if (transform.position.y - renderer.bounds.size.y / 2 > manager.BorderTop) {
			transform.position = new Vector3 (transform.position.x, manager.BorderTop, transform.position.z);
			
		} else if (transform.position.y + renderer.bounds.size.y / 2 < manager.BorderBottom) {
			transform.position = new Vector3 (transform.position.x, manager.BorderBottom, transform.position.z);
			
		}
	}
	
	void OnGUI ()
	{
		GUI.Box (new Rect ((Screen.width / 2) + transform.position.x, (Screen.height / 2) + transform.position.y, 0.1f, 0.1f), "T");
	}
}
