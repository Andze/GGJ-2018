using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {

    
    public Zombie agent;

    void Update ()
    {
        if (agent.moveTowards == null)
        {
            Wander();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, agent.moveTowards.position, agent.speed * Time.deltaTime);
        }
    }

    public void Wander()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Human")
        {
            agent.Infect(agent.Apperance, collision.transform);
         
            
        }

        if (collision.transform.tag == "Bullet")
        {
            //health -= other.getcomponent<Bullet>().Damage;
        }
    }
}
