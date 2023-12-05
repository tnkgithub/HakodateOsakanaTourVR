using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    //プレハブを変数に代入
    public GameObject fish;

    public GameObject CreateFish;

    [SerializeField] private int quantity = 10;
    //[SerializeField] private float depth = -10;
    [SerializeField] private float area = 10;

    [SerializeField] private float Xlenge = 1;

    [SerializeField] private float Ylenge = 1;

    private GameObject clone;

    void Start ()
    {
        Vector2[] setStart = new Vector2[quantity];

        for (int i = 0; i < setStart.Length; i++)
        {
            setStart[i].x = Random.insideUnitCircle.x * area * Xlenge + transform.position.x;
            setStart[i].y = Random.insideUnitCircle.y * area * Ylenge + transform.position.z;
            //オブジェクトを生産
            clone = GameObject.Instantiate (fish, new Vector3 (setStart[i].x, transform.position.y, setStart[i].y), Quaternion.identity);
        }
    }

    void Update ()
    {

        if (CreateFish.activeInHierarchy == false)
        {
            Destroy (clone);
            Debug.Log ("activeSelf " + CreateFish.activeSelf);
        }
    }
}