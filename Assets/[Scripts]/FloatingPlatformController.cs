// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Dec 16, 2021
// PURPOSE     : GAME2014_F2021_FinalTest_101206769
// SPECIAL NOTES:
// ===============================
// Change History:
// Added floating platform
//==================================
//==================================
// Change History:
// Fixed floating platform issue and synced the Shrinking sound effects properly.
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class FloatingPlatformController : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public bool isActive;
    public float platformTimer;
    public Animator platformAnimator;

    public PlayerBehaviour player;

    private Vector3 distance;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        platformAnimator = GetComponent<Animator>();

        platformTimer = 0;
        isActive = true;
        distance = end.position - start.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        platformTimer += Time.deltaTime;
        _Move();
     

    }

    private void _Move()
    {
        //using the same movement as moving platform changed the end point in the inspector.
        var distanceX = (distance.x > 0) ? start.position.x + Mathf.PingPong(platformTimer, distance.x) : start.position.x;
        var distanceY = (distance.y > 0) ? start.position.y + Mathf.PingPong(platformTimer, distance.y) : start.position.y;
      
        transform.position = new Vector3(distanceX, distanceY, 0.0f);
    }

    public void Reset()
    {
        transform.position = start.position;
        platformTimer = 0;
    }

    public void EnableShrinking()
    {
        platformAnimator.SetBool("IsActive", true);


    }

    public void DisableShrinking()
    {
        StartCoroutine(DisableShrink());

    }

    public IEnumerator DisableShrink()
    {
        yield return new WaitForSeconds(1);
        platformAnimator.SetBool("IsActive", false);
    }
}
