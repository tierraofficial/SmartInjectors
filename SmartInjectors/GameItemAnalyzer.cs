using UnityEngine;
using Duckov.Modding;
using ItemStatsSystem;
using System.Collections.Generic;
using System.Linq;

namespace SmartInjectors.Tools
{
    /// <summary>
    /// 游戏物品分析工具
    /// 用于在游戏运行时枚举所有物品的TypeID和信息
    /// </summary>
    public class GameItemAnalyzer : ModBehaviour
    {
        private bool hasAnalyzed = false;
        
        void Start()
        {
            Debug.Log("[SmartInjectors.Analyzer] 物品分析工具已加载");
            Debug.Log("[SmartInjectors.Analyzer] 按 F9 键分析游戏物品");
        }
        
        void Update()
        {
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
        /// 分析游戏中的所有物品
        /// </summary>
        private void AnalyzeAllItems()
        {
            Debug.Log("[SmartInjectors.Analyzer] ==========================================");
            Debug.Log("[SmartInjectors.Analyzer] 开始分析游戏物品...");
            Debug.Log("[SmartInjectors.Analyzer] ==========================================");
            
            try
            {
                var collection = ItemAssetsCollection.Instance;
                if (collection == null)
                {
                    Debug.LogError("[SmartInjectors.Analyzer] 无法获取 ItemAssetsCollection!");
                    return;
                }
                
                // 获取所有物品条目
                var entries = collection.entries;
                Debug.Log($"[SmartInjectors.Analyzer] 找到 {entries.Count} 个物品");
                Debug.Log("[SmartInjectors.Analyzer] ");
                
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
                                    displayName.ToLower().Contains("药") ||
                                    displayName.ToLower().Contains("针");
                    
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
                Debug.Log("[SmartInjectors.Analyzer] ");
                Debug.Log("[SmartInjectors.Analyzer] === 注射器/针剂相关物品 ===");
                if (injectionRelated.Count > 0)
                {
                    foreach (var info in injectionRelated)
                    {
                        Debug.Log($"[SmartInjectors.Analyzer]   {info}");
                    }
                }
                else
                {
                    Debug.Log("[SmartInjectors.Analyzer]   未找到(可能使用本地化名称)");
                }
                
                // 输出6槽位容器
                Debug.Log("[SmartInjectors.Analyzer] ");
                Debug.Log("[SmartInjectors.Analyzer] === 6槽位容器物品 (可能是Injection Case) ===");
                if (containerItems.Count > 0)
                {
                    foreach (var info in containerItems)
                    {
                        Debug.Log($"[SmartInjectors.Analyzer]   {info}");
                    }
                }
                else
                {
                    Debug.Log("[SmartInjectors.Analyzer]   未找到");
                }
                
                // 输出医疗物品
                Debug.Log("[SmartInjectors.Analyzer] ");
                Debug.Log($"[SmartInjectors.Analyzer] === 医疗相关物品 (共{medicalItems.Count}个) ===");
                foreach (var info in medicalItems.Take(20))
                {
                    Debug.Log($"[SmartInjectors.Analyzer]   {info}");
                }
                if (medicalItems.Count > 20)
                {
                    Debug.Log($"[SmartInjectors.Analyzer]   ... 还有 {medicalItems.Count - 20} 个");
                }
                
                Debug.Log("[SmartInjectors.Analyzer] ");
                Debug.Log("[SmartInjectors.Analyzer] ==========================================");
                Debug.Log("[SmartInjectors.Analyzer] 分析完成!");
                Debug.Log("[SmartInjectors.Analyzer] 日志文件位置: %AppData%\\..\\LocalLow\\TeamSoda\\Escape From Duckov\\Player.log");
                Debug.Log("[SmartInjectors.Analyzer] ==========================================");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"[SmartInjectors.Analyzer] 分析出错: {ex.Message}");
                Debug.LogError($"[SmartInjectors.Analyzer] 堆栈: {ex.StackTrace}");
            }
        }
    }
}
