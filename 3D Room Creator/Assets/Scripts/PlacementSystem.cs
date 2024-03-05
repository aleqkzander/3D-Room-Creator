using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementSystem : MonoBehaviour
{
    public Grid Grid;
    public GameObject GridPosition;
    public PreviewPlayer PreviewPlayer;
    public ObjectPlacer ObjectPlacerMaster;

    private void Update()
    {
        // don't execute when we our mouse is over an UI element
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Vector3 mousePosition = MouseTracker.GetSelectedMapPosition();
        Vector3Int gridPosition = Grid.WorldToCell(mousePosition);
        GridPosition.transform.position = Grid.CellToWorld(gridPosition);

        if (Input.GetMouseButtonDown(0)) ObjectPlacerMaster.CreateBasicCube(gridPosition);
        if (Input.GetMouseButtonDown(1)) DestroyObjectUnderMyMouse();
    }

    private void DestroyObjectUnderMyMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit)) return;
        GameObject objectHit = hit.transform.gameObject;
        if (objectHit == null) return; if (!objectHit.CompareTag("Placeable")) return;
        ObjectPlacerMaster.DeleteBasicCube(objectHit);  
    }
}
