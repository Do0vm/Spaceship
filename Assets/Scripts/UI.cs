using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShipStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI accelerationText;
    [SerializeField] private TextMeshProUGUI timeText;

    private SpaceShip shipController;
    public TMP_Text killCountText;  

    private int totalKillCount = 0;
    private int smallAsteroidsDestroyed = 0;
    void Start()
    {
        shipController = FindObjectOfType<SpaceShip>();
        UpdateKillCountDisplay();

    }

    void Update()
    {
        if (shipController != null)
        {
            speedText.text = $"Speed: {shipController.currentSpeed:F2}";

            accelerationText.text = $"Acceleration: {(shipController.IsStanding ? 0 : shipController.acceleration):F2}";

            timeText.text = $"Time: {Time.time:F2}";
        }
    }



    public void OnAsteroidDestroyed(AsteroidCollision asteroid)
    {
        
        if (asteroid.isAsteroid)
        {
            if (asteroid.transform.localScale == Vector3.one) 
            {
                totalKillCount += 3;  
            }
            else if (asteroid.transform.localScale == Vector3.one * 0.5f) 
            {
                totalKillCount += 1;  
            }
            else if (asteroid.transform.localScale == Vector3.one * 0.25f) 
            {
                totalKillCount += 1;  
                smallAsteroidsDestroyed++;
            }
        }

        
        UpdateKillCountDisplay();

        if (smallAsteroidsDestroyed == 27)
        {
            OnWinConditionMet();
        }
    }

    private void UpdateKillCountDisplay()
    {
        if (killCountText != null)
        {
            killCountText.text = "Asteroid Kill Count: " + totalKillCount.ToString();
        }
    }

    private void OnWinConditionMet()
    {
        Debug.Log("You Win!");

        SceneManager.LoadScene("WinScene"); 
    }


}