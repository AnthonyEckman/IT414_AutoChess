using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBlock : MonoBehaviour , ISelectable
{

    private BoardHalf myBoard;
    private Color myColor;




    // Start is called before the first frame update
    void Start()
    {
        myBoard = GetComponentInParent<BoardHalf>();
        myBoard.AddBlock(this.gameObject);
        myColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void ClickedOn()
    {
        throw new System.NotImplementedException();
    }

    public void Hovered()
    {
        if(myBoard.isPlayerSide())
        {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
    }

    public void UnHover()
    {
        if (myBoard.isPlayerSide())
        {
            GetComponent<Renderer>().material.color = myColor;
        }
    }
}
