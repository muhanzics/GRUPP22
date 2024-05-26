using UnityEngine;

public class PanelController : MonoBehaviour
{
    private void OnEnable()
    {
        DoNotDestroy.Instance.RegisterPanel(this.gameObject);
    }

    private void OnDisable()
    {
        DoNotDestroy.Instance.UnregisterPanel(this.gameObject);
    }
}
