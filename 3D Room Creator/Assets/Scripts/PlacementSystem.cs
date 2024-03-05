using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementSystem : MonoBehaviour
{
    public Grid Grid;
    public GameObject GridPosition;
    public PreviewPlayer PreviewPlayer;
    public ObjectPlacer ObjectPlacer;

    private void Update()
    {
        // Don't execute when our mouse is over a UI element
        if (EventSystem.current.IsPointerOverGameObject()) return;


        Vector3 mousePosition = MouseTracker.GetSelectedMapPosition();
        Vector3Int gridPosition = Grid.WorldToCell(mousePosition);
        GridPosition.transform.position = Grid.CellToWorld(gridPosition);
        GridPosition.transform.forward = Camera.main.transform.forward;

        if (Input.GetMouseButtonUp(0)) PlaceObjectAt(gridPosition);
        if (Input.GetMouseButtonUp(1)) DestroyObjectUnderMyMouse();
    }

    private void PlaceObjectAt(Vector3 position)
    {
        if (ObjectPlacer.OccupiedPositions.Contains(position))
        {
            Debug.Log("Position already occupied!");
            return;
        }

        ObjectPlacer.CreateBasicCube(position);
    }

    private void DestroyObjectUnderMyMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit)) return;
        GameObject objectHit = hit.transform.gameObject;

        if (objectHit == null) return; 
        if (!objectHit.CompareTag("Placeable")) return;

        ObjectPlacer.DeleteBasicCube(objectHit);
    }
}
