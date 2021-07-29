using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperShot : MonoBehaviour
{
    private float _lifeTime;
    private float _clock;

    private Transform _spriteRenderer;

    public void Initialize(float damage, Vector2 direction)
    {
        _lifeTime = 1.5f;
        _clock = 0;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>().transform;

        transform.eulerAngles = new Vector3(0, 0, Tools.DirectionToRotation(direction));

        RaycastHit2D[] raycastHit2D = Physics2D.RaycastAll(transform.position, direction);

        if (raycastHit2D.Length != 0)
        {
            foreach (RaycastHit2D raycast in raycastHit2D)
            {
                if (raycast.transform.tag == "PlayerShip")
                {
                    raycast.transform.GetComponent<Ship>().TakeDamage(damage);
                }
            }
        }

        Handheld.Vibrate();
    }
    private void Update()
    {
        _clock += Time.deltaTime;

        if(_spriteRenderer.localScale.x > 0)
        {
            _spriteRenderer.localScale -= new Vector3(10 * Time.deltaTime, 0);
        }
        if (_clock >= _lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
