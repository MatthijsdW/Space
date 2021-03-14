using System.Linq;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    public GameObject[] asteroidTypes;
    public int[] asteroidWeights;
    public int asteroidAmount;
    public int rerollAttempts;

    public float minX, maxX, minY, maxY, minZ, maxZ;
    
    private GameObject[] asteroids;

    void Start()
    {
        //Get the cumulative weights for asteroids.
        int totalWeight = 0;
        int[] cumulativeWeights = new int[asteroidWeights.Length];
        for (int i = 0; i < asteroidWeights.Length; i++)
        {
            totalWeight += asteroidWeights[i];
            cumulativeWeights[i] = totalWeight;
        }

        asteroids = new GameObject[asteroidAmount];
        for (int i = 0; i < asteroidAmount; i++)
        {
            //Determine which kind of asteroid will be created.
            int randomAsteroid = Random.Range(0, totalWeight);
            int index = 0;
            while (cumulativeWeights[index] <= randomAsteroid)
                index++;
            GameObject chosenAsteroid = asteroidTypes[index];

            //Determine where the asteroid is created
            Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

            //Reroll when an existing asteroid or the player is too close to the current position. After rerollAttempts attempts, assume the area is full and stop creating asteroids.
            int j = 0;
            while (position.sqrMagnitude < 1 || asteroids.Any(x => x != null && (x.transform.position - position).sqrMagnitude < 1))
            {
                if (j > rerollAttempts)
                {
                    return;
                }
                position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
                j++;
            }

            //Instantiate the asteroid
            chosenAsteroid.transform.position = position;
            asteroids[i] = Instantiate(chosenAsteroid);
        }
    }
}
