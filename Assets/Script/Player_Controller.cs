using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _offSet;

    private Vector2 _velocity = Vector2.zero;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // If Mouse's position is on Screen && Mouse0 is maintained >> Player follow MousePosition;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Map.IsOnScreen(mousePosition) && Input.GetKey(KeyCode.Mouse0))
        {
            this.gameObject.transform.position = Vector2.SmoothDamp(this.gameObject.transform.position, mousePosition + new Vector2(0, _offSet), ref _velocity, Time.deltaTime / _speed);
        }
    }

}
