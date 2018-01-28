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
        GetComponentInChildren<SphereCollider>().radius += size;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Zombie")
            collision.transform.gameObject.GetComponent<SteeringBasics>().seek(transform.position,1f);                  
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.transform.tag == "Zombie")
            collision.transform.gameObject.GetComponent<ZombieBehaviour>().agent.moveTowards = null;
    }

    private void Update()
    {
        

    }

  





}
