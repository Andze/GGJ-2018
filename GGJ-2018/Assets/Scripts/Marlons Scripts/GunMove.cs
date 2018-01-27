using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    public Player player;

    public Transform playerPosition;
    public float followDelay;

    public int knockbackTimer;
    private int knockBack;

	void Update ()
    {
        knockBack--;
        if (knockBack <=0 )
        {
            transform.position = Vector3.Lerp(transform.position, playerPosition.position, followDelay);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, playerPosition.position, 0.25f);
        }
    }

    public void KnockBack(float kb, Vector2 dir)
    {
        player.knockbackVelocity = dir.normalized;
        Vector3 dir3 = dir.normalized * 16f * Time.deltaTime;
        transform.position = transform.position + dir3;
        if (Mathf.Abs(kb) > 0)
        { knockBack = knockbackTimer; }
    }
}
