using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject ObjectPlacerMaster;
    public GameObject BasicCubePrefab;

    public void CreateBasicCube(Vector3 position)
    {
        Vector3 spawnPosition = new(position.x, position.y + 0.5f, position.z);
        Instantiate(BasicCubePrefab, spawnPosition, Quaternion.identity);
    }
}
