using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool AutoPlay;
    const int blocksNumber = 16;

    void Update()
    {
        float xPaddlePosition;
        if (AutoPlay) xPaddlePosition = FindObjectOfType<Ball>().transform.position.x;
        else
        {
            float brickWidth = GetComponent<PolygonCollider2D>().bounds.size.x;
            float paddlePositionInBlocks = Input.mousePosition.x / Screen.width * blocksNumber;
            xPaddlePosition = Mathf.Clamp(paddlePositionInBlocks, 0f + brickWidth / 2, blocksNumber - brickWidth / 2);
        }
        TransformPaddlePostion(xPaddlePosition);
    }

    private void TransformPaddlePostion(float xPosition)
    {    
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
