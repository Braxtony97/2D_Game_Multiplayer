using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private bool flipRigth = true;
    private Rigidbody2D _rigidbody;
    private float _horizontalInput;
    private float _verticalInput;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        MovePlayer();
        
    }

    private void MovePlayer()
    {
        if (_horizontalInput != 0)
        {
            _rigidbody.velocity = new Vector2(_speed * _horizontalInput, 0f);
            _animator.SetBool("Running", true);
            if (_horizontalInput > 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_horizontalInput < 0)
            {
                _spriteRenderer.flipX = false;
            }
        }

        else 
        {
            _animator.SetBool("Running", false);
        }  
    }
}
