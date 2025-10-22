# SmartInjectors 构建脚本
Write-Host '正在编译 SmartInjectors...' -ForegroundColor Green
dotnet build SmartInjectors/SmartInjectors.csproj -c Release

if ($LASTEXITCODE -eq 0) {
    Write-Host '编译成功! 正在复制 DLL...' -ForegroundColor Green
    Copy-Item SmartInjectors/bin/Release/netstandard2.1/SmartInjectors.dll ReleaseExample/SmartInjectors/ -Force
    Write-Host 'DLL 已复制到 ReleaseExample/SmartInjectors/' -ForegroundColor Green
    Write-Host ''
    Write-Host '要安装到游戏，请运行:' -ForegroundColor Yellow
    Write-Host 'Copy-Item -Recurse ReleaseExample/SmartInjectors \"E:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov_Data\Mods\"' -ForegroundColor Cyan
} else {
    Write-Host '编译失败!' -ForegroundColor Red
}
