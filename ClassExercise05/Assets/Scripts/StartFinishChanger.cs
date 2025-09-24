using System.Collections;
using TMPro;
using UnityEngine;

public class StartFinishChanger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tMPro;

    // Create coroutine and wait time
    private IEnumerator coroutine;
    private float waitTime = 3;

    void Start()
    {
        // Initialize coroutine
        coroutine = ChangeStartToFinish(waitTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // When we pass under the start line...
        StartCoroutine(coroutine);
    }

    private IEnumerator ChangeStartToFinish(float waitTime)
    {
        // ... Wait 3 seconds, then change the text to "FINISH"
        yield return new WaitForSeconds(waitTime);
        tMPro.text = "FINISH";
    }
}
