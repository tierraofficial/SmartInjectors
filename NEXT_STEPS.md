# 🚀 快速参考 - 下一步行动指南

## 📍 当前进度

✅ 开发环境已配置完成  
✅ 游戏系统已分析完毕  
✅ 分析工具已编译部署  
⏳ **等待获取游戏内数据**

## 🎯 立即行动

### 第一步: 启动游戏
```
打开 Escape From Duckov
```

### 第二步: 启用 Mod
```
主菜单 → Mods → 找到 "Smart Injectors" → 启用
```

### 第三步: 进入游戏
```
开始新游戏 或 加载存档
```

### 第四步: 运行分析
```
按键盘 F9 键
```

### 第五步: 查看日志
```
位置: %AppData%\..\LocalLow\TeamSoda\Escape From Duckov\Player.log

快速打开:
1. Win+R 
2. 输入: %AppData%\..\LocalLow\TeamSoda\Escape From Duckov
3. 回车
4. 打开 Player.log
```

### 第六步: 查找关键信息
在日志文件中搜索:
```
[SmartInjectors.Analyzer] === 注射器/针剂相关物品 ===
[SmartInjectors.Analyzer] === 6槽位容器物品 ===
```

### 第七步: 记录 TypeID
记录以下信息:
- [ ] Injection Case 的 TypeID: ______
- [ ] 所有针剂的 TypeID 列表
- [ ] 针剂的具体名称

## 📝 需要的信息格式


【已获得分析结果】

=== 注射器箱 ===
TypeID: 882
名称: 注射器收纳包
槽位: 6
重量: 0.5kg

=== 针剂列表（中文名含“针”且不含“配方”）===
1. TypeID: 137, 名称: 黄针
2. TypeID: 395, 名称: 黑色针剂
3. TypeID: 398, 名称: 负重针
4. TypeID: 408, 名称: 电抗性针
5. TypeID: 438, 名称: 热血针剂
6. TypeID: 797, 名称: 硬化针
7. TypeID: 798, 名称: 持久针
8. TypeID: 800, 名称: 近战针
9. TypeID: 856, 名称: 弱效空间风暴防护针
10. TypeID: 857, 名称: 测试用空间风暴防护针
11. TypeID: 872, 名称: 强翅针
12. TypeID: 875, 名称: 恢复针
13. TypeID: 1070, 名称: 火抗性针
14. TypeID: 1071, 名称: 毒抗性针
15. TypeID: 1072, 名称: 空间抗性针
16. TypeID: 1247, 名称: 止血针

【下一步建议】
1. 在代码中定义常量：
    - public const int INJECTION_CASE = 882;
    - public const int SYRINGE_XXX = ...;
2. 实现针剂相关功能（监听使用、Buff管理、箱子扩展等）
3. 按照GAME_SYSTEM_ANALYSIS.md的建议开发核心功能

## 🔧 问题排查

### 问题1: 游戏中没有看到 Mod
**解决**: 
- 检查 Mod 文件是否在正确位置
- 路径: `E:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov_Data\Mods\SmartInjectors\`
- 确保包含 `SmartInjectors.dll` 和 `info.ini`

### 问题2: 按 F9 没反应
**解决**:
- 确保已进入游戏(不是在主菜单)
- 检查游戏日志文件是否有 `[SmartInjectors.Analyzer]` 开头的输出
- 尝试按 F10 重新运行

### 问题3: 找不到日志文件
**解决**:
- 完整路径: `C:\Users\<你的用户名>\AppData\LocalLow\TeamSoda\Escape From Duckov\Player.log`
- 或者在游戏内按F9后立即退出游戏,日志会被刷新

## 💻 开发命令速查

### 编译并部署
```powershell
cd SmartInjectors
dotnet build -c Release
```

### 快速构建(如果脚本权限允许)
```powershell
.\quick-build.ps1
```

### 查看最新日志(PowerShell)
```powershell
Get-Content "$env:APPDATA\..\LocalLow\TeamSoda\Escape From Duckov\Player.log" -Tail 50
```

### 实时监控日志(PowerShell)
```powershell
Get-Content "$env:APPDATA\..\LocalLow\TeamSoda\Escape From Duckov\Player.log" -Wait -Tail 20
```

## 📂 重要文件位置

| 文件 | 位置 |
|------|------|
| 源代码 | `SmartInjectors/` |
| 编译输出 | `SmartInjectors/bin/Release/netstandard2.1/` |
| 发布文件夹 | `ReleaseExample/SmartInjectors/` |
| 游戏 Mod 文件夹 | `E:\...\Duckov_Data\Mods\SmartInjectors/` |
| 游戏日志 | `%AppData%\..\LocalLow\TeamSoda\Escape From Duckov\Player.log` |

## 🎮 分析工具快捷键

- **F9**: 运行分析(第一次)
- **F10**: 重新运行分析

## 📚 文档导航

- `README.md` - 项目总览
- `QUICKSTART.md` - 快速开始
- `GAME_SYSTEM_ANALYSIS.md` - 游戏系统分析
- `ANALYZER_GUIDE.md` - 分析工具详细说明
- `DEVELOPMENT_SUMMARY.md` - 开发进度总结
- **本文件** - 快速参考

## 🎯 获取到 TypeID 后的计划

1. **定义常量**
```csharp
public class ItemTypeIDs
{
    public const int INJECTION_CASE = ???;  // 从日志获取
    public const int SYRINGE_HEALTH = ???;  // 从日志获取
    public const int SYRINGE_STAMINA = ???; // 从日志获取
    // ...
}
```

2. **实现监听**
```csharp
private void OnItemUsed(Item item)
{
    if (item.TypeID == ItemTypeIDs.SYRINGE_HEALTH)
    {
        Debug.Log("使用了治疗针剂!");
        // 实现自定义逻辑
    }
}
```

3. **开发核心功能**
   - 针剂使用统计
   - Injection Case 增强
   - Buff 显示和管理
   - 快捷使用功能

---

## ✨ 准备好了吗?

**→ 启动游戏 → 启用 Mod → 按 F9 → 查看日志 → 发给我!**

期待看到分析结果! 🎉
