using UnityEngine;

public class CrackGene : MonoBehaviour
{
    [SerializeField] private Transform[] planes;
    [SerializeField] private GameObject[] crackPrefabs;
    [SerializeField] private int gridX = 10;
    [SerializeField] private int gridY = 10;
    [SerializeField] private float noiseScale = 0.1f;
    [SerializeField] private float noiseStrength = 0.5f;
    [SerializeField] private float rayMaxDistance = 10f;
    [SerializeField] private LayerMask hitMask = ~0;

    private void Start()
    {
        SpawnCracks();
    }

    private void SpawnCracks()
    {
        if (planes == null || crackPrefabs == null || crackPrefabs.Length == 0) return;
        foreach (Transform plane in planes)
        {
            if (plane == null) continue;
            MeshFilter mf = plane.GetComponent<MeshFilter>();
            if (mf == null) continue;
            Bounds bounds = mf.sharedMesh.bounds;
            Vector3 worldSize = Vector3.Scale(bounds.size, plane.lossyScale);

            for (int x = 0; x < gridX; x++)
            {
                for (int y = 0; y < gridY; y++)
                {
                    float u = (float)x / (gridX - 1);
                    float v = (float)y / (gridY - 1);
                    Vector3 localPos = new Vector3((u - 0.5f) * worldSize.x, (v - 0.5f) * worldSize.y, 0f);
                    float nx = Mathf.PerlinNoise(x * noiseScale, y * noiseScale) * noiseStrength;
                    float ny = Mathf.PerlinNoise(x * noiseScale + 100f, y * noiseScale + 100f) * noiseStrength;
                    localPos.x += nx;
                    localPos.y += ny;
                    Vector3 worldPos = plane.TransformPoint(localPos);
                    RaycastHit hit;
                    if (Physics.Raycast(worldPos, plane.forward, out hit, rayMaxDistance, hitMask))
                    {
                        GameObject prefab = crackPrefabs[Random.Range(0, crackPrefabs.Length)];
                        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, hit.normal);
                        Instantiate(prefab, hit.point, rot);
                    }
                }
            }
        }
    }
}
