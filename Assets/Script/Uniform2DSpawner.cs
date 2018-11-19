using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uniform2DSpawner : MonoBehaviour, IBlockSpawner {
    public int width;
    public int height;
    public float holeProbability; // needs to be within [0.0, 1.0]
    public Block blockPrefab;

    public List<Block> SpawnBlocks()
    {   
        List<Block> spawned_blocks = new List<Block>();

        //spawn blocks
        for(int r = 0; r < width; r++)
        {
            for(int c = 0; c < height; c++)
            {
                float rand = Random.Range(0.0f, 1.0f);
                if (rand <= holeProbability) continue;

                float x = (float)r * blockPrefab.transform.localScale.x;
                float z = (float)c * blockPrefab.transform.localScale.z;

                Block block = GameObject.Instantiate(blockPrefab, new Vector3(x, 0, z), Quaternion.identity) as Block;
                spawned_blocks.Add(block);
            }
        }
        return spawned_blocks;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
