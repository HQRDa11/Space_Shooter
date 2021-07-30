using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairRay : MonoBehaviour
{
    private float _lifeTime;
    private Transform _origin;
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _lifeTime = 0.3f;
    }
    public void Initialise(Transform origin, Transform target)
    {
        _origin = origin;
        _target = target;
    }


    // Update is called once per frame
    void Update()
    {
        _lifeTime -= Time.deltaTime;
        switch (_lifeTime <= 0 || !_target|| !_origin )
        {
            case true: GameObject.Destroy(this.gameObject);
                break;
        }

        if (this._origin != null && _target != null)
        {
            this.gameObject.GetComponent<LineRenderer>().SetPosition(0, _origin.position);
            this.gameObject.GetComponent<LineRenderer>().SetPosition(1, _target.position);
        }
    }
}
