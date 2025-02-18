using UnityEngine;

public class Push_Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 direction = new Vector2(1, 0);
    private float delta;

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.transform.Translate(_speed * Time.deltaTime * direction);
        delta = Mathf.Abs(this.transform.position.z - this.transform.position.z);
    }
}
