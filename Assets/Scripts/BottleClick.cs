using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleClick : MonoBehaviour
{
    // Start is called before the first frame update
    private Bottle bottle;
    private RaycastHit2D hit;
    private Ray ray;

    private bool drag;
    [SerializeField] private Vector3 oldPos;
    [SerializeField] private Vector3 newPos;

    private BottleClick otherBottle;

    void Start()
    {
        bottle = GetComponent<Bottle>();
        oldPos = transform.position;
        newPos = oldPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bottle"))
        {
            newPos = collision.transform.position;
            otherBottle = collision.GetComponent<BottleClick>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Bottle"))
        {
            newPos = oldPos;
            otherBottle = null;
        }
    }
    private void OnMouseDown()
    {
        drag = true;
    }

    private void OnMouseUp()
    {
        drag = false;
        if (newPos != oldPos)
        {
            transform.position = newPos;
            otherBottle.transform.position = oldPos;
            otherBottle.SetOldPos(oldPos);
            oldPos = newPos;
        }
        else if(newPos == oldPos)
        {
            transform.position = newPos;
        }
    }
    // Update is called once per frame
    void Update()
    {
        BottleDrag();
    }

    public void SetOldPos(Vector3 pos)
    {
        newPos = oldPos = pos;
    }

    void BottleClickSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                bottle.SetColor(Color.yellow);
            }
        }
    }

    private void BottleDrag()
    {
        if (drag)
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(MousePos);
        }
    }
}
