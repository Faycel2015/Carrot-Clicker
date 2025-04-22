using UnityEngine;
using System;
public class InputManager : MonoBehaviour
{
    [Header(" Actions ")]
    public static Action onCarrotClicked;
    public static Action<Vector2> onCarrotClickedPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
            ManageTouches();

        /*
        if (Input.GetMouseButtonDown(0))
            ThrowRaycast();
        */
    }

    private void ManageTouches()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
                ThrowRaycast(touch.position);
        }
    }

    private void ThrowRaycast(Vector2 touchPosition)
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(touchPosition));
        if (hit.collider == null)
            return;

        Debug.Log("We hit a carrot!");
        onCarrotClicked?.Invoke();

        onCarrotClickedPosition?.Invoke(hit.point);
    }

}