using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiTankController : MonoBehaviour {
    public GameObject wayPointObj;
    private List<Vector3> wayPointPoses = new List<Vector3>();
    private bool WayPointsSet = false;

    // Use this for initialization
    void Start() {
        SetupWayPoints();
    }

	// Update is called once per frame
	void Update () {

        if (WayPointsSet)
        {
            Vector3 directionToMove = transform.position - wayPointPoses[0];

            Vector3 targetPos = wayPointPoses[0];

            Quaternion toRot = Quaternion.LookRotation(targetPos - transform.position);

            transform.rotation = Quaternion.Lerp(transform.rotation, toRot, Time.deltaTime * 5);
            
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 1f)
            {
                Vector3 temp = wayPointPoses[0];
                wayPointPoses.RemoveAt(0);
                wayPointPoses.Add(temp);
            }
        }

    }

    void SetupWayPoints() {

        Vector3 centrePos = transform.position;

        float radiusX = Mathf.PI * 2;
        float radiusY = Mathf.PI * 2;

        int numPoints = 5;

        for (float pointNum = 0; pointNum < numPoints; pointNum++)
        {
            float i = (float)(pointNum * 1.0) / numPoints;
            // get the angle for this step (in radians, not degrees)
            var angle = i * Mathf.PI * 2;
            // the X &amp; Y position for this angle are calculated using Sin &amp; Cos
            var x = Mathf.Sin(angle) * radiusX;
            var y = Mathf.Cos(angle) * radiusY;
            Vector3 pos = new Vector3(x, 0, y) + centrePos;
            wayPointPoses.Add(pos);
            // no need to assign the instance to a variable unless you're using it afterwards:
            GameObject wayPoint = Instantiate(wayPointObj, pos, Quaternion.identity);
        }

        WayPointsSet = true;

    }
}
