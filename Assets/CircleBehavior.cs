using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleBehavior : MonoBehaviour
{
    public Vector3 position;
    private Vector2 direction;
    public float distance;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        while (direction.x == 0 && direction.y == 0)
        {
            direction.x = Random.Range(-10, 11);
            direction.y = Random.Range(-10, 11);
            direction=direction.normalized; 
        }

    }
    public void DoUpdate()
    {
        position = gameObject.transform.position;
        if (position.y > 4.5f || position.y < -4.5f)
        {
            direction.y *= -1;
            position = gameObject.transform.position;
        }
        if (position.x > 8.4f || position.x < -8.4f)
        {
            direction.x *= -1;
            position = gameObject.transform.position;
        }
        Vector3 newpos = new Vector3(position.x + direction.x*1/60, position.y + direction.y*1/60, position.z);
        gameObject.transform.position = newpos;
    }

    public void ChangeColor(int c)
    {
        Debug.Log(c);
        _spriteRenderer.color = new Color(255,0,0);
    }
    public void ChangeColorGreen()
    {
        _spriteRenderer.color = Color.green;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
