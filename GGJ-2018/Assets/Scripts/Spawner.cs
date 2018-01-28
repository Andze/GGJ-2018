using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject zombiePrefab;
    public Transform Location;
    public int amount;
    public List<Zombie> zombies;
    

    private void Start()
    {
        zombies = new List<Zombie>{};
        for (int i = 0; i < amount; i++)
        {
            Zombie myZombie = new Zombie(zombiePrefab, (Location.position = Random.insideUnitCircle * 50), Quaternion.identity);
            zombies.Add(myZombie);
        }
    }
}
