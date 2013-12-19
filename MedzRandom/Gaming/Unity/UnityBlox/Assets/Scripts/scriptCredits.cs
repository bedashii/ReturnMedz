using UnityEngine;
using System.Collections;

public class scriptCredits : MonoBehaviour
{
	public GUISkin mySkin;
	public Color[] FontColors;
	int startingColour = 0;

	GUIStyle myStyle = new GUIStyle();
    float maxMessageWidth = 0.0f;
    float maxMessageHeight = 0.0f;
    public string[] Credits;

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
	
	void OnGUI()
	{
		GUI.skin = mySkin;
		Vector2 sizeOfLabel;
		string message = "";
		
		Color defaultColor = GUI.color;
		
		// Score
		message = "Credits";
		GUI.skin.label.fontSize =
			myStyle.fontSize = Mathf.FloorToInt ((float)(Screen.width / 8));
		sizeOfLabel = myStyle.CalcSize (new GUIContent (message));
		CreateMultiColouredLabel (new Rect (Screen.width / 2 - sizeOfLabel.x / 2, 10f, sizeOfLabel.x + 10f, sizeOfLabel.y + 10f), "" + message);
		GUI.color = defaultColor;
		
		myStyle.alignment =
            GUI.skin.label.alignment =
            TextAnchor.MiddleCenter;
        myStyle.fontSize =
        GUI.skin.button.fontSize =
        GUI.skin.label.fontSize = Mathf.FloorToInt((float)(Screen.width / 48));

        //Debug.Log("W:"+Screen.width+" H:"+Screen.height);
        //string message = "Play";

        Vector2 messageSize;

        if (maxMessageWidth == 0.0f || maxMessageHeight == 0.0f)
        {


            for (int i = 0; i < Credits.Length; i++)
            {
                messageSize = myStyle.CalcSize(new GUIContent(Credits[i]));
                if (messageSize.x > maxMessageWidth)
                {
                    maxMessageWidth = messageSize.x;
                }
                if (messageSize.y > maxMessageHeight)
                {
                    maxMessageHeight = messageSize.y;
                }
            }

            //maxMessageWidth *= 2;
            maxMessageHeight *= 2;
        }

        float startPosition = Screen.height * 0.5f;
        float spaceUsed = 0;

        for (int i = 0; i < Credits.Length; i++)
        {
            GUI.Label(new Rect((Screen.width / 2) - (maxMessageWidth / 2), startPosition + spaceUsed - (maxMessageHeight / 2), maxMessageWidth, maxMessageHeight), Credits[i]);
            spaceUsed += maxMessageHeight + 10;
        }

        messageSize = myStyle.CalcSize(new GUIContent("Main Menu"));

        if(GUI.Button(new Rect((Screen.width / 2) - (messageSize.x), Screen.height * 0.9f - (messageSize.y / 2), messageSize.x * 2, messageSize.y * 2), "Main Menu"))
		{
			Application.LoadLevel("sceneMainMenu");
		}
    }
}
