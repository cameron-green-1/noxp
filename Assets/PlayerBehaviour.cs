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
        transform.position += Input.GetAxis("Vertical") * maxDistanceToMove * Vector3.forward;
        transform.position += Input.GetAxis("Horizontal") * maxDistanceToMove * Vector3.right;

        // Shooting
        if (Input.GetButton("Fire1"))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
