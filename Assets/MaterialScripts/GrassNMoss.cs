using UnityEngine;

public class GrassNMoss : MonoBehaviour
{

    [SerializeField] private Transform spawnPlane;
    [SerializeField] private GameObject grassPrefab;
    [SerializeField] private Vector2 planeSize = new Vector2(10f, 10f);
    [SerializeField] private int gridX = 10;
    [SerializeField] private int gridZ = 10;
    [SerializeField] private float noiseScale = 0.1f;
    [SerializeField] private float noiseStrength = 0.5f;
    [SerializeField] private float rayMaxDistance = 100f;
    [SerializeField] private LayerMask hitMask = ~0;

    private void Start()
    {
        SpawnGrass();
    }

    private void SpawnGrass()
    {
        if (spawnPlane == null || grassPrefab == null) return;
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                float u = (float)x / (gridX - 1);
                float v = (float)z / (gridZ - 1);
                Vector3 localPos = new Vector3((u - 0.5f) * planeSize.x, 0f, (v - 0.5f) * planeSize.y);
                float nx = Mathf.PerlinNoise(x * noiseScale, z * noiseScale) * noiseStrength;
                float nz = Mathf.PerlinNoise(x * noiseScale + 100f, z * noiseScale + 100f) * noiseStrength;
                localPos.x += nx;
                localPos.z += nz;
                Vector3 worldPos = spawnPlane.TransformPoint(localPos);
                RaycastHit hit;
                if (Physics.Raycast(worldPos, Vector3.down, out hit, rayMaxDistance, hitMask))
                {
                    Instantiate(grassPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                }
            }
        }
    }
}
