using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8.0f;

    void Start()
    {
    }

    void Update()
    {
        this.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
   
}
