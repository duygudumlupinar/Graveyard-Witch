using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    public Light _light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (_light.enabled != false)
            {
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.GetComponent<EnemyAttack>().enabled = false;
                //other.gameObject.transform.Rotate(new Vector3(-90f, 0f, -90f), Space.Self);
                StartCoroutine(ShutDownCoffin(other));

                Object winLose = FindAnyObjectByType(typeof(WinLose));
                winLose.GetComponent<WinLose>().CoffinFilled();
            }
        }
    }

    IEnumerator ShutDownCoffin(Collider other)
    {
        yield return new WaitForEndOfFrame();
        //Destroy(other.gameObject);
        transform.Rotate(new Vector3(0f, 0f, -90f), Space.Self);
        _light.enabled = false;
    }
}
