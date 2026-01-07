using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public UI manager;
    public int maxHp = 10;
    int currentHp = 10;

     public void Awake()
    {
        currentHp = maxHp;

    }

    public void playerHit(int damage)
    {
        currentHp -= damage;

        if (currentHp <=0)
        {
           
        }
        manager.UpdatePlayerHP(currentHp);
    }





}

