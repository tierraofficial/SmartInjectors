# SmartInjectors Mod - 快速开始

## ✅ 环境配置完成

您的 SmartInjectors mod 开发环境已经配置完成!

## 📁 项目结构

```
SmartInjectors/
├── SmartInjectors/              # C# 源代码
│   ├── SmartInjectors.csproj    # 项目配置(已配置 Duckov DLL 引用)
│   └── ModBehaviour.cs          # Mod 主类
├── ReleaseExample/              # Mod 发布文件夹
│   └── SmartInjectors/          
│       ├── SmartInjectors.dll   # ✅ 已编译
│       └── info.ini             # ✅ Mod 信息
├── .vscode/tasks.json           # VSCode 构建任务
├── build.ps1                    # 构建脚本
└── README.md                    # 说明文档
```

## 🚀 开发流程

### ⚡ 快速开发 (推荐)

1. **编写代码**: 编辑 `SmartInjectors/ModBehaviour.cs`
2. **编译测试**: 
```powershell
cd SmartInjectors
dotnet build -c Release
```

✨ **就这么简单!** 编译完成后会自动:
- ✅ 复制 DLL 到 `ReleaseExample/SmartInjectors/`
- ✅ 部署整个 Mod 文件夹到游戏目录
- ✅ 现在可以直接启动游戏测试!

### 📋 详细步骤说明

**自动部署流程** (已配置在 .csproj 中):

1. **编译** → 生成 `SmartInjectors.dll`
2. **复制** → DLL 复制到 `ReleaseExample/SmartInjectors/`
3. **部署** → 整个文件夹复制到 `E:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov_Data\Mods\SmartInjectors`

### 🎮 VSCode 快捷方式

- 按 `Ctrl+Shift+B` → 选择 `build-release` → 自动编译和部署
- 按 `F5` → 启动调试 (如果已配置)

## ⚠️ 待完成项

1. **添加预览图片**: 创建一个 256x256 像素的 `preview.png` 并放入 `ReleaseExample/SmartInjectors/` 文件夹

2. **实现核心功能**: 在 `ModBehaviour.cs` 中编写您的 mod 逻辑

3. **测试**: 启动游戏,在主菜单的 Mods 界面加载 SmartInjectors

## 📚 可用的 API

根据文档,您可以使用:

- **Unity 生命周期**: `Awake()`, `Start()`, `Update()`, `OnDestroy()` 等
- **自定义物品**: `ItemStatsSystem.ItemAssetsCollection.AddDynamicEntry()`
- **本地化**: `SodaCraft.Localizations.LocalizationManager.SetOverrideText()`
- **Duckov 事件**: 注册游戏内的各种事件

## 🐛 调试

使用 `Debug.Log()` 输出日志,日志文件位于游戏安装目录的日志文件中。

## 📝 修改 Mod 信息

编辑 `ReleaseExample/SmartInjectors/info.ini`:
- `name`: 必须是 `SmartInjectors`(用于加载 DLL)
- `displayName`: 游戏中显示的名称
- `description`: Mod 描述

## 🎉 开始开发吧!

现在您可以开始开发您的 SmartInjectors mod 了!
