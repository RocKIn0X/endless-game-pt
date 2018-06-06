﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnX = 0.0f;
    private float tileLength = 30.0f;
    private float safeZone = 90f;
    private int amountTileOnScreen = 6;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;

    ObjectPooler objectPooler;

	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

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
            print(tileObject.transform.position);
        }

        else
        {
            tileObject = objectPooler.SpawnFromPool(tilePrefabs[0], Vector3.right * spawnX, Quaternion.identity) as GameObject;
        }
            
        tileObject.transform.SetParent(transform);
        tileObject.transform.position = Vector3.right * spawnX;
        spawnX += tileLength;
        activeTiles.Add(tileObject);
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
