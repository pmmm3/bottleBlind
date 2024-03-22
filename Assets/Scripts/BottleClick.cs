using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleClick : MonoBehaviour
{
    // Start is called before the first frame update
    private Bottle bottle;
    void Start()
    {
        bottle = GetComponent<Bottle>();
    }

    Vector3 screenPos;
    Vector3 offset;
    RaycastHit hit;
    Ray ray;
    Transform focus;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin,ray.direction,Color.red,5);
            if (Physics.Raycast(ray.origin, ray.direction, out hit)) 
            {
                Debug.Log(hit.collider.tag);
                focus = hit.collider.transform;
                bottle.SetColor(Color.yellow);
                screenPos = Camera.main.WorldToScreenPoint(focus.position);
                offset = focus.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPos.z));
            }
        }
    }
}
