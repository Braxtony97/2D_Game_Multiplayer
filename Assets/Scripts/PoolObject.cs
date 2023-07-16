using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private List<GameObject> _bullets;
    [SerializeField] private int _number = 20;
    [SerializeField] private GameObject _bulletPrefab;

    void Start()
    {
        Instantiate();
    }

    void Instantiate()
    {
        _bullets = new List<GameObject>();

        for (int i = 0; i < _number; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.parent = this.transform;
            bullet.SetActive(false);
            _bullets.Add(bullet);
        }

    }
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in _bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(_bulletPrefab);
        _bullets.Add(newBullet);
        return newBullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
