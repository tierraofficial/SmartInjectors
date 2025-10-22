using UnityEngine;
using Duckov.Modding;
using ItemStatsSystem;
using Duckov;
using System.Collections.Generic;
using System.Linq;

namespace SmartInjectors
{
    /// <summary>
    /// SmartInjectors Mod 主类
    /// 继承自 Duckov.Modding.ModBehaviour
    /// 
    /// 核心功能:
    /// - 按数字键1-6使用快捷栏中的注射器收纳包时，显示针剂选择UI
    /// - 从UI中选择针剂直接使用
    /// 
    /// 调试功能:
    /// - 按 F9 键运行物品分析工具
    /// - 按 F10 键重新运行分析
    /// </summary>
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        private const string LOG_PREFIX = "[SmartInjectors]";
        
        // 调试工具
        private bool hasAnalyzed = false;
        
        // 核心功能
        private InjectionCaseUI injectionCaseUI;
        
        // Unity 事件: 当脚本实例被加载时调用
        private void Awake()
        {
            Debug.Log($"{LOG_PREFIX} ==========================================");
            Debug.Log($"{LOG_PREFIX} Smart Injectors Mod 正在加载...");
            Debug.Log($"{LOG_PREFIX} Version: 1.0.0");
            Debug.Log($"{LOG_PREFIX} ==========================================");
        }

        // Unity 事件: 在第一帧更新之前调用
        private void Start()
        {
            Debug.Log($"{LOG_PREFIX} Mod 启动成功!");
            Debug.Log($"{LOG_PREFIX} 按 F9 键运行物品分析工具");
            Debug.Log($"{LOG_PREFIX} 按 F10 键重新运行分析");
            
            InitializeMod();
        }

        /// <summary>
        /// 初始化 Mod 功能
        /// </summary>
        private void InitializeMod()
        {
            Debug.Log($"{LOG_PREFIX} 开始初始化 Smart Injectors 功能...");
            
            // 创建注射器收纳包UI
            injectionCaseUI = new InjectionCaseUI();
            Debug.Log($"{LOG_PREFIX} 注射器收纳包UI已创建");
            Debug.Log($"{LOG_PREFIX} 快捷栏监听已启用");
            Debug.Log($"{LOG_PREFIX} 提示: 按数字键1-6使用快捷栏中的注射器收纳包");
            
            Debug.Log($"{LOG_PREFIX} 初始化完成!");
        }

        // Unity 事件: 每帧调用一次
        private void Update()
        {
            // === 核心功能: 监听快捷键并检查注射器收纳包 ===
            if (injectionCaseUI != null)
            {
                // 处理UI输入 (UI内部会消耗数字键输入)
                injectionCaseUI.HandleInput();
                
                // 如果UI未显示，监听快捷键1-6
                if (!injectionCaseUI.IsVisible)
                {
                    CheckShortcutKeys();
                }
            }
            
            // === 调试功能 ===
            // 按 F9 键触发分析
            if (Input.GetKeyDown(KeyCode.F9) && !hasAnalyzed)
            {
                AnalyzeAllItems();
                hasAnalyzed = true;
            }
            
            // 按 F10 键重新分析
            if (Input.GetKeyDown(KeyCode.F10))
            {
                hasAnalyzed = false;
                AnalyzeAllItems();
            }
        }

        /// <summary>
        /// 检查快捷键1-6是否被按下
        /// 如果按下的快捷栏中是注射器收纳包，则显示UI
        /// 注意: 当UI显示时，此方法不处理按键，由injectionCaseUI.HandleInput()处理
        /// </summary>
        private void CheckShortcutKeys()
        {
            // 如果UI已显示，不在这里处理数字键，避免与游戏快捷栏冲突
            // UI的HandleInput()会处理数字键用于快速使用针剂
            if (injectionCaseUI != null && injectionCaseUI.IsVisible)
            {
                return;
            }
            
            for (int i = 0; i < 6; i++)
            {
                KeyCode key = KeyCode.Alpha1 + i;
                if (Input.GetKeyDown(key))
                {
                    OnShortcutKeyPressed(i);
                }
            }
        }

        /// <summary>
        /// 处理快捷键按下事件
        /// </summary>
        private void OnShortcutKeyPressed(int slotIndex)
        {
            try
            {
                // 使用游戏的ItemShortcut系统获取物品
                // 注意: ItemShortcut的索引从0开始，对应快捷栏1-6
                Item item = Duckov.ItemShortcut.Get(slotIndex);
                
                if (item == null)
                {
                    Debug.Log($"{LOG_PREFIX} 快捷栏 {slotIndex + 1} 为空");
                    return;
                }

                Debug.Log($"{LOG_PREFIX} 检测到快捷栏 {slotIndex + 1} 使用: {item.DisplayName} (TypeID: {item.TypeID})");

                // 检查是否是注射器收纳包
                if (item.TypeID == ItemTypeIDs.INJECTION_CASE)
                {
                    Debug.Log($"{LOG_PREFIX} 检测到注射器收纳包，显示UI");
                    injectionCaseUI.Show(item);
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"{LOG_PREFIX} 处理快捷键时出错: {ex.Message}");
                Debug.LogError($"{LOG_PREFIX} 堆栈: {ex.StackTrace}");
            }
        }

        /// <summary>
        /// 分析游戏中的所有物品
        /// </summary>
        private void AnalyzeAllItems()
        {
            Debug.Log($"{LOG_PREFIX} ==========================================");
            Debug.Log($"{LOG_PREFIX} 开始分析游戏物品...");
            Debug.Log($"{LOG_PREFIX} ==========================================");
            
            try
            {
                var collection = ItemAssetsCollection.Instance;
                if (collection == null)
                {
                    Debug.LogError($"{LOG_PREFIX} 无法获取 ItemAssetsCollection!");
                    return;
                }
                
                // 获取所有物品条目
                var entries = collection.entries;
                Debug.Log($"{LOG_PREFIX} 找到 {entries.Count} 个物品");
                Debug.Log($"{LOG_PREFIX} ");
                
                // 按类别分类
                var medicalItems = new List<string>();
                var containerItems = new List<string>();
                var injectionRelated = new List<string>();
                
                foreach (var entry in entries)
                {
                    if (entry == null || entry.prefab == null) continue;
                    
                    var item = entry.prefab;
                    var typeID = entry.typeID;
                    var displayName = item.DisplayName;
                    var tags = item.Tags;
                    
                    // 检查是否有槽位(容器)
                    bool hasSlots = item.Slots != null && item.Slots.Count > 0;
                    int slotCount = hasSlots ? item.Slots.Count : 0;
                    
                    // 检查是否是医疗物品
                    bool isMedical = tags.Contains("Medical") || 
                                    displayName.ToLower().Contains("medical") ||
                                    displayName.ToLower().Contains("syringe") ||
                                    displayName.ToLower().Contains("injection") ||
                                    displayName.Contains("药") ||
                                    displayName.Contains("针");
                    
                    // 收集注射器相关物品
                    if (displayName.ToLower().Contains("injection") ||
                        displayName.ToLower().Contains("syringe") ||
                        displayName.Contains("注射") ||
                        displayName.Contains("针剂"))
                    {
                        string info = $"TypeID: {typeID}, 名称: {displayName}, 槽位: {slotCount}";
                        injectionRelated.Add(info);
                    }
                    
                    // 收集医疗物品
                    if (isMedical)
                    {
                        string info = $"TypeID: {typeID}, 名称: {displayName}";
                        medicalItems.Add(info);
                    }
                    
                    // 收集有6个槽位的容器(可能是 Injection Case)
                    if (hasSlots && slotCount == 6)
                    {
                        string info = $"TypeID: {typeID}, 名称: {displayName}, 槽位: {slotCount}, 重量: {item.UnitSelfWeight}kg";
                        containerItems.Add(info);
                    }
                }
                
                // 输出注射器相关物品
                Debug.Log($"{LOG_PREFIX} ");
                Debug.Log($"{LOG_PREFIX} === 注射器/针剂相关物品 ===");
                if (injectionRelated.Count > 0)
                {
                    foreach (var info in injectionRelated)
                    {
                        Debug.Log($"{LOG_PREFIX}   {info}");
                    }
                }
                else
                {
                    Debug.Log($"{LOG_PREFIX}   未找到(可能使用本地化名称)");
                }
                
                // 输出6槽位容器
                Debug.Log($"{LOG_PREFIX} ");
                Debug.Log($"{LOG_PREFIX} === 6槽位容器物品 (可能是Injection Case) ===");
                if (containerItems.Count > 0)
                {
                    foreach (var info in containerItems)
                    {
                        Debug.Log($"{LOG_PREFIX}   {info}");
                    }
                }
                else
                {
                    Debug.Log($"{LOG_PREFIX}   未找到");
                }
                
                // 输出医疗物品
                Debug.Log($"{LOG_PREFIX} ");
                Debug.Log($"{LOG_PREFIX} === 医疗相关物品 (共{medicalItems.Count}个) ===");
                foreach (var info in medicalItems)
                {
                    Debug.Log($"{LOG_PREFIX}   {info}");
                }
                
                Debug.Log($"{LOG_PREFIX} ");
                Debug.Log($"{LOG_PREFIX} ==========================================");
                Debug.Log($"{LOG_PREFIX} 分析完成!");
                Debug.Log($"{LOG_PREFIX} 日志文件位置: %AppData%\\..\\LocalLow\\TeamSoda\\Escape From Duckov\\Player.log");
                Debug.Log($"{LOG_PREFIX} ==========================================");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"{LOG_PREFIX} 分析出错: {ex.Message}");
                Debug.LogError($"{LOG_PREFIX} 堆栈: {ex.StackTrace}");
            }
        }

        // Unity 事件: 绘制GUI
        private void OnGUI()
        {
            // 绘制注射器收纳包UI
            if (injectionCaseUI != null)
            {
                injectionCaseUI.DrawGUI();
            }
        }

        // 当 Mod 被禁用时调用
        private void OnDisable()
        {
            Debug.Log($"{LOG_PREFIX} Mod 被禁用");
            
            // 隐藏UI
            if (injectionCaseUI != null && injectionCaseUI.IsVisible)
            {
                injectionCaseUI.Hide();
            }
        }

        // 当 Mod 被销毁时调用
        private void OnDestroy()
        {
            Debug.Log($"{LOG_PREFIX} Mod 被卸载,清理资源...");
            
            // 清理UI
            if (injectionCaseUI != null && injectionCaseUI.IsVisible)
            {
                injectionCaseUI.Hide();
            }
            injectionCaseUI = null;
        }
    }
}
