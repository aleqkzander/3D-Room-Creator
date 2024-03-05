using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementSystem : MonoBehaviour
{
    public Grid Grid;
    public GameObject GridPosition;
    public PreviewPlayer PreviewPlayer;
    public ObjectPlacer ObjectPlacer;
    private readonly List<Vector3Int> _occupiedPositions = new();

    private void Update()
    {
        // Don't execute when our mouse is over a UI element
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Vector3 mousePosition = MouseTracker.GetSelectedMapPosition();
        Vector3Int gridPosition = Grid.WorldToCell(mousePosition);
        GridPosition.transform.position = Grid.CellToWorld(gridPosition);

        if (Input.GetMouseButtonDown(0)) PlaceObject(gridPosition);
        if (Input.GetMouseButtonDown(1)) DestroyObjectUnderMyMouse();
    }

    private void PlaceObject(Vector3Int position)
    {
        if (_occupiedPositions.Contains(position))
        {
            Debug.Log("Position already occupied!");
            return;
        }

        ObjectPlacer.CreateBasicCube(position);
        _occupiedPositions.Add(position);
    }

    private void DestroyObjectUnderMyMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit)) return;
        GameObject objectHit = hit.transform.gameObject;
        if (objectHit == null) return; if (!objectHit.CompareTag("Placeable")) return;
        ObjectPlacer.DeleteBasicCube(objectHit);  
    }
}
