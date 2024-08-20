using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardCursor : MonoBehaviour
{
    private Vector2 direction;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        direction = (Vector2)(mousePos - transform.position);

        angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
