# SmartInjectors - 游戏物品分析工具使用说明

## 🎯 目的

由于游戏物品名称使用本地化,很难从反编译代码中直接找到 `Injection Case` 和 `Syringe` 的 TypeID。
因此我创建了一个游戏内分析工具,可以在游戏运行时枚举所有物品信息。

## 📦 已编译并部署

分析工具已经编译并自动部署到游戏的 Mods 文件夹:
```
E:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov_Data\Mods\SmartInjectors\
```

## 🎮 使用方法

### 1. 启动游戏
打开 Escape From Duckov

### 2. 启用 Mod
- 主菜单 → Mods
- 找到 "Smart Injectors" 
- 启用它

### 3. 进入游戏
开始或加载一个存档

### 4. 运行分析
按 **F9** 键触发物品分析

### 5. 查看结果
分析结果会输出到游戏日志文件

## 📄 日志文件位置

### Windows
```
%AppData%\..\LocalLow\TeamSoda\Escape From Duckov\Player.log
```

或者完整路径:
```
C:\Users\<你的用户名>\AppData\LocalLow\TeamSoda\Escape From Duckov\Player.log
```

### 快速打开
在文件资源管理器地址栏输入:
```
%AppData%\..\LocalLow\TeamSoda\Escape From Duckov\
```

## 🔍 分析工具会输出

1. **注射器/针剂相关物品**
   - TypeID
   - 物品名称
   - 槽位数量

2. **6槽位容器物品** (可能是 Injection Case)
   - TypeID
   - 物品名称
   - 槽位数量
   - 重量

3. **所有医疗相关物品**
   - TypeID
   - 物品名称

## ⌨️ 快捷键

- **F9**: 运行分析(只运行一次)
- **F10**: 重新运行分析

## 📝 输出示例

日志文件中会看到类似这样的输出:

```
[SmartInjectors.Analyzer] ==========================================
[SmartInjectors.Analyzer] 开始分析游戏物品...
[SmartInjectors.Analyzer] ==========================================
[SmartInjectors.Analyzer] 找到 XXX 个物品
[SmartInjectors.Analyzer] 
[SmartInjectors.Analyzer] === 注射器/针剂相关物品 ===
[SmartInjectors.Analyzer]   TypeID: 123, 名称: Injection Case, 槽位: 6
[SmartInjectors.Analyzer]   TypeID: 124, 名称: Syringe A, 槽位: 0
[SmartInjectors.Analyzer] 
[SmartInjectors.Analyzer] === 6槽位容器物品 (可能是Injection Case) ===
[SmartInjectors.Analyzer]   TypeID: 123, 名称: Injection Case, 槽位: 6, 重量: 0.5kg
[SmartInjectors.Analyzer] 
[SmartInjectors.Analyzer] === 医疗相关物品 (共XX个) ===
[SmartInjectors.Analyzer]   TypeID: 124, 名称: Syringe A
[SmartInjectors.Analyzer]   TypeID: 125, 名称: Syringe B
[SmartInjectors.Analyzer]   ...
[SmartInjectors.Analyzer] ==========================================
[SmartInjectors.Analyzer] 分析完成!
[SmartInjectors.Analyzer] ==========================================
```

## 🔧 技术细节

分析工具通过以下方式工作:

1. **访问 ItemAssetsCollection**: 游戏的物品资产集合
2. **枚举所有 entries**: 遍历所有注册的物品
3. **提取信息**: TypeID, DisplayName, Tags, Slots等
4. **分类输出**: 按类别组织输出结果

## 📊 预期发现

通过这个分析,我们应该能找到:

- ✅ **Injection Case 的 TypeID**
- ✅ **所有 Syringe/针剂的 TypeID 列表**
- ✅ **每种针剂的具体名称**
- ✅ **医疗物品的完整列表**

## 🚀 下一步

找到 TypeID 后,我们就可以:

1. 实现针对 Injection Case 的功能增强
2. 监听特定针剂的使用事件
3. 创建自定义针剂
4. 修改现有针剂的效果

## 💡 提示

- 如果游戏内没有反应,检查Mod是否正确启用
- 如果找不到日志文件,在游戏内按F9后立即退出游戏,这样日志会被刷新到磁盘
- 可以用文本编辑器或 `tail -f` 命令实时查看日志文件

---

**准备好了吗?** 启动游戏,按F9,然后把日志结果发给我!
