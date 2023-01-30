using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject largeAstroidPrefab, mediumAstroidPrefab, smallAstroidPrefab;
    [SerializeField, Tooltip("Amount of astroids to spawn for this level\nx = large, y = medium, z = small")]
    private Vector3 level1AmountOfSpawnedAstroids, level2AmountOfSpawnedAstroids, level3AmountOfSpawnedAstroids;
    [SerializeField]
    private Vector2 minimumXYAstroidSpawnPoint, maximumXYAstroidSpawnPoint;

    List<BaseAstroid> activeAstroids;
    Transform astroidContainer;

    // Start is called before the first frame update
    void Start()
    {
        astroidContainer = new GameObject("Astroids").transform;
        astroidContainer.position = Vector3.zero;

        activeAstroids = new List<BaseAstroid>();
        BeginLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BeginLevel(int level)
    {
        switch (level)
        {
            case 1:

                GenerateInitialAstroids(level1AmountOfSpawnedAstroids);

                break;
            case 2:

                GenerateInitialAstroids(level1AmountOfSpawnedAstroids);

                break;
            case 3:

                GenerateInitialAstroids(level1AmountOfSpawnedAstroids);

                break;
            default:
                break;
        }
    }

    public void GenerateInitialAstroids(Vector3 amountOfEachAstroidToSpawn)
    {
        for (int i = 0; i < amountOfEachAstroidToSpawn.x; i++)
        {
            SpawnAstroid(largeAstroidPrefab);
        }

        for (int i = 0; i < amountOfEachAstroidToSpawn.y; i++)
        {
            SpawnAstroid(mediumAstroidPrefab);
        }

        for (int i = 0; i < amountOfEachAstroidToSpawn.z; i++)
        {
            SpawnAstroid(smallAstroidPrefab);
        }
    }

    public void SpawnAstroid(GameObject astroidPrefab)
    {
        Vector2 spawnPos = new Vector2(Random.Range(minimumXYAstroidSpawnPoint.x, maximumXYAstroidSpawnPoint.x), Random.Range(minimumXYAstroidSpawnPoint.y, maximumXYAstroidSpawnPoint.y));

        Vector2 moveDirection = new Vector2(Random.Range(0, 1), Random.Range(0, 1));
        BaseAstroid astroidObj = Instantiate(largeAstroidPrefab, astroidContainer).transform.GetComponent<BaseAstroid>();
        astroidObj.transform.position = new Vector3(spawnPos.x, 0, spawnPos.y);
        astroidObj.InitializeAstroid(moveDirection);
        activeAstroids.Add(astroidObj);
    }
}
