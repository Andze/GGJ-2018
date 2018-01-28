using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie {

    public float health;
    public float size;
    public float speed;
    public static int ID = 0;
    public int ZombieID;
    public Transform moveTowards = null;
    public GameObject Apperance;

    public Zombie(GameObject prefab, Vector3 location, Quaternion Rotation )
    {
        this.ZombieID = GetID();
        this.Apperance = GameObject.Instantiate(prefab, location , Rotation);
        this.Apperance.GetComponent<ZombieBehaviour>().agent = this;
        this.Apperance.name = "Zombie" + this.ZombieID;
        this.size = Random.Range(0.5f, 1.5f);
        this.speed = 3.0f - size;
        this.health = 100 * size;
        this.Apperance.transform.localScale = new Vector3(size, size, size);
    }

    public Zombie(GameObject prefab, Vector3 location, Quaternion Rotation, float agentSize)
    {
        this.ZombieID = GetID();
        this.Apperance = GameObject.Instantiate(prefab, location, Rotation);
        this.Apperance.GetComponent<ZombieBehaviour>().agent = this;
        this.Apperance.name = "Zombie" + this.ZombieID;
        this.size = agentSize;
        this.speed = 3.0f - this.size;
        this.health = 100 * this.size;
        this.Apperance.transform.localScale = new Vector3(this.size, this.size, this.size);
    }

 
    public void Infect(GameObject Prefab, Transform infected)
    {
        Zombie myZombie = new Zombie(Prefab, infected.position , infected.rotation, infected.gameObject.GetComponent<Human>().size);

        infected.gameObject.GetComponentInChildren<NearSensor>().targets.Remove(infected.gameObject.GetComponent<Rigidbody>());
        GameObject.Destroy(infected.gameObject);
    }
    
    static int GetID()
    {
        return ID++;
    }
}
