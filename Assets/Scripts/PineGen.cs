using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineGen : MonoBehaviour {

    public GameObject pinePrefab;
    GameObject[] pine;
    int nPines = 5000;

    public Vector2 bounds;


    // Start is called before the first frame update
    void Start() {
        float tx, ty;

        pine = new GameObject[nPines];

        for (int i = 0; i < nPines; i++) {
            tx = Random.Range(-bounds.x, bounds.x);
            ty = Random.Range(-bounds.y, bounds.y);
            pine[i] = Instantiate(pinePrefab, new Vector3(tx, 0, ty) + this.transform.position, Quaternion.identity);
            pine[i].transform.localScale *= Random.Range(.5f, 1.5f);
            pine[i].transform.parent = this.transform;

        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            this.transform.position = new Vector3(-transform.position.x, transform.position.y, -transform.position.z);
        }
    }

}
