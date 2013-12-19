using UnityEngine;
using System.Collections;

public class scriptPlayer : MonoBehaviour
{
	public float PlayerMoveSpeed = 1.0f;
    //Vector3 velocity = Vector3.zero;
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
		if (manager.paused)
			return;

		// Move Player Based On Input
		float transV = Input.GetAxis ("Vertical") * PlayerMoveSpeed * Time.deltaTime;
		float transH = Input.GetAxis ("Horizontal") * PlayerMoveSpeed * Time.deltaTime;

		transform.Translate (transH, 0f, transV);

		/*CharacterController controller = GetComponent<CharacterController> ();
		
        var velocity = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0.0f);
		
        controller.Move (velocity * PlayerMoveSpeed * Time.deltaTime);*/

		borderCheck ();
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

		if (transform.position.x /*- renderer.bounds.size.x / 2*/ > manager.BorderRight) {
			transform.position = new Vector3 (manager.BorderRight, transform.position.y, transform.position.z);
		} else if (transform.position.x /*+ renderer.bounds.size.x / 2*/ < manager.BorderLeft) {
			transform.position = new Vector3 (manager.BorderLeft, transform.position.y, transform.position.z);

		}
		if (transform.position.z /*- renderer.bounds.size.y / 2*/ > manager.BorderTop) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, manager.BorderTop);

		} else if (transform.position.z /*+ renderer.bounds.size.y / 2*/ < manager.BorderBottom) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, manager.BorderBottom);
		}
	}

	/*void OnDrawGizmos()
    {
        if (collider != null)
        {
            Gizmos.DrawWireCube(transform.position, collider.bounds.size * 2);
        }
    }*/
	
	
}