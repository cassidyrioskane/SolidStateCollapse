using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ObstacleRise : MonoBehaviour
{
    public Transform player;
    public GameObject obstacle;
    
    public float triggerValueZAxis = 517f;
    public float triggerRangeZAxis = 50f;
    public float obstacleEndPointYAxis = 0.08f;
    public float riseAmount = 0.05f;
    public bool obstacleIsRising = false;

    // Update is called once per frame
    void Update()
    {
        if (!obstacleIsRising && (player.position.z > triggerValueZAxis - triggerRangeZAxis 
           && player.position.z < triggerValueZAxis + triggerRangeZAxis))
        {
            Debug.Log("Rise triggered");
            moveObstacleUp();
            obstacleIsRising = true;
        } 
        else if (obstacleIsRising)
        {
            moveObstacleUp();
            if (obstacle.transform.position.y > obstacleEndPointYAxis)
                obstacleIsRising = false;
        }
    }

    void moveObstacleUp()
    {
        var obstacleOldPosition = obstacle.transform.position;
        float obstacleNewPositionY = obstacleOldPosition.y + riseAmount;
        Debug.Log("new Y pos: " + obstacleNewPositionY);

        obstacle.transform.position = new Vector3(obstacleOldPosition.x, obstacleNewPositionY, obstacleOldPosition.z);
        Debug.Log("In object "+obstacle.transform.position.y);
    }
}
