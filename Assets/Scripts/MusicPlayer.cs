using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer _instance = null;

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
