using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//����
//�V���O���g���̓O���[�o���ȃA�N�Z�X�|�C���g��񋟂������
//�C���X�y�N�^�[�Œl��������Ȃ��Ă������̂ŃV���O���g�������ꍇ��MonoBehavior���p�����Ȃ��Ă�����
//Monobehaviour���p������K�v���Ȃ��Ȃ�statuc�N���X�ł��V���O���g���Ƃ��܂�ς��Ȃ�
//->����ɂ�郁���b�g:SingletonBehavior�N���X�Ƃ̌���������ł���null�ɂȂ邱�Ƃ��Ȃ��G���[���N�����Ă��Ώ����₷��
//->�f�����b�g:�ϐ��̒l���蓮�ŏ��������Ȃ���΂Ȃ�Ȃ��BTexture�Ȃǂ̃��\�[�X�ւ̎Q�Ƃ����ꍇNull�����Ȃ��Ɖ������Ȃ�

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;

    //�J�v�Z����
    // public static T Instance => _instance;

    //�`�[������̎��͂����������ق�������
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Type t = typeof(T);
                _instance = (T)FindObjectOfType(t);

                if (_instance == null)
                {
                    Debug.LogError($"{t}���A�^�b�`���Ă���GameObject������܂���");
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        OnAwake();
        ChackIns();
    }


    //�p�����Awake���K�v�ȏꍇ�͂�����Ă�
    protected virtual void OnAwake() { }

    protected void ChackIns()
    {
        if (_instance == null)
        {
            //�L���X�g�̈Ӗ��𗝉�����BT�^�ɃL���X�g���Ă���
            _instance = this as T;
        }
        else if (Instance == this)
        {
            return;
        }
        else if (Instance != this)
        {
            //���łɂ��������͉��������ɏ�����
            Destroy(this);
        }
    }

}
