using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public int scoreValue;
    private GameController gameController;
    public float explosionPower;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null) Debug.Log("Cannot find 'GameController' script");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
            return;

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            EventManager.NotifyExplosion(explosionPower);
        }
        
        Destroy(gameObject);

        gameController.AddScore(scoreValue);
    }

}
