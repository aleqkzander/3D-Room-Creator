using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    public static Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Default")))
        {
            return hit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
