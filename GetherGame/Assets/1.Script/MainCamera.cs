using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject Player;

    public BoxCollider2D Bound;
    private Vector3 PlayerPosition;
    private Vector3 MinBound;
    private Vector3 MaxBound;

    private float halfWidth;
    private float halfHeight;

    private new Camera camera;

    public float MoveSpeed;
    public float minusY;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        if(Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void Start()
    {
        camera = GetComponent<Camera>();
        MinBound = Bound.bounds.min;
        MaxBound = Bound.bounds.max;
        halfHeight = camera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    private void Update()
    {
        if (Player.gameObject != null)
        {
            PlayerPosition.Set(Player.transform.position.x, Player.transform.position.y - minusY, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, PlayerPosition, MoveSpeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(this.transform.position.x, MinBound.x + halfWidth, MaxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, MinBound.y + halfWidth, MaxBound.y - halfWidth);


            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
