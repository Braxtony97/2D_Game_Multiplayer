using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public Text TextName;
    public ShootPointerBehaviour PointerBehaviour;


    private PoolObject _bulletPool;
    private Joystick _joystick;
    private Rigidbody2D _rigidbody;
    private float _horizontalInput;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PhotonView _view;
    [SerializeField] private float _speed;
    [SerializeField] Transform _bulletSpawnPoint;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _view = GetComponent<PhotonView>();
        _joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        _bulletPool = GameObject.Find("ObjectPool").GetComponent<PoolObject>();
        
    }

    private void Start()
    {
        TextName.text = _view.Owner.NickName;
        PointerBehaviour = GameObject.Find("ShootPointer").GetComponent<ShootPointerBehaviour>();
    }


    private void FixedUpdate()
    {
        _horizontalInput = _joystick.Horizontal;
        if (_view.IsMine)
        {
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

    public void Fire()
    {
            GameObject bullet = _bulletPool.GetBullet();
            bullet.transform.position = _bulletSpawnPoint.position;          
    }

    public void FlixPlayer()
    {
        if (_horizontalInput > 0)
        {
            _spriteRenderer.flipX = true;
            PointerBehaviour.RotatePointer(true);

        }
        else if (_horizontalInput < 0)
        {
            _spriteRenderer.flipX = false;
            PointerBehaviour.RotatePointer(false);
        }
    }
}
