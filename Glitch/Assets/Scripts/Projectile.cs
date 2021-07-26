using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    //[SerializeField] float rotationSpeed = 10f;
    [SerializeField] float damage = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) //otherCollider
    {
        //Debug.Log("I hit: " + collision.name);

        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.GetComponent<Health>(); // moze i var health
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
    
}
