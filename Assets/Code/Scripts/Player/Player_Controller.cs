using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    [field: SerializeField] public Movement_Player Movement { get; private set; }
    [field: SerializeField] public Shooting Shooting { get; private set; }
    [field: SerializeField] public Death_Component DeathComponent { get; private set; }

    public BoxCollider2D BoxCollider2D { get; private set; }

    private void Awake() => BoxCollider2D = GetComponent<BoxCollider2D>();

    //private void OnEnable() => DeathComponent.OnDeath += DisableScripts;
    //private void OnDisable() => DeathComponent.OnDeath -= DisableScripts;

    //private void DisableScripts()
    //{
    //    Movement.moveSpeed(Vector2.up, 7, 1, ForceMode2D.Impulse);

    //    Movement.enabled = false;
    //    Shooting.enabled = false;

    //    BoxCollider2D.enabled = false;
    //}
}
