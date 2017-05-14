using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptDeleteMePlease : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {
        StartCoroutine(createMultipleExplisions());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator createMultipleExplisions()
    {
        yield return new WaitForSeconds(3.0f);

        while (true)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            Instantiate(explosion, position, transform.rotation);

            yield return new WaitForSeconds(3.0f);
        }
    }
}
