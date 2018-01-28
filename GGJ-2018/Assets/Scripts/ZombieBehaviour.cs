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

            transform.rotation = Quaternion.Lerp(transform.rotation, RotateTowards(), agent.speed * Time.deltaTime);
        }
    }

    private Quaternion RotateTowards()
    {
        Vector3 vectorToTarget = agent.moveTowards.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        return q;
    }

    public void Wander()
    {

    }

    private void OnCollisionEnter(Collision collision)
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
