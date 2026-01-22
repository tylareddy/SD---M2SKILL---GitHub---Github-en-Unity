using UnityEngine;

public class ProximityExhibit : MonoBehaviour
{
    public string exhibitName = "Gaming Artifact";
    public float detectionRange = 3.0f;
    private bool hasShownInfo = false;
    private Transform playerCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = Camera.main.transform;

        if (playerCamera == null)
        {
            Debug.Log("No camera found for " + exhibitName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerDistance();
    }

    void CheckPlayerDistance()
    {
        if (playerCamera == null) return;

        float distance = Vector3.Distance(transform.position, playerCamera.position);

        if (distance < detectionRange && !hasShownInfo)
        {
            ShowExhibitInfo();
            hasShownInfo = true;
        }

        if (distance > detectionRange * 1.5f)
        {
            hasShownInfo = false;
        }
    }

    void ShowExhibitInfo()
    {
        Debug.Log("APPROACHING: " + exhibitName);
        Debug.Log("Information display activated...");

        SendMessage("ShowInfo", SendMessageOptions.DontRequireReceiver);
    }
}
