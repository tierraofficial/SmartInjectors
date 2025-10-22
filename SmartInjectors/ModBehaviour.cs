using UnityEngine;
using Duckov.Modding;

namespace SmartInjectors
{
    /// <summary>
    /// SmartInjectors Mod 主类
    /// 继承自 Duckov.Modding.ModBehaviour
    /// 
    /// 开发提示: 
    /// - 每次编译 Release 版本后会自动部署到游戏 Mods 文件夹
    /// - 使用 Debug.Log() 输出日志,可在游戏日志文件中查看
    /// - 修改代码后编译即可在游戏中测试
    /// </summary>
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        private const string LOG_PREFIX = "[SmartInjectors]";
        
        // Unity 事件: 当脚本实例被加载时调用
        private void Awake()
        {
            Debug.Log($"{LOG_PREFIX} ==========================================");
            Debug.Log($"{LOG_PREFIX} Smart Injectors Mod 正在加载...");
            Debug.Log($"{LOG_PREFIX} Version: 1.0.0");
            Debug.Log($"{LOG_PREFIX} ==========================================");
        }

        // Unity 事件: 在第一帧更新之前调用
        private void Start()
        {
            Debug.Log($"{LOG_PREFIX} Mod 启动成功!");
            Debug.Log($"{LOG_PREFIX} 自动部署功能已启用,修改代码后编译即可测试");
            
            // TODO: 在这里初始化您的 Mod 功能
            // 例如:
            // - 注册游戏事件
            // - 添加自定义物品
            // - 修改游戏机制
            
            InitializeMod();
        }

        /// <summary>
        /// 初始化 Mod 功能
        /// </summary>
        private void InitializeMod()
        {
            Debug.Log($"{LOG_PREFIX} 开始初始化 Smart Injectors 功能...");
            
            // 在这里添加您的初始化代码
            
            Debug.Log($"{LOG_PREFIX} 初始化完成!");
        }

        // Unity 事件: 每帧调用一次
        private void Update()
        {
            // 在这里实现需要每帧更新的逻辑
            // 注意: Update 每帧都会调用,避免在这里执行耗时操作
        }

        // 当 Mod 被禁用时调用
        private void OnDisable()
        {
            Debug.Log($"{LOG_PREFIX} Mod 被禁用");
            // 清理资源
        }

        // 当 Mod 被销毁时调用
        private void OnDestroy()
        {
            Debug.Log($"{LOG_PREFIX} Mod 被卸载,清理资源...");
            // 清理资源
            // 例如:
            // - 取消注册事件
            // - 移除自定义物品
            // - 恢复游戏原始状态
        }
    }
}
