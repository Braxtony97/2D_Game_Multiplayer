using Photon.Pun;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick Joystick;

    private Rigidbody2D _rigidbody;
    private float _horizontalInput;
    private float _verticalInput;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PhotonView _view;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_view.IsMine)
        {
            _horizontalInput = Joystick.Horizontal;
            _verticalInput = Joystick.Vertical;
            MovePlayer();
        } 
    }

    private void MovePlayer()
    {
        if (_horizontalInput != 0)
        {
            _rigidbody.velocity = new Vector2(_speed * _horizontalInput, 0f);
            _animator.SetBool("Running", true);
            FlixPlayer();
            
        }

        else 
        {
            _animator.SetBool("Running", false);
        }  
    }

    public void FlixPlayer()
    {
        if (_horizontalInput > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_horizontalInput < 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
