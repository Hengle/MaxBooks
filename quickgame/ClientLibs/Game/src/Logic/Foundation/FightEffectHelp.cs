//------------------------------------------------------------------------------

//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace xc
{
    [wxb.Hotfix]
    public class FightEffectPlayData
    {
//         public float NormalPlayTimeBySeconds = 1.0f;
         public float HurryPlayTimeBySeconds = 2.0f;

        public float NormalPlayDeltaTimeBySeconds = 0.5f;
        public float HurryPlayDeltaTimeBySeconds = 0.2f;

        public int NormalContainerSize = 20;
        public int HurryContainerSize = 20;
    }

    public class FightEffectHelp
    {
        public enum FightEffectPanelType
        {
            MonsterDamage = 1,
            PlayerDamage = 2,
            DamageEffect = 3,
            BuffTip = 4,
        }

        public enum FightEffectType
        {
            none,

            /// <summary>
            /// �����˺�
            /// </summary>
            EnemyDamage,

            /// <summary>
            /// ħ���˺�
            /// </summary>
            Attendant_damage,

            /// <summary>
            /// �����˺�
            /// </summary>
            CriticEnemyDamage,

            /// <summary>
            /// ħ�ͱ����˺�
            /// </summary>
            CriticAttendantDamage,

            /// <summary>
            /// �����˺�
            /// </summary>
            OurDamage,

            /// <summary>
            /// �˺�����
            /// </summary>
            BounceDamage,
            /// <summary>
            /// ����
            /// </summary>
            Dodge,
            /// <summary>
            /// ��
            /// </summary>
            Parry,
            /// <summary>
            /// �޵�
            /// </summary>
            Invincible,

            /// <summary>
            /// �ƶ�����
            /// </summary>
            Accelerate,

            /// <summary>
            /// ��Ѫ
            /// </summary>
            AddHp,
            AddMp,      //����
            AddExp,     //������
            AddSp,      //SP�ӳ�

            AttackSp,   //����(2017/8/18)
            Immune,     //����(2017/8/18)
            OneHitKill, //նɱ��2017/10/17��
            DamageDrain,    //�˺�����(2018/1/3)

            AbsoluteDoge,  // ��������
            FollowAttack,  // ׷��һ��
        }


        static Dictionary<int/* FightEffectPanelType */, FightEffectPlayData> mFightEffectPlayDataMap;
        //static Dictionary<int/* FightEffectType */, int/* Level */> mFightEffectTypeLayoutMap;
        static DBFightEfffectLayout m_db_layout;
        public static FightEffectPlayData GetFightEffectPlayData(FightEffectPanelType type)
        {
            if (mFightEffectPlayDataMap == null)
            {
                mFightEffectPlayDataMap = new Dictionary<int, FightEffectPlayData>();
            }

            FightEffectPlayData result = null;
            if (!mFightEffectPlayDataMap.TryGetValue((int)type, out result))
            {
                result = new FightEffectPlayData();

                var list = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_fight_effect", "id", ((int)type).ToString());
                if (list.Count > 0)
                {
                    Dictionary<string, string> table = list[0];
//                     result.NormalPlayTimeBySeconds = float.Parse(table["normal_play_time"]);
                    result.HurryPlayTimeBySeconds = float.Parse(table["hurry_play_time"]);
                    result.NormalPlayDeltaTimeBySeconds = float.Parse(table["normal_play_delta_time"]);
                    result.HurryPlayDeltaTimeBySeconds = float.Parse(table["hurry_play_delta_time"]);
                    result.NormalContainerSize = int.Parse(table["normal_container_size"]);
                    result.HurryContainerSize = int.Parse(table["hurry_container_size"]);

                    mFightEffectPlayDataMap.Add((int)type, result);
                }
            }

            return result;
        }

        public static int GetLayoutLevel(FightEffectType type)
        {
            if(m_db_layout == null)
                m_db_layout = DBManager.Instance.GetDB<DBFightEfffectLayout>();
            int result = 0;
            var item = m_db_layout.GetOneItem(type.ToString());
            if (item != null)
                result = item.Level;
            return result;
        }

        /// <summary>
        /// �����˺����ͻ�ȡ�����ս��״̬
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public static FightEffectType GetFightEffectTypeByDamageEffect(Damage.EDamageEffect effect)
        {
            FightEffectType result = FightEffectType.none;
            switch (effect)
            {
                case Damage.EDamageEffect.DE_BLOCK:
                    result = FightEffectType.Parry;
                    break;
                case Damage.EDamageEffect.DE_CRITIC:
                    result = FightEffectType.CriticEnemyDamage;
                    break;
                case Damage.EDamageEffect.DE_DODGE:
                    result = FightEffectType.Dodge;
                    break;
                case Damage.EDamageEffect.DE_HP_STEAL:
                    result = FightEffectType.AddHp;
                    break;
                case Damage.EDamageEffect.DE_EN_STEAL:
                    result = FightEffectType.AddMp;
                    break;
                case Damage.EDamageEffect.DE_RE_HURT:
                    result = FightEffectType.BounceDamage;
                    break;
                case Damage.EDamageEffect.DE_HURT_RELIEF:
                    result = FightEffectType.DamageDrain;
                    break;
                case Damage.EDamageEffect.DE_EN_SHIELD:
                    //result = FightEffectType.Parry;(��ʱ������)
                    break;
                case Damage.EDamageEffect.DE_SUPER:
                    result = FightEffectType.Invincible;
                    break;
                case Damage.EDamageEffect.DE_KILL:
                    result = FightEffectType.OneHitKill;
                    break;
                case Damage.EDamageEffect.DE_ABSOLUTE_DOGE: // ��������
                    result = FightEffectType.AbsoluteDoge;
                    break;
                case Damage.EDamageEffect.DB_FOLLOW_ATTACK:// ׷��һ��
                    result = FightEffectType.FollowAttack;
                    break;
                default:
                    break;
            }

            return result;
        }

        public static void SetEffectValue(FightEffectType effectType, Text valueLabel, long value = 0, bool show_percent = false, string push_str = "")
        {
            bool must_be_damage = false;
            if(effectType == FightEffectType.BounceDamage)
            {
                must_be_damage = true;
                if (value > 0)
                    value = -value;
            }
            string value_string;
            if(show_percent)
            {
                if (value > 0)
                    value_string = string.Format("+{0}%", value);
                else
                    value_string = string.Format("{0}%", value);
            }
            else
            {
                if (value > 0)
                    value_string = string.Format("+{0}", value);
                else
                    value_string = string.Format("{0}", value);
            }
            
            switch (effectType)
            {
                //�����֣������������֡�
                case FightEffectType.EnemyDamage:   //�����˺�
                case FightEffectType.OurDamage:   //�����˺�
                case FightEffectType.BounceDamage:   //�˺�����
                case FightEffectType.AddHp:   //��Ѫ
                case FightEffectType.AddMp:   //����
                case FightEffectType.AddSp:   //SP���
                    if (valueLabel != null)
                        valueLabel.text = value_string;
                    break;
                case FightEffectType.Attendant_damage:   //ħ���˺�
                    if (valueLabel != null)
                        valueLabel.text = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_25") + value_string;// ӡ������ʾ��ӡͼƬ
                    break;

                //�С����֡�������Ҫ�޸ģ���������
                case FightEffectType.CriticEnemyDamage:   //�����˺�
                case FightEffectType.CriticAttendantDamage:   //ħ�ͱ����˺�
                case FightEffectType.Accelerate:   //�ƶ�����
                case FightEffectType.AddExp:   //������
                case FightEffectType.AttackSp:  //����
                case FightEffectType.FollowAttack:  // ׷��һ��
                    if (valueLabel != null)
                        valueLabel.text = value_string;
                    break;

                //ֻ�С����֡����������κ�����
                case FightEffectType.Dodge:   //����
                case FightEffectType.AbsoluteDoge: // ��������
                case FightEffectType.Parry:   //��
                case FightEffectType.Invincible:   //�޵�
                case FightEffectType.Immune:  //����
                case FightEffectType.OneHitKill: //նɱ
                case FightEffectType.DamageDrain: //�˺�����
                    break;
                default:
                    Debug.LogError(string.Format("undefined FightEffectType {0}", effectType.ToString()));
                    break;
            }

            if (push_str != null && push_str != "" && valueLabel != null)
                valueLabel.text = valueLabel.text + push_str;
        }

    }
}

