using UnityEngine;
using Duckov.Modding;
using ItemStatsSystem;
using Duckov;

namespace SmartInjectors.Examples
{
    /// <summary>
    /// API 使用示例
    /// 展示如何使用游戏提供的各种API
    /// </summary>
    public class APIExamples : ModBehaviour
    {
        void Start()
        {
            Debug.Log("[SmartInjectors.Examples] API 使用示例已加载");
            
            // 注册物品使用事件监听
            RegisterItemUsageListeners();
            
            // 演示如何访问物品集合
            ExampleAccessItemCollection();
        }
        
        void OnDestroy()
        {
            // 取消注册事件
            UnregisterItemUsageListeners();
        }
        
        #region 物品使用事件监听
        
        /// <summary>
        /// 注册物品使用事件监听器
        /// </summary>
        private void RegisterItemUsageListeners()
        {
            // 方法1: 全局静态事件 - 监听所有物品使用
            UsageUtilities.OnItemUsedStaticEvent += OnAnyItemUsed;
            
            // 方法2: 主角开始使用物品事件
            CharacterMainControl.OnMainCharacterStartUseItem += OnMainCharacterStartUseItem;
            
            Debug.Log("[SmartInjectors.Examples] 物品使用监听器已注册");
        }
        
        /// <summary>
        /// 取消注册物品使用事件监听器
        /// </summary>
        private void UnregisterItemUsageListeners()
        {
            UsageUtilities.OnItemUsedStaticEvent -= OnAnyItemUsed;
            CharacterMainControl.OnMainCharacterStartUseItem -= OnMainCharacterStartUseItem;
        }
        
        /// <summary>
        /// 当任何物品被使用时调用
        /// </summary>
        private void OnAnyItemUsed(Item item)
        {
            Debug.Log($"[SmartInjectors.Examples] 物品被使用:");
            Debug.Log($"  - 名称: {item.DisplayName}");
            Debug.Log($"  - TypeID: {item.TypeID}");
            Debug.Log($"  - 堆叠数: {item.StackCount}");
            
            // 检查是否是特定物品
            // 注意: 这里的TypeID需要从游戏分析工具获取
            // if (item.TypeID == INJECTION_CASE_TYPE_ID)
            // {
            //     HandleInjectionCaseUsed(item);
            // }
        }
        
        /// <summary>
        /// 当主角开始使用物品时调用
        /// </summary>
        private void OnMainCharacterStartUseItem(Item item)
        {
            Debug.Log($"[SmartInjectors.Examples] 主角开始使用: {item.DisplayName}");
        }
        
        #endregion
        
        #region 访问物品集合
        
        /// <summary>
        /// 演示如何访问游戏的物品集合
        /// </summary>
        private void ExampleAccessItemCollection()
        {
            var collection = ItemAssetsCollection.Instance;
            if (collection == null)
            {
                Debug.LogError("[SmartInjectors.Examples] 无法获取 ItemAssetsCollection");
                return;
            }
            
            Debug.Log($"[SmartInjectors.Examples] 游戏中共有 {collection.entries.Count} 个物品");
            
            // 示例: 查找特定TypeID的物品
            // Item prefab = ItemAssetsCollection.GetPrefab(某个TypeID);
            // if (prefab != null)
            // {
            //     Debug.Log($"找到物品: {prefab.DisplayName}");
            // }
        }
        
        #endregion
        
        #region 自定义物品示例 (暂未实现)
        
        /// <summary>
        /// 演示如何添加自定义物品
        /// 注意: 需要先创建物品预制体
        /// </summary>
        private void ExampleAddCustomItem()
        {
            // // 1. 创建或加载自定义物品预制体
            // Item customItemPrefab = ...; // 需要通过Unity创建
            // 
            // // 2. 设置TypeID (避免冲突,建议使用高数值如 10000+)
            // // customItemPrefab.TypeID = 10001;
            // 
            // // 3. 添加到游戏
            // bool success = ItemAssetsCollection.AddDynamicEntry(customItemPrefab);
            // if (success)
            // {
            //     Debug.Log($"[SmartInjectors] 自定义物品已添加: {customItemPrefab.DisplayName}");
            // }
        }
        
        /// <summary>
        /// 演示如何移除自定义物品
        /// </summary>
        private void ExampleRemoveCustomItem(Item customItemPrefab)
        {
            // bool success = ItemAssetsCollection.RemoveDynamicEntry(customItemPrefab);
            // if (success)
            // {
            //     Debug.Log($"[SmartInjectors] 自定义物品已移除");
            // }
        }
        
        #endregion
        
        #region Buff系统示例 (暂未实现)
        
        /// <summary>
        /// 演示如何给角色添加Buff
        /// </summary>
        private void ExampleAddBuffToCharacter()
        {
            // // 1. 获取玩家角色
            // CharacterMainControl player = FindObjectOfType<CharacterMainControl>();
            // if (player == null) return;
            // 
            // // 2. 创建或加载Buff预制体
            // // Buff buffPrefab = ...; // 需要通过Unity创建
            // 
            // // 3. 添加Buff到角色
            // // player.AddBuff(buffPrefab, player);
            // 
            // Debug.Log($"[SmartInjectors] Buff已添加到角色");
        }
        
        #endregion
        
        #region 容器/槽位系统示例
        
        /// <summary>
        /// 演示如何访问物品的槽位
        /// </summary>
        private void ExampleAccessItemSlots(Item containerItem)
        {
            // 检查物品是否有槽位
            if (containerItem.Slots == null || containerItem.Slots.Count == 0)
            {
                Debug.Log($"[SmartInjectors] 该物品没有槽位");
                return;
            }
            
            Debug.Log($"[SmartInjectors] 槽位数量: {containerItem.Slots.Count}");
            
            // 遍历所有槽位
            for (int i = 0; i < containerItem.Slots.Count; i++)
            {
                var slot = containerItem.Slots[i];
                Debug.Log($"[SmartInjectors] 槽位 {i}:");
                Debug.Log($"  - Key: {slot.Key}");
                Debug.Log($"  - 内容: {(slot.Content != null ? slot.Content.DisplayName : "空")}");
            }
            
            // 获取特定槽位
            // var firstSlot = containerItem.Slots.GetSlot("Slot_0"); // 按Key
            // var secondSlot = containerItem.Slots.GetSlotByIndex(1); // 按索引
            
            // 监听槽位内容变化
            // containerItem.Slots.OnSlotContentChanged += (slot) => {
            //     Debug.Log($"[SmartInjectors] 槽位 {slot.Key} 内容已变化");
            // };
        }
        
        #endregion
    }
}
