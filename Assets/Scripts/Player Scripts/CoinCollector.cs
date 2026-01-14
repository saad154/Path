using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int totalCoinsintheLevel;
    [SerializeField] int coinsCollectedthisLevel;
    [SerializeField] int allTotalCoins;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinsCollectedthisLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinsCollectedthisLevel++;
        }
    }
}
