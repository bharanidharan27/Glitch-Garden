using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{

    [SerializeField] Defender defenderPrefab;
    Text starCost;
    private void Start()
    {
        starCost = GetComponentInChildren<Text>();
        if(!starCost)
        {
            Debug.LogError("Add Star Cost Text");
        }
        else
        {
            starCost.text = defenderPrefab.GetComponent<Defender>().GetStarCost().ToString();
        }
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(24, 24, 24, 255);
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SelectDefender(defenderPrefab);
    }

    public void DeactivateCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }


}
