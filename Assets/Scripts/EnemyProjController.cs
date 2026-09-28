using TMPro;
using UnityEngine;

public class EnemyProjController : MonoBehaviour
{
    public float bulletSpeed = 20.0f;
    public float lifespan = 3.0f;
    public int damage = 10;

    public TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject hud = GameObject.Find("HUD");
        healthText = hud.transform.Find("Player Health").GetComponent<TextMeshProUGUI>();

        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMove>(out PlayerMove playerVar))
        {
            playerVar.health -= damage;

            ScoreManager.Instance.AddScore(-25);

            healthText.SetText("HEALTH: " + playerVar.health.ToString());

            Destroy(gameObject);
        }
    }
}
