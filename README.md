# Smart Injectors

一个为《Escape From Duckov》开发的智能注射器 Mod。

## 开发环境

- .NET SDK 8.0.414
- 目标框架: netstandard2.1
- 游戏路径: E:\SteamLibrary\steamapps\common\Escape from Duckov

## 项目结构

```
SmartInjectors/
├── SmartInjectors/              # C# 项目文件夹
│   ├── SmartInjectors.csproj    # 项目配置文件
│   └── ModBehaviour.cs          # Mod 主类
├── ReleaseExample/              # 发布文件夹
│   └── SmartInjectors/          # Mod 发布结构
│       ├── info.ini             # Mod 信息配置
│       └── preview.png          # 预览图 (待添加)
└── README.md                    # 本文件

## 开发步骤

### ⚡ 自动化开发流程

项目已配置**自动部署**功能,编译后自动完成所有部署步骤!

#### 1. 编译项目(自动部署)

```powershell
cd SmartInjectors
dotnet build -c Release
```

**自动执行:**
- ✅ 编译生成 `SmartInjectors.dll`
- ✅ 复制 DLL 到 `ReleaseExample/SmartInjectors/`
- ✅ 部署整个 Mod 到游戏目录: `E:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov_Data\Mods\SmartInjectors`

#### 2. 启动游戏测试

直接启动游戏,在主菜单的 Mods 界面中即可看到并启用 Smart Injectors Mod!

### 📝 开发调试模式

```powershell
cd SmartInjectors
dotnet build  # Debug 模式编译(不自动部署)
```

需要手动部署时:
```powershell
dotnet build -c Release  # 自动部署到游戏
```

## 待办事项

- [ ] 添加 preview.png (256x256 像素)
- [ ] 实现核心功能逻辑
- [ ] 测试 Mod 加载和运行
- [ ] 准备发布到 Steam Workshop

## 参考文档

详细的 Mod 开发指南请参阅 `README_EN.md`。
