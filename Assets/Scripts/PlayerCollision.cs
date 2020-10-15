using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody playerRigidBody;
    public Renderer playerRenderer;
    public PlayerMovement playerMovement;

    public int playerHealth = 10;
    public Color currentPlayerColor = new Color(1f, 1f, 1f, 1f);
    public float colorDecreaseAmount = 0.1f;

    void Start()
    {
        playerRenderer = playerRigidBody.GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var tag = collision.collider.tag;
        if (tag == "Obstacle")
            handleObstacleCollision();
        else if (tag == "Health")
            handleHealthCollision(collision);
    }

    void handleObstacleCollision()
    {
        playerHealth--;
        changePlayerColor();
        if (playerHealth < 1)
        {
            playerMovement.enabled = false;
        }
    }

    void handleHealthCollision(Collision collision)
    {
        var healthCapsule = collision.gameObject;
        healthCapsule.SetActive(false);
        resetPlayerHealth();
    }

    void changePlayerColor()
    {
        float newGreenValue = currentPlayerColor.g - colorDecreaseAmount;
        currentPlayerColor = new Color(1f, newGreenValue, 1f, 1f);
        playerRenderer.material.SetColor("_Color", currentPlayerColor);
    }

    void resetPlayerHealth()
    {
        playerHealth = 10;
        currentPlayerColor = new Color(1f, 1f, 1f, 1f);
        playerRenderer.material.SetColor("_Color", currentPlayerColor);
    }
}
