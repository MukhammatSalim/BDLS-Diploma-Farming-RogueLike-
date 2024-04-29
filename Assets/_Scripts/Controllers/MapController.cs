using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> TerrainChunks;
    public GameObject Player;
    public float CheckerRadius;
    Vector3 NoTerrainPosition;
    public LayerMask TerrainMask;
    PlayerMovement pmScript;
    public GameObject CurrentChunk;

    [Header("Optimization")]
    public List<GameObject> SpawnedChunks;
    public GameObject LatestChunk;
    public float MaxOpDistance;
    float opDist;
    // Start is called before the first frame update
    void Start()
    {
        pmScript = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }
    void ChunkChecker()
    {
        if (!CurrentChunk) return;

        if (pmScript.moveDir.x > 0 && pmScript.moveDir.y == 0) //right
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("RightChunk").position, CheckerRadius, TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("RightChunk").position;
                SpawnChunk();
            }
        }
        if (pmScript.moveDir.x < 0 && pmScript.moveDir.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("LeftChunk").position, CheckerRadius, TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("LeftChunk").position;
                SpawnChunk();
            }
        }
        if (pmScript.moveDir.x == 0 && pmScript.moveDir.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("UpChunk").position, CheckerRadius, TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("UpChunk").position;
                SpawnChunk();
            }
        }
        if (pmScript.moveDir.x == 0 && pmScript.moveDir.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("DownChunk").position, CheckerRadius, TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("DownChunk").position;
                SpawnChunk();
            }
        }

        if (pmScript.moveDir.x > 0 && pmScript.moveDir.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("RightUpChunk").position, CheckerRadius, TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("RightUpChunk").position;
                SpawnChunk();
            }
        }
        if (pmScript.moveDir.x > 0 && pmScript.moveDir.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("RightDownChunk").position, CheckerRadius, TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("RightDownChunk").position;
                SpawnChunk();
            }
        }
        if (pmScript.moveDir.x < 0 && pmScript.moveDir.y > 0) //Left up
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("LeftUpChunk").position, CheckerRadius, TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("LeftUpChunk").position;
                SpawnChunk();
            }
        }
        if (pmScript.moveDir.x < 0 && pmScript.moveDir.y < 0) //Left down
        {
            if (!Physics2D.OverlapCircle(CurrentChunk.transform.Find("LeftDownChunk").position, CheckerRadius, TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("LeftDownChunk").position;
                SpawnChunk();
            }
        }
    }
    void SpawnChunk()
    {
        Debug.Log("Spawn");
        int RNG = Random.Range(0, TerrainChunks.Count);
        LatestChunk = Instantiate(TerrainChunks[RNG], NoTerrainPosition, Quaternion.identity);
        SpawnedChunks.Add(LatestChunk);
    }

    void ChunkOptimizer()
    {
        float optimizeCooldown = 1;
        optimizeCooldown -= Time.deltaTime;
        if (optimizeCooldown < -0)
        {
            optimizeCooldown = 1;
        }
        else { return; }
        foreach (GameObject chunk in SpawnedChunks)
        {
            opDist = Vector3.Distance(CurrentChunk.transform.position, chunk.transform.position);
            if (opDist > MaxOpDistance) chunk.SetActive(false);
            else chunk.SetActive(true);
        } 
        Debug.Log("Optimized");
    }
   
}
