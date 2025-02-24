using System.Collections;
using UnityEditor.Playables;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class Shooting : MonoBehaviour
{


    public GameObject bullet; // The prefab of the bullet
    public Transform muzzle;
    public float bulletForce;
    public float fireRate = 0.5f;
    private bool canFire = true;


    public void Fire()
    {
        if (canFire) // Check if you can shoot (delay check)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    // Coroutine that manages the delay between hits
    private IEnumerator ShootWithDelay()
    {
        canFire = false; // Disables the ability to shoot immediately

        // It instantiates the projectile and adds the force
        GameObject projectile = Instantiate(bullet, muzzle.position, muzzle.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(muzzle.right * bulletForce, ForceMode2D.Impulse);

        // Waits the specified delay time before allowing another hit
                yield return new WaitForSeconds(fireRate);

        canFire = true; // Now the player can shoot again
    }
}

