using UnityEngine;
using System.Collections;



public class DragObject : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isSupervisor;
    private bool isNormal;
    private static string typeOfUser;

    
    void Update()
    {
        if (typeOfUser!=null &&typeOfUser.CompareTo("normal")==0)
        {
            setNormal();
        }
        if(typeOfUser != null &&typeOfUser.CompareTo("supervisor")==0)
        {
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
    public static void setTheUserType(string type)
    {   

        typeOfUser = type;
        Debug.Log("current type of user is: " + typeOfUser);

    }

    private void setSupervisor()
    {
        
        isSupervisor = true;
        isNormal = false;
    }


    private void setNormal()
    {
        isNormal = true;
        isSupervisor = false;
    }
}