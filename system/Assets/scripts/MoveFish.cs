using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MoveFish : MonoBehaviour
{
    // SetPositionスクリプト
    private SetPosition setPosition;
    private Animator animator; // アニメーター
    private bool arrived; // 到着フラグ
    private Vector3 startPosition; // スタート位置 
    private Vector3 destination; // 目標地点
    [SerializeField] private float currentDistance = 3.0f; // 目標地点までの距離
    [SerializeField] private float animationSpeed = 1.0f; // アニメ再生速度 
    [SerializeField] private float speed = 1.0f; // 歩くスピード
    [SerializeField] private float rotateSpeed = 3.0f; // 回転スピード
    [SerializeField] private float waitMaxTime = 1.0f; // 目標に到達した場合の目標再設定までの最大待機時間
    [SerializeField] private float waitMinTime = 1.0f; // 目標に到達した場合の目標再設定までの最小待機時間

    private float elapsedTime; // 経過時間

    void Start ()
    {
        // アニメータを取得
        animator = GetComponent<Animator> ();
        // SetPositionコンポーネントを取得
        setPosition = GetComponent<SetPosition> ();
        arrived = false;
        startPosition = transform.position;
        setPosition.SetDestination (transform.position);
        destination = setPosition.GetDestination ();
    }

    void FixedUpdate ()
    {
        // rigidbodyを取得
        Rigidbody rb = this.GetComponent<Rigidbody> ();
        // 自動で前進する
        transform.Translate (0f, 0f, speed * Time.deltaTime);
        // アニメーションの再生速度を制御
        animator.SetFloat ("Speed", animationSpeed);

        // 目標地点にいないとき
        if (!arrived)
        {
            // 目標の方向に向く
            Quaternion targetRotation = Quaternion.LookRotation (destination - transform.position);
            transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            // 目標地点に近づいたとき
            if (Vector3.Distance (transform.position, destination) < currentDistance)
            {
                arrived = true;
            }

        }
        else
        {
            // 目標再設定までの時間
            elapsedTime += Time.deltaTime;
            float waitTime = Random.Range (waitMinTime, waitMaxTime);
            // 待ち時間を越えたら次の目的地を設定
            if (elapsedTime > waitTime)
            {
                setPosition.CreateRandomPosition ();
                destination = setPosition.GetDestination ();
                arrived = false;
                elapsedTime = 0f;
            }
        }

        // AddTorqueで姿勢制御
        var left = transform.TransformVector (Vector3.left);
        var hori_left = new Vector3 (left.x, 0f, left.z).normalized;
        rb.AddTorque (Vector3.Cross (left, hori_left) * 4f);
    }
}