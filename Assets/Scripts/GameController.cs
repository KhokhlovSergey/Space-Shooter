using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazaardCount;
    public float hazardTime = 0.5f;
    public float waveTime = 2.0f;
    public bool isSpawnHazard = true;

    private void Start() {
        StartCoroutine(spawnFunc());
    }

    IEnumerator spawnFunc() {
        yield return new WaitForSeconds(1.5f);
        while (isSpawnHazard) {
            for (int i = 0; i < hazaardCount; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(waveTime);
        }
    }
}
