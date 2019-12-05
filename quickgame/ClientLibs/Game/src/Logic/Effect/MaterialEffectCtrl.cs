//----------------------------------
// MatrtialEffectCtrl.cs
// ���ƽ�ɫ����Ч��
// @raorui
// 2017.6.7
//----------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;
using SGameEngine;
namespace xc
{
    [wxb.Hotfix]
    public class MaterialEffectCtrl : BaseCtrl
    {
        public MaterialEffectCtrl(Actor owner)
            : base(owner)
        {
            // �ڱ���ʱҪ�ָ���ɫ�Ĳ���
            mOwner.SubscribeActorEvent(Actor.ActorEvent.SHAPE_SHIFT, OnShapeShift);
            // �ڻ�װ���Է����仯ʱҪ�ָ���ɫ�Ĳ���
            mOwner.SubscribeActorEvent(Actor.ActorEvent.AVATAR_CHANGE, OnAvatarPropertyChange);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.AVATAR_CHANGE_BEGIN, OnAvatarPropertyChangeBegin);
        }

        /// <summary>
        /// ��ɫ�ܻ��Ĳ���
        /// </summary>
        public static Material MAT_HURT_HIGHLIGHT = ResourceLoader.Instance.try_load_cached_asset("Assets/Res/Materials/HurtHighLight.mat") as Material;

        /// <summary>
        /// ��ɫ�ܽ�Ĳ���
        /// </summary>
        public static Material MAT_DEAD_DISSOLVE = ResourceLoader.Instance.try_load_cached_asset("Assets/Res/Materials/Dissolve.mat") as Material;

        /// <summary>
        /// Boss��������Ĺ���Ĳ���
        /// </summary>
        public static Material MAT_TOMB_STONE = ResourceLoader.Instance.try_load_cached_asset("Assets/" + ResPath.MAT_TOMBSTONE) as Material;

        /// <summary>
        /// ��ɫ���ߵĲ���
        /// </summary>
        public static Material MAT_OUTLING = ResourceLoader.Instance.try_load_cached_asset("Assets/" + ResPath.MAT_OUTLING) as Material;

        /// <summary>
        /// ���ʵ����Ͷ���
        /// </summary>
        public enum MAT_TYPE 
        {
            OUTLING,
            HURT_HIGHLIGHT,
            DEAD_DISSOLVE,
            DEAD_TOMBSTONE
        }

        /// <summary>
        /// ������ʾ�����ȼ�
        /// </summary>
        public enum Priority //hightest -> lowest
        {
            OUTLING = 0,
            TOMB = 1,
            DEAD = 2,
            HURT = 3,
        }

        /// <summary>
        /// ��ӵ���Ч���ʵ�����
        /// </summary>
        public class MatInfo : IComparable
        {
            public float startTime;//��ʼ��ʱ��
            public float endTime;// ������ʱ��
            public MAT_TYPE type;// ���ʵ�����
            public int priority;// ��ʾ�����ȼ�
            public bool needDelete = false;// �Ƿ���Ҫɾ��

            public int CompareTo(object obj)
            {
                MatInfo b = obj as MatInfo;
                if (b.priority < priority)// �ȱȽ����ȼ���priorityֵԽС�����ȼ�Խ��
                    return 1;
                if (b.priority > priority)
                    return -1;
                else
                {
                    if (b.startTime > startTime)// �ȽϿ�ʼʱ�䣬��ʼʱ��Խ�������ȼ�Խ��
                        return 1;
                    else if (b.startTime < startTime)
                        return -1;
                    else
                        return 0;
                }
            }
        }

        /// <summary>
        /// ����ԭʼ���ʵĲ�����Ϣ
        /// </summary>
        public class ExtraMatInf
        {
            /// <summary>
            /// ���ʵ�ԭʼ��ɫ
            /// </summary>
            public Color OriColor = Color.white;

            /// <summary>
            /// �Ƿ���ʽ��й�ʵ����
            /// </summary>
            public bool Instance = false;
        }

        public readonly string MainColorName = "_Color";

        public Dictionary<Renderer, Material> m_InitMat = new Dictionary<Renderer, Material>();// ��¼��ɫ��ԭʼ����
        public Dictionary<Renderer, ExtraMatInf> m_InitMatExtra = new Dictionary<Renderer, ExtraMatInf>();// ��¼��ɫԭʼ���ʵĲ�����Ϣ
        private List<MatInfo> m_MatList = new List<MatInfo>();// ��ǰ��ӵ����в�����Ч
        private bool m_RecoverState = true;// �Ƿ��Ѿ��ָ���ԭʼ�Ĳ���

        /// <summary>
        /// ��ʼ��������Ϣ
        /// </summary>
        public void InitMat()
        {
            m_InitMat.Clear();
            m_InitMatExtra.Clear();

            if (mOwner == null || mOwner.IsDestroy)
                return;

            var game_obeject = mOwner.gameObject;
            if (game_obeject == null)
                return;

            Renderer[] renderes = mOwner.gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderes)
            {
                if (r.sharedMaterial == null)
                {
                    continue;
                }

                string tag_name = r.gameObject.tag;// ֻ�б��tag�Ľڵ���滻����
                if (tag_name.ToLower() != "matreplace")
                    continue;

                ExtraMatInf mat_info = new ExtraMatInf();
                if (r.sharedMaterial.HasProperty(MainColorName))
                    mat_info.OriColor = r.sharedMaterial.color;
                mat_info.Instance = false;

                m_InitMatExtra.Add(r, mat_info);
                m_InitMat.Add(r, r.sharedMaterial);
            }
        }

        /// <summary>
        /// ��Ӳ�����Ч
        /// </summary>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <param name="pri"></param>
        /// <returns></returns>
        public MatInfo AddEffectMat(float time, MAT_TYPE type, Priority pri)
        {
            MatInfo m = new MatInfo();
            m.startTime = Time.time;
            m.endTime = m.startTime + time;
            m.type = type;
            m.priority = (int)pri;

            m_MatList.Add(m);
            OnMatListChange();
            return m;
        }

        public void RemoveEffectMat(MAT_TYPE type)
        {
            List<int> remove_list = new List<int>();
            int i = 0;
            foreach(var info in m_MatList)
            {
                if(info.type == type)
                {
                    remove_list.Add(i);
                }

                i++;
            }

            for (i = remove_list.Count -1; i >=0; --i )
            {
                m_MatList.RemoveAt(i);
            }

            if(remove_list.Count > 0)
                OnMatListChange();
        }

        /// <summary>
        /// �����б����仯ʱ����
        /// </summary>
        private void OnMatListChange()
        {
            if (m_InitMat.Count == 0)
                InitMat();

            // ��������б�Ϊ�գ���ָ�ԭʼ�Ĳ���
            if (m_MatList.Count < 1)
            {
                Recover();
                return;
            }

            // �Ȼָ�ԭʼ����
            Recover();

            // �����²���Ч��
            m_MatList.Sort();
            MatInfo m = m_MatList[0];
            BeginMat(m);
            m_RecoverState = false;
        }

        /// <summary>
        /// ����������Ч
        /// </summary>
        /// <param name="m"></param>
        private void BeginMat(MatInfo m)
        {
            foreach (KeyValuePair<Renderer, Material> kvp in m_InitMat)
            {
                if (kvp.Key == null)
                    continue;

                var mat_info = m_InitMatExtra[kvp.Key];

                Material new_mat = null;
                switch (m.type)
                {
                    case MAT_TYPE.HURT_HIGHLIGHT:
                        mat_info.Instance = true;
                        kvp.Key.material = MAT_HURT_HIGHLIGHT;// ��ԭʼ�����޸�ΪHURT_HIGHLIGHT�Ĳ���
                        kvp.Key.material.mainTexture = kvp.Value.mainTexture;// texture��ֵ

                        break;
                    case MAT_TYPE.DEAD_DISSOLVE:
                        mat_info.Instance = true;
                        kvp.Key.material = MAT_DEAD_DISSOLVE;// ��ԭʼ�����޸�ΪHURT_HIGHLIGHT�Ĳ���
                        new_mat = kvp.Key.material;
                        new_mat.mainTexture = kvp.Value.mainTexture;// texture��ֵ
                        if(new_mat.HasProperty("_Normal") && kvp.Value.HasProperty("_Normal"))
                            new_mat.SetTexture("_Normal", kvp.Value.GetTexture("_Normal"));// normalmap texture
                        m_Dissolve_Time = 0;
                        m_DissolveActive = true;
                        break;
                    case MAT_TYPE.DEAD_TOMBSTONE:
                        mat_info.Instance = true;
                        kvp.Key.material = MAT_TOMB_STONE;// ��ԭʼ�����޸�ΪSTONE�Ĳ���
                        new_mat = kvp.Key.material;
                        new_mat.mainTexture = kvp.Value.mainTexture;// texture��ֵ
                        if (new_mat.HasProperty("_Normal") && kvp.Value.HasProperty("_Normal"))
                            new_mat.SetTexture("_Normal", kvp.Value.GetTexture("_Normal"));// normalmap texture
                        m_StoneTime = 0;
                        m_StoneActive = true;
                        break;
                    case MAT_TYPE.OUTLING:
                        mat_info.Instance = true;
                        kvp.Key.material = MAT_OUTLING;// ��ԭʼ�����޸�ΪOuting�Ĳ���
                        break;
                    default:
                        break;
                }
            }
        }

        bool m_DissolveActive = false;
        float m_DissolveProgress = 0;
        float m_Dissolve_Life = 3.0f;
        float m_Dissolve_Time = 0.0f;
        float m_Dissolve_Delay = 2.0f;
        void UpdateDissolve()
        {
            if (!m_DissolveActive)
                return;
            
            if (m_Dissolve_Time >= m_Dissolve_Delay)
            {
                m_DissolveProgress = (m_Dissolve_Time - m_Dissolve_Delay) / m_Dissolve_Life;
            }

            if (m_Dissolve_Time > (m_Dissolve_Delay + m_Dissolve_Life))
            {
                m_Dissolve_Time = 0.0f;
            }
            m_Dissolve_Time += Time.deltaTime;

            m_DissolveProgress = Mathf.Clamp01(m_DissolveProgress);
        }

        bool m_StoneActive = false;
        float m_StoneProgress = 0;
        float m_StoneLife = 2.0f;
        float m_StoneTime = 0.0f;
        void UpdateStone()
        {
            if (!m_StoneActive)
                return;

            if (m_StoneTime >= 0)
            {
                m_StoneProgress = m_StoneTime / m_Dissolve_Life;
            }

            m_StoneTime += Time.deltaTime;

            m_StoneProgress = Mathf.Clamp01(m_StoneProgress);
        }

        public override void Update()
        {
            base.Update();

            UpdateDissolve();
            UpdateStone();

            if(m_StoneActive || m_DissolveActive)
            {
                foreach (KeyValuePair<Renderer, Material> kvp in m_InitMat)
                {
                    if (kvp.Key == null || kvp.Value == null)
                        continue;

                    var mat_info = m_InitMatExtra[kvp.Key];
                    if (mat_info.Instance == false)
                        continue;

                    Material mat = kvp.Key.sharedMaterial; // ��m_InitMat�б��е�Material�Ѿ��ڳ�ʼ����ʱ�������Instance
                    if (mat.HasProperty("_Progress"))
                        mat.SetFloat("_Progress", 1 - m_DissolveProgress);
                    else if (mat.HasProperty("_StoneProgress"))
                        mat.SetFloat("_StoneProgress", 1 - m_StoneProgress);

                }
            }
            
            if (m_MatList.Count < 1)
                return;

            float t = Time.time;

            bool currentChanged = false;
            MatInfo current = m_MatList[0];
            foreach (MatInfo m in m_MatList)
            {
                // �������Ч����ʱ�������ѵ���������б����Ƴ�
                if (m.endTime != m.startTime && t > m.endTime)
                {
                    m.needDelete = true;
                    if (m == current)
                        currentChanged = true;
                }
            }

            // ���б����Ƴ�
            m_MatList.RemoveAll(item => item.needDelete == true);

            // ����Ƴ����ǵ�ǰ����ʹ�õ���Ч����Ҫ�����������²���
            if (currentChanged)
                OnMatListChange();
        }

        /// <summary>
        /// �ָ�ԭʼ�Ĳ���
        /// </summary>
        public void Recover()
        {
            if (m_RecoverState)
                return;

            foreach (KeyValuePair<Renderer, Material> kvp in m_InitMat)
            {
                if (kvp.Key == null || kvp.Value == null)
                    continue;

                var mat_info = m_InitMatExtra[kvp.Key];
                if (mat_info.Instance)
                {
                    mat_info.Instance = false;

                    // Ҫ������instance�Ĳ���
                    var instance_mat = kvp.Key.material;
                    kvp.Key.sharedMaterial = kvp.Value;
                    GameObject.Destroy(instance_mat);
                }
                else
                {
                    kvp.Key.sharedMaterial = kvp.Value;
                }
                ExtraMatInf emi = m_InitMatExtra[kvp.Key];
                if (kvp.Value.HasProperty(MainColorName))
                {
                    kvp.Key.sharedMaterial.SetColor(MainColorName, emi.OriColor);
                }

            }
            m_RecoverState = true;
        }

        public override void Destroy()
        {
            // �ڱ���ʱҪ�ָ���ɫ�Ĳ���
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.SHAPE_SHIFT, OnShapeShift);
            // �ڻ�װ���Է����仯ʱҪ�ָ���ɫ�Ĳ���
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.AVATAR_CHANGE, OnAvatarPropertyChange);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.AVATAR_CHANGE_BEGIN, OnAvatarPropertyChangeBegin);

            base.Destroy();

            ClearMat();
        }

        void ClearMat()
        {
            Recover();
            m_MatList.Clear();
            // ��ʼ����Ĳ���Ҳclear
            m_InitMat.Clear();
            m_InitMatExtra.Clear();
        }

        void OnShapeShift(CEventBaseArgs data)
        {
            ClearMat();
        }

        void OnAvatarPropertyChange(CEventBaseArgs data)
        {
            if (mIsDestroy || mOwner == null || mOwner.IsDestroy)
                return;

            ClearMat();
            InitMat();

            // ��������������������Ҫ�ٴ��������Ч��
            if (mOwner.IsMonster() && mOwner.IsDead())
                AddEffectMat(GlobalConst.MonsterDestroyDelay, MaterialEffectCtrl.MAT_TYPE.DEAD_DISSOLVE, MaterialEffectCtrl.Priority.DEAD);
        }

        void OnAvatarPropertyChangeBegin(CEventBaseArgs data)
        {
            if (mOwner == null || mOwner.IsDestroy)
                return;

            ClearMat();
        }
    }
}

