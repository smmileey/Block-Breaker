using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int BrickCount;
    public Sprite[] HitAppearances;
    public GameObject Smoke; 

    private LevelManager _levelManager;
    private bool _isBreakable;
    private int _maxHit;
    private int _timesHit;

    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _maxHit = HitAppearances.Length + 1;
        if (_isBreakable = tag.Equals("Breakable"))
        {
            BrickCount++;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (tag.Equals("Breakable")) HandleBlockHit();
    }

    private void HandleBlockHit()
    {
        if (++_timesHit >= _maxHit)
        {
            BrickCount--;
            _levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            int spriteIndex = _timesHit - 1;
            if (HitAppearances[spriteIndex]) GetComponent<SpriteRenderer>().sprite = HitAppearances[spriteIndex];
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
        }
    }

    private void PuffSmoke()
    {
        GameObject puff = Instantiate(Smoke, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule mainModule = puff.GetComponent<ParticleSystem>().main;
        mainModule.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
}
