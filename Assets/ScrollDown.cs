using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour
{
    private bool m_isNext;
    private float m_speed;

    private void Start()
    {
        m_isNext = false;
        m_speed = 0.8f;
    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += Vector3.down * Time.deltaTime * m_speed;

        if (m_isNext == false && this.gameObject.transform.position.y < - Camera.main.orthographicSize/2 )
        {
            GameObject clone = GameObject.Instantiate(this.gameObject, this.transform.parent);
            clone.GetComponent<SpriteRenderer>().flipY = (clone.GetComponent<SpriteRenderer>().flipY == true) ? false : true;
            clone.transform.position = this.transform.position + new Vector3(this.transform.position.x, this.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y) ;
            clone.name = "Background";
            m_isNext = true;
        }
        if (this.gameObject.transform.position.y + this.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y/2 < - Camera.main.orthographicSize )
        {
            GameObject.Destroy(this.gameObject);
        }
    }


}
