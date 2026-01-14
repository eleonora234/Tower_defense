using UnityEngine;

public class Cell : MonoBehaviour
{
    public SpriteRenderer cellRenderer;
    public Color hoverColor;


    PoweBase tower;


    public void HoverStart()
    {
        cellRenderer.color = hoverColor;
    }

    public void HoverEnd()
    {
        cellRenderer.color = new Color(0,0,0,0);
    }

    public void InsertTowerInCell(PoweBase _tower)
    {
        tower = _tower;
    }

    public bool HasTower()
    {
        return tower != null;
    }

}
