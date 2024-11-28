using UnityEngine;
using TMPro;

public class ShipStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI accelerationText;
    [SerializeField] private TextMeshProUGUI timeText;

    private SpaceShip shipController;

    void Start()
    {
        shipController = FindObjectOfType<SpaceShip>();
    }

    void Update()
    {
        if (shipController != null)
        {
            // Update speed text
            speedText.text = $"Speed: {shipController.currentSpeed:F2}";

            // Update acceleration text
            accelerationText.text = $"Acceleration: {(shipController.IsStanding ? 0 : shipController.acceleration):F2}";

            // Update time text
            timeText.text = $"Time: {Time.time:F2}";
        }
    }
}