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
// 
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
    public float threshold;
    public Animator platformAnimator;

    public PlayerBehaviour player;

    private Vector3 distance;
    //tried this code which is not animator related but it only works once
    //private Vector3 baseScale;            
    //private Vector3 targetScale;
    //private Vector3 normalScale = new Vector3(1.0f, 1.0f, 1.0f);
    //private Vector3 shrinkedScale = new Vector3(0.1f, 0.1f, 0.1f);
    //private float scaleAmount = 0.1f;
    //private float initScale = 1;
    //private bool scaleActive;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        platformAnimator = GetComponent<Animator>();
        //baseScale = transform.localScale;
        //targetScale = baseScale * scaleAmount;
      //  targetScale = new Vector3(targetScale.x + Mathf.PingPong(platformTimer, scaleAmount), targetScale.y, 1.0f);
        //normalScale = baseScale * initScale;
        //platformTimer = 0.1f;
        platformTimer = 0;
        isActive = true;
      //  scaleActive = false;
        distance = end.position - start.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            platformTimer += Time.deltaTime;
            _Move();
        }
        else
        {
            if (Vector3.Distance(player.transform.position, start.position) <
                Vector3.Distance(player.transform.position, end.position))
            {
                if (!(Vector3.Distance(transform.position, start.position) < threshold))
                {
                    platformTimer += Time.deltaTime;
                    _Move();
                }
            }
            else
            {
                if (!(Vector3.Distance(transform.position, end.position) < threshold))
                {
                    platformTimer += Time.deltaTime;
                    _Move();
                }
            }
        }

        //if(scaleActive)
        //{
        //    ScalePlatform();
        //}
        //else
        //{
        //   // DescalePlatform();
        //}
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

    public void SetAnimatorOn()
    {
        
        platformAnimator.SetBool("IsActive", true);
        platformAnimator.SetBool("Jumped", false);
    }

    public void SetAnimatorOff()
    {

        platformAnimator.SetBool("IsActive", false);
        platformAnimator.SetBool("Jumped", true);
    }

    //public void ScalePlatform()
    //{

    //    transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime);
    //    //transform.localScale = new Vector3(Mathf.PingPong(transform.localScale.x, scaleAmount), transform.localScale.y, transform.localScale.z);
    //    if (transform.localScale.x <= 0.2f && transform.localScale.y <= 0.2f)
    //    {
    //        targetScale = normalScale;
    //        // transform.localScale = Vector3.Lerp(transform.localScale, normalScale, Time.deltaTime);
    //        //scaleAmount++;

    //    }
    //    StartCoroutine(ScalePlatformCOro());


    //}
    //private IEnumerator ScalePlatformCOro()
    //{
    //    //normalScale = new Vector3(0.2f, 0.2f, 0.2f);
    //    // targetScale = new Vector3(1.0f, 2.0f, 0.2f);
    //    yield return new WaitForSeconds(2);
    //}
    //public void DescalePlatform()
    //{
    //    scaleAmount = 0;
    //    transform.localScale = Vector3.Lerp(transform.localScale, baseScale, Time.deltaTime);
    //    Debug.Log("Scaled all the way down");

    //}

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        //other.transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime);
    //        scaleActive = true;
    //    }
    //    else
    //    {
    //        scaleActive = false;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        //other.transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime);
    //        //transform.localScale = Vector3.Lerp(transform.localScale, normalScale, Time.deltaTime);
    //        scaleActive = false;
    //    }
    //}
}
