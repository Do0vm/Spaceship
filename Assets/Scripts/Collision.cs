using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AsteroidCollision : MonoBehaviour
{
    public float radius; 
    public bool isLaserBeam;
    public bool isAsteroid;

    
    public GameObject mediumAsteroidPrefab;
    public GameObject smallAsteroidPrefab;

    
    public bool isDestroyGizmo = true; 

    
    private static List<AsteroidCollision> activeObjects = new List<AsteroidCollision>();

    
    public static int smallAsteroidsDestroyed = 0;

    private void OnEnable()
    {
        activeObjects.Add(this);
    }

    private void OnDisable()
    {
        activeObjects.Remove(this);
    }

    private void Update()
    {
        
        if (!isLaserBeam && !isAsteroid)
        {
            CheckSpaceshipCollisions();
        }

        
        if (isLaserBeam)
        {
            CheckAsteroidCollisions();
        }
    }

    private void CheckAsteroidCollisions()
    {
        foreach (AsteroidCollision otherObject in activeObjects)
        {
            
            if (otherObject == this || !otherObject.isAsteroid) continue;

            
            Vector2 difference = (Vector2)(otherObject.transform.position - transform.position);
            float squareDistance = difference.x * difference.x + difference.y * difference.y;

            
            if (squareDistance < (radius + otherObject.radius) * (radius + otherObject.radius))
            {
                if (otherObject.isDestroyGizmo)
                {
                    HandleDestroyGizmo(otherObject);
                }
                else
                {
                    HandleSpawnGizmo(otherObject);
                }
                break; 
            }
        }
    }

    private void CheckSpaceshipCollisions()
    {
        
        Vector2 spaceshipPosition = new Vector2(transform.position.x, transform.position.y);

        
        foreach (AsteroidCollision asteroid in activeObjects)
        {
            if (!asteroid.isAsteroid) continue;

            
            Vector2 asteroidPosition = new Vector2(asteroid.transform.position.x, asteroid.transform.position.y);

            
            Vector2 difference = asteroidPosition - spaceshipPosition;
            float squareDistance = difference.sqrMagnitude; 
            
            if (squareDistance < (radius + asteroid.radius) * (radius + asteroid.radius))
            {
                Debug.Log("Spaceship hit an asteroid. Game Over!");
                SceneManager.LoadScene("GameOver"); 
                break; 
            }
        }
    }

    private void HandleDestroyGizmo(AsteroidCollision hitAsteroid)
    {
        Debug.Log($"Destroy Gizmo hit: {hitAsteroid.name}");

        
        if (isLaserBeam)
        {
            Destroy(gameObject);
        }

        if (hitAsteroid.isAsteroid)
        {
           
            if (hitAsteroid.transform.localScale == Vector3.one) 
            {
                
                SpawnSplitAsteroids(hitAsteroid, mediumAsteroidPrefab, 2);
            }
            else if (hitAsteroid.transform.localScale == Vector3.one * 0.5f) 
            {
                
                SpawnSplitAsteroids(hitAsteroid, smallAsteroidPrefab, 2);
            }
            else 
            {
                smallAsteroidsDestroyed++;

                
                if (smallAsteroidsDestroyed >= 12)
                {
                    OnWinConditionMet();
                }

                Destroy(hitAsteroid.gameObject);
            }
        }
    }

    private void HandleSpawnGizmo(AsteroidCollision hitAsteroid)
    {
        Debug.Log($"Spawn Gizmo hit: {hitAsteroid.name}");

  
        if (isLaserBeam)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    private void SpawnSplitAsteroids(AsteroidCollision originalAsteroid, GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Debug.Log($"Instantiating new asteroid from: {originalAsteroid.name}");

            
            GameObject newAsteroid = Instantiate(prefab, originalAsteroid.transform.position, Quaternion.identity);

            // random offset
            Vector2 randomOffset = Random.insideUnitCircle * 1f; 
            newAsteroid.transform.position += (Vector3)randomOffset;

            //  velocity
            Rigidbody2D rb = newAsteroid.GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.velocity = Random.insideUnitCircle * 5f; 
            }
        }

        
        Debug.Log($"Destroying Spawn Gizmo: {originalAsteroid.name}");
        Destroy(originalAsteroid.gameObject);
    }

    private void OnWinConditionMet()
    {
        Debug.Log("You Won!");

        SceneManager.LoadScene("YouWon");
    }

    private void OnDrawGizmos()
    {
        if (isAsteroid)
        {
            Gizmos.color = Color.blue; 
            Gizmos.DrawWireSphere(transform.position, radius);
        }
        else if (!isLaserBeam && !isAsteroid)
        {
            Gizmos.color = Color.green; 
            Gizmos.DrawWireSphere(transform.position, radius);
        }
        else
        {
            Gizmos.color = Color.red; 
        }
    }
}
