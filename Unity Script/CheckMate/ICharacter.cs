using System.Collections;
using UnityEngine;

public interface ICharacter {

    IEnumerator Move(Vector2 pos);
    void Death();
}
