using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField]
    float shotSpeed;
    [SerializeField]
    int fireRate;
    [SerializeField]
    float impact;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    WeaponPosition wp;
    [SerializeField]
    GunMove gm;
    [SerializeField]
    Transform barrelPos;

    int shotCount;

    public void Shoot()
    {
        shotCount--;
        if (shotCount <= 0)
        {
            Vector3 shotDir = Vector3.forward * wp.Angle;
            GameObject shot = Instantiate(bullet, new Vector3(barrelPos.position.x, barrelPos.position.y, -1f), Quaternion.identity);
            shot.GetComponent<StandardBullet>().direction = wp.MousePos;
            shotCount = fireRate;
            gm.KnockBack(impact, -wp.MousePos);
            WorldState.Trauma += 0.32f;
        }
    }
}
