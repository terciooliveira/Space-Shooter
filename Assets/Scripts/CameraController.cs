using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float springForce;

    private Vector3 originalPos;
    private Rigidbody rb;
    private Rigidbody pivotRb;

    private void OnEnable()
    {
        EventManager.Explosion += ShakeCamera;
    }

    private void OnDisable()
    {
        EventManager.Explosion -= ShakeCamera;
    }

    // Use this for initialization
    void Start () {
        originalPos = transform.position;
        rb = GetComponent<Rigidbody>();
        pivotRb = transform.parent.GetComponent<Rigidbody>();
    }

    /*private void Update()
    {
        Debug.DrawLine(originalPos, pivotRb.transform.position, Color.red);
        Debug.DrawLine(pivotRb.transform.position, rb.transform.position, Color.yellow);
    }*/

    // Update is called once per physicsStep
    void FixedUpdate () {
        Vector3 distance = originalPos - pivotRb.transform.position;
        pivotRb.AddForce(distance * springForce);
        distance = pivotRb.transform.position - rb.transform.position;
        rb.AddForce(distance * springForce);
        pivotRb.AddForce(-distance * springForce);
    }

    void ShakeCamera(float shakeForce)
    {
        Vector2 resultingForce = Random.insideUnitCircle * shakeForce;
        rb.AddForce( resultingForce.x, 0.0f, resultingForce.y );
        //Debug.DrawLine(rb.transform.position, rb.transform.position + new Vector3(resultingForce.x, 0.0f, resultingForce.y), Color.blue, 5.0f);
        resultingForce = new Vector2(resultingForce.y, -resultingForce.x); //Random.insideUnitCircle * shakeForce;
        pivotRb.AddForce(resultingForce.x, 0.0f, resultingForce.y);
        //Debug.DrawLine(pivotRb.transform.position, pivotRb.transform.position + new Vector3(resultingForce.x, 0.0f, resultingForce.y), Color.green, 5.0f);
    }

}
