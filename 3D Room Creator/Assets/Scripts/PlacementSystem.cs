using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementSystem : MonoBehaviour
{
    public Grid Grid;
    public GameObject GridPosition;

    private void Update()
    {
        // don't execute when we our mouse is over an UI element
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Vector3 mousePosition = MouseTracker.GetSelectedMapPosition();
        Vector3Int gridPosition = Grid.WorldToCell(mousePosition);
        GridPosition.transform.position = Grid.CellToWorld(gridPosition);
    }
}
