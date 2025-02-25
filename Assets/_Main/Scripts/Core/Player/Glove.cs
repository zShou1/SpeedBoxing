using System;
using UnityEngine;

public class Glove : Node
{
    public BallColor gloveColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (other.TryGetComponent(out Ball ball))
            {
                //  + Thật: Red, Yellow
                //  + Giả: White, Brown, Orange
                
                var isRealBall= ball.ballColor is BallColor.Red or BallColor.Yellow;

                if (isRealBall)
                {
                    // Nếu là bóng thật, kiểm tra màu
                    if (ball.ballColor == gloveColor)
                    {
                        // Đấm đúng màu
                        GameManager.Instance.AddScore(50);
                    }
                    else
                    {
                        // Đấm sai màu
                        GameManager.Instance.AddScore(-20);
                    }
                }
                else
                {
                    //Bóng giả
                    GameManager.Instance.AddScore(-20);
                }
                ball.Deactivate();
            }
        }
    }
}
