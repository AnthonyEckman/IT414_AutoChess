using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHalf : MonoBehaviour
{
    [SerializeField]
    private bool IsPlayerSide = false;

    private List<GameObject> myBlocks = new List<GameObject>();


    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void AddBlock(GameObject tile)
    {
        if (tile.GetComponent<UnitBlock>() != null && !myBlocks.Contains(tile))
        {
            myBlocks.Add(tile);
        }
        else
        {
            Debug.LogError("That Is Not a tile");
        }
    }

    public bool isPlayerSide()
    {
        return IsPlayerSide;
    }
}
