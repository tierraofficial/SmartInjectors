# 自动部署配置说明

## ✨ 功能

SmartInjectors 项目已配置**自动部署**功能。每次 Release 模式编译后,会自动:

1. ✅ 复制 DLL 到发布文件夹
2. ✅ 部署完整 Mod 到游戏目录
3. ✅ 可直接启动游戏测试

## 🔧 配置位置

自动部署配置在 `SmartInjectors/SmartInjectors.csproj` 文件中:

```xml
<!-- 编译后自动部署到游戏 Mods 文件夹 -->
<Target Name="PostBuildDeploy" AfterTargets="PostBuildEvent">
  <!-- 自动复制和部署逻辑 -->
</Target>
```

## 📋 工作流程

```
编写代码
   ↓
dotnet build -c Release
   ↓
编译 SmartInjectors.dll
   ↓
[自动] 复制 DLL → ReleaseExample/SmartInjectors/
   ↓
[自动] 部署 Mod → 游戏/Duckov_Data/Mods/SmartInjectors/
   ↓
启动游戏测试
```

## 🎮 使用方法

### 方法 1: 命令行

```powershell
cd SmartInjectors
dotnet build -c Release
```

### 方法 2: VSCode

1. 按 `Ctrl+Shift+B`
2. 选择 `build-release`
3. 完成!

### 方法 3: Visual Studio

1. 右键项目 → 生成
2. 或按 `Ctrl+Shift+B`

## 📁 部署位置

- **源文件**: `SmartInjectors/bin/Release/netstandard2.1/SmartInjectors.dll`
- **中间**: `ReleaseExample/SmartInjectors/SmartInjectors.dll`
- **游戏**: `E:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov_Data\Mods\SmartInjectors/`

## 🔍 验证部署

检查游戏 Mods 文件夹:

```powershell
Get-ChildItem "E:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov_Data\Mods\SmartInjectors"
```

应该看到:
- ✅ SmartInjectors.dll
- ✅ info.ini
- ⚠️ preview.png (待添加)

## ⚙️ 自定义配置

如果游戏安装在不同位置,修改 `SmartInjectors.csproj` 中的路径:

```xml
<PropertyGroup>
  <DuckovGamePath>您的游戏路径</DuckovGamePath>
</PropertyGroup>
```

## 🐛 问题排查

### 部署失败?

1. **检查游戏路径**: 确认 `E:\SteamLibrary\steamapps\common\Escape from Duckov` 存在
2. **检查权限**: 确保有写入 Mods 文件夹的权限
3. **手动部署**: 如果自动部署失败,可以手动复制 `ReleaseExample/SmartInjectors` 文件夹

### 只想编译不部署?

使用 Debug 模式:
```powershell
dotnet build  # 不会触发自动部署
```

### 查看详细日志

编译时会显示部署步骤:
```
==========================================
开始部署 SmartInjectors Mod...
==========================================
1. 复制 DLL 到发布文件夹...
   ✓ SmartInjectors.dll -> ReleaseExample/SmartInjectors
2. 部署 Mod 到游戏目录...
   ✓ Mod 已部署到: E:\...\Mods\SmartInjectors
==========================================
✓ SmartInjectors Mod 部署完成!
现在可以启动游戏进行测试了!
==========================================
```

## 💡 提示

- **快速迭代**: 修改代码 → `dotnet build -c Release` → 启动游戏
- **版本控制**: `ReleaseExample` 文件夹包含最新的可发布版本
- **Steam Workshop**: 发布前从 `ReleaseExample/SmartInjectors` 打包
