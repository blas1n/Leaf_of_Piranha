using System.Collections;
using UnityEngine;

public class ShotGun : Weapon {

    public override void EndBullet(Transform bullet) {
        base.EndBullet(bullet);

        for (int i = 0; i < bullet.childCount; i++)
            bullet.GetChild(i).localPosition = Vector3.zero;
    }

    protected override IEnumerator Bullet(Transform bullet) {
        for (float count = 0; count < range; count += Time.deltaTime) {
            for (int i = 0; i < bullet.childCount; i++)
                bullet.GetChild(i).position += BS * bullet.GetChild(i).up * Time.deltaTime;
            yield return null;
        }

        EndBullet(bullet);
    }
}
