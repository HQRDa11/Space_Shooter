using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairDrone : MonoBehaviour
{
    private Player _player;
    private Ship _owner;
    private float _lifeTime;
    private Ship  _target;
    private float _fireRate;
    private Vector2 _velocity;

    private bool _isHealing;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        _owner = _player.Assign_Drone();
        switch(_owner == null)
        {
            case true:
                GameObject.Destroy(this.gameObject);
                return;
        }
        _target = _owner;
        _lifeTime = 8;
        _fireRate = 0.6f;
        _velocity = Vector2.zero;
        _isHealing = false;
    }

    // Update is called once per frame
    void Update()
    {
        Update_Target();
        if (_target != null)
        {
        
            Update_Movement();
            switch(_isHealing)
            {
                case true:
                    Update_LifeTime();
                    Update_Action();
                    break;
            }
        }
    }

    private void Update_LifeTime()
    {
        switch (_isHealing)
        {
            case true:
                _lifeTime -= Time.deltaTime;
                {
                    if (_lifeTime <= 0)
                    {
                        _owner.hasDrone = false;
                        GameObject.Destroy(this.gameObject);
                    }
                }
                break;
            case false:
                break;
        }
    }


    private void Update_Target()
    {
        switch (NewTarget())
        {
            case true:
                _isHealing = true;
                break;

            case false:
                _target = _owner;
                _isHealing = false;
                break;
        }
    }
    private bool NewTarget()
    {
        if (_player.Ship.HealthRatio < 1) return _player.Ship;
        else
        {
            for (int i = 0; i < _player.AllAllies.Length; i++)
            {
                switch (_player.AllAllies[i] != null && _player.AllAllies[i].Ship.HealthRatio < 1)
                {
                    case true:
                        _target = _player.AllAllies[i].Ship;
                        return true;
                }
            }
        }
        return false;
    }

    public void Update_Movement()
    {
        Vector3 targetPosition = _target.transform.position + Vector3.down * 0.2f;
        switch (_isHealing)
        {
            case true:
                this.gameObject.transform.position = Vector2.SmoothDamp(this.gameObject.transform.position, targetPosition, ref _velocity, 0.6f);
                return;

            case false:
                
                    switch(Vector2.Distance(this.gameObject.transform.position, targetPosition) <= 0.5f) 
                    {
                        case true:
                            this.gameObject.transform.position = targetPosition;

                        return;
                        case false:
                            this.gameObject.transform.position = Vector2.SmoothDamp(this.gameObject.transform.position, targetPosition, ref _velocity, 0.6f);
                        return;
                    }
        }
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
        _target.ModifyHealth(2);
        GameObject ray = Instantiate(Resources.Load<GameObject>("Prefabs/RepairRay"));
        ray.GetComponent<RepairRay>().Initialise(this.transform, _target.transform);
    }
}
