using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    void Start()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }
    private void OnMouseDown()
    {
        //Debug.Log("Mouse Clicked");
        AttemptToPlaceDefenderAt(GetMousePosition());
    }

    public Vector2 GetMousePosition()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    // Check if enough stars are available to spawn a defender
    public void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int starCost = defender.GetStarCost();
        if(starDisplay.GetAvailableStars() >= starCost)
        {
            starDisplay.SpendStars(starCost);
            SpawnDefenders(gridPos);
        }
    }

    public void SelectDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    public Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    public void SpawnDefenders(Vector2 roundedPosition)
    {
        Defender newDefender = Instantiate(defender, roundedPosition, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
        //Debug.Log(roundedPosition);
    }
}
