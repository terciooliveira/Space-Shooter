using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireDelta = 0.5f;

    private float myTime = 0.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        myTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > fireDelta)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
            myTime = 0.0f;
        }
	}

	// Called just before each physics step
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Rigidbody rb = GetComponent<Rigidbody>();

         
        if (rb.position.x >= boundary.xMax && moveHorizontal > 0.0f) moveHorizontal = 0.0f;
        if (rb.position.x <= boundary.xMin && moveHorizontal < 0.0f) moveHorizontal = 0.0f;
        if (rb.position.z <= boundary.zMin && moveVertical   < 0.0f) moveVertical   = 0.0f;
        if (rb.position.z >= boundary.zMax && moveVertical   > 0.0f) moveVertical   = 0.0f;
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        /*
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            ); */

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
