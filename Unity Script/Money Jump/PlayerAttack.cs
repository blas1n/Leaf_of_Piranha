using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private struct Weapons {
        public Weapon weapon;
        public int bullet;

        public Weapons(string weaponName) {
            weapon = GameObject.Find(string.Format("{0} Pooler", weaponName)).GetComponent<Weapon>();
            bullet = weapon.MS;
        }
    }

    private List<Weapons> myWeapons;
    private int nowWeapon = 0;
    private bool isShoot, notPause, nowReload;

    private void Awake() {
        myWeapons = new List<Weapons>();
        notPause = true;
    }

    private void Start() {
        GetWeapon("Assault Gun");
    }

    private void Update() {
        if (myWeapons[nowWeapon].bullet <= 0)
            StartCoroutine("ReLoad");

        if (nowReload) { return; }

        if (isShoot && notPause) {
            myWeapons[nowWeapon].weapon.Shooting();
            StartCoroutine(Pause());
            Bullet--;
        }
    }

    public void GetWeapon(string weaponName) {
        for (int i = 0; i < NumOfWeapons; i++) {
            if (weaponName.Equals(myWeapons[i].weapon.weaponName))
                return;
        }

        myWeapons.Add(new Weapons(weaponName));
        NowWeapon = NumOfWeapons - 1;
    }

    public bool Attack {
        get { return isShoot; }
        set { isShoot = value; }
    }

    public int NowWeapon {
        get { return nowWeapon; }
        set {
            nowWeapon = value;
            nowReload = false;
            StopCoroutine("ReLoad");
        }
    }

    public string WeaponName {
        get { return myWeapons[nowWeapon].weapon.weaponName; }
    }


    public int NumOfWeapons {
        get { return myWeapons.Count; }
    }

    public int MagazineSize {
        get { return myWeapons[nowWeapon].weapon.MS; }
    }

    public int Bullet {
        get { return myWeapons[nowWeapon].bullet; }
        private set {
            Weapons weapons = myWeapons[nowWeapon];
            weapons.bullet = value;
            myWeapons[nowWeapon] = weapons;
        }
    }

    private IEnumerator Pause() {
        notPause = false;
        yield return new WaitForSeconds(myWeapons[nowWeapon].weapon.AS);
        notPause = true;
    }

    public IEnumerator ReLoad() {
        if (Bullet == MagazineSize) { yield break; }

        nowReload = true;
        yield return new WaitForSeconds(myWeapons[nowWeapon].weapon.LT);
        Bullet = MagazineSize;
        nowReload = false;
    }
}
