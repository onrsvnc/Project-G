using UnityEngine;


public class PlayerController : MonoBehaviour
{   
    [SerializeField] float moveSpeed; 
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -7f;
    [SerializeField] float positionYawFactor = 4f;
    [SerializeField] float controlRollFactor = -25f;
    float xThrow, yThrow;


    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * moveSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedxPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * moveSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedyPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedxPos, clampedyPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float rollDueToControl = xThrow * controlRollFactor;
        float roll = rollDueToControl;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
