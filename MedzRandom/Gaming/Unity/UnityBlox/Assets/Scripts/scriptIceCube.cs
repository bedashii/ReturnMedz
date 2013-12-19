using UnityEngine;
using System.Collections;

public class scriptIceCube : MonoBehaviour
{
    public float RotationSpeedX = 0.0f;
    public float RotationSpeedY = 0.0f;
    public float RotationSpeedZ = 0.0f;
    public float MoveSpeed = 0.1f;

    private scriptSceneManager manager;
    private Vector3 direction = Vector3.left;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("sceneManager").GetComponent("scriptSceneManager") as scriptSceneManager;

        RotationSpeedX *= 100;
        RotationSpeedY *= 100;
        RotationSpeedZ *= 100;
        MoveSpeed *= 10;

        // Left
        if (transform.position.x < renderer.bounds.size.x / 2)
        {
            // Top
            if (transform.position.y < renderer.bounds.size.y / 2)
            {
                if (Random.Range(0, 2) == 0)
                {
                    //Debug.Log("TOP LEFT - 0 - RIGHT");
                    direction = Vector3.right;
                }
                else
                {
                    //Debug.Log("TOP LEFT - 1 - DOWN");
                    direction = Vector3.down;
                }
            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    //Debug.Log("BOTTOM LEFT - 0 - RIGHT");

                    direction = Vector3.right;
                }
                else
                {
                    //Debug.Log("BOTTOM LEFT - 1 - UP");

                    direction = Vector3.up;
                }
            }
        }
        else
        {
            if (transform.position.y < renderer.bounds.size.y / 2)
            {
                if (Random.Range(0, 2) == 0)
                {
                    //Debug.Log("TOP RIGHT - 0 - LEFT");
                    direction = Vector3.left;
                }
                else
                {
                    //Debug.Log("TOP RIGHT - 1 - DOWN");
                    direction = Vector3.down;
                }
            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    //Debug.Log("BOTTOM RIGHT - 0 - LEFT");

                    direction = Vector3.left;
                }
                else
                {
                    //Debug.Log("BOTTOM RIGHT - 1 - UP");

                    direction = Vector3.up;
                }
            }
        }

        cube = GameObject.Find("Cube");
    }

    void Update()
    {
        if (!manager.paused)
        {
            Vector3 newPosition = Vector3.zero;
            if (direction == Vector3.left)
            {
                newPosition = new Vector3(transform.position.x - MoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if (direction == Vector3.up)
            {
                newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + MoveSpeed * Time.deltaTime);
            }
            else if (direction == Vector3.right)
            {
                newPosition = new Vector3(transform.position.x + MoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if (direction == Vector3.down)
            {
                newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - MoveSpeed * Time.deltaTime);
            }

            transform.position = newPosition;
            transform.Rotate(RotationSpeedX * Time.deltaTime, RotationSpeedY * Time.deltaTime, RotationSpeedZ * Time.deltaTime);

            borderCheck();
        }
    }

    public GameObject prefabIce;

    void FixedUpdate()
    {
        if (!manager.paused)
        {
            Instantiate(prefabIce, transform.position, this.transform.rotation);
        }
    }

    GameObject cube;

    void borderCheck()
    {
        if (cube == null)
            return;

        if (transform.position.x - cube.renderer.bounds.size.x / 2 > manager.BorderRight)
        {
            this.Destroy(gameObject);
        }
        else if (transform.position.x + cube.renderer.bounds.size.x / 2 < manager.BorderLeft)
        {
            this.Destroy(gameObject);
        }
        else if (transform.position.z - cube.renderer.bounds.size.z / 2 > manager.BorderTop)
        {
            this.Destroy(gameObject);
        }
        else if (transform.position.z + cube.renderer.bounds.size.z / 2 < manager.BorderBottom)
        {
            this.Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("ICECUBE IMPACT " + other);
        if (other.gameObject.tag == "Player")
        {
            manager.activateSpecialSlowMotion();
            this.Destroy(gameObject);
        }
    }
}