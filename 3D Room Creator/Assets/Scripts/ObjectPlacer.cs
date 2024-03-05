using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject ObjectPlacerMaster;
    public GameObject BasicCubePrefab;
    public LineCalculator LineCalculator;
    public TMP_Text LineLengthText;

    [Header("Object tracker")]
    public List<GameObject> SpawnedObjects;
    public List<Vector3> OccupiedPositions;

    public void CreateBasicCube(Vector3 gridPosition)
    {
        /*
         * We add a factor of 0.5f to prevent the cube from clipping into the ground and it't half heigth of the object itself
         */

        Vector3 spawnPosition = new(gridPosition.x, gridPosition.y + 0.5f, gridPosition.z);
        Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);

        GameObject spawnedCube = Instantiate(BasicCubePrefab, spawnPosition, spawnRotation);
        spawnedCube.transform.SetParent(ObjectPlacerMaster.transform);

        SpawnedObjects.Add(spawnedCube);
        OccupiedPositions.Add(spawnedCube.transform.position);
    }

    public void DeleteBasicCube(GameObject gameObject)
    {
        SpawnedObjects.Remove(gameObject);
        OccupiedPositions.Remove(gameObject.transform.position);
        Destroy(gameObject);
    }

    public void DrawLines()
    {
        int lineLength = LineCalculator.DrawLines(SpawnedObjects);

        if (lineLength == 0)
        {
            LineLengthText.gameObject.SetActive(false);
        }
        else
        { 
            LineLengthText.gameObject.SetActive(true); 
        }

        LineLengthText.text = $"Lenght {lineLength}m";
    }

    public void SaveObjects()
    {
        List<PositionData> positiondata = new();

        foreach (GameObject gameObject in SpawnedObjects)
        {
            positiondata.Add(new PositionData(gameObject.transform.position));
        }

        SaveData saveData = new(positiondata);

        string jsonPositionData = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("positiondata", jsonPositionData);
        Debug.Log("Position data saved.");
    }

    public void LoadObjects()
    {
        string jsonPositionData = PlayerPrefs.GetString("positiondata");

        if (string.IsNullOrEmpty(jsonPositionData))
        {
            Debug.Log("There is no data to load.");
            return;
        }

        SaveData saveData = JsonUtility.FromJson<SaveData>(jsonPositionData);
        List<PositionData> positiondata = saveData.PositionData;

        foreach (PositionData savedPosition in positiondata)
        {
            Vector3 position = new(savedPosition.x, savedPosition.y, savedPosition.z);
            GameObject savedObject = Instantiate(BasicCubePrefab, position, Quaternion.identity);
            savedObject.transform.SetParent(ObjectPlacerMaster.transform);
            SpawnedObjects.Add(savedObject);
        }

        Debug.Log("Successfully loaded.");
    }
}

[SerializeField]
public class SaveData
{
    /*
     * Class is responsible for saving and has no other purpose 
     */

    public List<PositionData> PositionData;
    public SaveData(List<PositionData> positionData) => PositionData = positionData;
}
