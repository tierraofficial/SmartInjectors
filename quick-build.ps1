# SmartInjectors 快速构建脚本
# 自动编译并部署到游戏,然后提示启动游戏

$ErrorActionPreference = "Stop"

Write-Host "╔════════════════════════════════════════════════════╗" -ForegroundColor Cyan
Write-Host "║     SmartInjectors - 快速构建和部署脚本             ║" -ForegroundColor Cyan
Write-Host "╚════════════════════════════════════════════════════╝" -ForegroundColor Cyan
Write-Host ""

# 进入项目目录
Set-Location -Path "$PSScriptRoot\SmartInjectors"

Write-Host "📦 正在编译 SmartInjectors Mod..." -ForegroundColor Yellow
Write-Host ""

# 编译项目(Release 模式会自动部署)
dotnet build -c Release

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "════════════════════════════════════════════════════" -ForegroundColor Green
    Write-Host "✅ 构建和部署成功完成!" -ForegroundColor Green
    Write-Host "════════════════════════════════════════════════════" -ForegroundColor Green
    Write-Host ""
    
    # 显示部署位置
    $modPath = "E:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov_Data\Mods\SmartInjectors"
    Write-Host "📁 Mod 已部署到:" -ForegroundColor Cyan
    Write-Host "   $modPath" -ForegroundColor White
    Write-Host ""
    
    # 显示文件信息
    if (Test-Path $modPath) {
        Write-Host "📋 文件列表:" -ForegroundColor Cyan
        Get-ChildItem $modPath | ForEach-Object {
            $size = if ($_.Length -lt 1KB) { "$($_.Length) B" } 
                    elseif ($_.Length -lt 1MB) { "{0:N2} KB" -f ($_.Length / 1KB) }
                    else { "{0:N2} MB" -f ($_.Length / 1MB) }
            $time = $_.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss")
            Write-Host "   ✓ $($_.Name.PadRight(25)) $($size.PadLeft(10))  ($time)" -ForegroundColor White
        }
        Write-Host ""
    }
    
    # 提示下一步操作
    Write-Host "🎮 下一步操作:" -ForegroundColor Yellow
    Write-Host "   1. 启动 Escape From Duckov" -ForegroundColor White
    Write-Host "   2. 主菜单 → Mods" -ForegroundColor White
    Write-Host "   3. 启用 Smart Injectors" -ForegroundColor White
    Write-Host "   4. 开始游戏测试!" -ForegroundColor White
    Write-Host ""
    
    # 询问是否启动游戏
    $gamePath = "E:\SteamLibrary\steamapps\common\Escape from Duckov\Duckov.exe"
    if (Test-Path $gamePath) {
        Write-Host "❓ 是否现在启动游戏? (Y/N): " -ForegroundColor Yellow -NoNewline
        $response = Read-Host
        
        if ($response -eq "Y" -or $response -eq "y") {
            Write-Host ""
            Write-Host "🚀 正在启动 Escape From Duckov..." -ForegroundColor Green
            Start-Process $gamePath
            Write-Host "✓ 游戏已启动!" -ForegroundColor Green
        } else {
            Write-Host ""
            Write-Host "👍 好的,手动启动游戏即可!" -ForegroundColor Cyan
        }
    } else {
        Write-Host "ℹ️  游戏路径: $gamePath" -ForegroundColor Cyan
    }
    
    Write-Host ""
    Write-Host "💡 提示: 修改代码后,再次运行此脚本即可快速测试!" -ForegroundColor Cyan
    
} else {
    Write-Host ""
    Write-Host "════════════════════════════════════════════════════" -ForegroundColor Red
    Write-Host "❌ 构建失败!" -ForegroundColor Red
    Write-Host "════════════════════════════════════════════════════" -ForegroundColor Red
    Write-Host ""
    Write-Host "请检查上面的错误信息并修复后重试。" -ForegroundColor Yellow
    exit 1
}

Write-Host ""
Write-Host "════════════════════════════════════════════════════" -ForegroundColor Cyan
