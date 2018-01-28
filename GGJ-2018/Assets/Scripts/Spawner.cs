using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject Prefab;
    public Transform Location;
    public int amount;
    public List<Zombie> zombies;
    public bool Human;

    private void Start()
    {
        if (Human)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(Prefab, (Location.position = Random.insideUnitCircle * 50), Quaternion.identity);
            }
        }
        else
        {
            zombies = new List<Zombie> { };
            for (int i = 0; i < amount; i++)
            {
                Zombie myPrefab = new Zombie(Prefab, (Location.position = Random.insideUnitCircle * 50), Quaternion.identity);
                zombies.Add(myPrefab);
            }
        }
    }
}
