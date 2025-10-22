namespace SmartInjectors
{
    /// <summary>
    /// 游戏物品的 TypeID 常量定义
    /// 通过游戏内分析工具获取 (按F9键运行分析)
    /// </summary>
    public static class ItemTypeIDs
    {
        /// <summary>
        /// 注射器收纳包 (Injection Case) - 6槽位容器
        /// </summary>
        public const int INJECTION_CASE = 882;

        #region 针剂类物品 (Syringes)
        
        /// <summary>
        /// 黄针
        /// </summary>
        public const int SYRINGE_YELLOW = 137;

        /// <summary>
        /// 黑色针剂
        /// </summary>
        public const int SYRINGE_BLACK = 395;

        /// <summary>
        /// 负重针
        /// </summary>
        public const int SYRINGE_WEIGHT = 398;

        /// <summary>
        /// 电抗性针
        /// </summary>
        public const int SYRINGE_ELECTRIC_RESIST = 408;

        /// <summary>
        /// 热血针剂
        /// </summary>
        public const int SYRINGE_HOT_BLOOD = 438;

        /// <summary>
        /// 硬化针
        /// </summary>
        public const int SYRINGE_HARDENING = 797;

        /// <summary>
        /// 持久针
        /// </summary>
        public const int SYRINGE_ENDURANCE = 798;

        /// <summary>
        /// 近战针
        /// </summary>
        public const int SYRINGE_MELEE = 800;

        /// <summary>
        /// 弱效空间风暴防护针
        /// </summary>
        public const int SYRINGE_WEAK_STORM_PROTECTION = 856;

        /// <summary>
        /// 测试用空间风暴防护针
        /// </summary>
        public const int SYRINGE_TEST_STORM_PROTECTION = 857;

        /// <summary>
        /// 强翅针
        /// </summary>
        public const int SYRINGE_STRONG_WINGS = 872;

        /// <summary>
        /// 恢复针
        /// </summary>
        public const int SYRINGE_RECOVERY = 875;

        /// <summary>
        /// 火抗性针
        /// </summary>
        public const int SYRINGE_FIRE_RESIST = 1070;

        /// <summary>
        /// 毒抗性针
        /// </summary>
        public const int SYRINGE_POISON_RESIST = 1071;

        /// <summary>
        /// 空间抗性针
        /// </summary>
        public const int SYRINGE_SPACE_RESIST = 1072;

        /// <summary>
        /// 止血针
        /// </summary>
        public const int SYRINGE_HEMOSTATIC = 1247;

        #endregion

        /// <summary>
        /// 判断指定TypeID是否为针剂
        /// </summary>
        public static bool IsSyringe(int typeID)
        {
            return typeID == SYRINGE_YELLOW ||
                   typeID == SYRINGE_BLACK ||
                   typeID == SYRINGE_WEIGHT ||
                   typeID == SYRINGE_ELECTRIC_RESIST ||
                   typeID == SYRINGE_HOT_BLOOD ||
                   typeID == SYRINGE_HARDENING ||
                   typeID == SYRINGE_ENDURANCE ||
                   typeID == SYRINGE_MELEE ||
                   typeID == SYRINGE_WEAK_STORM_PROTECTION ||
                   typeID == SYRINGE_TEST_STORM_PROTECTION ||
                   typeID == SYRINGE_STRONG_WINGS ||
                   typeID == SYRINGE_RECOVERY ||
                   typeID == SYRINGE_FIRE_RESIST ||
                   typeID == SYRINGE_POISON_RESIST ||
                   typeID == SYRINGE_SPACE_RESIST ||
                   typeID == SYRINGE_HEMOSTATIC;
        }
    }
}
