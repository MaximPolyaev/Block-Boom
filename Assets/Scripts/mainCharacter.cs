using System;
using UnityEngine;

public class mainCharacter : MonoBehaviour
{
    public float speedCamera;
    public GameObject mainCamera;

    private bool movingCamera = false;
    private bool movingMainChapter = false;
    private Vector3 newPosCamera;
    private float bottomWallCordY;
    private float fixedDistanceY;
    private Rigidbody2D rb;
    private Camera cameraComponent;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraComponent = mainCamera.GetComponent<Camera>();
        bottomWallCordY = cameraComponent.ScreenToWorldPoint(new Vector2(0, 0)).y;
        
        Vector3 nowPosMainCharacter = transform.position;
        nowPosMainCharacter.x = mainCamera.transform.position.x;
        nowPosMainCharacter.y = (mainCamera.transform.position.y + Math.Abs(bottomWallCordY)) * -0.7f;

        fixedDistanceY = Math.Abs(nowPosMainCharacter.y);
    }

    // Update is called once per frame
    private void Update()
    {
        movingMainChapter = rb.velocity.magnitude != 0 ? true : false;

        float distanceY = Math.Abs(mainCamera.transform.position.y - transform.position.y);

        if (movingMainChapter && mainCamera.transform.position.y < transform.position.y)
        {
            movingCamera = false;
            
            mainCamera.transform.position = Vector3.Lerp(
                mainCamera.transform.position,
                new Vector3(
                    mainCamera.transform.position.x, 
                    transform.position.y, 
                    mainCamera.transform.position.z
                    ),
                speedCamera * Time.deltaTime);
        } else if (!movingMainChapter &&
                   !(transform.position.y < mainCamera.transform.position.y && fixedDistanceY < distanceY))
        {
            movingCamera = true;

            newPosCamera = mainCamera.transform.position;
            if (transform.position.y >= mainCamera.transform.position.y)
            {
                newPosCamera.y = transform.position.y + distanceY;
            }
            else
            {
                newPosCamera.y = newPosCamera.y + fixedDistanceY - distanceY;
            }
        }
        
        if (movingCamera)
        {
            mainCamera.transform.position =
                Vector3.Lerp(mainCamera.transform.position, newPosCamera, speedCamera * Time.deltaTime);

            movingCamera = mainCamera.transform.position.y == newPosCamera.y ? false : movingCamera;
        }
        
        float nowBottomWallCordY = cameraComponent.ScreenToWorldPoint(new Vector2(0, 0)).y;
        bottomWallCordY = nowBottomWallCordY > bottomWallCordY ? nowBottomWallCordY : bottomWallCordY;
    }
}