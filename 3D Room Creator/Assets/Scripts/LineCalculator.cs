using System.Collections.Generic;
using UnityEngine;

public class LineCalculator : MonoBehaviour
{
    public LineRenderer LineRenderer;

    public int DrawLines(List<GameObject> spawnedObjectsList)
    {
        if (spawnedObjectsList.Count < 2)
        {
            Debug.Log("You need to add at least 2 elements to draw lines.");
            return 0;
        }

        // reset all positions
        LineRenderer.positionCount = 0;

        foreach (var spawnedObject in spawnedObjectsList)
        {
            // add new position
            LineRenderer.positionCount++;

            // get current position index
            int currentPositionIndex = LineRenderer.positionCount - 1;

            // create a postion based on the postion data list
            Vector3 linePosition = 
                new(spawnedObject.transform.position.x - 0.5f, spawnedObject.transform.position.y + 0.5f, spawnedObject.transform.position.z - 0.5f);

            // set the line render position data for current index
            LineRenderer.SetPosition(currentPositionIndex, linePosition);
        }

        // return the length of the linerender counter to determin the line length for each element is 1m
        return LineRenderer.positionCount;
    }
}
