using UnityEngine;
using System.Collections;

public class scriptEnemy_One : MonoBehaviour
{
    public float enemyWaitTime = 0.1f;
    public float EnemyMoveSpeed = 0.1f;
    private float EnemyMoveSpeedReference;

    public GameObject sceneManager;
    public GameObject explosion;

    private scriptSceneManager manager;
    private Vector3 direction = Vector3.left;

    // Use this for initialization
    void Start()
    {
        if (sceneManager != null)
        {
            manager = GameObject.Find("sceneManager").GetComponent("scriptSceneManager") as scriptSceneManager;
        }

        EnemyMoveSpeed *= 100;
        EnemyMoveSpeedReference = EnemyMoveSpeed;

        int dir = Random.Range(1, 4);
        switch (dir)
        {
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
    }

    public float SpecialFreezeSpeedMultiplier = 0.25f;

    // Update is called once per frame
    void Update()
    {
        if (!manager.paused)
        {
            if (manager.specialSlowMotionCounter > 0)
            {
                if (EnemyMoveSpeed == EnemyMoveSpeedReference)
                {
                    EnemyMoveSpeed *= SpecialFreezeSpeedMultiplier;
                }
            }
            else
            {
                EnemyMoveSpeed = EnemyMoveSpeedReference;
            }

            Vector3 newPosition = Vector3.zero;
            if (direction == Vector3.left)
            {
                newPosition = new Vector3(transform.position.x - EnemyMoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if (direction == Vector3.up)
            {
                newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + EnemyMoveSpeed * Time.deltaTime);
            }
            else if (direction == Vector3.right)
            {
                newPosition = new Vector3(transform.position.x + EnemyMoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if (direction == Vector3.down)
            {
                newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - EnemyMoveSpeed * Time.deltaTime);
            }

            transform.position = newPosition;

            borderCheck();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (enabled && other.gameObject.tag == "Player")
        {

            die();

            manager.RemoveLife();

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

    public void die()
    {
        // Explode
        Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);

        resetPosition();
    }

    void resetPosition()
    {
        //Debug.Log("Reset Position");
        int dir = Random.Range(1, 4);
        switch (dir)
        {
            case 1:
                direction = Vector3.left;
                transform.position = new Vector3(manager.BorderRight + renderer.bounds.size.x / 2, transform.position.y, Random.Range(manager.BorderBottom, manager.BorderTop));
                break;
            case 2:
                direction = Vector3.up;
                transform.position = new Vector3(Random.Range(manager.BorderBottom, manager.BorderTop), transform.position.y, manager.BorderBottom - renderer.bounds.size.z / 2);
                break;
            case 3:
                direction = Vector3.right;

                transform.position = new Vector3(manager.BorderLeft - renderer.bounds.size.x / 2, transform.position.y, Random.Range(manager.BorderBottom, manager.BorderTop));
                break;
            case 4:
                direction = Vector3.down;
                transform.position = new Vector3(Random.Range(manager.BorderBottom, manager.BorderTop), transform.position.y, manager.BorderTop + renderer.bounds.size.z / 2);
                break;
        }

        enabled = false;
        Invoke("ReEnable", enemyWaitTime);
    }

    void ReEnable()
    {
        enabled = true;
    }

    void borderCheck()
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
        if (transform.position.x - renderer.bounds.size.x / 2 > manager.BorderRight)
        {
            resetPosition();
        }
        else if (transform.position.x + renderer.bounds.size.x / 2 < manager.BorderLeft)
        {
            resetPosition();
        }
        else if (transform.position.z - renderer.bounds.size.z / 2 > manager.BorderTop)
        {
            resetPosition();
        }
        else if (transform.position.z + renderer.bounds.size.z / 2 < manager.BorderBottom)
        {
            resetPosition();
        }
    }

    void OnDrawGizmos()
    {
        if (collider != null)
        {
            Gizmos.DrawWireCube(transform.position, collider.bounds.size * 2);
        }
    }
}