using System.Collections.Generic;
using UnityEngine;

public class LineCalculator : MonoBehaviour
{
    public LineRenderer LineRenderer;

    public float DrawLines(List<GameObject> spawnedObjectsList)
    {
        LineRenderer.positionCount = 0;

        if (spawnedObjectsList.Count < 2)
        {
            Debug.Log("You need to add at least 2 elements to draw lines.");
            return 0;
        }

        foreach (var spawnedObject in spawnedObjectsList)
        {
            LineRenderer.positionCount++;
            int currentPositionIndex = LineRenderer.positionCount - 1;

            Vector3 linePosition = 
                new(spawnedObject.transform.position.x, spawnedObject.transform.position.y + 0.5f, spawnedObject.transform.position.z);

            LineRenderer.SetPosition(currentPositionIndex, linePosition);
        }

        return GetLineLenght() + 1;
    }

    private float GetLineLenght()
    {
        float length = 0f;

        // Iterate through each segment of the line
        for (int i = 0; i < LineRenderer.positionCount - 1; i++)
        {
            // Calculate distance between consecutive points and add to total length
            length += Vector3.Distance(LineRenderer.GetPosition(i), LineRenderer.GetPosition(i + 1));
        }

        return length;
    }
}
