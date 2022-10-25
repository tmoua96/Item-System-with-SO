using UnityEngine;

[CreateAssetMenu(menuName = "Logging/Logger")]
public class Logging : ScriptableObject
{
    [SerializeField]
    private bool showLogs = true;
    [SerializeField]
    private string prefix;
    [SerializeField]
    private Color prefixColor;

    private string hexColor;

    public void Log(object message, Object sender)
    {
        if (showLogs)
        {
            Debug.Log($"<color={hexColor}>{prefix}: {message}. Sender: {sender.name}</color>", sender);
        }
    }

    public void Log(object message, object sender)
    {
        if (showLogs)
        {
            Debug.Log($"<color={hexColor}>{prefix}: {message}. Sender: {sender.GetType()}</color>");
        }
    }

    public void LogError(object message, Object sender)
    {
        if (showLogs)
        {
            Debug.LogError($"<color={hexColor}>{prefix}: {message}. Sender: {sender.name}", sender);
        }
    }

    public void LogError(object message, object sender)
    {
        if (showLogs)
        {
            Debug.LogError($"<color={hexColor}>{prefix}: {message}. Sender: {sender.GetType()}");
        }
    }

    private void OnValidate()
    {
        hexColor = $"#{ColorUtility.ToHtmlStringRGBA(prefixColor)}";
    }
}
