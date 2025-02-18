using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 direction = new Vector2(1, 0);
    [SerializeField] GameObject _player;
    private float distanceToTarget = 8f;
    private float delta;
    [SerializeField] private float _speedTarget;

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.transform.Translate(_speed * Time.deltaTime * direction);
        delta = Mathf.Abs(this.transform.position.z - this.transform.position.z);
        if (delta > distanceToTarget)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, _player.transform.position, _speedTarget * Time.deltaTime);
        }
    }
}
