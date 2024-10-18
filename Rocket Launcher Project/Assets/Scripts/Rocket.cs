using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb;
    SpriteRenderer rbSprite;
    
    private float Fuel = 100f;
    private readonly float Speed = 5f;
    private readonly float FuelPerShoot = 10f; 

    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;

    private const string key = "highScore";
    private const string RocketLauncherScene = "RocketLauncher";

    private float maxHeight = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = Vector2.zero;
    }
    
    public void Shoot()
    {
        if(Fuel >= FuelPerShoot)
        {
            rb.AddForce(Vector2.up * Speed,ForceMode2D.Impulse); // 백터의 방향과 크기로 힘을 줌
            Fuel -= FuelPerShoot;
            return;
        }
            PlayerPrefs.SetFloat(key, maxHeight);
    }
    private void Update()
    {
        float Height = transform.position.y; // 발판과로켓길이 

        if (Height > maxHeight) 
        {
            maxHeight = Height;
            highScoreTxt.text = $"HIGH : {maxHeight:F0} M";
        }
        else
        {
            currentScoreTxt.text = $"{Height:F0} M";
        }
    }
    
    public void RetryButton()
    {
        SceneManager.LoadScene(RocketLauncherScene);
    }
}
