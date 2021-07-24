using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour  
{ // concept explain to player on tuto: Be careful of this deposit, you can
  // try too mine and crush it to pieces for, but staying on their way might damage your ship too hard.
    private double m_totalLife;
    private double m_life;
    private double m_size;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "Damageable";
    }

    public void Initialise(double life,double size)
    {
        m_totalLife = life;
        m_life = life;
        m_size = size;

        Debug.LogWarning("Deposit initialised");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += Vector3.down * 0.6f * Time.deltaTime;
        switch (Map.IsOnScreen(this.transform.position) == false && this.transform.position.y < 0)
        {
            case true:
                 GameObject.Destroy(this.gameObject);
                break;
        }
    }

    public void TakeDamage(double damage)
    {
        m_life -= damage;
        switch(m_life <= 0)
        {
            case true:
                switch(m_size < 1)
                {
                    case true:
                        Destroy();
                        break;

                    case false: 
                        Divide();
                        break;
                }
                break;
        }
    }
    public void Destroy()
    {
        Rarity rarity = Factory.Dice_Rarity();
        Factory.Instance.Bonus_Factory.Instantiate_ComponentBonus(this.transform.position, rarity);

        GameObject.Destroy(this.gameObject);
    }
    public void Divide()
    {
        Debug.Log("should devide");

        for (int i = 0; i<m_size; i++)
        {
            switch (Random.Range(0,10)>5)
            {
                case true:
                    Rarity rarity = Factory.Dice_Rarity();
                    this.gameObject.transform.localScale /= (float)m_size;
                    Vector3 componentPosition = Map.RandomSpawnAround(this.gameObject.transform.position,0.5f);
                    Factory.Instance.Bonus_Factory.Instantiate_ComponentBonus(componentPosition, rarity);
                    break;
            }
            Vector3 newDepositPosition = Map.RandomSpawnAround(this.gameObject.transform.position, 0.5f);
            Factory.Create_Deposit(m_totalLife, m_size - 1f, newDepositPosition);
            Debug.Log("new size:" + (m_size - 1f).ToString());
            break;
        }
        GameObject.Destroy(this.gameObject);
    }
}
