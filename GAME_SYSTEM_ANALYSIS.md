# Duckov 游戏系统分析 - 针剂系统

## ✅ ILSpy 安装完成

已成功安装 ILSpy 命令行工具(ilspycmd v9.1.0.7988)并反编译游戏DLL。

## 📁 反编译文件位置

- `DecompiledCode/DuckovCore/` - 游戏核心系统
- `DecompiledCode/ItemStatsSystem/` - 物品系统
- `DecompiledCode/AssemblyCSharp/` - 游戏主要逻辑

## 🎯 针剂系统分析

### 1. 物品系统 (ItemStatsSystem)

#### Item 类 (核心物品类)
```csharp
public class Item : MonoBehaviour
{
    // 核心属性
    private int typeID;                    // 物品类型ID
    private string displayName;            // 显示名称
    private Sprite icon;                   // 图标
    private int maxStackCount = 1;         // 最大堆叠数量
    private float weight;                  // 重量
    private TagCollection tags;            // 标签集合
    
    // 组件
    private SlotCollection slots;          // 插槽集合(用于容器功能)
    private Inventory inventory;           // 内部库存
    private UsageUtilities usageUtilities; // 使用功能工具
    private List<Effect> effects;          // 效果列表
}
```

#### SlotCollection 类 (容器槽位系统)
```csharp
public class SlotCollection : ItemComponent
{
    public List<Slot> list;                // 槽位列表
    public Action<Slot> OnSlotContentChanged; // 槽位内容变更事件
    
    // 方法
    public Slot GetSlot(string key);       // 获取指定槽位
    public Slot GetSlotByIndex(int index); // 按索引获取槽位
}
```

**关键发现**: 
- 注射器箱（Injection Case）TypeID: 882，名称: 注射器收纳包，槽位: 6，重量: 0.5kg
- 所有Syringe类物品（中文名含“针”且不含“配方”）TypeID及名称如下：

| TypeID | 名称           |
|--------|----------------|
| 137    | 黄针           |
| 395    | 黑色针剂       |
| 398    | 负重针         |
| 408    | 电抗性针       |
| 438    | 热血针剂       |
| 797    | 硬化针         |
| 798    | 持久针         |
| 800    | 近战针         |
| 856    | 弱效空间风暴防护针 |
| 857    | 测试用空间风暴防护针 |
| 872    | 强翅针         |
| 875    | 恢复针         |
| 1070   | 火抗性针       |
| 1071   | 毒抗性针       |
| 1072   | 空间抗性针     |
| 1247   | 止血针         |

（提取规则：中文名包含“针”且不包含“配方”）
- Injection Case 使用 `SlotCollection` 来实现6个槽位
- 每个槽位可以容纳一个 Syringe (针剂)

### 2. 使用行为系统 (UsageBehavior)

#### Drug 类 (药物/针剂基类)
```csharp
[MenuPath("医疗/药")]
public class Drug : UsageBehavior
{
    public int healValue;                  // 治疗值
    public bool useDurability;             // 是否使用耐久度
    public float durabilityUsage;          // 耐久度消耗
    public bool canUsePart;                // 是否可以部分使用
    
    protected override void OnUse(Item item, object user)
    {
        // 治疗角色
        CharacterMainControl character = user as CharacterMainControl;
        Heal(character, item, healValue);
    }
}
```

#### AddBuff 类 (添加Buff行为)
```csharp
public class AddBuff : UsageBehavior
{
    public Buff buffPrefab;                // Buff预制体
    public float chance = 1f;              // 触发概率
    
    protected override void OnUse(Item item, object user)
    {
        CharacterMainControl character = user as CharacterMainControl;
        character.AddBuff(buffPrefab, character);
    }
}
```

**关键发现**:
- 针剂通过 `UsageBehavior` 定义使用效果
- 可以继承 `Drug` 类实现治疗
- 可以使用 `AddBuff` 添加临时Buff效果

### 3. Buff系统

#### Buff 类 (增益/减益效果)
```csharp
public class Buff : MonoBehaviour
{
    // 核心属性
    private int id;                        // Buff ID
    private int maxLayers = 1;             // 最大层数
    private BuffExclusiveTags exclusiveTag;// 排他标签
    private string displayName;            // 显示名称
    private string description;            // 描述
    private Sprite icon;                   // 图标
    private bool limitedLifeTime;          // 是否限时
    private float totalLifeTime;           // 总持续时间
    private List<Effect> effects;          // 效果列表
    
    // 状态
    public int CurrentLayers;              // 当前层数
    public float RemainingTime;            // 剩余时间
    public bool IsOutOfTime;               // 是否超时
}
```

#### BuffExclusiveTags 枚举 (Buff类型)
```csharp
public enum BuffExclusiveTags
{
    NotExclusive,      // 无排他性
    Bleeding,          // 流血
    Starve,            // 饥饿
    Thirsty,           // 口渴
    Weight,            // 负重
    Poison,            // 中毒
    Pain,              // 疼痛
    Electric,          // 电击
    Burning,           // 燃烧
    Space,             // 空间
    StormProtection,   // 风暴保护
    Nauseous,          // 恶心
    Stun               // 眩晕
}
```

**关键发现**:
- Buff可以叠加层数(maxLayers)
- Buff可以设置持续时间
- Buff通过 Effect 系统施加实际效果
- 某些Buff有排他性(同类型只能存在一个)

### 4. CharacterBuffManager (角色Buff管理器)
```csharp
public class CharacterBuffManager : MonoBehaviour
{
    // 管理角色的所有Buff
    // 添加、移除、更新Buff
}
```

## 🎮 游戏中的针剂工作流程

```
1. Injection Case (注射器箱)
   ├─ 有6个Slot槽位
   ├─ 每个槽位可容纳1个Syringe
   └─ 必须从箱子中取出才能使用

2. Syringe (针剂) - Item
   ├─ 继承自 Item 类
   ├─ 有 UsageBehavior 组件
   │   ├─ Drug (治疗)
   │   └─ AddBuff (添加Buff)
   └─ 使用时触发效果

3. 使用针剂后
   ├─ 立即治疗 (Drug.healValue)
   └─ 添加Buff到角色
       ├─ Buff有持续时间
       ├─ Buff可以叠加层数
       └─ Buff通过Effect系统持续作用
```

## 💡 Mod开发建议

基于以上分析,SmartInjectors Mod 可以实现以下功能:

### 可能的功能方向

1. **智能注射器箱**
   - 自动整理针剂
   - 快速访问常用针剂
   - 显示针剂剩余数量和效果

2. **增强针剂系统**
   - 新增针剂类型
   - 修改现有针剂效果
   - 添加组合针剂(多种Buff)

3. **Buff管理**
   - 显示当前所有Buff
   - Buff计时器提醒
   - 自动续Buff功能

4. **使用便利性**
   - 快捷键直接使用针剂
   - 自动使用针剂(血量低时)
   - 批量使用针剂

## 📝 研究进展

### ✅ 已解决

#### 1. 如何注册Mod的自定义物品
```csharp
// 添加自定义物品到游戏
ItemStatsSystem.ItemAssetsCollection.AddDynamicEntry(Item prefab);

// 移除自定义物品
ItemStatsSystem.ItemAssetsCollection.RemoveDynamicEntry(Item prefab);

// 注意事项:
// - 自定义物品需要配置 TypeID,避免与基础游戏和其他Mod冲突
// - 如果MOD未加载,保存文件中的自定义物品会消失
```

#### 2. 如何hook物品使用事件
```csharp
// 全局静态事件 - 任何物品被使用时触发
using ItemStatsSystem;

void Start()
{
    UsageUtilities.OnItemUsedStaticEvent += OnItemUsed;
}

void OnDestroy()
{
    UsageUtilities.OnItemUsedStaticEvent -= OnItemUsed;
}

private void OnItemUsed(Item item)
{
    Debug.Log($"物品被使用: {item.DisplayName}, TypeID: {item.TypeID}");
    
    // 可以在这里检查是否是特定物品
    if (item.TypeID == 某个针剂的TypeID)
    {
        // 执行自定义逻辑
    }
}
```

```csharp
// 角色开始使用物品事件
using Duckov;

CharacterMainControl.OnMainCharacterStartUseItem += (item) => {
    Debug.Log($"主角开始使用: {item.DisplayName}");
};
```

```csharp
// 单个物品的使用事件
Item myItem = ...;
myItem.onUse += (item, user) => {
    Debug.Log($"这个物品被使用了!");
};
```

#### 3. 如何获取所有物品信息
```csharp
var collection = ItemStatsSystem.ItemAssetsCollection.Instance;
foreach (var entry in collection.entries)
{
    int typeID = entry.typeID;
    Item prefab = entry.prefab;
    string displayName = prefab.DisplayName;
    // ...
}
```

## 🎮 快捷物品栏系统分析

### ItemShortcut 类 (快捷栏管理器)
```csharp
public class ItemShortcut : MonoBehaviour
{
    private int maxIndex = 3;  // 实际有6个快捷栏 (索引0-5)
    private List<Item> items;  // 快捷栏中的物品列表
    
    // 静态方法
    public static Item Get(int index);      // 获取指定快捷栏的物品
    public static bool Set(int index, Item item);  // 设置快捷栏物品
    public static bool IsItemValid(Item item);     // 检查物品是否有效
    
    // 事件
    public static event Action<int> OnSetItem;  // 快捷栏物品变更事件
}
```

### 快捷栏使用规则
```csharp
// 物品必须满足以下条件才能放入快捷栏:
public static bool IsItemValid(Item item)
{
    if (item == null) return false;
    if (MainInventory != item.InInventory) return false;  // 必须在主背包中
    if (item.Tags.Contains("Weapon")) return false;       // 武器不能放入
    return true;
}

// 按下数字键时的处理逻辑:
private void ShortCutInput(int index)
{
    Item item = ItemShortcut.Get(index - 3);  // 索引3-8对应数字键1-6
    if (item != null && character != null)
    {
        // 优先级1: 如果物品可使用 (有UsageUtilities且IsUsable)
        if (item.UsageUtilities && item.UsageUtilities.IsUsable(item, character))
        {
            character.UseItem(item);  // 使用物品
        }
        // 优先级2: 如果是技能物品
        else if (item.GetBool("IsSkill"))
        {
            character.ChangeHoldItem(item);  // 装备到手上
        }
        // 优先级3: 如果有HandHeldAgent (可手持物品)
        else if (item.HasHandHeldAgent)
        {
            character.ChangeHoldItem(item);  // 装备到手上
        }
    }
}
```

### UsageUtilities 类 (物品使用功能)
```csharp
public class UsageUtilities : ItemComponent
{
    public List<UsageBehavior> behaviors;  // 使用行为列表
    public float useTime;                  // 使用时间
    public bool useDurability;             // 是否消耗耐久
    public int durabilityUsage;            // 耐久消耗量
    
    // 判断物品是否可使用
    public bool IsUsable(Item item, object user)
    {
        if (!item) return false;
        
        // 检查耐久度
        if (useDurability && item.Durability < durabilityUsage)
            return false;
        
        // 检查是否有任何behavior可以使用
        foreach (UsageBehavior behavior in behaviors)
        {
            if (behavior != null && behavior.CanBeUsed(item, user))
                return true;
        }
        return false;
    }
    
    // 使用物品
    public void Use(Item item, object user)
    {
        // 执行所有可用的behavior
        foreach (UsageBehavior behavior in behaviors)
        {
            if (behavior != null && behavior.CanBeUsed(item, user))
                behavior.Use(item, user);
        }
        
        // 消耗耐久度
        if (useDurability && item.Durability > 0f)
            item.Durability -= durabilityUsage;
        
        // 触发全局使用事件
        OnItemUsedStaticEvent?.Invoke(item);
    }
}
```

### 关键发现
1. **快捷栏数量**: 游戏有6个快捷栏 (对应数字键1-6)
2. **物品必须有 UsageUtilities 组件才能被"使用"**
3. **注射器收纳包 (TypeID: 882) 没有 UsageUtilities 组件**，所以图3中没有"使用"按钮
4. **武器 (带"Weapon"标签) 无法放入快捷栏**，它们使用 Q/E/V 键切换
5. **快捷栏只能放置背包中的物品**，不能是装备槽或容器内的物品
6. **物品类型互斥**: 同一TypeID的物品在快捷栏中只能存在一个

### ⏳ 待解决(需要游戏运行时数据)

- [x] ~~Injection Case 的具体 TypeID~~ **已获取: 882**
- [x] ~~现有游戏中有哪些针剂及其效果~~ **已获取: 16种针剂**
- [ ] 如何获取玩家当前的Buff列表 - **需要分析 CharacterBuffManager**
- [ ] 如何修改Slot容量(6个槽位是否可以增加) - **需要研究 SlotCollection 的限制**

## � SmartInjectors Mod 功能设计建议

基于以上分析，可以实现以下功能：

### 1. 直接从快捷栏使用针剂 (推荐实现)
**问题**: 注射器收纳包没有UsageUtilities，无法直接使用  
**解决方案**: 
- Hook快捷栏输入事件
- 检测到注射器收纳包时，显示其内部针剂列表UI
- 玩家选择针剂后直接使用

### 2. 智能针剂管理
- 监听针剂使用事件 (UsageUtilities.OnItemUsedStaticEvent)
- 记录使用统计和Buff效果
- 在HUD显示当前Buff和剩余时间

### 3. 针剂收纳包增强
- 自动整理针剂 (按类型/效果分类)
- 显示每个槽位针剂的效果预览
- 快速补充针剂功能

### 4. 自定义快捷操作
- 为常用针剂组合设置快捷键
- 自动使用针剂 (血量低/Buff即将过期)
- 批量使用同类针剂

## �🔍 下一步

1. ✅ ~~了解如何注册Mod的自定义物品~~ **完成!**
2. ✅ ~~研究如何hook物品使用事件~~ **完成!**
3. ✅ ~~运行游戏内分析工具获取TypeID~~ **完成!**
4. ✅ ~~分析快捷物品栏系统~~ **完成!**
5. 🚀 **开始实现核心功能** - 见下方开发路线图

### 开发路线图
```
Phase 1: 基础功能
├─ 创建 ItemTypeIDs.cs (定义所有TypeID常量)
├─ 实现针剂使用监听
└─ 在日志中记录针剂使用情况

Phase 2: UI增强
├─ 创建针剂收纳包快捷使用UI
├─ 显示针剂效果和数量
└─ 实现快捷选择和使用

Phase 3: 高级功能
├─ Buff状态显示
├─ 自动使用功能
└─ 使用统计和建议
```

---

**分析完成时间**: 2025-10-23  
**使用工具**: ILSpy v9.1.0.7988  
**游戏版本**: 1.0.26
