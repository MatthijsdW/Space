using System;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    [SerializeField]
    private float distance;
    private float distanceSquared;
    private GameObject player;
    private GameObject[] asteroids;
    private GameObject panel;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        panel = transform.GetChild(0).gameObject;
        distanceSquared = distance * distance;
    }

    void Update()
    {
        //Find the closest asteroid.
        GameObject closestAsteroid = null;
        float closestDistanceSquared = float.PositiveInfinity;
        for (int i = 0; i < asteroids.Length; i++)
        {
            float currentDistanceSquared = (asteroids[i].transform.position - player.transform.position).sqrMagnitude;
            if (currentDistanceSquared < closestDistanceSquared)
            {
                closestAsteroid = asteroids[i];
                closestDistanceSquared = currentDistanceSquared;
            }
        }

        //If the closest asteroid is closer than the specified distance, show the info panel and fill the text fields with data from the asteroid.
        if (closestDistanceSquared < distanceSquared)
        {
            panel.SetActive(true);
            AsteroidData asteroidData = closestAsteroid.GetComponent<AsteroidData>();
            if (asteroidData)
            {
                TMPro.TMP_Text textHeader = panel.transform.Find("Header").GetComponent<TMPro.TMP_Text>();
                textHeader.text = asteroidData.Name;

                TMPro.TMP_Text textContent = panel.transform.Find("Text").GetComponent<TMPro.TMP_Text>();
                textContent.text = $"Distance: {Math.Round(Math.Sqrt(closestDistanceSquared), 2)}";
                for (int i = 0; i < asteroidData.OreNames.Length; i++)
                {
                    textContent.text += $"\n{asteroidData.OreNames[i]}: {asteroidData.OreQuantities[i]} kg";
                }
            }
        }
        //Hide the panel when the closest asteroid is too far away.
        else
        {
            panel.SetActive(false);
        }
    }
}
