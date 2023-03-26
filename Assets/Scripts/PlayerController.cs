using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float speedControl = 5f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

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

        float offsetX = horizontalAxis * Time.deltaTime * speedControl;
        float offsetY = verticalAxis * Time.deltaTime * speedControl;

        float newXPos = transform.localPosition.x + offsetX;
        float newYPos = transform.localPosition.y + offsetY;

        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
        

    }
}
