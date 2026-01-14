using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI moneytext;
    public void UpdatePlayerHP(int playerHP)
    {
        playerHPText.text = playerHP.ToString();
    }

    public void UpdatePlayerMoney(int money)
    {
        moneytext.text = money.ToString();
    }
}
