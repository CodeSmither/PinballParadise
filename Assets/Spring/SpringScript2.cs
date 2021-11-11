using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript2 : MonoBehaviour
{
    
        private float fullCompressedLength;
        private float semiCompressedLength;
        private float fullLength;
        private int springState = 3;
        private Animator Springmation;
        private GameObject SpringLauncher;
        private GameObject Spring;
        private GameObject button;
        private Vector3 velocity = Vector3.zero;
        private float smoothTime = 0.5f;
        private GameObject ball;
        private Rigidbody2D ballbody;
        private bool LiftOffCheck;
        private bool ReadyToLaunch = false;

        private void Start()
        {
            ball = GameObject.FindGameObjectWithTag("Ball");
            ballbody = ball.GetComponent<Rigidbody2D>();
            button = GameObject.FindGameObjectWithTag("SpringButton");
            SpringLauncher = this.gameObject;
            Spring = SpringLauncher.transform.parent.gameObject;
            fullCompressedLength = Spring.transform.position.y + 3.05f;
            semiCompressedLength = Spring.transform.position.y + 4.65f;
            fullLength = Spring.transform.position.y + 6.1f;
            Springmation = Spring.GetComponent<Animator>();


        }


        public void Update()
        {
            springState = button.GetComponent<SpringButton>().WoundState;
            ChangeState();
            Springmation.SetInteger("TightnessLevel", springState);
        }
        void ChangeState()
        {

            if (SpringLauncher.transform.position.y != fullLength && springState == 3)
            {
                float change = fullLength - SpringLauncher.transform.position.y;
                Vector3 targetpoint = SpringLauncher.transform.TransformPoint(new Vector3(0, change, 0));
                transform.position = Vector3.SmoothDamp(SpringLauncher.transform.position, targetpoint, ref velocity, smoothTime);
                LiftOff();

            }
            else if (SpringLauncher.transform.position.y != semiCompressedLength && springState == 2)
            {
                float change = semiCompressedLength - SpringLauncher.transform.position.y;
                Vector3 targetpoint = SpringLauncher.transform.TransformPoint(new Vector3(0, change, 0));
                transform.position = Vector3.SmoothDamp(SpringLauncher.transform.position, targetpoint, ref velocity, smoothTime);

            }
            else if (SpringLauncher.transform.position.y != fullCompressedLength && springState == 1)
            {
                float change = fullCompressedLength - SpringLauncher.transform.position.y;
                Vector3 targetpoint = SpringLauncher.transform.TransformPoint(new Vector3(0, change, 0));
                transform.position = Vector3.SmoothDamp(SpringLauncher.transform.position, targetpoint, ref velocity, smoothTime);
                ReadyToLaunch = true;
            }

        }
        void LiftOff()
        {
            if (LiftOffCheck == true)
            {
                if (ReadyToLaunch == true)
                {
                    ballbody.AddForce(transform.up * 800f);
                    StartCoroutine(LaunchTime());
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject == ball)
            {
                LiftOffCheck = true;
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {

            if (collision.gameObject == ball)
            {
                LiftOffCheck = false;
            }
        }

        IEnumerator LaunchTime()
        {
            yield return new WaitForSeconds(3);
            ReadyToLaunch = false;
        }
    
}
