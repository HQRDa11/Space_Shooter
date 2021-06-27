using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _offSet;
   
    private Vector2 _velocity = Vector2.zero;

    private Vector2 _mousePosition;
    private bool _isMouseOnScreen;

    private float _doubleClickTimer = 0;
    private float _doubleClickMaxDelay = 0.6f;
    private bool _isInitialClick;

    private void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _isMouseOnScreen = Map.IsOnScreen(_mousePosition) && Input.GetKey(KeyCode.Mouse0) ? true : false;

        if (_isMouseOnScreen) Shoot();


        if (TryDoubleClick())
        {
            GameObject zoneAttack = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/ZoneAttack"));
            zoneAttack.GetComponent<ZoneAttack>().Initialise(this.transform.position,0.8f, 200);
        }
    }

    private void FixedUpdate()
    {
        if (_isMouseOnScreen) Move(_mousePosition);
    }

    private void Move(Vector2 mousePosition)
    {
        this.gameObject.transform.position = Vector2.SmoothDamp(this.gameObject.transform.position, mousePosition + new Vector2(0, _offSet), ref _velocity, Time.deltaTime / _speed);
    }

    private void Shoot()
    {
        gameObject.GetComponent<Player>().Shoot();
    }

    private bool TryDoubleClick()
    {
        _doubleClickTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) )
        {
            if (_doubleClickTimer > 0 && _doubleClickTimer <= _doubleClickMaxDelay && _isInitialClick)
            {
                //Debug.Log("DoubleClick!");
                _isInitialClick = false;
                return true;
            }
            else
            {
                _doubleClickTimer = 0;
                _isInitialClick = true;
            }
        }
        return false;
    }
}
