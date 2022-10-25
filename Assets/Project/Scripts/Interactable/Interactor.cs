using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private float boxHalfSize = 0.5f;
    [SerializeField]
    private float interactDistance = 2f;
    [SerializeField]
    private LayerMask interactableMask;
    [SerializeField]
    private Vector3 interactableStartOffset;

    [SerializeField]
    private Logging logger;

    private IInteractable currentInteractable;

    public void Interact()
    {
        if(currentInteractable != null)
            currentInteractable.Interact(this);
    }

    public bool HasInteractable()
    {
        if(Physics.BoxCast(transform.position + interactableStartOffset, Vector3.one * boxHalfSize, transform.forward, out RaycastHit hit, Quaternion.identity, interactDistance, interactableMask, QueryTriggerInteraction.Collide))
        {
            if(hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {

                logger?.Log("interactable detected", this);
                currentInteractable = interactable;
                return true;
            }
        }

        logger?.Log("interactable not detected", this);

        currentInteractable = null;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position + interactableStartOffset + transform.forward * interactDistance, 2 * boxHalfSize * Vector3.one);
    }
}
