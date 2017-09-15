using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject enemyExplosion;
    private GameController gameController;
    public int scoreValue;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Can't find 'GameController'");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" ||  other.CompareTag("Enemy Bolt"))
        {
            return;
        }

        if (explosion != null)
        {
            /* if (other.CompareTag("Enemy"))
            {
                Instantiate(enemyExplosion, transform.position, transform.rotation);
            }
            else
            {*/
                Instantiate(explosion, transform.position, transform.rotation);
            //}
        }

        if (other.CompareTag("Player") || other.CompareTag("NPC"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            if (!other.CompareTag("NPC"))
                {
                    gameController.GameOver();
                }
        }
        if (other.CompareTag("Bolt"))
        {
            gameController.AddScore(scoreValue);
        }

        if (gameObject.name == "BossModel")
        {
            GameController.isBossfight = false;
        }
            

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
