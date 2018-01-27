using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public float health;
    public float size;
    public float speed;
    public Transform moveTowards;
    public bool hasTarget = false;

    private void Awake()
    {
        size = Random.Range(0.5f, 1.5f);
        speed = 3.0f - size;
        health = 100 * size;
        transform.localScale = new Vector3(size, size, size);
        hasTarget = false;
    }

    void Update()
    {
        if (moveTowards == null)
            Wander();
        else
            transform.position = Vector2.MoveTowards(transform.position, moveTowards.position, speed * Time.deltaTime);
    }

    void Wander()
    {

    }
}
