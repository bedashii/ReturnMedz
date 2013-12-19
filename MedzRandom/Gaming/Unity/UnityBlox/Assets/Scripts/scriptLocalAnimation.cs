using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class scriptLocalAnimation : MonoBehaviour
{
	Vector3 localPos;
	bool wasPlaying;
	
	void Awake ()
	{
		//Debug.Log ("Waking: " + transform.position);
		localPos = transform.position;
		wasPlaying = false;
	}
	
	public void ResetLocalPosition()
	{
		localPos = transform.position;
	}
	
	void LateUpdate ()
	{
		if (!animation.isPlaying && !wasPlaying)
			return;
		
		//Debug.Log ("localPos: " + localPos);
		
		//Debug.Log (transform.localPosition);
		transform.localPosition += localPos;
		//Debug.Log (transform.localPosition);
		wasPlaying = animation.isPlaying;
	}
}
