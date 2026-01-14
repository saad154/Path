using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool isPaused;
    public bool overState;
    public bool finishedState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPaused = false;
        overState = false;
        finishedState = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
