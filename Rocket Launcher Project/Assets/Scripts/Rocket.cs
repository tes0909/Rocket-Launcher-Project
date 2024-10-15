using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb;
    private float fuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void Shoot()
    {
        if(fuel >= 10)
        {
            rb.AddForce(Vector2.up * SPEED,ForceMode2D.Impulse); // 백터의 방향과 크기로 힘을 줌
            fuel -= FUELPERSHOOT;
        }
        else
        {

        }
       
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
    }
}
