﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnX = 0.0f;
    private float tileLength = 15.0f;
    private float safeZone = 60f;
    private int amountTileOnScreen = 6;
    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

        for (int i = 0; i < amountTileOnScreen; i++)
        {
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
        GameObject tileObject;
        tileObject = Instantiate(tilePrefabs[0]) as GameObject;
        tileObject.transform.SetParent(transform);
        tileObject.transform.position = Vector3.right * spawnX;
        spawnX += tileLength;
        activeTiles.Add(tileObject);
    }

    void DestroyTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
