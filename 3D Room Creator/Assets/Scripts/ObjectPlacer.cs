using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject ObjectPlacerMaster;
    public GameObject BasicCubePrefab;
    public List<GameObject> SpawnedObjects;

    public void CreateBasicCube(Vector3 position)
    {
        Vector3 spawnPosition = new(position.x, position.y + 0.5f, position.z);
        GameObject spawnedCube = Instantiate(BasicCubePrefab, spawnPosition, Quaternion.identity);
        spawnedCube.transform.SetParent(ObjectPlacerMaster.transform);
        SpawnedObjects.Add(spawnedCube);
    }

    public void DeleteBasicCube(GameObject gameObject)
    {
        SpawnedObjects.Remove(gameObject);
        Destroy(gameObject);
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
        List<PositionData> positionData = saveData.PositionData;

        foreach (PositionData savedPosition in positionData)
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
