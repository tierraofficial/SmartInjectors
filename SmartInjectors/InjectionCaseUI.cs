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
        // Y轴: Screen.height - 300 (距离底部300像素，往上移动)
        private Rect windowRect = new Rect(Screen.width / 2 - 100, Screen.height - 300, 800, 170);
        
        // UI样式
        private GUIStyle windowStyle;
        private GUIStyle buttonStyle;
        private GUIStyle labelStyle;
        private bool stylesInitialized = false;

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
            if (!isVisible)
                return;

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

        /// <summary>
        /// UI是否正在显示
        /// </summary>
        public bool IsVisible => isVisible;
    }
}
