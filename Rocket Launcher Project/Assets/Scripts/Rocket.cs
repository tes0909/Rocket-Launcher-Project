using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb;
    private float fuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;

    private const string key = "highScore";

    private int currentScore = 0;
    private int highScore = 0;
    private float maxHeight = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentScoreTxt.text = $"{currentScore} M";
        highScoreTxt.text = $"{highScore} M";
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
    private void Update()
    {
        float Height = transform.position.y;

        if (Height > maxHeight) 
        {
            maxHeight = Height;
            PlayerPrefs.SetFloat(key, maxHeight);
            highScoreTxt.text = $"HIGH : {maxHeight:F0} M";
        }
        else
        {
            currentScoreTxt.text = $"{Height:F0} M";
        }
    }
    
    public void RetryButton()
    {
        SceneManager.LoadScene("RocketLauncher");
    }
}
