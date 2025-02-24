using System;
using UnityEngine;
using Unity.Mathematics;

public class Boos_Shooting : MonoBehaviour
{
    [SerializeField] private Transform[] muzzles;
    [SerializeField] private Direction bulletDirection;
    [SerializeField] private Enemy_Bullet bulletToSpawn;

    [SerializeField] private float fireRate = 2f;
    private float _currentTime = 0f;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        // Se è passato abbastanza tempo (fireRate), spara da tutte le bocche di fuoco
        if (_currentTime >= fireRate)
        {
            foreach (Transform muzzle in muzzles)
            {
                Enemy_Bullet bullet = Instantiate(bulletToSpawn, muzzle.position, quaternion.identity);

                Vector3 direction = (bulletDirection) switch
                {
                    Direction.Left => Vector3.left,
                    Direction.Right => Vector3.right,
                    _ => throw new NotImplementedException(),
                };

               // muzzle.localPosition = new Vector3(direction.x, 0f, muzzle.localPosition.z);

                bullet.SetVelocity(direction);
            }

            _currentTime = 0f;
        }
    }

    private enum Direction { Left, Right }
}
