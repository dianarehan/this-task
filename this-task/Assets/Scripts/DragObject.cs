using UnityEngine;
using System.Collections;



public class DragObject : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isSupervisor;
    private bool isNormal;
    private string typeOfUser;
    private void Start()
    {
        typeOfUser = readFromFile.typeOfUser;
        Debug.Log(typeOfUser);
        Debug.Log("isnormal "+ isNormal);
        Debug.Log("is Supervisor " + isSupervisor);
    }




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // typeOfUser.CompareTo("normal")==0||
            setNormal();
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            //typeOfUser.CompareTo("supervisor") == 0||
            setSupervisor();
        }
    }


    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {   

        if((isNormal&& gameObject.CompareTag("blueObject")) || isSupervisor)
        {
            
                Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                transform.position = curPosition;

            
        }
        
        

    }


    private void setSupervisor()
    {
        
        isSupervisor = !isSupervisor;
        isNormal = !isSupervisor;
    }


    private void setNormal()
    {
        isNormal = !isNormal;
        isSupervisor = !isNormal;
    }
}