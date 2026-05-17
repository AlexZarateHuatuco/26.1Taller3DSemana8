using UnityEngine;

public class ArmorSpawner : MonoBehaviour
{

    [SerializeField] private Armor[] armorPrefabs;

    [SerializeField] private float spawnRange = 50f;

    [SerializeField] private int amountToSpawn = 10;

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
        Vector3 randomPosition =GetRandomGroundPosition();

        int randomArmor = Random.Range( 0,armorPrefabs.Length);

        Instantiate(armorPrefabs[randomArmor],randomPosition,Quaternion.identity);
    }

    private Vector3 GetRandomGroundPosition()
    {
        Vector3 randomPoint = new Vector3(Random.Range(-spawnRange, spawnRange),50f,Random.Range(-spawnRange, spawnRange));

        RaycastHit hit;

        if (Physics.Raycast(randomPoint, Vector3.down,out hit,100f))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                return hit.point;
            }
        }

        return GetRandomGroundPosition();
    }
}