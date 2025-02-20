using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{


    public GameObject bullet; // Il prefab del proiettile
    public Transform muzzle; // La posizione da cui il proiettile verrà sparato
    public float bulletForce; // La forza con cui il proiettile viene sparato
    public float fireRate = 0.5f; // Il tempo di attesa tra i colpi
    private bool canFire = true; // Controlla se il giocatore può sparare

    // Metodo per sparare
    public void Fire()
    {
        if (canFire) // Verifica se è possibile sparare (controllo del delay)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    // Coroutine che gestisce il ritardo tra i colpi
    private IEnumerator ShootWithDelay()
    {
        canFire = false; // Disabilita la possibilità di sparare immediatamente

        // Instanzia il proiettile e aggiunge la forza
        GameObject projectile = Instantiate(bullet, muzzle.position, muzzle.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(muzzle.right * bulletForce, ForceMode2D.Impulse);

        // Aspetta il tempo di ritardo specificato prima di consentire un altro colpo
        yield return new WaitForSeconds(fireRate);

        canFire = true; // Ora il giocatore può sparare di nuovo
    }
}

