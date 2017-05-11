using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour {

    private GameController gameController;
    public GameObject playerExplosion;
    public float explosionForce;

    // Use this for initialization
    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null) Debug.Log("Cannot find 'GameController' script");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
            return;

        Instantiate(playerExplosion, transform.position, transform.rotation);
        EventManager.NotifyExplosion(explosionForce);

        Destroy(gameObject);

        gameController.GameOver();
    }
}
