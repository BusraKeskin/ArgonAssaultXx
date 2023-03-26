using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float offset = 0.1f;
    void Start()
    {
        
    }

   void OnEnable()
    {
        movement.Enable();
    }
   void OnDisable()
    {
        movement.Disable();
    }
    void Update()
    {
        float horizontalAxis = movement.ReadValue<Vector2>().x;
        float verticalAxis = movement.ReadValue<Vector2>().y;

        ////float horizontalAxis = Input.GetAxis("Horizontal");
        //Debug.Log(horizontalAxis);
        ////float verticalAxis = Input.GetAxis("Vertical");
        //Debug.Log(verticalAxis);

        transform.localPosition = new Vector3(
            transform.localPosition.x + offset,
            transform.localPosition.y,
            transform.localPosition.z);


    }
}
