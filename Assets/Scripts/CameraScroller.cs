using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    public Vector3 startPos;
    public List<Section> cameraPath;

    [SerializeField] private int curFlag = 0;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float smoothTime = 0.125f;
    void LateUpdate()
    {

        Vector3 camHeightPos = cameraPath[curFlag].endPos + new Vector3(0, 0, -5);
        transform.position = Vector3.SmoothDamp(transform.position, camHeightPos, ref velocity, smoothTime, cameraPath[curFlag].Speed);


        if (Vector3.Distance(transform.position, camHeightPos) < 0.1f){
            if(GameManager.instance.player.raisedEndFlag){
                curFlag--;
            }else{
                curFlag++;
            }
        }
        

    }

    [Header("Path visualizaion")]
    [SerializeField] private Gradient gradient;
    void OnDrawGizmos()
    {
        for (int i = 0; i < cameraPath.Count; i++)
        {
            Gizmos.color = gradient.Evaluate(cameraPath[i].Speed / 5);
            if (i - 1 < 0)
                Gizmos.DrawLine(startPos, cameraPath[i].endPos);
            else
                Gizmos.DrawLine(cameraPath[i - 1].endPos, cameraPath[i].endPos);
        }
    }
}


[System.Serializable]
public struct Section
{
    public Vector3 endPos;
    public float Speed;
}