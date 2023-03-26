using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float speedControl = 5f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    [SerializeField] float pitchPositionFactor = -2f;
    [SerializeField] float pitchControlFactor = -10f;
    [SerializeField] float yawPositionFactor = 2f;
    [SerializeField] float rollControlFactor = -20f;

    float newXPos, newYPos;

   

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
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessTranslation()
    {
        float horizontalAxis = movement.ReadValue<Vector2>().x;
        float verticalAxis = movement.ReadValue<Vector2>().y;

        float offsetX = horizontalAxis * Time.deltaTime * speedControl;
        float offsetY = verticalAxis * Time.deltaTime * speedControl;

        newXPos = transform.localPosition.x + offsetX;
        newYPos = transform.localPosition.y + offsetY;

        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    void ProcessRotation()
    {
        //pitch,yaw,roll 
        float pitchDueToPosition = transform.localPosition.y * pitchPositionFactor;
        float pitchDueToControl = newYPos * pitchControlFactor;
        float yawDueToPosition = transform.localPosition.x * yawPositionFactor;
        ;
        float rollDueToControl = newXPos * rollControlFactor;

        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = yawDueToPosition;
        float roll = rollDueToControl;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
