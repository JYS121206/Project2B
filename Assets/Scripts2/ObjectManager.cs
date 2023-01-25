using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectManager : MonoBehaviour
{
    #region Singletone
    public static ObjectManager instance;


    public static ObjectManager GetInstance()
    {
        if (instance == null)   //  null�� ����
        {
            GameObject go = new GameObject("@ObjectManager");   // ����̴� �׳� ������ ���� �ϱ� ���� �׳� ������
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go); // ���� ��ȯ�ɶ� ������Ʈ �ı� ����
        }
        return instance;
    }
    #endregion

    public GameObject CreateCharacter(string characterName)
    {
        Object CharacterObj = Resources.Load("Sprite/" + characterName );
        GameObject Character = (GameObject)Instantiate(CharacterObj);

        return Character;
    }

    public GameObject CreateMonster(string monsterName)
    {
        Object monsterObj = Resources.Load("Sprite/" + monsterName);
        GameObject monster = (GameObject)Instantiate(monsterObj);

        return monster;
    }

    public ParticleSystem CreateHitEffect()
    {
        Object effectObj = Resources.Load("Sprite/Hit_Green");
        GameObject effect = (GameObject)Instantiate(effectObj);

        return effect.GetComponent<ParticleSystem>();
    }

    public GameObject CreateHCharacter()
    {
        Object HCharacterObj = Resources.Load("Sprite/HealingCha");
        GameObject HCharacter = (GameObject)Instantiate(HCharacterObj);

        return HCharacter;
    }
}
