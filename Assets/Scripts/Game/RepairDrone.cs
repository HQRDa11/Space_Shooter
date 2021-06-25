using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairDrone : MonoBehaviour
{
    private Player _player;
    private float _lifeTime;
    private Ship  _target;
    private float _fireRate;
    private Vector2 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _lifeTime = 12;
        _fireRate = 0.6f;
        _velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Update_LifeTime();
        Update_Target();
        
        if (_target != null)
        {
            Update_Movement();
            Update_Action();
        }
    }

    private void Update_LifeTime()
    {
        _lifeTime -= Time.deltaTime;
        {
            if (_lifeTime <= 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }

    }

    private void Update_Target()
    {
        switch( _target == null || _target.HealthRatio >= 1f)
        {
            case true:
                _target = NewTarget();
                break;
            case false:

                break;
        }
    }
    private Ship NewTarget()
    {
        if (_player.Ship.HealthRatio < 1) return _player.Ship;
        else
        {
            for (int i = 0; i < _player.AllAllies.Length; i++)
            {
                switch (_player.AllAllies[i] != null && _player.AllAllies[i].Ship.HealthRatio < 1)
                {
                    case true:
                        return _player.AllAllies[i].Ship;
                }
            }
        }
        return null;
    }

    public void Update_Movement()
    {       
            this.gameObject.transform.position = Vector2.SmoothDamp(this.gameObject.transform.position, _target.transform.position, ref _velocity, 0.8f);
    }
    public void Update_Action()
    {
        _fireRate -= Time.deltaTime;
        if(_fireRate <=0)
        {
            RepairTarget();
            _fireRate = 0.6f;
        }
    }

    private void RepairTarget()
    {
        _target.ModifyHealth(8);
        GameObject ray = Instantiate(Resources.Load<GameObject>("Prefabs/RepairRay"));
        ray.GetComponent<RepairRay>().Initialise(this.transform, _target.transform);
    }
}
