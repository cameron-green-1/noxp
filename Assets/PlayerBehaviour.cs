using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public GameObject bulletPrefab;
    public float secondsBetweenShots;

    private float secondsSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShot = secondsBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = inputVector * speed;

        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        // Face the new position
        transform.LookAt(cursorPosition);

        // Firing
        secondsSinceLastShot += Time.deltaTime;
        if (Input.GetButton("Fire1") && secondsSinceLastShot >= secondsBetweenShots)
        {
            secondsSinceLastShot = 0;
            Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
        }
    }
}
