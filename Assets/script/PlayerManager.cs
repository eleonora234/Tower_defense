using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public UI manager;
    public int startingMoney = 10;
    public int maxHp = 10;
    int currentHp = 10;
    int money = 0;

     public void Awake()
    {
        currentHp = maxHp;
       
        money = startingMoney;
        manager.UpdatePlayerHP(money);

    }

    public void playerHit(int damage)
    {
        currentHp -= damage;

        if (currentHp <=0)
        {
           
        }
        manager.UpdatePlayerHP(currentHp);
    }

    public void GainMoney(int amount)
    {
        money += amount;    
        manager.UpdatePlayerMoney(money);
    }

    public bool SpendMoney(int amount)
    {
        if (money< amount)
        {
            return false;
        }
        money -= amount;
        manager.UpdatePlayerMoney(money);
        return true;
        
    }

}

