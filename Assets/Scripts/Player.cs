using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 5f;
    void Update()
    {
        Move();
    }

    void Move()
    {
        //For continous movement instead of move on press
        //Time.deltaTime is the last frame took to get processed, making it frame rate independant
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
