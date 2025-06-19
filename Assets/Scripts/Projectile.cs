using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage;
    [SerializeField] float _duration = 5f;
    [SerializeField] bool _enemyBullet;

    [SerializeField] GameObject _parent;

    [SerializeField] bool _resetRotation;

    void Start()
    {
        if (_resetRotation) transform.rotation = Quaternion.identity;
        Destroy(_parent, _duration);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!_enemyBullet)
        {
            if (collider.gameObject.GetComponent<HPEnemy>())
            {
                collider.gameObject.GetComponent<HPEnemy>().TakeDamage(Damage);
            }

            if (collider.tag == "Enemy") Destroy(_parent);
        }
        else
        {
            if (collider.gameObject.GetComponent<PlayerHP>())
            {
                collider.gameObject.GetComponent<PlayerHP>().TakeDamage(Damage);
            }
        }

        if (collider.tag == "Map") Destroy(_parent);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "MainCamera") Destroy(_parent);
    }
}
