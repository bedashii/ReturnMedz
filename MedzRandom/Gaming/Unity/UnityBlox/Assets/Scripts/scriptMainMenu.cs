using UnityEngine;
using System.Collections;

public class scriptMainMenu : MonoBehaviour
{
		public GUISkin mySkin;
		public Color[] FontColors;
		int startingColour = 0;
		GUIStyle myStyle = new GUIStyle ();
		float maxMessageWidth = 0.0f;
		float maxMessageHeight = 0.0f;

		public void CreateMultiColouredLabel (Rect rect, string message)
		{
				float startLocation = rect.x;
				float spaceUsed = 0.0f;
		
				if (startingColour == 0 && FontColors.Length != 0) {
						startingColour = Random.Range (FontColors.Length, (FontColors.Length) * 2);
				}
		
				for (int i = 0; i < message.Length; i++) {
						GUI.color = FontColors [(i + startingColour) % FontColors.Length];
			
						float charWidth = myStyle.CalcSize (new GUIContent (message [i].ToString ())).x;
						GUI.Label (new Rect (startLocation + spaceUsed, rect.y, charWidth, rect.height), message [i].ToString ());
						spaceUsed += charWidth;
				}
		
				GUI.color = FontColors [startingColour - FontColors.Length];
		}
	
		void OnGUI ()
		{
				/*if(manager==null)
			manager = new scriptSceneManager();*/

				GUI.skin = mySkin;
				Vector2 sizeOfLabel;
				string message = "";

				Color defaultColor = GUI.color;

				// Score
				message = "Blox";
				GUI.skin.label.fontSize =
		myStyle.fontSize = Mathf.FloorToInt ((float)(Screen.width / 6));
				sizeOfLabel = myStyle.CalcSize (new GUIContent (message));
				CreateMultiColouredLabel (new Rect (Screen.width / 2 - sizeOfLabel.x / 2, 10f, sizeOfLabel.x + 10f, sizeOfLabel.y + 10f), "" + message);
				GUI.color = defaultColor;
		

				myStyle.fontSize =
        GUI.skin.button.fontSize = Mathf.FloorToInt ((float)(Screen.width / 36.125));

				//Debug.Log("W:"+Screen.width+" H:"+Screen.height);
				//string message = "Play";
        
				Vector2 messageSize;

				if (maxMessageWidth == 0.0f || maxMessageHeight == 0.0f) {
						messageSize = myStyle.CalcSize (new GUIContent ("Play"));
						if (messageSize.x > maxMessageWidth) {
								maxMessageWidth = messageSize.x;
						}
						if (messageSize.y > maxMessageHeight) {
								maxMessageHeight = messageSize.y;
						}

						messageSize = myStyle.CalcSize (new GUIContent ("Credits"));

						if (messageSize.x > maxMessageWidth) {
								maxMessageWidth = messageSize.x;
						}
						if (messageSize.y > maxMessageHeight) {
								maxMessageHeight = messageSize.y;
						}

						messageSize = myStyle.CalcSize (new GUIContent ("Exit"));
						if (messageSize.x > maxMessageWidth) {
								maxMessageWidth = messageSize.x;
						}
						if (messageSize.y > maxMessageHeight) {
								maxMessageHeight = messageSize.y;
						}

						maxMessageWidth *= 2;
						maxMessageHeight *= 2;
				}

				//messageSize = myStyle.CalcSize (new GUIContent (message));

				if (GUI.Button (new Rect ((Screen.width / 2) - (maxMessageWidth / 2), (Screen.height * 0.45f) - (maxMessageHeight / 2), maxMessageWidth, maxMessageHeight), "Play")) {
						Application.LoadLevel ("sceneOne");
				}
				if (GUI.Button (new Rect ((Screen.width / 2) - (maxMessageWidth / 2), (Screen.height * 0.6f) - (maxMessageHeight / 2), maxMessageWidth, maxMessageHeight), "High score")) {
						Application.LoadLevel ("sceneHighScore");
				}		
				if (GUI.Button (new Rect ((Screen.width / 2) - (maxMessageWidth / 2), (Screen.height * 0.75f) - (maxMessageHeight / 2), maxMessageWidth, maxMessageHeight), "Credits")) {
						Application.LoadLevel ("sceneCredits");
				}
				if (GUI.Button (new Rect ((Screen.width / 2) - (maxMessageWidth / 2), (Screen.height * 0.9f) - (maxMessageHeight / 2), maxMessageWidth, maxMessageHeight), "Exit")) {
						Application.Quit ();
				}
		}
}
