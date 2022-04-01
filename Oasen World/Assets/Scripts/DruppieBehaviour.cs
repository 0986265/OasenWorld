using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruppieBehaviour : MonoBehaviour
{

    public Transform druppiePoint;
    public Transform druppiePointBack;
    public Transform druppiePointFinal;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DruppieMovement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DruppieMovement()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().Play("Jump Rivier");
        yield return new WaitForSeconds(2f);
        this.gameObject.transform.position = druppiePoint.position;
        this.gameObject.transform.rotation = druppiePoint.rotation;
        GetComponent<Animator>().Play("Wave");
        DialogueTrigger.instance.TriggerDialogue();
        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().Play("Idle");
        //Druppie Explain
        yield return new WaitForSeconds(4f);
        /*this.gameObject.transform.rotation = druppiePointBack.rotation;
        GetComponent<Animator>().Play("Jump Rivier");
        yield return new WaitForSeconds(2f);
        this.gameObject.transform.position = druppiePointFinal.position;*/
    }
}
