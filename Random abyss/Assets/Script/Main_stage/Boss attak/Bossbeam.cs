using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossbeam : MonoBehaviour
{
    Vector3 target;
    // Start is called before the first frame update
    private void OnEnable()
    {
        target = new Vector3(transform.position.x * -1, 1.8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, target, 0.01f);
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}
