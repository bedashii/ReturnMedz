using UnityEngine;
using System.Collections;

public class scriptCoin : MonoBehaviour
{
    public GameObject sceneManager;
    scriptSceneManager manager;
	
	public GameObject puff;

    // Use this for initialization
    void Start()
    {
        if (sceneManager != null)
        {
            manager = GameObject.Find("sceneManager").GetComponent("scriptSceneManager") as scriptSceneManager;
        }

        RotationSpeedX *= 100;
        RotationSpeedY *= 100;
        RotationSpeedZ *= 100;
    }

    public float RotationSpeedX = 0.0f;
    public float RotationSpeedY = 0.0f;
    public float RotationSpeedZ = 0.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotationSpeedX, RotationSpeedY, Time.deltaTime * RotationSpeedZ);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            manager.AddScore();

            resetPosition(other.gameObject);
        }
    }

    void resetPosition(GameObject player)
    {
        float playerLeftEdge = player.transform.position.x - (player.renderer.bounds.size.x * 2);
        float playerRightEdge = player.transform.position.x + (player.renderer.bounds.size.x * 2);
        float playerTopEdge = player.transform.position.y + (player.renderer.bounds.size.y * 2);
        float playerBottomEdge = player.transform.position.y - (player.renderer.bounds.size.y * 2);

        if (playerLeftEdge > playerRightEdge)
        {
            Debug.Log("playerLeftEdge " + playerLeftEdge);
            Debug.Log("playerRightEdge " + playerRightEdge);
        }

        if (playerTopEdge < playerBottomEdge)
        {
            Debug.Log("playerTopEdge " + playerTopEdge);
            Debug.Log("playerBottomEdge " + playerBottomEdge);
        }

        /*
        Debug.Log ("playerLeftEdge " + playerLeftEdge);
        Debug.Log ("playerRightEdge " + playerRightEdge);
        Debug.Log ("playerTopEdge " + playerTopEdge);
        Debug.Log ("playerBottomEdge " + playerBottomEdge);
        */

        // make sure of min -> max

        float minX1 = 0.0f;
        float maxX1 = 0.0f;
        float minX2 = 0.0f;
        float maxX2 = 0.0f;

        float minY1 = 0.0f;
        float maxY1 = 0.0f;
        float minY2 = 0.0f;
        float maxY2 = 0.0f;
        /*
        Debug.Log ("BorderLeft " + (manager.BorderLeft + renderer.bounds.size.x));
        Debug.Log ("BorderRight " + (manager.BorderRight - renderer.bounds.size.x));
        */
        if (playerLeftEdge <= manager.BorderLeft + renderer.bounds.size.x)
        {
            minX1 = playerRightEdge;
            maxX1 = manager.BorderRight - renderer.bounds.size.x;
        }
        else if (playerRightEdge >= manager.BorderRight - renderer.bounds.size.x)
        {
            minX1 = manager.BorderLeft + renderer.bounds.size.x;
            maxX1 = playerLeftEdge;
        }
        else
        {
            minX1 = manager.BorderLeft + renderer.bounds.size.x;
            maxX1 = playerLeftEdge;

            minX2 = playerRightEdge;
            maxX2 = manager.BorderRight - renderer.bounds.size.x;
        }

        float newX = 0.0f;
        if (minX2 == maxX2)
        {
            newX = Random.Range(minX1, maxX1);
        }
        else
        {
            int leftRight = Random.Range(0, 2);
            if (leftRight < 1)
            {
                newX = Random.Range(minX1, maxX1);
            }
            else
            {
                newX = Random.Range(minX2, maxX2);
            }
        }
        /*
        Debug.Log ("BorderTop " + (manager.BorderTop - renderer.bounds.size.y));
        Debug.Log ("BorderBottom " + (manager.BorderBottom + renderer.bounds.size.y));
        */
        if (playerTopEdge >= manager.BorderTop - renderer.bounds.size.y)
        {
            maxY1 = playerBottomEdge;
            minY1 = manager.BorderBottom + renderer.bounds.size.y;
        }
        else if (playerBottomEdge <= manager.BorderBottom + renderer.bounds.size.y)
        {
            maxY1 = manager.BorderTop - renderer.bounds.size.y;
            minY1 = playerTopEdge;
        }
        else
        {
            maxY1 = manager.BorderTop - renderer.bounds.size.y;
            minY1 = playerTopEdge;

            maxY2 = playerBottomEdge;
            minY2 = manager.BorderBottom + renderer.bounds.size.y;
        }

        float newY = 0.0f;
        if (minY2 == maxY2)
        {
            newY = Random.Range(minY1, maxY1);
        }
        else
        {
            int topBottom = Random.Range(0, 2);
            if (topBottom < 1)
            {
                newY = Random.Range(minY1, maxY1);
            }
            else
            {
                newY = Random.Range(minY2, maxY2);
            }
        }
        //Debug.Log ("X:" + newX + ";Y:" + newY);
		Instantiate (puff, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
        transform.position = new Vector3(newX, transform.position.y, newY);
		//GameObject entrancePuff = (GameObject)Instantiate (puff, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
		
		animation.Play("animCoinEntry");
		(GetComponent("scriptLocalAnimation") as scriptLocalAnimation).ResetLocalPosition();
    }
}