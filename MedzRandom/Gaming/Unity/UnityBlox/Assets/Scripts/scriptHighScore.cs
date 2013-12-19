using UnityEngine;
using System.Collections;

public class scriptHighScore : MonoBehaviour
{
		public GUISkin mySkin;
		public Color[] FontColors;
		int startingColour = 0;
		GUIStyle myStyle = new GUIStyle ();
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

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
				// Header Bounds
				GUI.Box (new Rect (Screen.width * 0.1f, Screen.height * 0.05f, Screen.width * 0.8f, Screen.height * 0.15f), "");

				GUI.skin = mySkin;
				Vector2 sizeOfLabel;
				string message = "";
		
				Color defaultColor = GUI.color;
		
				// Score
				message = "High Score";
				GUI.skin.label.fontSize =
			myStyle.fontSize = Mathf.FloorToInt ((float)(Screen.width / 12));
				sizeOfLabel = myStyle.CalcSize (new GUIContent (message));
				CreateMultiColouredLabel (new Rect (Screen.width / 2 - sizeOfLabel.x / 2, 10f, sizeOfLabel.x + 10f, sizeOfLabel.y + 10f), "" + message);
				GUI.color = defaultColor;
		
		
				// High Score Bounds
				//GUI.Box (new Rect (Screen.width * 0.1f, Screen.height * 0.225f, Screen.width * 0.8f, Screen.height * 0.675f), "");

                //float scoreLoactionHeight = 0.235f;

				// Local Button
				//GUI.Button (new Rect (Screen.width * 0.11f, Screen.height * scoreLoactionHeight, Screen.width * 0.38f, Screen.height * 0.04f), "Local");
				// Global Button
				//GUI.Button (new Rect (Screen.width * 0.51f, Screen.height * scoreLoactionHeight, Screen.width * 0.38f, Screen.height * 0.04f), "Global");

				GUI.skin.label.fontSize = Mathf.FloorToInt ((float)(Screen.width / 48));

				GUIStyle centeredStyle = new GUIStyle (GUI.skin.label);
				centeredStyle.alignment = TextAnchor.UpperCenter;

				GUIStyle leftStyle = new GUIStyle (GUI.skin.label);
				leftStyle.alignment = TextAnchor.UpperLeft;

				float scoreInitWidth = 0.1f;
				float scoreInitHeight = 0.32f;
				//float scorePadding = 0.005f;
				float scoreHeight = 0.055f;
				float scoreAHeight = Screen.height * (scoreHeight * 2);
				float scoreY = 0.0f;

				float scorePositionX = Screen.width * (scoreInitWidth);
				float scorePositionWidth = 0.15f;
				float scorePositionAWidth = Screen.width * (scorePositionWidth);

				float scoreNameX = Screen.width * (0.25f);
				float scoreNameWidth = 0.325f;
				float scoreNameAWidth = Screen.width * scoreNameWidth;

				float scoreX = Screen.width * (0.25f + scoreNameWidth);
				float scoreWidth = scoreNameWidth;
				float scoreAWidth = Screen.width * (scoreWidth);

				// Draw Table Boxes Here

				//GUI.Box (new Rect(scorePositionX),"");

				GUI.Label (new Rect (scorePositionX, Screen.height * (0.25f), scorePositionAWidth, scoreAHeight), "Position", centeredStyle);
				GUI.Label (new Rect (scoreNameX, Screen.height * (0.25f), scoreNameAWidth, scoreAHeight), "Name", centeredStyle);
				GUI.Label (new Rect (scoreX, Screen.height * (0.25f), scoreAWidth, scoreAHeight), "Score", centeredStyle);

				for (int i=0; i<10; i++) {
						// General
						scoreY = Screen.height * (scoreInitHeight + (i * scoreHeight));

						//Postition
						GUI.Label (new Rect (scorePositionX, scoreY, scorePositionAWidth, scoreAHeight), (i + 100001).ToString (), centeredStyle);
						
						// Name
						GUI.Label (new Rect (scoreNameX, scoreY, scoreNameAWidth, scoreAHeight), "Derp", centeredStyle);

						// Score
						GUI.Label (new Rect (scoreX, scoreY, scoreAWidth, scoreAHeight), Random.Range (10000, 100000000).ToString (), centeredStyle);
				}
				GUI.skin.button.fontSize =
		GUI.skin.label.fontSize =
			myStyle.fontSize = Mathf.FloorToInt ((float)(Screen.width / 50));

				// Menu Button
				if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.925f, Screen.width * 0.2f, Screen.height * 0.05f), "Main Menu")) {
						Application.LoadLevel ("sceneMainMenu");
				}

				// Retry Button
				if (GUI.Button (new Rect (Screen.width * 0.55f, Screen.height * 0.925f, Screen.width * 0.2f, Screen.height * 0.05f), "Retry")) {
						Application.LoadLevel ("sceneOne");
				}
		}
}