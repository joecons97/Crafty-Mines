﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ChunkHolder
{
    public Vector2 Position;
    public ChunkGenerator ChunkObject;
}

public class ChunkFollower : MonoBehaviour {

    public ChunkGenerator Prefab;

    public int ViewSize = 16;

    public int ActualViewSize { get { return ViewSize * Chunk.ChunkSize; } }

    public List<ChunkHolder> Chunks = new List<ChunkHolder>();

    List<ChunkGenerator> lastActive = new List<ChunkGenerator>();

	// Use this for initialization
	void Start () {
        Chunks = new List<ChunkHolder>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        UpdateChunks();
    }

    void UpdateChunks()
    {
        int xPos = (int)(Mathf.Round(transform.position.x / (float)Chunk.ChunkSize) * Chunk.ChunkSize) + Chunk.ChunkSize /2;
        int zPos = (int)(Mathf.Round(transform.position.z / (float)Chunk.ChunkSize) * Chunk.ChunkSize) + Chunk.ChunkSize / 2;

        lastActive.ForEach(x => x.gameObject.SetActive(false));
        lastActive.Clear();

        for (int x = -ActualViewSize - Chunk.ChunkSize; x < ActualViewSize; x += Chunk.ChunkSize)
        {
            for (int y = -ActualViewSize - Chunk.ChunkSize; y < ActualViewSize; y += Chunk.ChunkSize)
            {
                var pos = new Vector2(x + xPos, y + zPos);
                var holder = GetHolder((int)pos.x, (int)pos.y);
                if(holder != null)
                {
                    holder.ChunkObject.gameObject.SetActive(true);
                    lastActive.Add(holder.ChunkObject);
                }
                else
                {
                    //Create...
                    var obj = Instantiate(Prefab, new Vector3((int)pos.x, 0, (int)pos.y), Quaternion.identity);
                    obj.Manager = this;
                    Chunks.Add(new ChunkHolder()
                    {
                        ChunkObject = obj,
                        Position = new Vector2((int)pos.x, (int)pos.y)
                    });
                    lastActive.Add(obj);
                }
            }
        }

        //Chunks.ForEach(x => x.ChunkObject.UpdateNeighbours());
    }

    ChunkHolder GetHolder(int x, int y)
    {
        return Chunks.SingleOrDefault(v => (int)v.Position.x == x && (int)v.Position.y == y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one * ActualViewSize * 2);
        int xPos = (int)(Mathf.Round(transform.position.x / (float)Chunk.ChunkSize) * Chunk.ChunkSize);
        int zPos = (int)(Mathf.Round(transform.position.z / (float)Chunk.ChunkSize) * Chunk.ChunkSize);
        Gizmos.DrawWireCube(new Vector3(xPos, transform.position.y, zPos), Vector3.one * Chunk.ChunkSize);
    }
}
