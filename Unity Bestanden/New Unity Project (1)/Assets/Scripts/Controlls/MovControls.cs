using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovControls : MonoBehaviour
{
    public Camera OverheadCam;
    
    public float MoveSpeed;

    float moveHorizontal;
    float moveVertical;
    Vector3 movement;

    void Start()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.Self);
        }

        //Get the Screen positions of the object
        Vector2 positionOnScreen = OverheadCam.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)OverheadCam.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0));


        float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }
}