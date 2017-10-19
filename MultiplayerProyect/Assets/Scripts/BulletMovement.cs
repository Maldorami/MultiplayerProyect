using UnityEngine;


public class BulletMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float lifeTime = 5;

    private void Start()
    {
        //Movement
        GetComponent<Rigidbody>().velocity = transform.forward * movementSpeed;

        //Lifetime
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {        
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }

        //Destroy(gameObject);
    }
}