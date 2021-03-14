using UnityEngine;

public class AsteroidData : MonoBehaviour
{
    public string Name;
    public string[] OreNames;

    [SerializeField]
    private float minQuantity, maxQuantity;

    public float[] OreQuantities { get; private set; }

    void Start()
    {
        //Generate random values for ore quantities.
        OreQuantities = new float[OreNames.Length];
        for (int i = 0; i < OreQuantities.Length; i++)
        {
            OreQuantities[i] = (float)System.Math.Round(Random.Range(minQuantity, maxQuantity), 2);
        }
    }
}
