using PixelPlay.OffScreenIndicator;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Attach the script to the off screen indicator panel.
/// </summary>
public class OffScreenIndicator : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 screenCentre;
    private Vector3 screenBounds;
    private string targetTag = "Target";

    [Range(0.5f, 0.9f)]
    [Tooltip("Distance offset of the indicators from the centre of the screen")]
    public float screenBoundOffset = 0.9f;

    void Awake()
    {
        mainCamera = Camera.main;
        screenCentre = new Vector3(Screen.width, Screen.height, 0) / 2;
        screenBounds = screenCentre * screenBoundOffset;
    }

    void Update()
    {
        DeactivateAllIndicators();
    }

    void LateUpdate()
    {
        DrawIndicators();
    }

    void DrawIndicators()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag); // Find all the objects with 'Target' tag in the scene.
        List<Target> targets = new List<Target>();
        objects.ToList().ForEach(obj =>
        {
            Target target = obj.GetComponent<Target>();
            if (target) { targets.Add(target); }
        });

        foreach (Target target in targets)
        {
            Vector3 screenPosition = OffScreenIndicatorCore.GetScreenPosition(mainCamera, target.transform.position);
            bool isTargetVisible = OffScreenIndicatorCore.IsTargetVisible(screenPosition);
            float distanceFromCamera = target.NeedDistanceText ? target.GetDistanceFromCamera(mainCamera.transform.position) : float.MinValue;// Gets the target distance from the camera.
            Indicator indicator = null;

            if (target.NeedBoxIndicator && isTargetVisible)
            {
                screenPosition.z = 0;
                indicator = BoxObjectPool.current.GetPooledObject(); // Gets the box indicator from the pool.
            }
            else if (target.NeedArrowIndicator && !isTargetVisible)
            {
                float angle = float.MinValue;
                OffScreenIndicatorCore.GetArrowIndicatorPositionAndAngle(ref screenPosition, ref angle, screenCentre, screenBounds);
                indicator = ArrowObjectPool.current.GetPooledObject(); // Gets the arrow indicator from the pool.
                indicator.transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg); // Sets the rotation for the arrow indicator.
            }
            if (indicator)
            {
                indicator.SetImageColor(target.TargetColor);// Sets the image color of the indicator.
                indicator.SetDistanceText(distanceFromCamera); //Set the distance text for the indicator.
                indicator.transform.position = screenPosition; //Sets the position of the indicator on the screen.
                indicator.SetTextRotation(Quaternion.identity); // Sets the rotation of the distance text of the indicator.
                indicator.Activate(true); // Sets the indicator as active.
            }
        }
    }

    private void DeactivateAllIndicators()
    {
        BoxObjectPool.current.DeactivateAllPooledObjects();
        ArrowObjectPool.current.DeactivateAllPooledObjects();
    }
}
