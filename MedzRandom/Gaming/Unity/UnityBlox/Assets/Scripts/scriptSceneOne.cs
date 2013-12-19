using UnityEngine;
using System.Collections;

public class scriptSceneOne : MonoBehaviour
{
    scriptSceneManager manager;
    public GameObject enemyOne;
    
    // Use this for initialization
    void Start()
    {
            manager = GameObject.Find("sceneManager").GetComponent("scriptSceneManager") as scriptSceneManager;
        
        StartLevel();
    }

    public void StartLevel()
    {
        for (int i = 0; i < 2; i++)
        {
            creatEnemyOne();
        }
        lastTime = manager.gameTime;
        manager.paused = true;
    }

    public float intervals = 10.0f;
    public float lastTime = 0f;
    public int lastScore = 0;
    public int scoreInterval = 50;

    void Update()
    {
        if (manager.paused)
            return;

        // Spawn on new enemy everytime the user gets above a certain score threshold.
        if (manager.score >= lastScore + scoreInterval)
        {
            lastScore = manager.score;
            creatEnemyOne();
        }
    }

    void creatEnemyOne()
    {
        float x = 0;
        float y = 0;
        if (Random.Range(0, 2) == 0)
        {
            x = Random.Range(manager.BorderLeft, manager.BorderRight);
            if (Random.Range(0, 2) == 0)
            {
                y = manager.BorderTop;
                //Debug.Log ("x: " + x + " " + "y: " + y);
            }
            else
            {
                y = manager.BorderBottom;
                //Debug.Log ("x: " + x + " " + "y: " + y);
            }
        }
        {
            if (Random.Range(0, 2) == 0)
            {
                x = manager.BorderLeft;
            }
            else
            {
                x = manager.BorderRight;
            }
            y = Random.Range(manager.BorderBottom, manager.BorderTop);
        }
        Quaternion quat = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        GameObject enemy = (GameObject)Instantiate(enemyOne, new Vector3(x, 0.0f, y), quat);
        //Debug.Log ("x: " + enemy.transform.position.x + " " + "y: " + enemy.transform.position.z);

        enemy.transform.parent = manager.Level;
        //enemy.GetComponent<scriptEnemy_One> ().EnemyMoveSpeed = 0.00f;
    }
}