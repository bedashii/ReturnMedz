using UnityEngine;
using System.Collections;

public class scriptSceneManager : MonoBehaviour
{
    public float gameTime = 60;
    public int score = 0;
    public int lives = 3;
    public int startLives = 3;
    public float BorderTop = 3.0f;
    public float BorderBottom = -3.0f;
    public float BorderLeft = -4.15f;
    public float BorderRight = 4.15f;
    private float startGameTime;
    public GUISkin mySkin;
    public Transform Level;
    GUIStyle myStyle = new GUIStyle();
    public Color[] FontColors;
    int startingColour = 0;

    public float iceIntervalStart = 2.0f;
    public float iceIntervalStop = 5.0f;

    public GameObject prefabBonuxBox;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");

        startGameTime = gameTime;
        InvokeRepeating("countDown", 1.0f, 1.0f);
    }

    public bool paused = true;

    // Update is called once per frame
    void Update()
    {
        var vertExtent = Camera.main.camera.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;
        Debug.Log(vertExtent);
        Debug.Log(horzExtent);

        BorderTop = vertExtent - (player.gameObject.renderer.bounds.size.z / 2);
        BorderBottom = (-vertExtent) + (player.gameObject.renderer.bounds.size.z / 2);
        BorderLeft = (-horzExtent) + (player.gameObject.renderer.bounds.size.x / 2);
        BorderRight = horzExtent - (player.gameObject.renderer.bounds.size.x / 2);

        //PlayerPrefs.SetInt ("PlayerScore", score);

        if (!paused)
        {
            if (lives <= 0)
            {
                Application.LoadLevel("sceneHighScore");
            }

            if (gameTime <= 0)
            {
                Application.LoadLevel("sceneHighScore");
            }

            instatiateIceCheck();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("sceneMainMenu");
            }
            else if (Input.anyKeyDown)
            {
                {
                    paused = false;
                }
            }
        }
    }

    public GameObject prefabIce;
    private float lastIce = 0.0f;
    private float intervalIce = 0.0f;
    void instatiateIceCheck()
    {
        if (lastIce + intervalIce < Time.time)
        {
            createSpecialIce();
            lastIce = Time.time;
            intervalIce = Random.Range(iceIntervalStart, iceIntervalStop);
        }
    }

    void createSpecialIce()
    {
        float x = 0;
        float y = 0;
        if (Random.Range(0, 2) == 0)
        {
            x = Random.Range(BorderLeft, BorderRight);
            if (Random.Range(0, 2) == 0)
            {
                y = BorderTop;
            }
            else
            {
                y = BorderBottom;
            }
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                x = BorderLeft;
            }
            else
            {
                x = BorderRight;
            }
            y = Random.Range(BorderBottom, BorderTop);
        }
        GameObject ice = (GameObject)Instantiate(prefabIce, new Vector3(x, 0.0f, y), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        //Debug.Log ("x: " + enemy.transform.position.x + " " + "y: " + enemy.transform.position.z);

        ice.transform.parent = Level;
    }

    void removeAllEnemies()
    {
        for (int i = 0; i < Level.childCount; i++)
        {
            Transform trans = Level.GetChild(i);
            if (trans != null)
                GameObject.Destroy(trans.gameObject);
        }
        paused = true;
        gameTime = startGameTime;

        Application.LoadLevel("sceneOne");
    }

    public void AddScore()
    {
        score += 10;
    }

    public void RemoveLife()
    {
        lives -= 1;
        //FlashWhenHit ();
    }

    //define Fade parameters
    /*void Fade (float start, float end, float length, GameObject currentObject)
    { 
        if (currentObject.guiTexture.color.a == start) {
            for (float i = 0.0f; i < 1.0f; i += Time.deltaTime*(1.0f/length)) { //for the length of time
				
                //lerp the value of the transparency from the start value to the end value in equal increments
                Color col = currentObject.guiTexture.color;
                col.a = Mathf.Lerp (start, end, i); 
                currentObject.guiTexture.color = col;
//yield;
                // ensure the fade is completely finished (because lerp doesn't always end on an exact value)
                col = currentObject.guiTexture.color;
                col.a = end;
                currentObject.guiTexture.color = col; 
            }
        }
    }
 
    void FlashWhenHit ()
    {
        Fade (0.0f, 0.8f, 0.5f, guiTexture.gameObject);
        //yield WaitForSeconds (.01);
        Fade (0.8f, 0.0f, 0.5f, guiTexture.gameObject);
    }*/

    public void CreateMultiColouredLabel(Rect rect, string message)
    {
        float startLocation = rect.x;
        float spaceUsed = 0.0f;

        if (startingColour == 0 && FontColors.Length != 0)
        {
            startingColour = Random.Range(FontColors.Length, (FontColors.Length) * 2);
        }

        for (int i = 0; i < message.Length; i++)
        {
            GUI.color = FontColors[(i + startingColour) % FontColors.Length];

            float charWidth = myStyle.CalcSize(new GUIContent(message[i].ToString())).x;
            GUI.Label(new Rect(startLocation + spaceUsed, rect.y, charWidth, rect.height), message[i].ToString());
            spaceUsed += charWidth;
        }

        GUI.color = FontColors[startingColour - FontColors.Length];
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        Vector2 sizeOfLabel;
        string message = "";

        // Score
        myStyle.fontSize = GUI.skin.label.fontSize = 16;
        sizeOfLabel = myStyle.CalcSize(new GUIContent(score.ToString()));
        CreateMultiColouredLabel(new Rect(Screen.width - sizeOfLabel.x - 10f, 10f, sizeOfLabel.x + 10f, 100f), "" + score);

        //Lives
        myStyle.fontSize = GUI.skin.label.fontSize = 16;
        message = "Lives: " + lives;
        sizeOfLabel = myStyle.CalcSize(new GUIContent(message));
        CreateMultiColouredLabel(new Rect(10f, 10f, sizeOfLabel.x, 100f), message);

        // Time
        myStyle.fontSize = GUI.skin.label.fontSize = 32;
        message = "Timer";
        sizeOfLabel = myStyle.CalcSize(new GUIContent(message));
        CreateMultiColouredLabel(new Rect((Screen.width / 2) - (sizeOfLabel.x / 2), 10f, sizeOfLabel.x, sizeOfLabel.y * 2), message);

        message = ((int)gameTime).ToString();
        sizeOfLabel = myStyle.CalcSize(new GUIContent(message));
        CreateMultiColouredLabel(new Rect((Screen.width / 2) - (sizeOfLabel.x / 2), 20f + sizeOfLabel.y, sizeOfLabel.x, sizeOfLabel.y * 2), message);

        myStyle.fontSize = GUI.skin.label.fontSize = 16;
        if (paused)
        {
            myStyle.fontSize = GUI.skin.label.fontSize = 16;
            message = "Paused, press any key to continue";
            sizeOfLabel = myStyle.CalcSize(new GUIContent(message));
            GUI.Label(new Rect((Screen.width / 2) - (sizeOfLabel.x / 2), (Screen.height / 2) - (sizeOfLabel.y / 2), sizeOfLabel.x, sizeOfLabel.y * 2), message);
        }
    }

    void countDown()
    {
        if (gameTime <= 0)
        {
            CancelInvoke("countDown");
        }
        else
        {
            if (!paused)
            {
                specialSlowMotion();

                gameTime -= countDownSpeed;
            }
        }
    }

    float countDownSpeed = 1.0f;

    float specialSlowMotionDuration = 5.0f;
    public float specialSlowMotionCounter = 0.0f;
    public float specialSlowMotionSpeed = 0.5f;

    public void activateSpecialSlowMotion()
    {
        specialSlowMotionCounter += specialSlowMotionDuration;
    }

    public void specialSlowMotion()
    {
        if (specialSlowMotionCounter > 0.0f)
        {
            if (countDownSpeed == 1.0f)
                countDownSpeed = specialSlowMotionSpeed;

            specialSlowMotionCounter -= 1.0f;
            if (specialSlowMotionCounter < 0.0f)
                specialSlowMotionCounter = 0.0f;
        }
        else
        {
            if (countDownSpeed != 1.0f)
                countDownSpeed = 1.0f;
        }
    }
}