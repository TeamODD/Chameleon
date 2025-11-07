using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Set Stage's "START X'pos" and "END X'Pos". It will controll Camera's MaxMove.
    // 0-index is "START X'pos" and 1-index is "END X'pos".'

    [SerializeField] Transform stageLength;
    [SerializeField] private Transform player; // player's Transform
    [SerializeField] private float smoothSpeed = 5f; // smooth

    float stageEnd;
    float stageStart;
    float cameraHeight; 
    float cameraWidth;

    void Start()
    {
        cameraHeight = Camera.main.orthographicSize * 2f;
        cameraWidth = cameraHeight * Camera.main.aspect;

        stageEnd = (stageLength.localScale.x) / 2 + stageLength.position.x;
        Debug.Log($"끝점 : {stageEnd}");
        stageStart = stageLength.position.x - (stageLength.localScale.x) / 2;
        Debug.Log($"시작점 : {stageStart}");
    }

    void LateUpdate()
    {
        Vector3 targetPos = player.position;

        float clampedX = Mathf.Clamp(targetPos.x, stageStart + (cameraWidth / 2), stageEnd - (cameraWidth / 2));

        Vector3 clampedPos = new Vector3(clampedX, 0, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, clampedPos, smoothSpeed * Time.deltaTime);  
    }
}
