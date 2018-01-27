using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject zombiePrefab;
    public Transform Location;
    public List<Zombie> zombies;

    private void Start()
    {
        Zombie myZombie = new Zombie(zombiePrefab, Location.position, Quaternion.identity);
        
        Zombie myZombie1 = new Zombie(zombiePrefab, Location.position, Quaternion.identity);
        zombies = new List<Zombie> { myZombie,myZombie1 };

        Debug.Log(myZombie.ZombieID + "+ " + myZombie1.ZombieID);

    }
}
