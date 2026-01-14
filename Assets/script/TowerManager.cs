using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerManager : MonoBehaviour
{
    [Header("settings")]
    public LayerMask raycastLayer;

    [Header("Components")]
    public TowerPreview towerPreview;
    public PlayerManager playerManager;

    [Header("PreFab")]

    public PoweBase towerToBuild;


    Cell currentHoverCell;


    bool isBuildingtower;
    int buildTowerIndex = -1;


    private void Awake()
    {
        towerPreview.gameObject.SetActive(false);
    }


    public void Update()
    {
        Vector2 viewMousePos = Mouse.current.position.value;
        Vector3 worldmousePos = Camera.main.ScreenToWorldPoint(viewMousePos);

        RaycastHit2D hit = Physics2D.Raycast(worldmousePos, Vector2.zero, 500, raycastLayer);

        if (hit.collider != null)
        {
            Cell cell = hit.collider.transform.GetComponent<Cell>();
            if (cell != null && cell != currentHoverCell)
            {
                cell.HoverStart(); 
                ResetHover();
                currentHoverCell = cell;

            }
        }
        else
        {
            ResetHover();
            towerPreview.gameObject.SetActive(false);
        }

        if (isBuildingtower && currentHoverCell != null) 
            {
                towerPreview.transform.position = currentHoverCell.transform.position;
            if (currentHoverCell.HasTower())
             towerPreview.gameObject.SetActive(false);
            else 
                towerPreview.gameObject.SetActive(true);


            }

        if(Mouse.current.leftButton.wasPressedThisFrame && currentHoverCell != null)
        {
            if(playerManager.SpendMoney(5))
            {
                Vector3 pos = currentHoverCell.transform.position;
                PoweBase newTower = Instantiate(towerToBuild, pos, Quaternion.identity, currentHoverCell.transform);
                currentHoverCell.InsertTowerInCell(newTower);
            }
            else
            {
                //TODO: feedback
            }
        }



    }
    void ResetHover()
    {
        if (currentHoverCell != null)
        {
            currentHoverCell.HoverEnd();
            currentHoverCell = null;
        }
    }

    public void EventButton_BuildTower(int towerIndex)
    {
        if(isBuildingtower && buildTowerIndex == towerIndex)
        {
            isBuildingtower = false;
            towerPreview.gameObject.SetActive(false);

        }
        else
        {
            isBuildingtower = true;
            buildTowerIndex = towerIndex;
        }
           
    
    }
    


}
