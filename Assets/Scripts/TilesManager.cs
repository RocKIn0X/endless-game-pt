using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private GameObject player;
    private Transform playerTransform;
    private float spawnX = 0.0f;
    private float tileLength = 30.0f;
    private float safeZone = 90f;
    private int amountTileOnScreen = 6;
    private int lastPrefabIndex = 0;
    private int countForHighscore;
    private int highscore;
    private bool isShowHighscore;
    private List<GameObject> activeTiles;

    ObjectPooler objectPooler;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        activeTiles = new List<GameObject>();
        highscore = player.GetComponent<PlayerController>().GetHighscore();
        print("Highscore is: " + highscore);
        countForHighscore = 0;
        isShowHighscore = false;

        objectPooler = ObjectPooler.Instance;

        for (int i = 0; i < amountTileOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
	}
	
	// Update is called once per frame
	void Update () {

		if (playerTransform.position.x - safeZone > (spawnX - amountTileOnScreen * tileLength))
        {
            SpawnTile();
            DestroyTile();
        }
	}

    void SpawnTile (int prefabIndex = -1)
    {
        GameObject tileObject = null;

        if (prefabIndex == -1)
        {
            tileObject = objectPooler.SpawnFromPool(tilePrefabs[RandomPrefabIndex()], Vector3.right * spawnX, Quaternion.identity) as GameObject;
        }

        else
        {
            tileObject = objectPooler.SpawnFromPool(tilePrefabs[0], Vector3.right * spawnX, Quaternion.identity) as GameObject;
        }

        Debug.Log("Spawn tile: " + tileObject.name);

        // spawn object in spawnX and add to activeTiles list
        tileObject.transform.SetParent(transform);
        tileObject.transform.position = Vector3.right * spawnX;
        spawnX += tileLength;
        activeTiles.Add(tileObject);

        // set highscore particle false
        int tileChild = tileObject.transform.childCount;
        tileObject.transform.GetChild(tileChild - 1).gameObject.SetActive(false);

        // if count for highscore >= highscore show particle
        if(countForHighscore >= highscore && isShowHighscore != true)
        {
            Tile tile = tileObject.GetComponent<Tile>();
            isShowHighscore = true;
            tileObject.transform.GetChild(tileChild - 1).gameObject.SetActive(true);
        }

        print("Highscore: " + highscore + " | Tile: " + countForHighscore + " | isShowHS: " + isShowHighscore);

        countForHighscore += 1;
    }

    void DestroyTile()
    {
        activeTiles[0].SetActive(false);
        activeTiles.RemoveAt(0);
    }
    
    int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
