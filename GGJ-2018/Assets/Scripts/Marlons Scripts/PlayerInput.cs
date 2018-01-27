using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour
{
	Player player;
    [SerializeField]
    WeaponShoot ws;

    Vector3 start;

	void Start () {
		player = GetComponent<Player> ();
        start = transform.position;
    }

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		player.SetDirectionalInput (directionalInput);

        if (Input.GetMouseButton(0))
        {
            //ws.Shoot();
        }
        if (Input.GetKey(KeyCode.G))
        {
            WorldState.Trauma += 0.1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
