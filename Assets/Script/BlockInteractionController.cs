using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteractionController : MonoBehaviour {

    public float max_distance = 1.0f;

    private Block current_selected;

    public GameObject highlight_object;

	// Update is called once per frame
	void Update () {
        Ray r = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(r, out hitInfo, max_distance) && hitInfo.collider.tag == "Block";

        if (hit)
        {
            current_selected = hitInfo.collider.gameObject.GetComponent<Block>();
        }
        else
        {
            current_selected = null;
        }

        highlight_object.SetActive(hit);
    }
    public bool RemoveSelectedBlock()
    {
        if(current_selected == null)
        {
            Debug.Log("Nothing currently selected to remove");
            return false;
        }
        BlockManager.getInstance().RemoveBlock(current_selected.transform.position);
        return true;
    }
    public bool AddBlock(string resource_id)
    {
        if(current_selected == null)
        {
            Debug.Log("No Block currently selected, can't spawn in emptyness");
            return false;
        }
        BlockManager.getInstance().AddBlock(resource_id, current_selected.transform.position + 
                                                        current_selected.transform.up * current_selected.transform.localScale.y);
        return true;
    }
    private void OnDrawGizmos()
    {
        Ray r = new Ray(this.transform.position, this.transform.forward);
        Gizmos.DrawRay(r.origin, r.direction * max_distance);
    }
}
