using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _bulletSpeed = 8.0f;
    private PlayerBehaviour _playerBehaviour;

    void Start()
    {
        _playerBehaviour = GetComponent<PlayerBehaviour>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.right * _bulletSpeed;

    }
}

