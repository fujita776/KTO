using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseRotationButton : RepressableButton
{
    [Header("参照するRotateObject")]
    [SerializeField] private RotateObject rotateObject;

    public override void Execute()
    {
        if (rotateObject == null)
        {
            Debug.LogError($"{gameObject.name}: RotateObject が設定されていません。");
            return;
        }

        //  現在の回転方向を反転する
        int newDirection = -rotateObject.RotateDirection;
        rotateObject.SetRotationDirection(newDirection);

        Debug.Log($"{gameObject.name}: RotateObjectの回転方向を{(newDirection == 1 ? "正転" : "逆回転")}に変更した。");
    }
}
