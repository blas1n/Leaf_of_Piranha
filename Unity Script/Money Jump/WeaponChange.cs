using UnityEngine;

public class WeaponChange : MonoBehaviour {

    PlayerAttack player;

    private void Awake() {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
    }

    public void WeaponUp() {
        if (player.NumOfWeapons <= 1) { return; }

        if (player.NowWeapon > 0)
            player.NowWeapon -= 1;
        else
            player.NowWeapon = player.NumOfWeapons - 1;
    }

    public void WeaponDown() {
        if (player.NumOfWeapons <= 1) { return; }

        if (player.NowWeapon < player.NumOfWeapons - 1)
            player.NowWeapon += 1;
        else
            player.NowWeapon = 0;
    }
}
