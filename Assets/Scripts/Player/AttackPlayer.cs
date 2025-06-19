using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] KeyCode _fireButton;
    /*
    [SerializeField] GameObject _muzzleFlash;
    [SerializeField] Transform _muzzleFlashPoint;
    */
    [SerializeField] Transform[] _firePoint;
    [SerializeField] float _damage;
    [SerializeField] float _firePower;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _attackSpeed;
    //[SerializeField] AudioSource _fireSound;

    [SerializeField] float _repeatSpeed;
    [SerializeField] int _repeatAttack = 1;

    AudioSource _attackSound;

    float cooldown;

    void Start()
    {
        _attackSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(_fireButton) && cooldown <= 0f)
        {
            cooldown = _attackSpeed;
            StartCoroutine(Attack());
        }

        if (cooldown > 0f) cooldown -= Time.deltaTime;
    }

    IEnumerator Attack()
    {
        for (int i = 0; i < _repeatAttack; i++)
        {
            yield return new WaitForSeconds(0.1f);
            /*
            GameObject flash = Instantiate(_muzzleFlash, _muzzleFlashPoint.position, _muzzleFlashPoint.rotation);
            flash.transform.SetParent(_muzzleFlashPoint);
            */

            foreach (Transform t in _firePoint)
            {
                Fire(t);
            }
        }
    }

    void Fire(Transform FirePoint)
    {
        if (_attackSound != null) _attackSound.Play();

        GameObject bullet = Instantiate(_projectilePrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.transform.right * _firePower, ForceMode2D.Impulse);

        bullet.GetComponentInChildren<Projectile>().Damage = _damage;
    }
}
