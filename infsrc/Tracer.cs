using ABI_RC.Core.Player;
using MelonLoader;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveMarker : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Transform> playerEntities = new List<Transform>();
    GameObject lineObject;
    public void Initialize()
    {
        // Create an empty GameObject for the LineRenderer
        lineObject = new GameObject("ObjectiveLine");
        lineRenderer = lineObject.AddComponent<LineRenderer>();

        // Set LineRenderer settings
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 0;

        // Find all CVRPlayerEntity objects in the scene and add them to the list
        FindPlayerEntities();
    }
    public void DeInitialize()
    {
        playerEntities.Clear();
        lineObject = null;
    }
    private void FindPlayerEntities()
    {
        Object[] allPlayerEntities = FindObjectsOfType(typeof(CVRPlayerEntity));
        foreach (GameObject playerEntity in allPlayerEntities)
        {
            playerEntities.Add(playerEntity.GetComponent<CVRPlayerEntity>().GetAvatarObject().transform);
        }
    }

    public void UpdateObjectiveMarkers()
    {
        // Check for destroyed player entities and remove them from the list
        playerEntities.RemoveAll(entity => entity == null);

        // If the list is empty, find player entities again
        if (playerEntities.Count == 0)
        {
            FindPlayerEntities();
        }

        // Clear existing positions
        lineRenderer.positionCount = 0;

        // Set the positions to connect the current GameObject to each playerEntity
        lineRenderer.positionCount = playerEntities.Count + 1;
        lineRenderer.SetPosition(0, transform.position);

        for (int i = 0; i < playerEntities.Count; i++)
        {
            lineRenderer.SetPosition(i + 1, playerEntities[i].position);
        }
    }
}
