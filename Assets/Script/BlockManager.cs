using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    IBlockSpawner blockSpawner;
    private Dictionary<Vector3, Block> blockList;
    private static BlockManager pInstance = null;
    public List<Block> blockPrefabList;
    private Dictionary<string, Block> resource_to_block;

    public void Awake()
    {
        if (pInstance == null) pInstance = this;
        else Destroy(this);
    }

    public static BlockManager getInstance() { return pInstance; }

    public void Start()
    {
        blockSpawner = GetComponent<IBlockSpawner>();

        resource_to_block = new Dictionary<string, Block>();
        foreach(Block b in blockPrefabList)
        {
            if (resource_to_block.ContainsKey(b.resource_id)) Debug.LogError("Multiple blocks in same position detached at position" + b.resource_id);
            resource_to_block[b.resource_id] = b;
        }

        //Map blocks to position
        List<Block> blocks = blockSpawner.SpawnBlocks();
        blockList = new Dictionary<Vector3, Block>();
        foreach (Block b in blocks)
        {
            if (blockList.ContainsKey(b.transform.position))
            {
                Debug.LogError("Multiple blocks in same position detached at position" + b.transform.position);
            }

            blockList[b.transform.position] = b;
        }

    }
    
    public bool AddBlock(string resource_id, Vector3 position)
    {
        if (blockList.ContainsKey(position))
        {
            Debug.LogError("Block already existed at position" + position.ToString());
            return false;
        }

        if (!resource_to_block.ContainsKey(resource_id))
        {
            Debug.LogError("Resource type " + resource_id + "does not exist");
            return false;
        }
        blockList[position] = GameObject.Instantiate(resource_to_block[resource_id], position, Quaternion.identity);
        return true;
    }

    public bool RemoveBlock(Vector3 position)
    {
        if (!blockList.ContainsKey(position))
        {
            Debug.LogError("Tried to remove block which does not exist at position " + position.ToString());
            return false;
        }

        Destroy(blockList[position].gameObject);
        blockList.Remove(position);
        return true;
    }
}
