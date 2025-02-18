using System;
using Unity.Mathematics;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private Direction bulletDirection;
    [SerializeField] private Enemy_Bullet bulletToSpawn;

    [SerializeField] private float fireRate = 2f;
    private float _currentTime = 0f;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= fireRate)
        {
            Enemy_Bullet bullet = Instantiate(bulletToSpawn, muzzle.position, quaternion.identity);

            Vector3 direction = (bulletDirection) switch
            {
                Direction.Left => Vector3.left,
                Direction.Right => Vector3.right,
                _ => throw new NotImplementedException(),
            };

            muzzle.localPosition = new Vector3(direction.x, 0f);

            bullet.SetVelocity(direction);

            _currentTime = 0f;
        }
    }

    private enum Direction { Left, Right }
}
