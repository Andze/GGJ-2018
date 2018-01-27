using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBullet : MonoBehaviour
{
    public Vector2 direction;

    [SerializeField]
    float speed;
    [SerializeField]
    float damage;
    [SerializeField]
    float lifetime;

	void Update ()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f) { Destroy(gameObject); }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<EnemyMove>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
