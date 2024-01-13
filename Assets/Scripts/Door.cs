using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public float openAngle = 90.0f;
    public float openSpeed = 2.0f;
    private bool doorOpen = false;
    private Vector3 defaultRotation;
    private Vector3 openRotation;
    public float maxDistance = 2f; // ћаксимальное рассто€ние, на котором игрок может находитьс€ от двери
    public float maxAngle = 90f; // ћаксимальный угол, под которым игрок должен смотреть на дверь

    public Transform player;
    public Transform door;

    void Start()
    {
        defaultRotation = transform.eulerAngles;
        openRotation = new Vector3(defaultRotation.x, defaultRotation.y + openAngle, defaultRotation.z);
    }

    void Update()
    {
        if (Vector3.Distance(player.position, door.position) <= maxDistance)
        {

                // ќткрываем дверь
                if (Input.GetKeyDown(KeyCode.E) && doorOpen == false)
                {
                    StartCoroutine(OpenDoor());
                }
                else if (Input.GetKeyDown(KeyCode.E) && doorOpen == true)
                {
                    StartCoroutine(CloseDoor());
                }
        }

        
    }

    IEnumerator OpenDoor()
    {
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime * openSpeed;
            transform.eulerAngles = Vector3.Slerp(defaultRotation, openRotation, t);
            yield return null;
        }
        doorOpen = true;
    }

    IEnumerator CloseDoor()
    {
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime * openSpeed;
            transform.eulerAngles = Vector3.Slerp(openRotation, defaultRotation, t);
            yield return null;
        }
        doorOpen = false;
    }
}
