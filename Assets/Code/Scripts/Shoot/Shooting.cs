using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    public float bulletForce;

    /*HELP!!! SERVE IL DELAY*/

    public void Fire()
    {
        GameObject projectile = Instantiate(bullet, muzzle.position, muzzle.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(muzzle.right * bulletForce, ForceMode2D.Impulse);
    }
}

