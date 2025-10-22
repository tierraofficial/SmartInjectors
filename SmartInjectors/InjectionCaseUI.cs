using UnityEngine;
using ItemStatsSystem;
using Duckov;

namespace SmartInjectors
{
    /// <summary>
    /// 注射器收纳包快捷使用UI
    /// 当玩家按下快捷键使用注射器收纳包时显示
    /// </summary>
    public class InjectionCaseUI
    {
        private const string LOG_PREFIX = "[SmartInjectors.UI]";
        
        // UI状态
        private bool isVisible = false;
        private Item currentInjectionCase = null;
        // 横向布局，位置在快捷栏上方并向右偏移 (避免遮挡左侧UI元素)
        // X轴: Screen.width / 2 - 100 (向右偏移300像素)
        // Y轴: Screen.height - 350 (距离底部350像素，继续往上移动)
        private Rect windowRect = new Rect(Screen.width / 2 - 100, Screen.height - 350, 800, 170);
        
        // UI样式
        private GUIStyle windowStyle;
        private GUIStyle buttonStyle;
        private GUIStyle labelStyle;
        private bool stylesInitialized = false;
        
        // 一键注射功能
        private bool showQuickInjectPrompt = false;     // 是否显示"即将全部注射..."提示
        private float promptShowTime = 0f;              // 提示显示的开始时间
        private const float PROMPT_DURATION = 5f;       // 提示持续5秒
        
        private bool showInjectionResult = false;       // 是否显示注射结果
        private string injectionResultText = "";        // 注射结果文本
        private float resultShowTime = 0f;              // 结果显示的开始时间
        private const float RESULT_DURATION = 3f;       // 结果持续3秒
        
        private bool showCooldownWarning = false;       // 是否显示CD警告
        private string cooldownWarningText = "";        // CD警告文本
        private float cooldownWarningTime = 0f;         // CD警告显示时间
        private const float COOLDOWN_WARNING_DURATION = 1.5f;  // CD警告持续1.5秒
        
        private float lastQuickInjectTime = -999f;      // 上次一键注射的时间
        private const float QUICK_INJECT_COOLDOWN = 60f; // 一键注射CD为60秒

        /// <summary>
        /// 显示针剂选择UI
        /// </summary>
        public void Show(Item injectionCase)
        {
            if (injectionCase == null)
            {
                Debug.LogWarning($"{LOG_PREFIX} 尝试显示UI但注射器收纳包为null");
                return;
            }

            if (injectionCase.TypeID != ItemTypeIDs.INJECTION_CASE)
            {
                Debug.LogWarning($"{LOG_PREFIX} 物品TypeID不是注射器收纳包: {injectionCase.TypeID}");
                return;
            }

            currentInjectionCase = injectionCase;
            isVisible = true;
            
            // 暂停游戏时间（可选）
            // Time.timeScale = 0f;
            
            Debug.Log($"{LOG_PREFIX} 显示注射器收纳包UI");
        }

        /// <summary>
        /// 隐藏UI
        /// </summary>
        public void Hide()
        {
            isVisible = false;
            currentInjectionCase = null;
            
            // 恢复游戏时间
            // Time.timeScale = 1f;
            
            Debug.Log($"{LOG_PREFIX} 隐藏注射器收纳包UI");
        }

        /// <summary>
        /// 切换UI显示状态
        /// </summary>
        public void Toggle(Item injectionCase)
        {
            if (isVisible && currentInjectionCase == injectionCase)
            {
                Hide();
            }
            else
            {
                Show(injectionCase);
            }
        }

        /// <summary>
        /// 绘制UI (在OnGUI中调用)
        /// </summary>
        public void DrawGUI()
        {
            // 绘制一键注射的提示文字（不受UI显示状态限制）
            DrawQuickInjectPrompts();
            
            if (!isVisible || currentInjectionCase == null)
                return;

            // ===== 关键: 在 OnGUI 阶段处理键盘事件，优先级高于游戏系统 =====
            // 这样可以通过 Event.Use() 消费事件，防止游戏快捷栏响应
            HandleKeyboardEventInGUI();

            // 初始化样式
            if (!stylesInitialized)
            {
                InitializeStyles();
            }

            // 绘制窗口
            windowRect = GUI.Window(12345, windowRect, DrawWindow, "注射器收纳包", windowStyle);
        }
        
        /// <summary>
        /// 绘制一键注射的各种提示文字
        /// </summary>
        private void DrawQuickInjectPrompts()
        {
            // 文字样式（居中显示在屏幕中央）
            GUIStyle centerStyle = new GUIStyle(GUI.skin.label);
            centerStyle.alignment = TextAnchor.MiddleCenter;
            centerStyle.fontSize = 24;
            centerStyle.fontStyle = FontStyle.Bold;
            centerStyle.normal.textColor = Color.white;
            
            // 添加文字阴影效果
            GUIStyle shadowStyle = new GUIStyle(centerStyle);
            shadowStyle.normal.textColor = Color.black;
            
            // 1. "即将全部注射..."提示
            if (showQuickInjectPrompt)
            {
                float centerX = Screen.width / 2f;
                float centerY = Screen.height / 2f;
                string text = "即将全部注射...";
                
                // 绘制阴影
                GUI.Label(new Rect(centerX - 198, centerY - 48, 400, 100), text, shadowStyle);
                // 绘制文字
                GUI.Label(new Rect(centerX - 200, centerY - 50, 400, 100), text, centerStyle);
            }
            
            // 2. 注射结果提示
            if (showInjectionResult)
            {
                float centerX = Screen.width / 2f;
                float centerY = Screen.height / 2f;
                
                // 多行文字样式
                GUIStyle resultStyle = new GUIStyle(GUI.skin.label);
                resultStyle.alignment = TextAnchor.MiddleCenter;
                resultStyle.fontSize = 20;
                resultStyle.fontStyle = FontStyle.Bold;
                resultStyle.normal.textColor = Color.green;
                
                GUIStyle resultShadowStyle = new GUIStyle(resultStyle);
                resultShadowStyle.normal.textColor = Color.black;
                
                // 绘制阴影
                GUI.Label(new Rect(centerX - 298, centerY - 98, 600, 200), injectionResultText, resultShadowStyle);
                // 绘制文字
                GUI.Label(new Rect(centerX - 300, centerY - 100, 600, 200), injectionResultText, resultStyle);
            }
            
            // 3. CD警告
            if (showCooldownWarning)
            {
                float centerX = Screen.width / 2f;
                float centerY = Screen.height / 2f;
                
                GUIStyle warningStyle = new GUIStyle(GUI.skin.label);
                warningStyle.alignment = TextAnchor.MiddleCenter;
                warningStyle.fontSize = 22;
                warningStyle.fontStyle = FontStyle.Bold;
                warningStyle.normal.textColor = Color.red;
                
                GUIStyle warningShadowStyle = new GUIStyle(warningStyle);
                warningShadowStyle.normal.textColor = Color.black;
                
                // 绘制阴影
                GUI.Label(new Rect(centerX - 248, centerY - 48, 500, 100), cooldownWarningText, warningShadowStyle);
                // 绘制文字
                GUI.Label(new Rect(centerX - 250, centerY - 50, 500, 100), cooldownWarningText, warningStyle);
            }
        }

        private void InitializeStyles()
        {
            // 窗口样式
            windowStyle = new GUIStyle(GUI.skin.window);
            windowStyle.fontSize = 16;
            windowStyle.fontStyle = FontStyle.Bold;

            // 按钮样式
            buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 13;
            buttonStyle.padding = new RectOffset(5, 5, 5, 5);
            buttonStyle.fixedHeight = 30;

            // 标签样式 - 居中对齐，类似快捷栏
            labelStyle = new GUIStyle(GUI.skin.label);
            labelStyle.fontSize = 12;
            labelStyle.alignment = TextAnchor.UpperCenter;
            labelStyle.wordWrap = true;

            stylesInitialized = true;
        }

        private void DrawWindow(int windowID)
        {
            GUILayout.BeginVertical();

            // 检查收纳包是否有槽位
            if (currentInjectionCase.Slots == null || currentInjectionCase.Slots.Count == 0)
            {
                GUILayout.Label("注射器收纳包没有槽位!", labelStyle);
                GUILayout.EndVertical();
                GUI.DragWindow();
                return;
            }

            // 横向显示所有槽位 (1×6布局)
            GUILayout.BeginHorizontal();

            // 遍历6个槽位
            for (int i = 0; i < 6; i++)
            {
                // 开始每个槽位的垂直布局 (图标、名称、按钮垂直居中)
                GUILayout.BeginVertical(GUILayout.Width(120));
                
                // 添加顶部弹性空间，实现垂直居中
                GUILayout.FlexibleSpace();

                if (i < currentInjectionCase.Slots.Count)
                {
                    var slot = currentInjectionCase.Slots.GetSlotByIndex(i);
                    Item syringe = slot?.Content;

                    if (syringe != null)
                    {
                        // 居中显示针剂图标
                        GUILayout.BeginHorizontal();
                        GUILayout.FlexibleSpace();
                        if (syringe.Icon != null)
                        {
                            Texture2D iconTexture = syringe.Icon.texture;
                            if (iconTexture != null)
                            {
                                GUILayout.Box(iconTexture, GUILayout.Width(64), GUILayout.Height(64));
                            }
                            else
                            {
                                GUILayout.Box("", GUILayout.Width(64), GUILayout.Height(64));
                            }
                        }
                        else
                        {
                            GUILayout.Box("", GUILayout.Width(64), GUILayout.Height(64));
                        }
                        GUILayout.FlexibleSpace();
                        GUILayout.EndHorizontal();
                        
                        // 显示针剂名称和数量
                        string displayText = $"{i + 1}. {syringe.DisplayName}";
                        
                        // 如果是堆叠物品，显示数量
                        if (syringe.StackCount > 1)
                        {
                            displayText += $" x{syringe.StackCount}";
                        }
                        
                        // 如果有耐久度，显示耐久度
                        if (syringe.UseDurability && syringe.MaxDurability > 0)
                        {
                            int durabilityPercent = (int)((syringe.Durability / syringe.MaxDurability) * 100);
                            displayText += $" ({durabilityPercent}%)";
                        }
                        
                        GUILayout.Label(displayText, labelStyle);
                        GUILayout.Space(3);
                        
                        // 使用按钮
                        if (GUILayout.Button("使用", buttonStyle))
                        {
                            UseSyringe(syringe);
                        }
                    }
                    else
                    {
                        // 空槽位 - 居中显示
                        GUILayout.BeginHorizontal();
                        GUILayout.FlexibleSpace();
                        GUILayout.Box("", GUILayout.Width(64), GUILayout.Height(64));
                        GUILayout.FlexibleSpace();
                        GUILayout.EndHorizontal();
                        
                        GUILayout.Label($"{i + 1}. (空)", labelStyle);
                        GUILayout.Space(buttonStyle.fixedHeight > 0 ? buttonStyle.fixedHeight + 3 : 33);
                    }
                }
                else
                {
                    // 超出槽位数量 - 居中显示
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    GUILayout.Box("", GUILayout.Width(64), GUILayout.Height(64));
                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                    
                    GUILayout.Label($"{i + 1}. (空)", labelStyle);
                    GUILayout.Space(33);
                }
                
                // 添加底部弹性空间，实现垂直居中
                GUILayout.FlexibleSpace();

                GUILayout.EndVertical();

                // 槽位之间添加间距
                if (i < 5)
                {
                    GUILayout.Space(8);
                }
            }

            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            // 允许拖动窗口
            GUI.DragWindow();
        }

        private void UseSyringe(Item syringe)
        {
            if (syringe == null)
            {
                Debug.LogWarning($"{LOG_PREFIX} 尝试使用null针剂");
                return;
            }

            // 获取主角色
            var character = CharacterMainControl.Main;
            if (character == null)
            {
                Debug.LogError($"{LOG_PREFIX} 无法获取主角色引用");
                return;
            }

            // 检查针剂是否可使用
            if (syringe.UsageUtilities == null)
            {
                Debug.LogWarning($"{LOG_PREFIX} 针剂没有UsageUtilities组件: {syringe.DisplayName}");
                return;
            }

            if (!syringe.UsageUtilities.IsUsable(syringe, character))
            {
                Debug.LogWarning($"{LOG_PREFIX} 针剂当前不可使用: {syringe.DisplayName}");
                return;
            }

            // 使用针剂
            Debug.Log($"{LOG_PREFIX} 使用针剂: {syringe.DisplayName} (TypeID: {syringe.TypeID})");
            character.UseItem(syringe);

            // 使用后不关闭UI，允许连续使用多个针剂
            // 只有右键点击才会关闭UI
            Debug.Log($"{LOG_PREFIX} 针剂使用完成，UI保持打开状态");
        }

        /// <summary>
        /// 处理输入 (在Update中调用)
        /// </summary>
        public void HandleInput()
        {
            // 更新提示和结果的显示时间
            UpdatePromptAndResults();
            
            if (!isVisible)
                return;

            // 检测`·`键（数字1左边的波浪号键）
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                HandleQuickInjectKey();
            }

            // 鼠标右键关闭UI (使用Mouse1代替ESC，避免与游戏暂停冲突)
            if (Input.GetMouseButtonDown(1)) // 1 = 鼠标右键
            {
                Debug.Log($"{LOG_PREFIX} 鼠标右键按下，关闭UI");
                Hide(); // 右键直接关闭，不需要延迟
            }

            // 关键: 在Update中也处理数字键，使用Input.GetKeyDown()
            // 这样可以"消耗"Input状态，防止游戏系统检测到
            // 同时OnGUI中也处理Event事件
            for (int i = 0; i < 6; i++)
            {
                KeyCode key = KeyCode.Alpha1 + i;
                if (Input.GetKeyDown(key))
                {
                    Debug.Log($"{LOG_PREFIX} [Update] 检测到数字键 {i + 1}，直接使用针剂");
                    QuickUseSyringeAtSlot(i);
                    // Input.GetKeyDown()在一帧内只会返回true一次
                    // 游戏系统后续检查时会返回false
                }
            }
        }
        
        /// <summary>
        /// 在 OnGUI 中处理键盘事件 (更高优先级，可以消费事件)
        /// 必须在 OnGUI 的 KeyDown 事件类型中调用
        /// </summary>
        private void HandleKeyboardEventInGUI()
        {
            if (!isVisible)
                return;
                
            Event e = Event.current;
            
            // 只处理 KeyDown 事件
            if (e.type != EventType.KeyDown)
                return;
            
            // 数字键1-6快速使用对应槽位的针剂
            for (int i = 0; i < 6; i++)
            {
                KeyCode key = KeyCode.Alpha1 + i;
                if (e.keyCode == key)
                {
                    Debug.Log($"{LOG_PREFIX} OnGUI捕获数字键 {i + 1} (消费事件防止游戏快捷栏响应)");
                    
                    QuickUseSyringeAtSlot(i);
                    
                    // 消费此事件，防止传递到游戏的其他系统
                    e.Use();
                    return;
                }
            }
        }

        private void QuickUseSyringeAtSlot(int slotIndex)
        {
            Debug.Log($"{LOG_PREFIX} QuickUseSyringeAtSlot 被调用，槽位索引: {slotIndex}");
            
            if (currentInjectionCase == null || currentInjectionCase.Slots == null)
            {
                Debug.LogWarning($"{LOG_PREFIX} 收纳包或槽位为null，无法使用");
                return;
            }

            if (slotIndex >= currentInjectionCase.Slots.Count)
            {
                Debug.LogWarning($"{LOG_PREFIX} 槽位索引超出范围: {slotIndex} >= {currentInjectionCase.Slots.Count}");
                return;
            }

            var slot = currentInjectionCase.Slots.GetSlotByIndex(slotIndex);
            if (slot == null || slot.Content == null)
            {
                Debug.Log($"{LOG_PREFIX} 槽位 {slotIndex + 1} 为空");
                return;
            }

            Debug.Log($"{LOG_PREFIX} 准备使用槽位 {slotIndex + 1} 的针剂: {slot.Content.DisplayName}");
            UseSyringe(slot.Content);
        }
        
        // ==================== 一键注射功能 ====================
        
        /// <summary>
        /// 更新提示和结果的显示状态
        /// </summary>
        private void UpdatePromptAndResults()
        {
            // 更新"即将全部注射..."提示
            if (showQuickInjectPrompt)
            {
                if (Time.time - promptShowTime > PROMPT_DURATION)
                {
                    showQuickInjectPrompt = false;
                    Debug.Log($"{LOG_PREFIX} 一键注射提示超时消失");
                }
            }
            
            // 更新注射结果提示
            if (showInjectionResult)
            {
                if (Time.time - resultShowTime > RESULT_DURATION)
                {
                    showInjectionResult = false;
                }
            }
            
            // 更新CD警告
            if (showCooldownWarning)
            {
                if (Time.time - cooldownWarningTime > COOLDOWN_WARNING_DURATION)
                {
                    showCooldownWarning = false;
                }
            }
        }
        
        /// <summary>
        /// 处理`·`键按下
        /// </summary>
        private void HandleQuickInjectKey()
        {
            // 检查是否在CD中
            float timeSinceLastInject = Time.time - lastQuickInjectTime;
            float remainingCooldown = QUICK_INJECT_COOLDOWN - timeSinceLastInject;
            
            if (remainingCooldown > 0f)
            {
                // 在CD中，显示警告
                ShowCooldownWarning(remainingCooldown);
                return;
            }
            
            // 第一次按下：显示提示
            if (!showQuickInjectPrompt)
            {
                showQuickInjectPrompt = true;
                promptShowTime = Time.time;
                Debug.Log($"{LOG_PREFIX} 显示一键注射提示");
                return;
            }
            
            // 第二次按下：执行一键注射
            showQuickInjectPrompt = false;
            ExecuteQuickInject();
        }
        
        /// <summary>
        /// 显示CD警告
        /// </summary>
        private void ShowCooldownWarning(float remainingSeconds)
        {
            showCooldownWarning = true;
            cooldownWarningTime = Time.time;
            cooldownWarningText = $"一键注射冷却中！还有 {Mathf.CeilToInt(remainingSeconds)} 秒";
            Debug.Log($"{LOG_PREFIX} {cooldownWarningText}");
        }
        
        /// <summary>
        /// 执行智能一键注射
        /// 简化版本：按TypeID去重，每种针剂只使用一次
        /// </summary>
        private void ExecuteQuickInject()
        {
            CharacterMainControl character = CharacterMainControl.Main;
            if (character == null)
            {
                Debug.LogError($"{LOG_PREFIX} 无法获取主角色引用");
                return;
            }
            
            if (currentInjectionCase == null || currentInjectionCase.Slots == null)
            {
                Debug.LogError($"{LOG_PREFIX} 收纳包无效");
                return;
            }
            
            Debug.Log($"{LOG_PREFIX} ========== 开始执行一键注射 ==========");
            
            // TypeID去重
            System.Collections.Generic.HashSet<int> usedTypeIDs = new System.Collections.Generic.HashSet<int>();
            System.Collections.Generic.List<string> injectedNames = new System.Collections.Generic.List<string>();
            
            // 遍历6个槽位
            for (int i = 0; i < 6; i++)
            {
                if (i >= currentInjectionCase.Slots.Count)
                    break;
                    
                var slot = currentInjectionCase.Slots.GetSlotByIndex(i);
                if (slot == null || slot.Content == null)
                {
                    Debug.Log($"{LOG_PREFIX} 槽位 {i + 1} 为空");
                    continue;
                }
                
                Item syringe = slot.Content;
                
                Debug.Log($"{LOG_PREFIX} 检查槽位 {i + 1}: {syringe.DisplayName} (TypeID: {syringe.TypeID})");
                
                // ⭐ 修改判断逻辑：不再使用IsSyringe()，而是检查UsageUtilities
                // 如果物品有UsageUtilities组件且可以使用，就认为它是可注射的
                if (syringe.UsageUtilities == null)
                {
                    Debug.Log($"{LOG_PREFIX} 跳过 {syringe.DisplayName} (TypeID: {syringe.TypeID}) - 没有UsageUtilities");
                    continue;
                }
                
                // TypeID去重
                if (usedTypeIDs.Contains(syringe.TypeID))
                {
                    Debug.Log($"{LOG_PREFIX} 跳过 {syringe.DisplayName} (TypeID: {syringe.TypeID}) - TypeID重复");
                    continue;
                }
                
                // 尝试注射
                Debug.Log($"{LOG_PREFIX} 尝试注射: {syringe.DisplayName} (TypeID: {syringe.TypeID})");
                if (TryInjectSyringe(character, syringe))
                {
                    usedTypeIDs.Add(syringe.TypeID);
                    injectedNames.Add(syringe.DisplayName);
                }
            }
            
            // 显示结果
            if (injectedNames.Count > 0)
            {
                ShowInjectionResult(injectedNames);
                lastQuickInjectTime = Time.time;
                Debug.Log($"{LOG_PREFIX} 一键注射完成，共注射 {injectedNames.Count} 种针剂");
            }
            else
            {
                Debug.Log($"{LOG_PREFIX} 没有可用的针剂");
            }
        }
        
        /// <summary>
        /// 尝试注射一支针剂
        /// </summary>
        private bool TryInjectSyringe(CharacterMainControl character, Item syringe)
        {
            try
            {
                // 检查是否可用
                if (!syringe.UsageUtilities.IsUsable(syringe, character))
                {
                    Debug.LogWarning($"{LOG_PREFIX} {syringe.DisplayName} 当前不可用");
                    return false;
                }
                
                // 直接调用UsageUtilities.Use方法，它会调用所有behaviors（包括Drug等）
                syringe.UsageUtilities.Use(syringe, character);
                
                // ===== 测试模式：暂时禁用针剂消耗 =====
                // 测试完成后取消下面的注释，恢复正常消耗逻辑
                /*
                // 减少针剂数量
                if (syringe.Stackable && syringe.StackCount > 1)
                {
                    syringe.StackCount--;
                }
                else
                {
                    // 找到并移除针剂（调用Unplug方法）
                    for (int i = 0; i < currentInjectionCase.Slots.Count; i++)
                    {
                        var slot = currentInjectionCase.Slots.GetSlotByIndex(i);
                        if (slot != null && slot.Content == syringe)
                        {
                            slot.Unplug();
                            break;
                        }
                    }
                }
                */
                
                Debug.Log($"{LOG_PREFIX} 成功注射: {syringe.DisplayName} (测试模式：未消耗)");
                return true;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"{LOG_PREFIX} 注射 {syringe.DisplayName} 时出错: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// 显示注射结果
        /// </summary>
        private void ShowInjectionResult(System.Collections.Generic.List<string> injectedNames)
        {
            showInjectionResult = true;
            resultShowTime = Time.time;
            
            // 构建结果文本
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("已注射:");
            foreach (string name in injectedNames)
            {
                sb.AppendLine($"• {name}");
            }
            
            injectionResultText = sb.ToString();
        }

        /// <summary>
        /// UI是否正在显示
        /// </summary>
        public bool IsVisible => isVisible;
    }
}
