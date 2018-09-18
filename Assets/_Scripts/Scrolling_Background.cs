using UnityEngine;
using System.Collections;

public class Scrolling_Background : MonoBehaviour
{
    
    private BoxCollider2D LengthCheck;
    private float VertLength;
    public float MaxScrollSpeed;

    private void Awake()
    {
        LengthCheck = GetComponent<BoxCollider2D>();
        VertLength = LengthCheck.size.y;

    }

    private void Update()
    {
        if (gameObject.transform.position.y < - VertLength)
        {
            BackgroundReposition();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D r2d = GetComponent<Rigidbody2D>();
        r2d.velocity = Vector2.ClampMagnitude(r2d.velocity, MaxScrollSpeed);
    }

    private void BackgroundReposition()
    {
        Vector2 vertOffset = new Vector2(0, VertLength * 3f);
        transform.position = (Vector2) transform.position + vertOffset;
    }
}