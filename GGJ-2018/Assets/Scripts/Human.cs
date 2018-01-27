using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

    public float health;
    public float size;
    public float speed;
    public Transform target;

    private void Awake()
    {
        size = Random.Range(0.5f, 1.5f);
        health = 100 * size;
        speed = 3.0f - size;
        transform.localScale = new Vector3(size,size,size);
        GetComponent<CircleCollider2D>().radius += size;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Zombie")
            collision.transform.gameObject.GetComponent<Zombie>().moveTowards = transform;                  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Zombie")
            collision.transform.gameObject.GetComponent<Zombie>().moveTowards = null;
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Zombie")
        {

            //make new zombie
            //zombie 2 overloads 1 random new spawn and one with human size
            Destroy(this.transform.gameObject);
        }

        if (collision.transform.tag == "Bullet")
        {
            //health -= other.getcomponent<Bullet>().Damage;
        }
    }
  
    
}
