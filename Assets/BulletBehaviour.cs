using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision thisCollision)
    {
        GameObject enemyGameObject = thisCollision.gameObject;

        if (enemyGameObject.GetComponent<EnemyBehaviour>() != null)
        {
            Destroy(enemyGameObject);
            Destroy(gameObject);
        }
    }
}
