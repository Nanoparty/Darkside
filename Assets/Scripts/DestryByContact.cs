using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameCtlr gameCtlr;

	// Use this for initialization
	void Start () {
        GameObject gameCtlrObject = GameObject.FindWithTag("GameController");
        if(gameCtlrObject != null)
        {
            gameCtlr = gameCtlrObject.GetComponent<GameCtlr>();
        }
        else
        {
            Debug.Log("GameCtrl Null");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
            return;
        if(explosion != null)
            Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameCtlr.GameOver();
        }

        gameCtlr.addScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
