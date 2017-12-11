using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager _levelManager;

	void OnTriggerEnter2D(Collider2D trigger)
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _levelManager.LoadLevel("Lose");
    } 

    void onCollisionEnter2D(Collision2D collission)
    {
        print("Collision");
    }
}
