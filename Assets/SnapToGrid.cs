using UnityEngine;

[ExecuteInEditMode]
public class SnapToGrid : MonoBehaviour
{
    [SerializeField] private float gridSize = 1.28f;  // Set this to the size of your grid.

    private void Update()
    {
        foreach (GameObject go in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            Vector3 snapPos;

            snapPos.x = Mathf.Round(go.transform.position.x / gridSize) * gridSize;
            snapPos.y = Mathf.Round(go.transform.position.y / gridSize) * gridSize;
            snapPos.z = Mathf.Round(go.transform.position.z / gridSize) * gridSize;

            go.transform.position = snapPos;
        }
    }
}
