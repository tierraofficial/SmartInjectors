# Smart Injectors - 发布说明

## 文件说明

将 `ReleaseExample/SmartInjectors` 文件夹复制到游戏安装目录下的 `Duckov_Data/Mods` 文件夹中即可使用。

## 发布前检查清单

1. ✅ 确保 `SmartInjectors.dll` 已编译并复制到此文件夹
2. ✅ `info.ini` 包含正确的 mod 信息
3. ⚠️ 需要准备 `preview.png` (256x256 像素的方形预览图)

## 编译和复制 DLL

在项目根目录运行:
```powershell
dotnet build SmartInjectors/SmartInjectors.csproj -c Release
Copy-Item SmartInjectors/bin/Release/netstandard2.1/SmartInjectors.dll ReleaseExample/SmartInjectors/
```

## 安装到游戏

```powershell
Copy-Item -Recurse ReleaseExample/SmartInjectors "E:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov_Data\Mods\"
```
