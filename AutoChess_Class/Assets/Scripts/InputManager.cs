using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    //Player Camera
    public Camera playerView;
    

    //UI Inputs
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    List<RaycastResult> UILookingAt = new List<RaycastResult>();

    //GameWorld Inputs
    GameObject LookingAt;


    // Start is called before the first frame update
    void Start()
    {
        playerView = FindObjectOfType<Camera>();

        m_EventSystem = FindObjectOfType<EventSystem>();
        m_Raycaster = GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        //future ui elements will use this
        //UILookingAt = UIPointingAt();
        

        //Detects what the player hovers over in the game world
        if (LookingAt != null)
        {
            if (PointingAt() != LookingAt)
            {
                if (LookingAt.GetComponent<ISelectable>() != null)
                {
                    LookingAt.GetComponent<ISelectable>().UnHover();
                }
            }
        }

        LookingAt = PointingAt();
        if (LookingAt != null)
        {
            if (LookingAt.GetComponent<ISelectable>() != null)
            {
                LookingAt.GetComponent<ISelectable>().Hovered();
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (LookingAt.GetComponent<ISelectable>() != null)
                {
                    LookingAt.GetComponent<ISelectable>().ClickedOn();
                }
            }
        }
    }

    public GameObject PointingAt()
    {
        Ray ray = playerView.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject go = hitInfo.collider.gameObject;
            if (go != null)
            {
                return go;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }


    }
    public List<RaycastResult> UIPointingAt()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);

        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        return results;
    }
}
