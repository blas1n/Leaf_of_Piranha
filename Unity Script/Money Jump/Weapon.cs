using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string weaponName;
    public int MS;
    public float AP, AS, BS, range, LT;
    
    protected List<Transform> unusedbullets = new List<Transform>();
    protected Transform player;

    private void Awake() {
        player = GameObject.FindWithTag("Player").transform;

        foreach (Transform child in transform) {
            unusedbullets.Add(child);
            child.gameObject.SetActive(false);
        }
    }

    public void Shooting() {
        Transform nowBullet = unusedbullets[0];
        unusedbullets.RemoveAt(0);

        nowBullet.position = player.position;
        nowBullet.rotation = player.rotation;
        nowBullet.position += 0.1f * nowBullet.up;

        nowBullet.gameObject.SetActive(true);
        StartCoroutine(Bullet(nowBullet));
    }

    public virtual void EndBullet(Transform bullet) {
        unusedbullets.Add(bullet);
        bullet.gameObject.SetActive(false);
    }

    protected virtual IEnumerator Bullet(Transform bullet) {
        for (float count = 0; count < range; count += Time.deltaTime) {
            bullet.localPosition += BS * bullet.up * Time.deltaTime;
            yield return null;
        }

        EndBullet(bullet);
    }
}