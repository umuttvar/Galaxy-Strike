using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;

    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFiring = false;


    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        CrosshairTracking();
        TargetPointTracking();
        AimLasers();
    }
    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
            foreach (GameObject lasser in lasers)
            {
                ParticleSystem.EmissionModule emmisionModule = lasser.GetComponent<ParticleSystem>().emission;
                emmisionModule.enabled = isFiring;
            }
    }

    void CrosshairTracking()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        crosshair.position = mousePos;
    }

    void TargetPointTracking()
    {
       
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 targetPointPosition = new Vector3(mousePos.x, mousePos.y, targetDistance);

        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    
    void AimLasers()
    {
        foreach(GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
    
}
