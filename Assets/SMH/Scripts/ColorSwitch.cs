using UnityEngine;
using System.Collections;

public class ColorSwitch : MonoBehaviour
{
    public int objectColorIndex;
    [SerializeField]
    Transform targetPlatform, arrivePlatform;

    [SerializeField]
    float speed = 5f;

    public void SwitchOn()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (Vector2.Distance(targetPlatform.position, arrivePlatform.position) > 0.01f)
        {
            targetPlatform.position = Vector2.MoveTowards(
                targetPlatform.position,
                arrivePlatform.position,
                speed * Time.deltaTime
            );

            yield return null;
        }

        targetPlatform.position = arrivePlatform.position;
    }
    /*
    public void SwitchOn()
    {
        while(targetPlatform.position != arrivePlatform.position)
            targetPlatform.position = Vector2.MoveTowards(targetPlatform.position, arrivePlatform.position, Time.deltaTime);
    }
    */
}
