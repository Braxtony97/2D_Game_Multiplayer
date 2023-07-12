using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _bulletSpeed = 8.0f;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody)
        {
            _rigidbody.velocity = transform.right * _bulletSpeed;
            
        }
    }
}
