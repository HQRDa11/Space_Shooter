using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _offSet;
    [SerializeField]
    private float _shotTimerMax;
    private float _shotTimer;

    private Vector2 _velocity = Vector2.zero;

    public void Start()
    {
        _shotTimerMax = 0.4f;
        _shotTimer = 0;
    }

    private void Update()
    {
        _shotTimer += Time.deltaTime;
        Update_Inputs();
    }

    private void Update_Inputs()
    {
        // If Mouse's position is on Screen && Mouse0 is maintained >> Player follow MousePosition;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Map.IsOnScreen(mousePosition) && Input.GetKey(KeyCode.Mouse0))
        {
            Move(mousePosition);

            Shoot(); 
        }
    }

    private void Move(Vector2 mousePosition)
    {
        this.gameObject.transform.position = Vector2.SmoothDamp(this.gameObject.transform.position, mousePosition + new Vector2(0, _offSet), ref _velocity, Time.deltaTime / _speed);
    }

    private void Shoot()
    {
        if (_shotTimer >= _shotTimerMax)
        {
            GameObject newShot = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Shot"));
            newShot.transform.position = this.transform.position + Vector3.up;
            _shotTimer = 0;
        }

    }

    private void ShootTimerOk()
    {

    }
}
