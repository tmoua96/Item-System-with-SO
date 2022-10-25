using UnityEngine;

public interface IInteractable
{
    public float MaxInteractRange { get; }

    public void OnHover();
    public void Interact(MonoBehaviour user);
    public void OnEndHover();
}
