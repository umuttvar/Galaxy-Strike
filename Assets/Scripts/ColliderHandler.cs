using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;

    void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity); 
        Destroy(this.gameObject);
    }
}
