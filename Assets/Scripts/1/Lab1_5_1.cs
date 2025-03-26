using UnityEngine;
using TMPro;

public class Lab1_5_1 : BaseLab
{
    public TMP_InputField speedXInput; 
    public TMP_InputField speedYInput;
    public TMP_InputField speedZInput;
    public TMP_Text timeOutput;
    public TMP_Text distanceOutput;

    private float speedX;
    private float speedY;
    private float speedZ;
    private float startTime;
    private bool isMoving = false;

    public override void ExecuteTask()
    {
        if (float.TryParse(speedXInput.text, out speedX) &&
            float.TryParse(speedYInput.text, out speedY) &&
            float.TryParse(speedZInput.text, out speedZ))
        {
            startTime = Time.time;
            isMoving = true;
        }
        else
        {
            Debug.LogError("Некорректный ввод скорости!");
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            float currentTime = Time.time - startTime;

            float distanceX = speedX * currentTime;
            float distanceY = speedY * currentTime;
            float distanceZ = speedZ * currentTime;

            float totalDistance = Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY + distanceZ * distanceZ);

            timeOutput.text = currentTime.ToString("F2");
            distanceOutput.text = totalDistance.ToString("F2");

            float newPositionX = distanceX % 120; // 120 = 60 - (-60)
            if (newPositionX > 60)
            {
                newPositionX -= 120;
            }

            float newPositionY = distanceY % 120;
            if (newPositionY > 60)
            {
                newPositionY -= 120;
            }

            float newPositionZ = distanceZ % 120;
            if (newPositionZ > 60)
            {
                newPositionZ -= 120;
            }

            movingObject.transform.position = new Vector3(newPositionX, newPositionY, newPositionZ);
        }
    }
}