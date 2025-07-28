using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private float speed = 10.0f;
    private Vector3 mousePos;

    void Start()
    {
        Input.multiTouchEnabled = false;
    }

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            player.transform.Translate(Vector3.MoveTowards(player.transform.position, targetPos, speed * Time.deltaTime) - player.transform.position);
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePos, speed);
        }
    }
}
