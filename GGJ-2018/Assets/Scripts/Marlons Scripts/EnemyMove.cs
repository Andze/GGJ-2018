using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    Transform tracked;

    [SerializeField]
    float health;
    [SerializeField]
    float size;
    [SerializeField]
    float speed;

    Controller2D controller;

    Vector3 mousePos;
    float angle;

    private void Start()
    {
        controller = GetComponent<Controller2D>();
        health = size * 10f;
        speed = 6f - (health / 10f);

        transform.localScale = size * Vector3.one;
    }

    void Update()
    {
        CalculateRotation();
        transform.localRotation = Quaternion.Euler(Vector3.forward * angle);
        Vector3 dir = transform.position - tracked.position;
        // Movement that circles 
        //controller.Move(dir.normalized * Time.deltaTime * speed, true);

        // Movement straight to player
        transform.position = transform.position + dir.normalized * Time.deltaTime * -speed;
    }

    void CalculateRotation()
    {
        mousePos = -tracked.position;
        mousePos.z = 0f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        angle = ((Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg) - (1.5f * Mathf.Rad2Deg));
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
