using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(speed);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float maxDistanceToMove = speed * Time.deltaTime;
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 movementVector = inputVector * maxDistanceToMove;
        Vector3 newPosition = transform.position + movementVector;

        transform.LookAt(newPosition);
        transform.position = newPosition;

        // Shooting
        if (Input.GetButton("Fire1"))
        {
            Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
        }
    }
}
