using UnityEngine;

public class ArmorSpawner : MonoBehaviour
{
    [SerializeField] private Armor[] armorPrefabs;
    [SerializeField] private float spawnRange = 50f;
    [SerializeField] private int amountToSpawn = 10;
    [SerializeField] private float wallCheckRadius = 2f;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float armorCheckRadius = 2f;
    [SerializeField] private LayerMask armorLayer;

    private void Start()
    {
        SpawnArmors();
    }

    private void SpawnArmors()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            SpawnRandomArmor();
        }
    }

    private void SpawnRandomArmor()
    {
        Vector3 randomPosition = GetValidSpawnPosition();

        int randomArmor = Random.Range( 0, armorPrefabs.Length);

        Instantiate(armorPrefabs[randomArmor], randomPosition, Quaternion.identity );
    }

    private Vector3 GetValidSpawnPosition()
    {
        Vector3 randomPoint = new Vector3( Random.Range(-spawnRange, spawnRange), 50f, Random.Range(-spawnRange, spawnRange));

        RaycastHit hit;

        if (Physics.Raycast(randomPoint, Vector3.down, out hit, 100f))
        {
            bool isGround = hit.collider.CompareTag("Ground");
            bool nearWall = Physics.CheckSphere(hit.point, wallCheckRadius, wallLayer);
            bool nearArmor = Physics.CheckSphere(hit.point, armorCheckRadius, armorLayer);

            if (isGround &&!nearWall &&!nearArmor)
            {
                return hit.point;
            }
        }

        return GetValidSpawnPosition();
    }
}