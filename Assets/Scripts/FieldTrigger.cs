using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTrigger : MonoBehaviour {
    private EnemyControl enemyControl;

    private void Awake() {
        this.enemyControl = this.GetComponentInParent<EnemyControl>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            this.enemyControl.targetPosition = other.gameObject.transform;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            this.enemyControl.targetPosition = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            this.enemyControl.targetPosition = null;
        }
    }
}
