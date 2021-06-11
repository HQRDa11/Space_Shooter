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
    private void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _isMouseOnScreen = Map.IsOnScreen(_mousePosition) && Input.GetKey(KeyCode.Mouse0) ? true : false;

        if (_isMouseOnScreen) Shoot();
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
        gameObject.GetComponent<TurretSystem>().Shoot();
    }

}
