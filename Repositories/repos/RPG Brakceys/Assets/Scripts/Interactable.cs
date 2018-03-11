using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocused = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        // This method is meant to be overridden.
        Debug.Log("Interacting with " + interactionTransform.name);
    }

    private void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
