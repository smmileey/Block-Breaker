using Assets.Scripts;
using UnityEngine;

public class TagManager : MonoBehaviour {

    public static bool IsBallSoundAllowedForTag(Tags objectTag)
    {
        return objectTag != Tags.Paddle;
    }
}
