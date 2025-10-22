using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Cysharp.Threading.Tasks;
using Duckov.Utilities;
using Duckov.Utilities.Updatables;
using ItemStatsSystem;
using ItemStatsSystem.Items;
using ItemStatsSystem.Stats;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using SodaCraft.Localizations;
using UnityEngine;
using UnityEngine.SceneManagement;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyVersion("0.0.0.0")]
public class ItemGraphicInfo : MonoBehaviour
{
	[Serializable]
	public struct ItemGraphicSocket
	{
		public Transform socketPoint;

		public GameObject showIfPluged;

		public GameObject hideIfPluged;
	}

	[SerializeField]
	private List<ItemGraphicSocket> sockets;

	public Dictionary<string, ItemGraphicSocket> socketsDictionary;

	private Item itemRefrence;

	private List<ItemGraphicInfo> subGraphics;

	public Item ItemRefrence => itemRefrence;

	public static ItemGraphicInfo CreateAGraphic(Item item, Transform parent)
	{
		if (item == null || item.ItemGraphic == null)
		{
			return null;
		}
		ItemGraphicInfo itemGraphicInfo = UnityEngine.Object.Instantiate(item.ItemGraphic);
		if (parent != null)
		{
			itemGraphicInfo.transform.SetParent(parent);
		}
		itemGraphicInfo.transform.localPosition = Vector3.zero;
		itemGraphicInfo.transform.localRotation = Quaternion.identity;
		itemGraphicInfo.transform.localScale = Vector3.one;
		itemGraphicInfo.Setup(item);
		return itemGraphicInfo;
	}

	public void Setup(Item item)
	{
		itemRefrence = item;
		subGraphics = new List<ItemGraphicInfo>();
		socketsDictionary = new Dictionary<string, ItemGraphicSocket>();
		foreach (ItemGraphicSocket socket in sockets)
		{
			socketsDictionary.Add(socket.socketPoint.name, socket);
		}
		if (!(item.Slots != null) || item.Slots.Count <= 0)
		{
			return;
		}
		foreach (Slot slot in item.Slots)
		{
			Item content = slot.Content;
			if (content == null)
			{
				continue;
			}
			string key = slot.Key;
			if (!socketsDictionary.TryGetValue(key, out var value))
			{
				continue;
			}
			ItemGraphicInfo itemGraphicInfo = CreateAGraphic(content, value.socketPoint);
			if ((bool)itemGraphicInfo)
			{
				if ((bool)value.showIfPluged)
				{
					value.showIfPluged.SetActive(value: true);
				}
				if ((bool)value.hideIfPluged)
				{
					value.hideIfPluged.SetActive(value: false);
				}
				subGraphics.Add(itemGraphicInfo);
				itemGraphicInfo.Setup(content);
			}
		}
	}
}
[CompilerGenerated]
[EditorBrowsable(EditorBrowsableState.Never)]
[GeneratedCode("Unity.MonoScriptGenerator.MonoScriptInfoGenerator", null)]
internal class UnitySourceGeneratedAssemblyMonoScriptTypes_v1
{
	private struct MonoScriptData
	{
		public byte[] FilePathsData;

		public byte[] TypesData;

		public int TotalTypes;

		public int TotalFiles;

		public bool IsEditorOnly;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static MonoScriptData Get()
	{
		return new MonoScriptData
		{
			FilePathsData = new byte[2462]
			{
				0, 0, 0, 5, 0, 0, 0, 74, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 117, 98, 80,
				114, 111, 106, 101, 99, 116, 115, 92, 73, 116,
				101, 109, 83, 121, 115, 116, 101, 109, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 65, 100, 100,
				114, 101, 115, 115, 97, 98, 108, 101, 92, 73,
				116, 101, 109, 65, 115, 115, 101, 116, 115, 67,
				111, 108, 108, 101, 99, 116, 105, 111, 110, 46,
				99, 115, 0, 0, 0, 3, 0, 0, 0, 57,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 117,
				98, 80, 114, 111, 106, 101, 99, 116, 115, 92,
				73, 116, 101, 109, 83, 121, 115, 116, 101, 109,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 65,
				103, 101, 110, 116, 92, 73, 116, 101, 109, 65,
				103, 101, 110, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 72, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 117, 98, 80, 114, 111, 106,
				101, 99, 116, 115, 92, 73, 116, 101, 109, 83,
				121, 115, 116, 101, 109, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 65, 116, 116, 114, 105, 98,
				117, 116, 101, 115, 92, 73, 116, 101, 109, 84,
				121, 112, 101, 73, 68, 65, 116, 116, 114, 105,
				98, 117, 116, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 70, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 117, 98, 80, 114, 111, 106,
				101, 99, 116, 115, 92, 73, 116, 101, 109, 83,
				121, 115, 116, 101, 109, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 65, 116, 116, 114, 105, 98,
				117, 116, 101, 115, 92, 77, 101, 110, 117, 80,
				97, 116, 104, 65, 116, 116, 114, 105, 98, 117,
				116, 101, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 61, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 117, 98, 80, 114, 111, 106, 101, 99,
				116, 115, 92, 73, 116, 101, 109, 83, 121, 115,
				116, 101, 109, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 66, 97, 115, 101, 115, 92, 73, 116,
				101, 109, 67, 111, 109, 112, 111, 110, 101, 110,
				116, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 74, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 117, 98, 80, 114, 111, 106, 101, 99, 116,
				115, 92, 73, 116, 101, 109, 83, 121, 115, 116,
				101, 109, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 69, 102, 102, 101, 99, 116, 92, 65, 99,
				116, 105, 111, 110, 115, 92, 76, 111, 103, 73,
				116, 101, 109, 78, 97, 109, 101, 65, 99, 116,
				105, 111, 110, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 67, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 117, 98, 80, 114, 111, 106, 101,
				99, 116, 115, 92, 73, 116, 101, 109, 83, 121,
				115, 116, 101, 109, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 69, 102, 102, 101, 99, 116, 92,
				66, 97, 115, 101, 115, 92, 69, 102, 102, 101,
				99, 116, 65, 99, 116, 105, 111, 110, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 70, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 117, 98,
				80, 114, 111, 106, 101, 99, 116, 115, 92, 73,
				116, 101, 109, 83, 121, 115, 116, 101, 109, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 69, 102,
				102, 101, 99, 116, 92, 66, 97, 115, 101, 115,
				92, 69, 102, 102, 101, 99, 116, 67, 111, 109,
				112, 111, 110, 101, 110, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 67, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 117, 98, 80, 114,
				111, 106, 101, 99, 116, 115, 92, 73, 116, 101,
				109, 83, 121, 115, 116, 101, 109, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 69, 102, 102, 101,
				99, 116, 92, 66, 97, 115, 101, 115, 92, 69,
				102, 102, 101, 99, 116, 70, 105, 108, 116, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 68, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 117, 98, 80, 114, 111, 106, 101, 99, 116,
				115, 92, 73, 116, 101, 109, 83, 121, 115, 116,
				101, 109, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 69, 102, 102, 101, 99, 116, 92, 66, 97,
				115, 101, 115, 92, 69, 102, 102, 101, 99, 116,
				84, 114, 105, 103, 103, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 55, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 117, 98, 80,
				114, 111, 106, 101, 99, 116, 115, 92, 73, 116,
				101, 109, 83, 121, 115, 116, 101, 109, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 69, 102, 102,
				101, 99, 116, 92, 69, 102, 102, 101, 99, 116,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				74, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				117, 98, 80, 114, 111, 106, 101, 99, 116, 115,
				92, 73, 116, 101, 109, 83, 121, 115, 116, 101,
				109, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				69, 102, 102, 101, 99, 116, 92, 69, 102, 102,
				101, 99, 116, 84, 114, 105, 103, 103, 101, 114,
				69, 118, 101, 110, 116, 67, 111, 110, 116, 101,
				120, 116, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 67, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 117, 98, 80, 114, 111, 106, 101, 99,
				116, 115, 92, 73, 116, 101, 109, 83, 121, 115,
				116, 101, 109, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 69, 102, 102, 101, 99, 116, 92, 70,
				105, 108, 116, 101, 114, 115, 92, 66, 111, 111,
				108, 70, 105, 108, 116, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 82, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 117, 98, 80,
				114, 111, 106, 101, 99, 116, 115, 92, 73, 116,
				101, 109, 83, 121, 115, 116, 101, 109, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 69, 102, 102,
				101, 99, 116, 92, 70, 105, 108, 116, 101, 114,
				115, 92, 73, 116, 101, 109, 73, 110, 67, 104,
				97, 114, 97, 99, 116, 101, 114, 83, 108, 111,
				116, 70, 105, 108, 116, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 73, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 117, 98, 80,
				114, 111, 106, 101, 99, 116, 115, 92, 73, 116,
				101, 109, 83, 121, 115, 116, 101, 109, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 69, 102, 102,
				101, 99, 116, 92, 84, 114, 105, 103, 103, 101,
				114, 115, 92, 73, 116, 101, 109, 85, 115, 101,
				100, 84, 114, 105, 103, 103, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 82, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 117, 98,
				80, 114, 111, 106, 101, 99, 116, 115, 92, 73,
				116, 101, 109, 83, 121, 115, 116, 101, 109, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 69, 102,
				102, 101, 99, 116, 92, 84, 114, 105, 103, 103,
				101, 114, 115, 92, 79, 110, 73, 116, 101, 109,
				84, 114, 101, 101, 67, 104, 97, 110, 103, 101,
				100, 84, 114, 105, 103, 103, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 69, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 117, 98,
				80, 114, 111, 106, 101, 99, 116, 115, 92, 73,
				116, 101, 109, 83, 121, 115, 116, 101, 109, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 69, 102,
				102, 101, 99, 116, 92, 84, 114, 105, 103, 103,
				101, 114, 115, 92, 84, 105, 99, 107, 84, 114,
				105, 103, 103, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 74, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 117, 98, 80, 114, 111,
				106, 101, 99, 116, 115, 92, 73, 116, 101, 109,
				83, 121, 115, 116, 101, 109, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 69, 102, 102, 101, 99,
				116, 92, 84, 114, 105, 103, 103, 101, 114, 115,
				92, 84, 114, 105, 103, 103, 101, 114, 79, 110,
				83, 101, 116, 73, 116, 101, 109, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 71, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 117, 98, 80,
				114, 111, 106, 101, 99, 116, 115, 92, 73, 116,
				101, 109, 83, 121, 115, 116, 101, 109, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 69, 102, 102,
				101, 99, 116, 92, 84, 114, 105, 103, 103, 101,
				114, 115, 92, 85, 112, 100, 97, 116, 101, 84,
				114, 105, 103, 103, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 61, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 117, 98, 80, 114,
				111, 106, 101, 99, 116, 115, 92, 73, 116, 101,
				109, 83, 121, 115, 116, 101, 109, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 73, 110, 118, 101,
				110, 116, 111, 114, 121, 92, 73, 110, 118, 101,
				110, 116, 111, 114, 121, 46, 99, 115, 0, 0,
				0, 2, 0, 0, 0, 67, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 117, 98, 80, 114, 111,
				106, 101, 99, 116, 115, 92, 73, 116, 101, 109,
				83, 121, 115, 116, 101, 109, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 73, 116, 101, 109, 71,
				114, 97, 112, 104, 92, 73, 116, 101, 109, 71,
				114, 97, 112, 104, 105, 99, 73, 110, 102, 111,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				52, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				117, 98, 80, 114, 111, 106, 101, 99, 116, 115,
				92, 73, 116, 101, 109, 83, 121, 115, 116, 101,
				109, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				73, 116, 101, 109, 115, 92, 73, 116, 101, 109,
				46, 99, 115, 0, 0, 0, 7, 0, 0, 0,
				66, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				117, 98, 80, 114, 111, 106, 101, 99, 116, 115,
				92, 73, 116, 101, 109, 83, 121, 115, 116, 101,
				109, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				73, 116, 101, 109, 115, 92, 73, 116, 101, 109,
				84, 114, 101, 101, 69, 120, 116, 101, 110, 115,
				105, 111, 110, 115, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 52, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 117, 98, 80, 114, 111, 106,
				101, 99, 116, 115, 92, 73, 116, 101, 109, 83,
				121, 115, 116, 101, 109, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 73, 116, 101, 109, 115, 92,
				83, 108, 111, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 62, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 117, 98, 80, 114, 111, 106,
				101, 99, 116, 115, 92, 73, 116, 101, 109, 83,
				121, 115, 116, 101, 109, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 73, 116, 101, 109, 115, 92,
				83, 108, 111, 116, 67, 111, 108, 108, 101, 99,
				116, 105, 111, 110, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 56, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 117, 98, 80, 114, 111, 106,
				101, 99, 116, 115, 92, 73, 116, 101, 109, 83,
				121, 115, 116, 101, 109, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 116, 97, 116, 115, 92,
				77, 111, 100, 105, 102, 105, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 67, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 117, 98,
				80, 114, 111, 106, 101, 99, 116, 115, 92, 73,
				116, 101, 109, 83, 121, 115, 116, 101, 109, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 83, 116,
				97, 116, 115, 92, 77, 111, 100, 105, 102, 105,
				101, 114, 68, 101, 115, 99, 114, 105, 112, 116,
				105, 111, 110, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 77, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 117, 98, 80, 114, 111, 106, 101,
				99, 116, 115, 92, 73, 116, 101, 109, 83, 121,
				115, 116, 101, 109, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 83, 116, 97, 116, 115, 92, 77,
				111, 100, 105, 102, 105, 101, 114, 68, 101, 115,
				99, 114, 105, 112, 116, 105, 111, 110, 67, 111,
				108, 108, 101, 99, 116, 105, 111, 110, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 52, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 117, 98,
				80, 114, 111, 106, 101, 99, 116, 115, 92, 73,
				116, 101, 109, 83, 121, 115, 116, 101, 109, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 83, 116,
				97, 116, 115, 92, 83, 116, 97, 116, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 62, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 117, 98,
				80, 114, 111, 106, 101, 99, 116, 115, 92, 73,
				116, 101, 109, 83, 121, 115, 116, 101, 109, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 83, 116,
				97, 116, 115, 92, 83, 116, 97, 116, 67, 111,
				108, 108, 101, 99, 116, 105, 111, 110, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 74, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 117, 98,
				80, 114, 111, 106, 101, 99, 116, 115, 92, 73,
				116, 101, 109, 83, 121, 115, 116, 101, 109, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 85, 115,
				97, 103, 101, 92, 85, 115, 97, 103, 101, 66,
				101, 104, 97, 105, 118, 111, 114, 115, 92, 76,
				111, 103, 87, 104, 101, 110, 85, 115, 101, 100,
				46, 99, 115, 0, 0, 0, 2, 0, 0, 0,
				61, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				117, 98, 80, 114, 111, 106, 101, 99, 116, 115,
				92, 73, 116, 101, 109, 83, 121, 115, 116, 101,
				109, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				85, 115, 97, 103, 101, 92, 85, 115, 97, 103,
				101, 66, 101, 104, 97, 118, 105, 111, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 62,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 117,
				98, 80, 114, 111, 106, 101, 99, 116, 115, 92,
				73, 116, 101, 109, 83, 121, 115, 116, 101, 109,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 85,
				115, 97, 103, 101, 92, 85, 115, 97, 103, 101,
				85, 105, 116, 105, 108, 105, 116, 101, 115, 46,
				99, 115
			},
			TypesData = new byte[1795]
			{
				0, 0, 0, 0, 36, 73, 116, 101, 109, 83,
				116, 97, 116, 115, 83, 121, 115, 116, 101, 109,
				124, 73, 116, 101, 109, 65, 115, 115, 101, 116,
				115, 67, 111, 108, 108, 101, 99, 116, 105, 111,
				110, 0, 0, 0, 0, 42, 73, 116, 101, 109,
				83, 116, 97, 116, 115, 83, 121, 115, 116, 101,
				109, 46, 73, 116, 101, 109, 65, 115, 115, 101,
				116, 115, 67, 111, 108, 108, 101, 99, 116, 105,
				111, 110, 124, 69, 110, 116, 114, 121, 0, 0,
				0, 0, 49, 73, 116, 101, 109, 83, 116, 97,
				116, 115, 83, 121, 115, 116, 101, 109, 46, 73,
				116, 101, 109, 65, 115, 115, 101, 116, 115, 67,
				111, 108, 108, 101, 99, 116, 105, 111, 110, 124,
				68, 121, 110, 97, 109, 105, 99, 69, 110, 116,
				114, 121, 0, 0, 0, 0, 26, 73, 116, 101,
				109, 83, 116, 97, 116, 115, 83, 121, 115, 116,
				101, 109, 124, 73, 116, 101, 109, 70, 105, 108,
				116, 101, 114, 0, 0, 0, 0, 28, 73, 116,
				101, 109, 83, 116, 97, 116, 115, 83, 121, 115,
				116, 101, 109, 124, 73, 116, 101, 109, 77, 101,
				116, 97, 68, 97, 116, 97, 0, 0, 0, 0,
				25, 73, 116, 101, 109, 83, 116, 97, 116, 115,
				83, 121, 115, 116, 101, 109, 124, 73, 116, 101,
				109, 65, 103, 101, 110, 116, 0, 0, 0, 0,
				34, 73, 116, 101, 109, 83, 116, 97, 116, 115,
				83, 121, 115, 116, 101, 109, 124, 73, 116, 101,
				109, 65, 103, 101, 110, 116, 85, 116, 105, 108,
				105, 116, 105, 101, 115, 0, 0, 0, 0, 47,
				73, 116, 101, 109, 83, 116, 97, 116, 115, 83,
				121, 115, 116, 101, 109, 46, 73, 116, 101, 109,
				65, 103, 101, 110, 116, 85, 116, 105, 108, 105,
				116, 105, 101, 115, 124, 65, 103, 101, 110, 116,
				75, 101, 121, 80, 97, 105, 114, 0, 0, 0,
				0, 35, 73, 116, 101, 109, 83, 116, 97, 116,
				115, 83, 121, 115, 116, 101, 109, 124, 73, 116,
				101, 109, 84, 121, 112, 101, 73, 68, 65, 116,
				116, 114, 105, 98, 117, 116, 101, 0, 0, 0,
				0, 33, 73, 116, 101, 109, 83, 116, 97, 116,
				115, 83, 121, 115, 116, 101, 109, 124, 77, 101,
				110, 117, 80, 97, 116, 104, 65, 116, 116, 114,
				105, 98, 117, 116, 101, 0, 0, 0, 0, 29,
				73, 116, 101, 109, 83, 116, 97, 116, 115, 83,
				121, 115, 116, 101, 109, 124, 73, 116, 101, 109,
				67, 111, 109, 112, 111, 110, 101, 110, 116, 0,
				0, 0, 0, 33, 73, 116, 101, 109, 83, 116,
				97, 116, 115, 83, 121, 115, 116, 101, 109, 124,
				76, 111, 103, 73, 116, 101, 109, 78, 97, 109,
				101, 65, 99, 116, 105, 111, 110, 0, 0, 0,
				0, 28, 73, 116, 101, 109, 83, 116, 97, 116,
				115, 83, 121, 115, 116, 101, 109, 124, 69, 102,
				102, 101, 99, 116, 65, 99, 116, 105, 111, 110,
				0, 0, 0, 0, 31, 73, 116, 101, 109, 83,
				116, 97, 116, 115, 83, 121, 115, 116, 101, 109,
				124, 69, 102, 102, 101, 99, 116, 67, 111, 109,
				112, 111, 110, 101, 110, 116, 0, 0, 0, 0,
				28, 73, 116, 101, 109, 83, 116, 97, 116, 115,
				83, 121, 115, 116, 101, 109, 124, 69, 102, 102,
				101, 99, 116, 70, 105, 108, 116, 101, 114, 0,
				0, 0, 0, 29, 73, 116, 101, 109, 83, 116,
				97, 116, 115, 83, 121, 115, 116, 101, 109, 124,
				69, 102, 102, 101, 99, 116, 84, 114, 105, 103,
				103, 101, 114, 0, 0, 0, 0, 22, 73, 116,
				101, 109, 83, 116, 97, 116, 115, 83, 121, 115,
				116, 101, 109, 124, 69, 102, 102, 101, 99, 116,
				0, 0, 0, 0, 41, 73, 116, 101, 109, 83,
				116, 97, 116, 115, 83, 121, 115, 116, 101, 109,
				124, 69, 102, 102, 101, 99, 116, 84, 114, 105,
				103, 103, 101, 114, 69, 118, 101, 110, 116, 67,
				111, 110, 116, 101, 120, 116, 0, 0, 0, 0,
				26, 73, 116, 101, 109, 83, 116, 97, 116, 115,
				83, 121, 115, 116, 101, 109, 124, 66, 111, 111,
				108, 70, 105, 108, 116, 101, 114, 0, 0, 0,
				0, 41, 73, 116, 101, 109, 83, 116, 97, 116,
				115, 83, 121, 115, 116, 101, 109, 124, 73, 116,
				101, 109, 73, 110, 67, 104, 97, 114, 97, 99,
				116, 101, 114, 83, 108, 111, 116, 70, 105, 108,
				116, 101, 114, 0, 0, 0, 0, 31, 73, 116,
				101, 109, 83, 116, 97, 116, 115, 83, 121, 115,
				116, 101, 109, 124, 73, 116, 101, 109, 85, 115,
				101, 100, 84, 114, 105, 103, 103, 101, 114, 0,
				0, 0, 0, 39, 68, 117, 99, 107, 111, 118,
				46, 69, 102, 102, 101, 99, 116, 115, 124, 79,
				110, 73, 116, 101, 109, 84, 114, 101, 101, 67,
				104, 97, 110, 103, 101, 100, 84, 114, 105, 103,
				103, 101, 114, 0, 0, 0, 0, 27, 73, 116,
				101, 109, 83, 116, 97, 116, 115, 83, 121, 115,
				116, 101, 109, 124, 84, 105, 99, 107, 84, 114,
				105, 103, 103, 101, 114, 0, 0, 0, 0, 32,
				73, 116, 101, 109, 83, 116, 97, 116, 115, 83,
				121, 115, 116, 101, 109, 124, 84, 114, 105, 103,
				103, 101, 114, 79, 110, 83, 101, 116, 73, 116,
				101, 109, 0, 0, 0, 0, 29, 73, 116, 101,
				109, 83, 116, 97, 116, 115, 83, 121, 115, 116,
				101, 109, 124, 85, 112, 100, 97, 116, 101, 84,
				114, 105, 103, 103, 101, 114, 0, 0, 0, 0,
				25, 73, 116, 101, 109, 83, 116, 97, 116, 115,
				83, 121, 115, 116, 101, 109, 124, 73, 110, 118,
				101, 110, 116, 111, 114, 121, 0, 0, 0, 0,
				16, 124, 73, 116, 101, 109, 71, 114, 97, 112,
				104, 105, 99, 73, 110, 102, 111, 0, 0, 0,
				0, 33, 73, 116, 101, 109, 71, 114, 97, 112,
				104, 105, 99, 73, 110, 102, 111, 124, 73, 116,
				101, 109, 71, 114, 97, 112, 104, 105, 99, 83,
				111, 99, 107, 101, 116, 0, 0, 0, 0, 20,
				73, 116, 101, 109, 83, 116, 97, 116, 115, 83,
				121, 115, 116, 101, 109, 124, 73, 116, 101, 109,
				0, 0, 0, 0, 34, 73, 116, 101, 109, 83,
				116, 97, 116, 115, 83, 121, 115, 116, 101, 109,
				124, 73, 116, 101, 109, 84, 114, 101, 101, 69,
				120, 116, 101, 110, 115, 105, 111, 110, 115, 0,
				0, 0, 0, 33, 73, 116, 101, 109, 83, 116,
				97, 116, 115, 83, 121, 115, 116, 101, 109, 46,
				68, 97, 116, 97, 124, 73, 116, 101, 109, 84,
				114, 101, 101, 68, 97, 116, 97, 0, 0, 0,
				0, 43, 73, 116, 101, 109, 83, 116, 97, 116,
				115, 83, 121, 115, 116, 101, 109, 46, 68, 97,
				116, 97, 46, 73, 116, 101, 109, 84, 114, 101,
				101, 68, 97, 116, 97, 124, 68, 97, 116, 97,
				69, 110, 116, 114, 121, 0, 0, 0, 0, 52,
				73, 116, 101, 109, 83, 116, 97, 116, 115, 83,
				121, 115, 116, 101, 109, 46, 68, 97, 116, 97,
				46, 73, 116, 101, 109, 84, 114, 101, 101, 68,
				97, 116, 97, 124, 83, 108, 111, 116, 73, 110,
				115, 116, 97, 110, 99, 101, 73, 68, 80, 97,
				105, 114, 0, 0, 0, 0, 52, 73, 116, 101,
				109, 83, 116, 97, 116, 115, 83, 121, 115, 116,
				101, 109, 46, 68, 97, 116, 97, 46, 73, 116,
				101, 109, 84, 114, 101, 101, 68, 97, 116, 97,
				124, 73, 110, 118, 101, 110, 116, 111, 114, 121,
				68, 97, 116, 97, 69, 110, 116, 114, 121, 0,
				0, 0, 0, 34, 73, 116, 101, 109, 83, 116,
				97, 116, 115, 83, 121, 115, 116, 101, 109, 46,
				68, 97, 116, 97, 124, 73, 110, 118, 101, 110,
				116, 111, 114, 121, 68, 97, 116, 97, 0, 0,
				0, 0, 40, 73, 116, 101, 109, 83, 116, 97,
				116, 115, 83, 121, 115, 116, 101, 109, 46, 68,
				97, 116, 97, 46, 73, 110, 118, 101, 110, 116,
				111, 114, 121, 68, 97, 116, 97, 124, 69, 110,
				116, 114, 121, 0, 0, 0, 0, 26, 73, 116,
				101, 109, 83, 116, 97, 116, 115, 83, 121, 115,
				116, 101, 109, 46, 73, 116, 101, 109, 115, 124,
				83, 108, 111, 116, 0, 0, 0, 0, 36, 73,
				116, 101, 109, 83, 116, 97, 116, 115, 83, 121,
				115, 116, 101, 109, 46, 73, 116, 101, 109, 115,
				124, 83, 108, 111, 116, 67, 111, 108, 108, 101,
				99, 116, 105, 111, 110, 0, 0, 0, 0, 30,
				73, 116, 101, 109, 83, 116, 97, 116, 115, 83,
				121, 115, 116, 101, 109, 46, 83, 116, 97, 116,
				115, 124, 77, 111, 100, 105, 102, 105, 101, 114,
				0, 0, 0, 0, 35, 73, 116, 101, 109, 83,
				116, 97, 116, 115, 83, 121, 115, 116, 101, 109,
				124, 77, 111, 100, 105, 102, 105, 101, 114, 68,
				101, 115, 99, 114, 105, 112, 116, 105, 111, 110,
				0, 0, 0, 0, 45, 73, 116, 101, 109, 83,
				116, 97, 116, 115, 83, 121, 115, 116, 101, 109,
				124, 77, 111, 100, 105, 102, 105, 101, 114, 68,
				101, 115, 99, 114, 105, 112, 116, 105, 111, 110,
				67, 111, 108, 108, 101, 99, 116, 105, 111, 110,
				0, 0, 0, 0, 20, 73, 116, 101, 109, 83,
				116, 97, 116, 115, 83, 121, 115, 116, 101, 109,
				124, 83, 116, 97, 116, 0, 0, 0, 0, 30,
				73, 116, 101, 109, 83, 116, 97, 116, 115, 83,
				121, 115, 116, 101, 109, 124, 83, 116, 97, 116,
				67, 111, 108, 108, 101, 99, 116, 105, 111, 110,
				0, 0, 0, 0, 27, 73, 116, 101, 109, 83,
				116, 97, 116, 115, 83, 121, 115, 116, 101, 109,
				124, 76, 111, 103, 87, 104, 101, 110, 85, 115,
				101, 100, 0, 0, 0, 0, 29, 73, 116, 101,
				109, 83, 116, 97, 116, 115, 83, 121, 115, 116,
				101, 109, 124, 85, 115, 97, 103, 101, 66, 101,
				104, 97, 118, 105, 111, 114, 0, 0, 0, 0,
				49, 73, 116, 101, 109, 83, 116, 97, 116, 115,
				83, 121, 115, 116, 101, 109, 46, 85, 115, 97,
				103, 101, 66, 101, 104, 97, 118, 105, 111, 114,
				124, 68, 105, 115, 112, 108, 97, 121, 83, 101,
				116, 116, 105, 110, 103, 115, 68, 97, 116, 97,
				0, 0, 0, 0, 30, 73, 116, 101, 109, 83,
				116, 97, 116, 115, 83, 121, 115, 116, 101, 109,
				124, 85, 115, 97, 103, 101, 85, 116, 105, 108,
				105, 116, 105, 101, 115
			},
			TotalFiles = 33,
			TotalTypes = 47,
			IsEditorOnly = false
		};
	}
}
namespace Duckov.Effects
{
	public class OnItemTreeChangedTrigger : EffectTrigger
	{
		[SerializeField]
		private bool triggerFalseWheneverChanged = true;

		[SerializeField]
		private bool triggerInInventory;

		protected override void Awake()
		{
			base.Awake();
			base.Master.onItemTreeChanged += OnItemTreeChanged;
		}

		private void OnDestroy()
		{
			if (!(base.Master == null))
			{
				base.Master.onItemTreeChanged -= OnItemTreeChanged;
			}
		}

		private void OnItemTreeChanged(Effect effect, Item item)
		{
			Item characterItem = item.GetCharacterItem();
			if (triggerFalseWheneverChanged)
			{
				Trigger(positive: false);
			}
			if (characterItem == null)
			{
				if (!triggerFalseWheneverChanged)
				{
					Trigger(positive: false);
				}
			}
			else if (triggerInInventory)
			{
				Trigger();
			}
			else if (item.IsInCharacterSlot())
			{
				Trigger();
			}
			else if (!triggerFalseWheneverChanged)
			{
				Trigger(positive: false);
			}
		}
	}
}
namespace ItemStatsSystem
{
	[CreateAssetMenu(menuName = "Items/Item Asset Collection")]
	public class ItemAssetsCollection : ScriptableObject, ISelfValidator
	{
		[Serializable]
		public class Entry : ISelfValidator
		{
			public int typeID;

			public Item prefab;

			public ItemMetaData metaData;

			public void RefreshMetaData()
			{
			}

			public void Validate(SelfValidationResult result)
			{
			}
		}

		public class DynamicEntry
		{
			public int typeID;

			public Item prefab;

			private ItemMetaData? _metaData;

			public ItemMetaData MetaData
			{
				get
				{
					if (prefab == null)
					{
						return default(ItemMetaData);
					}
					if (!_metaData.HasValue)
					{
						_metaData = new ItemMetaData(prefab);
					}
					return _metaData.Value;
				}
			}
		}

		private static ItemAssetsCollection instanceCache;

		private bool editNextTypeID;

		[SerializeField]
		private int nextTypeID;

		public List<Entry> entries;

		private Dictionary<int, Entry> dic;

		private static Dictionary<int, DynamicEntry> dynamicDic = new Dictionary<int, DynamicEntry>();

		private static Dictionary<int, int[]> cachedSearchResults = new Dictionary<int, int[]>();

		public static ItemAssetsCollection Instance
		{
			get
			{
				if ((bool)instanceCache)
				{
					return instanceCache;
				}
				instanceCache = Resources.Load<ItemAssetsCollection>("ItemAssetsCollection");
				return instanceCache;
			}
		}

		public int NextTypeID
		{
			get
			{
				int num = entries.Max((Entry e) => e.typeID);
				if (nextTypeID <= num)
				{
					nextTypeID = num + 1;
				}
				return nextTypeID;
			}
		}

		private static bool TryGetDynamicEntry(int typeID, out DynamicEntry entry)
		{
			if (!dynamicDic.TryGetValue(typeID, out entry))
			{
				return false;
			}
			if (entry == null)
			{
				return false;
			}
			return true;
		}

		public static bool AddDynamicEntry(Item prefab)
		{
			if (prefab == null)
			{
				return false;
			}
			if (Instance == null)
			{
				return false;
			}
			int typeID = prefab.TypeID;
			if (Instance.entries.Any((Entry e) => e != null && e.typeID == typeID))
			{
				UnityEngine.Debug.LogWarning($"Warning from Dynamic Item:{typeID}\nDynamic Item Type ID collides with the main game. This will override the main game's item. Please make sure this is intentional, or avoid it.");
			}
			if (TryGetDynamicEntry(typeID, out var _))
			{
				UnityEngine.Debug.LogWarning($"Warning from Dynamic Item:{typeID}\nDynamic Item Overwrite detected! May cause some of the mod work incorrectly. Please avoid colliding item type ids.");
			}
			DynamicEntry value = new DynamicEntry
			{
				typeID = typeID,
				prefab = prefab
			};
			dynamicDic[typeID] = value;
			return true;
		}

		public static bool RemoveDynamicEntry(Item prefab)
		{
			if (prefab == null)
			{
				return false;
			}
			if (Instance == null)
			{
				return false;
			}
			int typeID = prefab.TypeID;
			if (!TryGetDynamicEntry(typeID, out var entry))
			{
				return false;
			}
			if (entry.prefab != prefab)
			{
				return false;
			}
			return dynamicDic.Remove(typeID);
		}

		private Entry GetEntry(int typeID)
		{
			if (dic == null)
			{
				dic = new Dictionary<int, Entry>();
				foreach (Entry entry in entries)
				{
					dic[entry.typeID] = entry;
				}
			}
			if (dic.TryGetValue(typeID, out var value))
			{
				return value;
			}
			return null;
		}

		public async UniTask<Item> InstantiateAsync_Local(int typeID)
		{
			if (TryGetDynamicEntry(typeID, out var entry))
			{
				return UnityEngine.Object.Instantiate(entry.prefab);
			}
			Entry entry2 = GetEntry(typeID);
			if (entry2 == null)
			{
				UnityEngine.Debug.LogWarning($"在 ItemAssetCollection 中找不到 Item ID:{typeID} 的项目。");
				return null;
			}
			if (entry2.prefab == null)
			{
				UnityEngine.Debug.LogWarning($"在 ItemAssetCollection 中未配置 Item ID:{typeID} 的 Asset。");
				return null;
			}
			return UnityEngine.Object.Instantiate(entry2.prefab);
		}

		public static async UniTask<Item> InstantiateAsync(int typeID)
		{
			if (Instance == null)
			{
				UnityEngine.Debug.LogError("Instance of ItemAssetsCollection not found");
				return null;
			}
			return await Instance.InstantiateAsync_Local(typeID);
		}

		public static Item InstantiateSync(int typeID)
		{
			if (Instance == null)
			{
				UnityEngine.Debug.LogError("Instance of ItemAssetsCollection not found");
				return null;
			}
			if (TryGetDynamicEntry(typeID, out var entry))
			{
				return UnityEngine.Object.Instantiate(entry.prefab);
			}
			Entry entry2 = Instance.GetEntry(typeID);
			if (entry2.prefab == null)
			{
				UnityEngine.Debug.LogWarning($"在 ItemAssetCollection 中未配置 Item ID:{typeID} 的 Asset。");
				return null;
			}
			return UnityEngine.Object.Instantiate(entry2.prefab);
		}

		public static ItemMetaData GetMetaData(int typeID)
		{
			if (TryGetDynamicEntry(typeID, out var entry))
			{
				return entry.MetaData;
			}
			return Instance.GetEntry(typeID)?.metaData ?? default(ItemMetaData);
		}

		public static Item GetPrefab(int typeID)
		{
			return Instance.GetEntry(typeID)?.prefab;
		}

		public void Validate(SelfValidationResult result)
		{
		}

		public void Collect()
		{
		}

		private void SetFolderTag(Item item)
		{
		}

		public void RefreshMeta()
		{
			foreach (Entry entry in entries)
			{
				entry.RefreshMetaData();
			}
		}

		public static int[] GetAllTypeIds(ItemFilter filter)
		{
			if (Instance == null)
			{
				return null;
			}
			bool matchCaliber = !string.IsNullOrEmpty(filter.caliber);
			IEnumerable<int> collection = from e in Instance.entries.FindAll(delegate(Entry entry)
				{
					ItemMetaData metaData = entry.metaData;
					return EvaluateFilter(metaData, filter);
				})
				select e.typeID;
			IEnumerable<int> range = from e in dynamicDic.Where(delegate(KeyValuePair<int, DynamicEntry> e)
				{
					DynamicEntry value = e.Value;
					return !(value.prefab == null) && EvaluateFilter(value.MetaData, filter);
				})
				select e.Key;
			HashSet<int> hashSet = new HashSet<int>(collection);
			hashSet.AddRange(range);
			return hashSet.ToArray();
			bool EvaluateFilter(ItemMetaData meta, ItemFilter itemFilter)
			{
				if (meta.quality < itemFilter.minQuality || meta.quality > itemFilter.maxQuality)
				{
					return false;
				}
				if (matchCaliber && meta.caliber != itemFilter.caliber)
				{
					return false;
				}
				if (itemFilter.requireTags != null)
				{
					Tag[] requireTags = itemFilter.requireTags;
					foreach (Tag requiredTag in requireTags)
					{
						if (!(requiredTag == null) && !meta.tags.Any((Tag tag) => tag != null && tag.Hash == requiredTag.Hash))
						{
							return false;
						}
					}
				}
				if (itemFilter.excludeTags != null)
				{
					Tag[] requireTags = itemFilter.excludeTags;
					foreach (Tag excludeTag in requireTags)
					{
						if (!(excludeTag == null) && meta.tags.Any((Tag tag) => tag != null && tag.Hash == excludeTag.Hash))
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		public static int[] Search(ItemFilter filter)
		{
			if (cachedSearchResults.TryGetValue(filter.GetHashCode(), out var value))
			{
				return value;
			}
			int[] result = GetAllTypeIds(filter);
			while (result.Length < 1)
			{
				DownGradeSearch();
				if (filter.maxQuality < 0 || filter.minQuality < 0)
				{
					break;
				}
			}
			cachedSearchResults[filter.GetHashCode()] = result;
			return result;
			void DownGradeSearch()
			{
				int num = Mathf.Min(filter.maxQuality, filter.minQuality) - 1;
				filter.maxQuality = num;
				filter.minQuality = num;
				if (num >= 0)
				{
					result = GetAllTypeIds(filter);
				}
			}
		}

		public static int TryGetIDByName(string name)
		{
			if (Instance == null)
			{
				return -1;
			}
			return Instance.entries.Find((Entry e) => e.metaData.Name == name)?.typeID ?? (-1);
		}
	}
	[Serializable]
	public struct ItemFilter
	{
		public Tag[] requireTags;

		public Tag[] excludeTags;

		public int minQuality;

		public int maxQuality;

		public string caliber;

		private static StringBuilder sb = new StringBuilder();

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override string ToString()
		{
			sb.Clear();
			sb.AppendLine("R");
			if (requireTags != null)
			{
				Tag[] array = requireTags;
				foreach (Tag tag in array)
				{
					if (!(tag == null))
					{
						sb.AppendLine(tag.name);
					}
				}
			}
			sb.AppendLine("E");
			if (excludeTags != null)
			{
				Tag[] array = excludeTags;
				foreach (Tag tag2 in array)
				{
					if (!(tag2 == null))
					{
						sb.AppendLine(tag2.name);
					}
				}
			}
			sb.AppendLine("MinQ");
			sb.AppendLine(minQuality.ToString());
			sb.AppendLine("MaxQ");
			sb.AppendLine(maxQuality.ToString());
			sb.AppendLine("CALIBER");
			sb.AppendLine(caliber);
			return sb.ToString();
		}
	}
	[Serializable]
	public struct ItemMetaData
	{
		[ItemTypeID]
		public int id;

		public int quality;

		public Tag[] tags;

		[SerializeField]
		private string name;

		[SerializeField]
		private string displayName;

		[SerializeField]
		private string description;

		public int maxStackCount;

		public int defaultStackCount;

		public Sprite icon;

		public DisplayQuality displayQuality;

		public int priceEach;

		public string caliber;

		public string Catagory
		{
			get
			{
				if (tags != null && tags.Length != 0)
				{
					return tags[0].name;
				}
				return "None";
			}
		}

		public string Name => name;

		public string DisplayNameKey => displayName;

		public string DisplayName => displayName.ToPlainText();

		public string Description => description.ToPlainText();

		public ItemMetaData(int id, int quality, Tag[] tags, string name, string displayName, Sprite icon, string caliber = "", string description = "", DisplayQuality displayQuality = DisplayQuality.None, int maxStackCount = 1, int defaultStackCount = 1, int priceEach = 0)
		{
			this.id = id;
			this.quality = quality;
			this.tags = tags;
			this.name = name;
			this.displayName = displayName;
			this.icon = icon;
			this.caliber = caliber;
			this.description = description;
			this.displayQuality = displayQuality;
			this.maxStackCount = maxStackCount;
			this.defaultStackCount = defaultStackCount;
			this.priceEach = priceEach;
		}

		public ItemMetaData(Item from)
		{
			id = from.TypeID;
			quality = from.Quality;
			tags = from.Tags.ToArray();
			name = from.name;
			displayName = from.DisplayNameRaw;
			icon = from.Icon;
			string text = from.Constants.GetString("Caliber", "");
			caliber = text;
			description = from.DescriptionRaw;
			displayQuality = from.DisplayQuality;
			maxStackCount = from.MaxStackCount;
			defaultStackCount = from.StackCount;
			priceEach = from.Value;
		}
	}
	[AddComponentMenu("ItemAgent(不要用，用DuckovItemAgent)")]
	public class ItemAgent : MonoBehaviour
	{
		public enum AgentTypes
		{
			normal,
			pickUp,
			handheld,
			equipment
		}

		private Item item;

		protected AgentTypes agentType;

		public AgentTypes AgentType => agentType;

		public Item Item => item;

		public void Initialize(Item item, AgentTypes _agentType)
		{
			this.item = item;
			agentType = _agentType;
			item.onUnpluggedFromSlot += OnUnplugedFromSlot;
			OnInitialize();
		}

		protected virtual void OnDestroy()
		{
			if (item != null)
			{
				item.onUnpluggedFromSlot -= OnUnplugedFromSlot;
			}
		}

		private void OnUnplugedFromSlot(Item item)
		{
			if (!(item == null) && item.AgentUtilities != null && !(item.AgentUtilities.ActiveAgent == null))
			{
				if (item.AgentUtilities.ActiveAgent != this)
				{
					UnityEngine.Debug.LogError("release的对象是" + item.AgentUtilities.ActiveAgent.gameObject.name + ",而调用者是" + base.gameObject.name);
				}
				item.AgentUtilities.ReleaseActiveAgent();
			}
		}

		protected virtual void OnInitialize()
		{
		}
	}
	[Serializable]
	public class ItemAgentUtilities
	{
		[Serializable]
		public class AgentKeyPair
		{
			public string key;

			public ItemAgent agentPrefab;

			private StringList avaliableKeys => StringLists.ItemAgentKeys;
		}

		private Item master;

		private ItemAgent activeAgent;

		[SerializeField]
		private List<AgentKeyPair> agents;

		private Dictionary<int, AgentKeyPair> hashedAgentsCache;

		public Item Master => master;

		public ItemAgent ActiveAgent => activeAgent;

		private Dictionary<int, AgentKeyPair> HashedAgents
		{
			get
			{
				if (hashedAgentsCache == null)
				{
					hashedAgentsCache = new Dictionary<int, AgentKeyPair>();
					foreach (AgentKeyPair agent in agents)
					{
						hashedAgentsCache.Add(agent.key.GetHashCode(), agent);
					}
				}
				return hashedAgentsCache;
			}
		}

		public ItemAgent this[int hash] => GetPrefab(hash);

		public ItemAgent this[string key] => GetPrefab(key);

		public event Action<Item, ItemAgent> onCreateAgent;

		public ItemAgent GetPrefab(int hash)
		{
			if (HashedAgents.TryGetValue(hash, out var value))
			{
				return value.agentPrefab;
			}
			return null;
		}

		public ItemAgent GetPrefab(string key)
		{
			return GetPrefab(key.GetHashCode());
		}

		public void Initialize(Item master)
		{
			this.master = master;
		}

		public ItemAgent CreateAgent(int hash, ItemAgent.AgentTypes agentType)
		{
			ItemAgent prefab = GetPrefab(hash);
			return CreateAgent(prefab, agentType);
		}

		public ItemAgent CreateAgent(ItemAgent prefab, ItemAgent.AgentTypes agentType)
		{
			if (prefab == null)
			{
				return null;
			}
			if (Master == null)
			{
				UnityEngine.Debug.Log("Create agent:" + prefab.name + " failed,master is null");
				return null;
			}
			if (ActiveAgent != null)
			{
				ReleaseActiveAgent();
				UnityEngine.Debug.Log("Creating agent:" + prefab.name + ",destrory another agent");
			}
			ItemAgent itemAgent = (activeAgent = UnityEngine.Object.Instantiate(prefab));
			itemAgent.Initialize(Master, agentType);
			this.onCreateAgent?.Invoke(Master, itemAgent);
			return itemAgent;
		}

		public void ReleaseActiveAgent()
		{
			if (!(ActiveAgent == null))
			{
				UnityEngine.Object.Destroy(ActiveAgent.gameObject);
				activeAgent = null;
			}
		}
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class ItemTypeIDAttribute : Attribute
	{
	}
	public class MenuPathAttribute : Attribute
	{
		public string path;

		public MenuPathAttribute(string path)
		{
			this.path = path;
		}
	}
	public class ItemComponent : MonoBehaviour, ISelfValidator
	{
		[SerializeField]
		private Item master;

		private bool initialized;

		public Item Master
		{
			get
			{
				return master;
			}
			internal set
			{
				master = value;
			}
		}

		private void Awake()
		{
			if (!initialized)
			{
				Initialize();
			}
			OnAwake();
		}

		protected virtual void OnAwake()
		{
		}

		internal void Initialize()
		{
			initialized = true;
			if (master == null)
			{
				master = GetComponent<Item>();
			}
			OnInitialize();
		}

		internal virtual void OnInitialize()
		{
		}

		public void Validate(SelfValidationResult result)
		{
			if (Master == null)
			{
				result.AddError("这个组件依赖Item，Item不可以留空。").WithFix("设置为本Game Object上的Item", delegate
				{
					master = GetComponent<Item>();
				});
			}
			else if (Master.gameObject != base.gameObject)
			{
				result.AddError("Master需要和本组件处于同一个Game Object上。").WithFix("设置为本Game Object上的Item", delegate
				{
					master = GetComponent<Item>();
				});
			}
		}
	}
	[MenuPath("Debug/Log Item Name")]
	public class LogItemNameAction : EffectAction
	{
		public override string DisplayName => "Log 物品名称";

		protected override void OnTriggeredPositive()
		{
			if (base.Master.Item == null)
			{
				UnityEngine.Debug.Log("物品不存在");
			}
			else
			{
				UnityEngine.Debug.Log(base.Master.Item.DisplayName);
			}
		}
	}
	[RequireComponent(typeof(Effect))]
	public class EffectAction : EffectComponent, ISelfValidator
	{
		protected override Color ActiveLabelColor => DuckovUtilitiesSettings.Colors.EffectAction;

		public override string DisplayName => "未命名动作(" + GetType().Name + ")";

		internal void NotifyTriggered(EffectTriggerEventContext context)
		{
			if (base.enabled)
			{
				OnTriggered(context.positive);
				if (context.positive)
				{
					OnTriggeredPositive();
				}
				else
				{
					OnTriggeredNegative();
				}
			}
		}

		protected virtual void OnTriggered(bool positive)
		{
		}

		protected virtual void OnTriggeredPositive()
		{
		}

		protected virtual void OnTriggeredNegative()
		{
		}

		private void OnDisable()
		{
			OnTriggeredNegative();
		}

		public override void Validate(SelfValidationResult result)
		{
			base.Validate(result);
			if (base.Master != null && !base.Master.Actions.Contains(this))
			{
				result.AddError("Master 中不包含本 Filter。").WithFix("将此 Filter 添加到 Master 中。", delegate
				{
					base.Master.AddEffectComponent(this);
				});
			}
		}
	}
	public class EffectComponent : MonoBehaviour, ISelfValidator
	{
		[SerializeField]
		private Effect master;

		private Empty label;

		public Effect Master
		{
			get
			{
				return master;
			}
			internal set
			{
				master = value;
			}
		}

		public virtual string DisplayName => GetType().Name;

		internal Color LabelColor
		{
			get
			{
				if (!base.enabled)
				{
					return Color.gray;
				}
				return ActiveLabelColor;
			}
		}

		protected virtual Color ActiveLabelColor => Color.white;

		public virtual void Validate(SelfValidationResult result)
		{
			if (master == null)
			{
				result.AddError("需要一个Master。").WithFix("将Master设为本物体上的Effect。", delegate
				{
					master = GetComponent<Effect>();
				});
			}
			else if (master.gameObject != base.gameObject)
			{
				result.AddError("Master必须处于同一Game Object上。").WithFix("将Master设为本物体上的Effect。", delegate
				{
					master = GetComponent<Effect>();
				});
			}
		}

		protected virtual void Awake()
		{
			if (Master == null)
			{
				master = GetComponent<Effect>();
			}
			if (Master == null)
			{
				UnityEngine.Debug.LogWarning("No Effect component on current game object.");
			}
		}

		private void Start()
		{
		}

		private void RemoveThisComponent()
		{
		}
	}
	[RequireComponent(typeof(Effect))]
	public class EffectFilter : EffectComponent, ISelfValidator
	{
		[SerializeField]
		private bool ignoreNegativeTrigger = true;

		protected override Color ActiveLabelColor => DuckovUtilitiesSettings.Colors.EffectFilter;

		public override string DisplayName => "未命名过滤器(" + GetType().Name + ")";

		protected bool IgnoreNegativeTrigger
		{
			get
			{
				return ignoreNegativeTrigger;
			}
			set
			{
				ignoreNegativeTrigger = value;
			}
		}

		public bool Evaluate(EffectTriggerEventContext context)
		{
			if (!base.enabled)
			{
				return true;
			}
			if (!context.positive && IgnoreNegativeTrigger)
			{
				return true;
			}
			return OnEvaluate(context);
		}

		protected virtual bool OnEvaluate(EffectTriggerEventContext context)
		{
			return true;
		}

		public override void Validate(SelfValidationResult result)
		{
			base.Validate(result);
			if (base.Master != null && !base.Master.Filters.Contains(this))
			{
				result.AddError("Master 中不包含本 Filter。").WithFix("将此 Filter 添加到 Master 中。", delegate
				{
					base.Master.AddEffectComponent(this);
				});
			}
		}
	}
	[RequireComponent(typeof(Effect))]
	public class EffectTrigger : EffectComponent, ISelfValidator
	{
		protected override Color ActiveLabelColor => DuckovUtilitiesSettings.Colors.EffectTrigger;

		public override string DisplayName => "未命名触发器(" + GetType().Name + ")";

		protected void Trigger(bool positive = true)
		{
			base.Master.Trigger(new EffectTriggerEventContext(this, positive));
		}

		protected void TriggerPositive()
		{
			Trigger();
		}

		protected void TriggerNegative()
		{
			Trigger(positive: false);
		}

		public override void Validate(SelfValidationResult result)
		{
			base.Validate(result);
			if (base.Master != null && !base.Master.Triggers.Contains(this))
			{
				result.AddError("Master 中不包含本 Filter。").WithFix("将此 Filter 添加到 Master 中。", delegate
				{
					base.Master.AddEffectComponent(this);
				});
			}
		}

		protected virtual void OnDisable()
		{
			Trigger(positive: false);
		}

		protected virtual void OnMasterSetTargetItem(Effect effect, Item item)
		{
		}

		internal void NotifySetItem(Effect effect, Item targetItem)
		{
			OnMasterSetTargetItem(effect, targetItem);
		}
	}
	public class Effect : MonoBehaviour, ISelfValidator
	{
		[SerializeField]
		private Item item;

		[SerializeField]
		private bool display;

		[SerializeField]
		private string description = "未定义描述";

		[SerializeField]
		internal List<EffectTrigger> triggers = new List<EffectTrigger>();

		[SerializeField]
		internal List<EffectFilter> filters = new List<EffectFilter>();

		[SerializeField]
		internal List<EffectAction> actions = new List<EffectAction>();

		private ReadOnlyCollection<EffectTrigger> _Triggers;

		private ReadOnlyCollection<EffectFilter> _Filters;

		private ReadOnlyCollection<EffectAction> _Actions;

		public Item Item => item;

		public bool Display => display;

		public string Description => description;

		public ReadOnlyCollection<EffectTrigger> Triggers
		{
			get
			{
				if (_Triggers == null)
				{
					_Triggers = new ReadOnlyCollection<EffectTrigger>(triggers);
				}
				return _Triggers;
			}
		}

		public ReadOnlyCollection<EffectFilter> Filters
		{
			get
			{
				if (_Filters == null)
				{
					_Filters = new ReadOnlyCollection<EffectFilter>(filters);
				}
				return _Filters;
			}
		}

		public ReadOnlyCollection<EffectAction> Actions
		{
			get
			{
				if (_Actions == null)
				{
					_Actions = new ReadOnlyCollection<EffectAction>(actions);
				}
				return _Actions;
			}
		}

		private static Color TriggerColor => DuckovUtilitiesSettings.Colors.EffectTrigger;

		private static Color FilterColor => DuckovUtilitiesSettings.Colors.EffectFilter;

		private static Color ActionColor => DuckovUtilitiesSettings.Colors.EffectAction;

		public event Action<Effect, Item> onSetTargetItem;

		public event Action<Effect, Item> onItemTreeChanged;

		public string GetDisplayString()
		{
			return Description;
		}

		private bool EvaluateFilters(EffectTriggerEventContext context)
		{
			foreach (EffectFilter filter in filters)
			{
				if (filter.enabled && !filter.Evaluate(context))
				{
					return false;
				}
			}
			return true;
		}

		internal void Trigger(EffectTriggerEventContext context)
		{
			if (!base.enabled || !base.gameObject.activeInHierarchy || !EvaluateFilters(context))
			{
				return;
			}
			foreach (EffectAction action in actions)
			{
				action.NotifyTriggered(context);
			}
		}

		private void OnValidate()
		{
			if (item == null)
			{
				item = base.transform.parent?.GetComponent<Item>();
			}
			base.transform.hideFlags = HideFlags.HideInInspector;
		}

		public void SetItem(Item targetItem)
		{
			UnregisterItemEvents();
			if (targetItem == null)
			{
				item = null;
				base.transform.SetParent(null);
			}
			item = targetItem;
			foreach (EffectTrigger trigger in triggers)
			{
				trigger.NotifySetItem(this, targetItem);
			}
			this.onSetTargetItem?.Invoke(this, targetItem);
			RegisterItemEvents();
		}

		private void RegisterItemEvents()
		{
			if (!(item == null))
			{
				item.onItemTreeChanged += OnItemTreeChanged;
			}
		}

		private void UnregisterItemEvents()
		{
			if (!(item == null))
			{
				item.onItemTreeChanged -= OnItemTreeChanged;
			}
		}

		private void OnItemTreeChanged(Item item)
		{
			this.onItemTreeChanged?.Invoke(this, this.item);
		}

		public void Validate(SelfValidationResult result)
		{
			Item item = base.transform.parent?.GetComponent<Item>();
			if (this.item != item)
			{
				result.AddError("Item 应为直接父物体").WithFix("将 Item 设为正确的值", delegate
				{
					this.item = base.transform.parent?.GetComponent<Item>();
				});
			}
			else if (this.item != null && !this.item.Effects.Contains(this))
			{
				result.AddError("Item中未引用本Effect").WithFix("在Item中加入本Effect。", delegate
				{
					this.item.Effects.Add(this);
				});
			}
			bool flag = false;
			foreach (EffectTrigger trigger in triggers)
			{
				if (!ValidateComponent(trigger))
				{
					flag = true;
				}
			}
			if (flag)
			{
				result.AddError("Trigger 列表中包含来自其他 Game Object 的 Trigger。").WithFix("移除来自其他 Game Object 的 Trigger。", delegate
				{
					triggers.RemoveAll((EffectTrigger e) => e.gameObject != base.gameObject);
				});
			}
			flag = false;
			foreach (EffectFilter filter in filters)
			{
				if (!ValidateComponent(filter))
				{
					flag = true;
				}
			}
			if (flag)
			{
				result.AddError("Filter 列表中包含来自其他 Game Object 的 Filter。").WithFix("移除来自其他 Game Object 的 Filter。", delegate
				{
					filters.RemoveAll((EffectFilter e) => e.gameObject != base.gameObject);
				});
			}
			flag = false;
			foreach (EffectAction action in actions)
			{
				if (!ValidateComponent(action))
				{
					flag = true;
				}
			}
			if (flag)
			{
				result.AddError("Trigger 列表中包含来自其他 Game Object 的 Trigger。").WithFix("移除来自其他 Game Object 的 Trigger。", delegate
				{
					actions.RemoveAll((EffectAction e) => e.gameObject != base.gameObject);
				});
			}
			if (AnyDuplicate<EffectTrigger>(triggers))
			{
				result.AddError("Trigger 列表中有重复的元素。").WithFix("移除重复元素。", delegate
				{
					triggers = new List<EffectTrigger>(triggers.Distinct());
				});
			}
			if (AnyDuplicate<EffectFilter>(filters))
			{
				result.AddError("Filter 列表中有重复的元素。").WithFix("移除重复元素。", delegate
				{
					filters = new List<EffectFilter>(filters.Distinct());
				});
			}
			if (AnyDuplicate<EffectAction>(actions))
			{
				result.AddError("Trigger 列表中有重复的元素。").WithFix("移除重复元素。", delegate
				{
					actions = new List<EffectAction>(actions.Distinct());
				});
			}
			if (AnyNull<EffectTrigger>(triggers))
			{
				result.AddError("Trigger 列表中有空元素。").WithFix("移除空元素。", delegate
				{
					triggers.RemoveAll((EffectTrigger e) => e == null);
				});
			}
			if (AnyNull<EffectFilter>(filters))
			{
				result.AddError("Filter 列表中有空元素。").WithFix("移除空元素。", delegate
				{
					filters.RemoveAll((EffectFilter e) => e == null);
				});
			}
			if (AnyNull<EffectAction>(actions))
			{
				result.AddError("Trigger 列表中有空元素。").WithFix("移除空元素。", delegate
				{
					actions.RemoveAll((EffectAction e) => e == null);
				});
			}
			if (triggers.Count < 1)
			{
				result.AddWarning("没有配置任何触发器(Trigger)，将无法触发效果。");
			}
			if (actions.Count < 1)
			{
				result.AddWarning("没有配置任何动作(Action),该效果没有任何实际作用。");
			}
			static bool AnyDuplicate<T>(List<T> list)
			{
				return (from e in list
					group e by e).Any((IGrouping<T, T> g) => g.Count() > 1);
			}
			static bool AnyNull<T>(List<T> list)
			{
				return list.Any((T e) => e == null);
			}
			bool ValidateComponent(EffectComponent component)
			{
				if (component == null)
				{
					return true;
				}
				if (component.gameObject != base.gameObject)
				{
					return false;
				}
				return true;
			}
		}

		internal void AddEffectComponent(EffectComponent effectComponent)
		{
			if (effectComponent is EffectTrigger)
			{
				triggers.Add(effectComponent as EffectTrigger);
				effectComponent.Master = this;
			}
			else if (effectComponent is EffectFilter)
			{
				filters.Add(effectComponent as EffectFilter);
				effectComponent.Master = this;
			}
			else if (effectComponent is EffectAction)
			{
				actions.Add(effectComponent as EffectAction);
				effectComponent.Master = this;
			}
		}

		private void Awake()
		{
			RegisterItemEvents();
		}
	}
	public struct EffectTriggerEventContext
	{
		public EffectTrigger source;

		public bool positive;

		public EffectTriggerEventContext(EffectTrigger source, bool positive)
		{
			this.source = source;
			this.positive = positive;
		}
	}
	[MenuPath("Debug/Bool")]
	public class BoolFilter : EffectFilter
	{
		public bool value;

		public override string DisplayName => "根据 Bool 值";

		protected override bool OnEvaluate(EffectTriggerEventContext context)
		{
			return value;
		}
	}
	public class ItemInCharacterSlotFilter : EffectFilter
	{
		protected override bool OnEvaluate(EffectTriggerEventContext context)
		{
			if (base.Master == null)
			{
				return false;
			}
			if (base.Master.Item == null)
			{
				return false;
			}
			return base.Master.Item.IsInCharacterSlot();
		}
	}
	public class ItemUsedTrigger : EffectTrigger
	{
		public override string DisplayName => "当物品被使用";

		private void OnEnable()
		{
			if (base.Master != null && base.Master.Item != null)
			{
				base.Master.Item.onUse += OnItemUsed;
			}
			else
			{
				UnityEngine.Debug.LogError("因为找不到对象，未能注册物品使用事件。");
			}
		}

		private new void OnDisable()
		{
			if (!(base.Master == null) && !(base.Master.Item == null))
			{
				base.Master.Item.onUse -= OnItemUsed;
			}
		}

		private void OnItemUsed(Item item, object user)
		{
			Trigger();
		}
	}
	public class TickTrigger : EffectTrigger, IUpdatable
	{
		[SerializeField]
		private float period = 1f;

		[SerializeField]
		private bool allowMultipleTrigger = true;

		private float buffer;

		private float _currentPeriod;

		private float _factor = 1f;

		public override string DisplayName => $"每{period}秒";

		private float Factor
		{
			get
			{
				if (period <= 0f)
				{
					return 0f;
				}
				if (_currentPeriod != period)
				{
					_factor = 1f / period;
					_currentPeriod = period;
				}
				return _factor;
			}
		}

		private void OnEnable()
		{
			UpdatableInvoker.Register(this);
		}

		private new void OnDisable()
		{
			UpdatableInvoker.Unregister(this);
		}

		private void UpdateBuffer()
		{
			buffer += Time.deltaTime * Factor;
			while (buffer > 1f)
			{
				buffer -= 1f;
				Trigger();
				if (!allowMultipleTrigger)
				{
					break;
				}
			}
		}

		public void OnUpdate()
		{
			UpdateBuffer();
		}
	}
	public class TriggerOnSetItem : EffectTrigger
	{
		protected override void OnMasterSetTargetItem(Effect effect, Item item)
		{
			Trigger();
		}
	}
	[MenuPath("General/Update")]
	public class UpdateTrigger : EffectTrigger
	{
		public override string DisplayName => "Update";

		private void Update()
		{
			Trigger();
		}
	}
	public class Inventory : MonoBehaviour, ISelfValidator, IEnumerable<Item>, IEnumerable
	{
		private bool loading;

		[LocalizationKey("Default")]
		[SerializeField]
		private string displayNameKey = "";

		private const string defaultDisplayNameKey = "UI_InventoryDefault";

		[SerializeField]
		private int defaultCapacity = 64;

		[SerializeField]
		private Item attachedToItem;

		[SerializeField]
		private List<Item> content = new List<Item>();

		[SerializeField]
		private bool needInspection;

		[SerializeField]
		private bool acceptSticky;

		private const bool TrimListWhenRemovingItem = true;

		public bool hasBeenInspectedInLootBox;

		[SerializeField]
		public List<int> lockedIndexes = new List<int>();

		private float? cachedWeight;

		public bool Loading
		{
			get
			{
				return loading;
			}
			set
			{
				loading = value;
			}
		}

		public string DisplayNameKey
		{
			get
			{
				if (string.IsNullOrWhiteSpace(displayNameKey))
				{
					return "UI_InventoryDefault";
				}
				return displayNameKey;
			}
			set
			{
				displayNameKey = value;
			}
		}

		public string DisplayName => DisplayNameKey.ToPlainText();

		public List<Item> Content => content;

		public bool AcceptSticky
		{
			get
			{
				return acceptSticky;
			}
			set
			{
				acceptSticky = value;
			}
		}

		public bool NeedInspection
		{
			get
			{
				return needInspection;
			}
			set
			{
				needInspection = value;
			}
		}

		public int Capacity => defaultCapacity;

		public Item AttachedToItem
		{
			get
			{
				return attachedToItem;
			}
			internal set
			{
				attachedToItem = value;
			}
		}

		public Item this[int index] => GetItemAt(index);

		public float CachedWeight
		{
			get
			{
				if (!cachedWeight.HasValue)
				{
					RecalculateWeight();
				}
				return cachedWeight.Value;
			}
		}

		public event Action<Inventory, int> onContentChanged;

		public event Action<Inventory> onInventorySorted;

		public event Action<Inventory> onCapacityChanged;

		public event Action<Inventory, int> onSetIndexLock;

		public void LockIndex(int index)
		{
			if (!lockedIndexes.Contains(index))
			{
				lockedIndexes.Add(index);
				this.onSetIndexLock?.Invoke(this, index);
			}
		}

		public void UnlockIndex(int index)
		{
			lockedIndexes.RemoveAll((int e) => e == index);
			this.onSetIndexLock?.Invoke(this, index);
		}

		public bool IsIndexLocked(int index)
		{
			return lockedIndexes.Contains(index);
		}

		public void ToggleLockIndex(int index)
		{
			if (IsIndexLocked(index))
			{
				UnlockIndex(index);
			}
			else
			{
				LockIndex(index);
			}
		}

		private void Start()
		{
			using IEnumerator<Item> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				Item current = enumerator.Current;
				if (!(current == null) && current.ParentItem != this)
				{
					current.NotifyAddedToInventory(this);
				}
			}
		}

		public bool IsEmpty()
		{
			foreach (Item item in content)
			{
				if (item != null)
				{
					return false;
				}
			}
			return true;
		}

		public void Sort(Comparison<Item> comparison)
		{
			content.Sort(comparison);
		}

		[ContextMenu("Sort")]
		public void Sort()
		{
			if (Loading)
			{
				return;
			}
			Loading = true;
			List<Item> list = new List<Item>();
			for (int i = 0; i < content.Count; i++)
			{
				if (!IsIndexLocked(i))
				{
					Item item = content[i];
					if (!(item == null))
					{
						item.Detach();
						list.Add(item);
					}
				}
			}
			List<IGrouping<Tag, Item>> list2 = (from item2 in list
				where item2 != null
				group item2 by GetFirstTag(item2)).ToList();
			list2.Sort(delegate(IGrouping<Tag, Item> g1, IGrouping<Tag, Item> g2)
			{
				Tag key = g1.Key;
				Tag key2 = g2.Key;
				int num = ((key != null) ? key.Priority : (-1));
				int num2 = ((key2 != null) ? key2.Priority : (-1));
				return (num != num2) ? (num - num2) : string.Compare(key.name, key2.name, StringComparison.OrdinalIgnoreCase);
			});
			List<Item> list3 = new List<Item>();
			foreach (IGrouping<Tag, Item> item4 in list2)
			{
				List<IGrouping<int, Item>> list4 = (from item2 in item4
					group item2 by item2.TypeID).ToList();
				list4.Sort(delegate(IGrouping<int, Item> a, IGrouping<int, Item> b)
				{
					Item item2 = a.First();
					Item item3 = b.First();
					return (item2.Order == item3.Order) ? (a.Key - b.Key) : (item2.Order - item3.Order);
				});
				foreach (IGrouping<int, Item> item5 in list4)
				{
					if (item5.First().Stackable && TryMerge(item5, out var result))
					{
						list3.AddRange(result);
					}
					else
					{
						list3.AddRange(item5);
					}
				}
			}
			_ = content.Count;
			foreach (Item item6 in list3)
			{
				AddItem(item6);
			}
			Loading = false;
			this.onInventorySorted?.Invoke(this);
			static Tag GetFirstTag(Item item2)
			{
				if (item2 == null)
				{
					return null;
				}
				if (item2.Tags == null || item2.Tags.Count == 0)
				{
					return null;
				}
				return item2.Tags.Get(0);
			}
		}

		private static bool TryMerge(IEnumerable<Item> itemsOfSameTypeID, out List<Item> result)
		{
			result = null;
			List<Item> list = itemsOfSameTypeID.ToList();
			list.RemoveAll((Item e) => e == null);
			if (list.Count <= 0)
			{
				return false;
			}
			int typeID = list[0].TypeID;
			foreach (Item item3 in list)
			{
				if (typeID != item3.TypeID)
				{
					UnityEngine.Debug.LogError("尝试融合的Item具有不同的TypeID,已取消");
					return false;
				}
			}
			if (!list[0].Stackable)
			{
				UnityEngine.Debug.LogError("此类物品不可堆叠，已取消");
				return false;
			}
			result = new List<Item>();
			Stack<Item> stack = new Stack<Item>(list);
			Item item = null;
			while (stack.Count > 0)
			{
				if (item == null)
				{
					item = stack.Pop();
				}
				if (stack.Count <= 0)
				{
					result.Add(item);
					break;
				}
				item.Detach();
				Item item2 = null;
				while (item.StackCount < item.MaxStackCount && stack.Count > 0)
				{
					item2 = stack.Pop();
					item2.Detach();
					item.Combine(item2);
				}
				result.Add(item);
				if (item2 != null && item2.StackCount > 0)
				{
					if (stack.Count <= 0)
					{
						result.Add(item2);
						break;
					}
					item = item2;
				}
				else
				{
					item = null;
				}
			}
			return true;
		}

		public int GetFirstEmptyPosition(int preferedFirstPosition = 0)
		{
			if (preferedFirstPosition < 0)
			{
				preferedFirstPosition = 0;
			}
			if (content.Count <= preferedFirstPosition)
			{
				return preferedFirstPosition;
			}
			for (int i = preferedFirstPosition; i < content.Count; i++)
			{
				if (content[i] == null)
				{
					return i;
				}
			}
			if (content.Count < Capacity)
			{
				return content.Count;
			}
			for (int j = 0; j < preferedFirstPosition; j++)
			{
				if (content[j] == null)
				{
					return j;
				}
			}
			return -1;
		}

		public int GetLastItemPosition()
		{
			for (int num = content.Count - 1; num >= 0; num--)
			{
				if (content[num] != null)
				{
					return num;
				}
			}
			return -1;
		}

		public bool AddAt(Item item, int atPosition)
		{
			if (item == null)
			{
				UnityEngine.Debug.LogError("尝试添加的物体为空");
				return false;
			}
			if (Capacity <= atPosition)
			{
				UnityEngine.Debug.LogError($"向 Inventory {base.name} 加入物品时位置 {atPosition} 超出最大容量 {Capacity}。");
				return false;
			}
			if (item.ParentObject != null)
			{
				UnityEngine.Debug.Log($"{item.name} \nParent: {item.ParentItem} \nInventory: {item.InInventory?.name} \nPlug: {item.PluggedIntoSlot?.DisplayName}");
				UnityEngine.Debug.LogError("正在尝试将一个有父物体的物品 " + item.DisplayName + " 放入Inventory。请先使其脱离其父物体 " + item.ParentObject.name + " 再进行此操作。");
				return false;
			}
			Item itemAt = GetItemAt(atPosition);
			if (itemAt != null)
			{
				UnityEngine.Debug.LogError($"正在尝试将物品 {item.DisplayName} 放入 Inventory {base.name} 的 {atPosition} 位置。但此位置已经存在另一物体 {itemAt.DisplayName}。");
			}
			while (content.Count <= atPosition)
			{
				content.Add(null);
			}
			content[atPosition] = item;
			item.transform.SetParent(base.transform);
			item.NotifyAddedToInventory(this);
			item.InitiateNotifyItemTreeChanged();
			RecalculateWeight();
			this.onContentChanged?.Invoke(this, atPosition);
			return true;
		}

		public bool RemoveAt(int position, out Item removedItem)
		{
			removedItem = null;
			if (Capacity <= position && position >= content.Count)
			{
				UnityEngine.Debug.LogError("位置超出Inventory容量。");
				return false;
			}
			Item itemAt = GetItemAt(position);
			if (itemAt != null)
			{
				content[position] = null;
				removedItem = itemAt;
				removedItem.NotifyRemovedFromInventory(this);
				removedItem.InitiateNotifyItemTreeChanged();
				AttachedToItem?.InitiateNotifyItemTreeChanged();
				int num = content.Count - 1;
				while (num >= 0 && content[num] == null)
				{
					content.RemoveAt(num);
					num--;
				}
				RecalculateWeight();
				this.onContentChanged?.Invoke(this, position);
				return true;
			}
			return false;
		}

		public bool AddItem(Item item)
		{
			int firstEmptyPosition = GetFirstEmptyPosition();
			if (firstEmptyPosition < 0)
			{
				UnityEngine.Debug.Log("添加物品失败，Inventory " + base.name + " 已满。");
				return false;
			}
			return AddAt(item, firstEmptyPosition);
		}

		public bool RemoveItem(Item item)
		{
			int num = content.IndexOf(item);
			if (num < 0)
			{
				UnityEngine.Debug.LogError("正在尝试从Inventory " + base.name + " 中删除 " + item.DisplayName + "，但它并不在这个Inventory中。");
				return false;
			}
			Item removedItem;
			return RemoveAt(num, out removedItem);
		}

		public Item GetItemAt(int position)
		{
			if (position >= Capacity && position >= content.Count)
			{
				UnityEngine.Debug.LogError("访问的位置超出Inventory容量。");
				return null;
			}
			if (content.Count <= position)
			{
				return null;
			}
			return content[position];
		}

		public void Validate(SelfValidationResult result)
		{
			if (AttachedToItem != null)
			{
				if (AttachedToItem.gameObject != base.gameObject)
				{
					result.AddError("AttachedItem引用了另一个Game Object上的Item。").WithFix("引用本物体上的Item。", delegate
					{
						attachedToItem = GetComponent<Item>();
					});
				}
				if (AttachedToItem.Inventory != this)
				{
					if (AttachedToItem.Inventory != null)
					{
						result.AddError("AttachedItem引用了其他的Inventory。请检查Item内的配置。");
					}
					else
					{
						result.AddError("AttachedItem没有引用此Inventory。").WithFix("使AttachedItem引用此Inventory。", delegate
						{
							AttachedToItem.Inventory = this;
						});
					}
				}
			}
			if (!(AttachedToItem == null))
			{
				return;
			}
			Item gotItem = GetComponent<Item>();
			if (gotItem != null)
			{
				result.AddError("同一GameObject上存在Item，但AttachedToItem变量留空。").WithFix("设为本物体上的Item。", delegate
				{
					attachedToItem = gotItem;
				});
			}
		}

		public IEnumerator<Item> GetEnumerator()
		{
			foreach (Item item in content)
			{
				if (!(item == null))
				{
					yield return item;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void DestroyAllContent()
		{
			for (int i = 0; i < content.Count; i++)
			{
				Item item = content[i];
				if (!(item == null))
				{
					RemoveItem(item);
					item.DestroyTree();
				}
			}
		}

		public List<Item> FindAll(Predicate<Item> match)
		{
			return content.FindAll(match);
		}

		public void RecalculateWeight()
		{
			float num = 0f;
			foreach (Item item in content)
			{
				if (!(item == null))
				{
					float num2 = item.RecalculateTotalWeight();
					num += num2;
				}
			}
			cachedWeight = num;
		}

		public void SetCapacity(int capacity)
		{
			defaultCapacity = capacity;
			this.onCapacityChanged?.Invoke(this);
		}

		public int GetItemCount()
		{
			int num = 0;
			foreach (Item item in content)
			{
				if (!(item == null))
				{
					num++;
				}
			}
			return num;
		}

		internal void NotifyContentChanged(Item item)
		{
			if ((bool)item)
			{
				this.onContentChanged?.Invoke(this, content.IndexOf(item));
			}
		}

		public int GetIndex(Item item)
		{
			if (item == null)
			{
				return -1;
			}
			return content.IndexOf(item);
		}

		public Item Find(int typeID)
		{
			return content.Find((Item e) => e != null && e.TypeID == typeID);
		}
	}
	public enum DisplayQuality
	{
		None,
		White,
		Green,
		Blue,
		Purple,
		Orange,
		Red,
		Q7,
		Q8
	}
	public class Item : MonoBehaviour, ISelfValidator
	{
		[SerializeField]
		private int typeID;

		[SerializeField]
		private int order;

		[LocalizationKey("Items")]
		[SerializeField]
		private string displayName;

		[SerializeField]
		private Sprite icon;

		[SerializeField]
		private int maxStackCount = 1;

		[SerializeField]
		private int value;

		[SerializeField]
		private int quality;

		[SerializeField]
		private DisplayQuality displayQuality;

		[SerializeField]
		private float weight;

		private float _cachedWeight;

		private float? _cachedTotalWeight;

		private int handheldHash = "Handheld".GetHashCode();

		[SerializeField]
		private TagCollection tags = new TagCollection();

		[SerializeField]
		private ItemAgentUtilities agentUtilities = new ItemAgentUtilities();

		[SerializeField]
		private ItemGraphicInfo itemGraphic;

		[SerializeField]
		private StatCollection stats;

		[SerializeField]
		private SlotCollection slots;

		[SerializeField]
		private ModifierDescriptionCollection modifiers;

		[SerializeField]
		private CustomDataCollection variables = new CustomDataCollection();

		[SerializeField]
		private CustomDataCollection constants = new CustomDataCollection();

		[SerializeField]
		private Inventory inventory;

		[SerializeField]
		private List<Effect> effects = new List<Effect>();

		[SerializeField]
		private UsageUtilities usageUtilities;

		private Slot pluggedIntoSlot;

		private Inventory inInventory;

		private bool initialized;

		private const string StackCountVariableKey = "Count";

		private static readonly int StackCountVariableHash = "Count".GetHashCode();

		private const string InspectedVariableKey = "Inspected";

		private static readonly int InspectedVariableHash = "Inspected".GetHashCode();

		private const string MaxDurabilityConstantKey = "MaxDurability";

		private const string DurabilityVariableKey = "Durability";

		private static readonly int MaxDurabilityConstantHash = "MaxDurability".GetHashCode();

		private static readonly int DurabilityVariableHash = "Durability".GetHashCode();

		private bool _inspecting;

		public string soundKey;

		private bool isBeingDestroyed;

		public int TypeID
		{
			get
			{
				return typeID;
			}
			internal set
			{
				typeID = value;
			}
		}

		public int Order
		{
			get
			{
				return order;
			}
			set
			{
				order = value;
			}
		}

		public string DisplayName => displayName.ToPlainText();

		public string DisplayNameRaw
		{
			get
			{
				return displayName;
			}
			set
			{
				displayName = value;
			}
		}

		[LocalizationKey("Items")]
		private string description
		{
			get
			{
				return displayName + "_Desc";
			}
			set
			{
			}
		}

		public string DescriptionRaw => description;

		public string Description => description.ToPlainText();

		public Sprite Icon
		{
			get
			{
				return icon;
			}
			set
			{
				icon = value;
			}
		}

		private string MaxStackCountSuffixLabel
		{
			get
			{
				if (MaxStackCount <= 1)
				{
					return "不可堆叠";
				}
				return "可堆叠";
			}
		}

		public int MaxStackCount
		{
			get
			{
				return maxStackCount;
			}
			set
			{
				maxStackCount = value;
			}
		}

		public bool Stackable => MaxStackCount > 1;

		public int Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}

		public int Quality
		{
			get
			{
				return quality;
			}
			set
			{
				quality = value;
			}
		}

		public DisplayQuality DisplayQuality
		{
			get
			{
				return displayQuality;
			}
			set
			{
				displayQuality = value;
			}
		}

		public float UnitSelfWeight => weight;

		public float SelfWeight => weight * (float)StackCount;

		public bool Sticky => Tags.Contains("Sticky");

		public bool CanBeSold
		{
			get
			{
				if (Sticky)
				{
					return false;
				}
				return !Tags.Contains("NotSellable");
			}
		}

		public bool CanDrop => !Sticky;

		public float TotalWeight
		{
			get
			{
				if (!_cachedTotalWeight.HasValue || _cachedWeight != SelfWeight)
				{
					_cachedWeight = SelfWeight;
					_cachedTotalWeight = RecalculateTotalWeight();
				}
				return _cachedTotalWeight.Value;
			}
		}

		public bool HasHandHeldAgent => AgentUtilities.GetPrefab(handheldHash) != null;

		private string TagsLabelText
		{
			get
			{
				string text = "Tags: ";
				bool flag = true;
				foreach (Tag tag in tags)
				{
					text = text + (flag ? "" : ", ") + tag.DisplayName;
					flag = false;
				}
				return text;
			}
		}

		public ItemAgentUtilities AgentUtilities => agentUtilities;

		public ItemAgent ActiveAgent => agentUtilities.ActiveAgent;

		public ItemGraphicInfo ItemGraphic => itemGraphic;

		private string StatsTabLabelText
		{
			get
			{
				if (!stats)
				{
					return "No Stats";
				}
				return $"Stats({stats.Count})";
			}
		}

		private string SlotsTabLabelText
		{
			get
			{
				if (!slots)
				{
					return "No Slots";
				}
				return $"Slots({slots.Count})";
			}
		}

		private string ModifiersTabLabelText
		{
			get
			{
				if (!modifiers)
				{
					return "No Modifiers";
				}
				return $"Modifiers({modifiers.Count})";
			}
		}

		public UsageUtilities UsageUtilities => usageUtilities;

		public float UseTime
		{
			get
			{
				if (usageUtilities != null)
				{
					return usageUtilities.UseTime;
				}
				return 0f;
			}
		}

		public StatCollection Stats => stats;

		public ModifierDescriptionCollection Modifiers => modifiers;

		public SlotCollection Slots => slots;

		public Inventory Inventory
		{
			get
			{
				return inventory;
			}
			internal set
			{
				inventory = value;
			}
		}

		public List<Effect> Effects => effects;

		public Slot PluggedIntoSlot
		{
			get
			{
				if (pluggedIntoSlot == null)
				{
					return null;
				}
				if (pluggedIntoSlot.Master == null)
				{
					return null;
				}
				return pluggedIntoSlot;
			}
		}

		public Inventory InInventory => inInventory;

		public Item ParentItem
		{
			get
			{
				UnityEngine.Object parentObject = ParentObject;
				if (parentObject == null)
				{
					return null;
				}
				Item item = ParentObject as Item;
				if (item != null)
				{
					return item;
				}
				Inventory inventory = parentObject as Inventory;
				if (inventory == null)
				{
					UnityEngine.Debug.LogError("侦测到不合法的Parent Object。需要检查ParentObject代码。");
					return null;
				}
				Item attachedToItem = inventory.AttachedToItem;
				if (attachedToItem != null)
				{
					return attachedToItem;
				}
				return null;
			}
		}

		public UnityEngine.Object ParentObject
		{
			get
			{
				if (PluggedIntoSlot != null && InInventory != null)
				{
					UnityEngine.Debug.LogError($"物品 {DisplayName} ({GetInstanceID()})同时存在于Slot和Inventory中。");
				}
				if (PluggedIntoSlot != null)
				{
					return PluggedIntoSlot?.Master;
				}
				if (InInventory != null)
				{
					return InInventory;
				}
				return null;
			}
		}

		public TagCollection Tags => tags;

		public CustomDataCollection Variables => variables;

		public CustomDataCollection Constants => constants;

		public bool IsCharacter => tags.Any((Tag e) => e != null && e.name == "Character");

		public int StackCount
		{
			get
			{
				if (Stackable)
				{
					return GetInt(StackCountVariableHash, 1);
				}
				return 1;
			}
			set
			{
				if (!Stackable)
				{
					if (value != 1)
					{
						UnityEngine.Debug.LogError("该物品 " + DisplayName + " 不可堆叠。无法设置数量。");
					}
					return;
				}
				int num = value;
				if (value >= 1 && value > MaxStackCount)
				{
					UnityEngine.Debug.LogWarning($"尝试将数量设为{value},但该物品 {DisplayName} 的数量最多为{MaxStackCount}。将改为设为{MaxStackCount}。");
					num = MaxStackCount;
				}
				SetInt("Count", num);
				this.onSetStackCount?.Invoke(this);
				NotifyChildChanged();
				if ((bool)InInventory)
				{
					InInventory.NotifyContentChanged(this);
				}
				if (StackCount < 1)
				{
					this.DestroyTree();
				}
			}
		}

		public bool UseDurability => MaxDurability > 0f;

		public float MaxDurability
		{
			get
			{
				return Constants.GetFloat(MaxDurabilityConstantHash);
			}
			set
			{
				Constants.SetFloat("MaxDurability", value);
				this.onDurabilityChanged?.Invoke(this);
			}
		}

		public float MaxDurabilityWithLoss => MaxDurability * (1f - DurabilityLoss);

		public float DurabilityLoss
		{
			get
			{
				return Mathf.Clamp01(Variables.GetFloat("DurabilityLoss"));
			}
			set
			{
				Variables.SetFloat("DurabilityLoss", value);
			}
		}

		public float Durability
		{
			get
			{
				return GetFloat(DurabilityVariableHash);
			}
			set
			{
				float num = Mathf.Min(MaxDurability, value);
				if (num < 0f)
				{
					num = 0f;
				}
				SetFloat("Durability", num);
				this.onDurabilityChanged?.Invoke(this);
				HandleEffectsActive();
			}
		}

		public bool Inspected
		{
			get
			{
				return Variables.GetBool(InspectedVariableHash);
			}
			set
			{
				Variables.SetBool("Inspected", value);
				if (slots != null)
				{
					foreach (Slot slot in slots)
					{
						if (slot != null)
						{
							Item content = slot.Content;
							if (!(content == null))
							{
								content.Inspected = value;
							}
						}
					}
				}
				this.onInspectionStateChanged?.Invoke(this);
			}
		}

		public bool Inspecting
		{
			get
			{
				return _inspecting;
			}
			set
			{
				_inspecting = value;
				this.onInspectionStateChanged?.Invoke(this);
			}
		}

		public bool NeedInspection
		{
			get
			{
				if (Inspected)
				{
					return false;
				}
				if (InInventory == null)
				{
					return false;
				}
				if (!InInventory.NeedInspection)
				{
					return false;
				}
				return true;
			}
		}

		public bool IsBeingDestroyed => isBeingDestroyed;

		public bool Repairable
		{
			get
			{
				if (!UseDurability)
				{
					return false;
				}
				return Tags.Contains("Repairable");
			}
		}

		public string SoundKey
		{
			get
			{
				if (string.IsNullOrWhiteSpace(soundKey))
				{
					return "default";
				}
				return soundKey;
			}
		}

		public event Action<Item> onItemTreeChanged;

		public event Action<Item> onDestroy;

		public event Action<Item> onSetStackCount;

		public event Action<Item> onDurabilityChanged;

		public event Action<Item> onInspectionStateChanged;

		public event Action<Item, object> onUse;

		public static event Action<Item, object> onUseStatic;

		public event Action<Item> onChildChanged;

		public event Action<Item> onParentChanged;

		public event Action<Item> onPluggedIntoSlot;

		public event Action<Item> onUnpluggedFromSlot;

		public event Action<Item, Slot> onSlotContentChanged;

		public event Action<Item> onSlotTreeChanged;

		[SerializeField]
		private void CreateStatsComponent()
		{
			(stats = base.gameObject.AddComponent<StatCollection>()).Master = this;
		}

		[SerializeField]
		public void CreateSlotsComponent()
		{
			if (slots != null)
			{
				UnityEngine.Debug.LogError("Slot component已存在");
			}
			else
			{
				(slots = base.gameObject.AddComponent<SlotCollection>()).Master = this;
			}
		}

		[SerializeField]
		public void CreateModifiersComponent()
		{
			if (modifiers == null)
			{
				ModifierDescriptionCollection modifierDescriptionCollection = base.gameObject.AddComponent<ModifierDescriptionCollection>();
				modifiers = modifierDescriptionCollection;
			}
			modifiers.Master = this;
		}

		[SerializeField]
		private void CreateInventoryComponent()
		{
			(inventory = base.gameObject.AddComponent<Inventory>()).AttachedToItem = this;
		}

		public bool IsUsable(object user)
		{
			if (usageUtilities != null)
			{
				return usageUtilities.IsUsable(this, user);
			}
			return false;
		}

		public void AddUsageUtilitiesComponent()
		{
		}

		private void Awake()
		{
			if (!initialized)
			{
				Initialize();
			}
			if ((bool)inventory)
			{
				inventory.onContentChanged += OnInventoryContentChanged;
			}
		}

		private void OnInventoryContentChanged(Inventory inventory, int index)
		{
			NotifyChildChanged();
		}

		public void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				agentUtilities.Initialize(this);
				Stats?.Initialize();
				Slots?.Initialize();
				Modifiers?.Initialize();
				modifiers?.ReapplyModifiers();
				HandleEffectsActive();
			}
		}

		public Item GetCharacterItem()
		{
			Item item = this;
			while (item != null)
			{
				if (item.IsCharacter)
				{
					return item;
				}
				item = item.ParentItem;
			}
			return null;
		}

		public bool IsInCharacterSlot()
		{
			Item item = null;
			Item item2 = this;
			if (item2.IsCharacter)
			{
				return false;
			}
			while (item2 != null)
			{
				if (item2.IsCharacter)
				{
					if (item.PluggedIntoSlot != null)
					{
						return true;
					}
					return false;
				}
				item = item2;
				item2 = item2.ParentItem;
			}
			return false;
		}

		public Item CreateInstance()
		{
			Item item = UnityEngine.Object.Instantiate(this);
			item.Initialize();
			return item;
		}

		public void Detach()
		{
			PluggedIntoSlot?.Unplug();
			InInventory?.RemoveItem(this);
		}

		internal void NotifyPluggedTo(Slot slot)
		{
			pluggedIntoSlot = slot;
			this.onPluggedIntoSlot?.Invoke(this);
			this.onParentChanged?.Invoke(this);
		}

		internal void NotifyUnpluggedFrom(Slot slot)
		{
			if (pluggedIntoSlot == slot)
			{
				pluggedIntoSlot = null;
				this.onUnpluggedFromSlot?.Invoke(this);
				this.onParentChanged?.Invoke(this);
				return;
			}
			UnityEngine.Debug.LogError("物品 " + DisplayName + " 被通知从Slot移除，但当前Slot " + ((pluggedIntoSlot != null) ? (pluggedIntoSlot.Master.DisplayName + "/" + pluggedIntoSlot.Key) : "空") + " 与通知Slot " + ((slot != null) ? (slot.Master.DisplayName + "/" + slot.Key) : "空") + " 不匹配。");
		}

		internal void NotifySlotPlugged(Slot slot)
		{
			NotifyChildChanged();
			NotifySlotTreeChanged();
			this.onSlotContentChanged?.Invoke(this, slot);
		}

		internal void NotifySlotUnplugged(Slot slot)
		{
			NotifyChildChanged();
			NotifySlotTreeChanged();
			this.onSlotContentChanged?.Invoke(this, slot);
		}

		internal void NotifyRemovedFromInventory(Inventory inventory)
		{
			if (inventory == InInventory)
			{
				inInventory = null;
				this.onParentChanged?.Invoke(this);
			}
			else if (InInventory != null)
			{
				UnityEngine.Debug.LogError("尝试从不是当前的Inventory中移除，已取消。");
			}
		}

		internal void NotifyAddedToInventory(Inventory inventory)
		{
			inInventory = inventory;
			this.onParentChanged?.Invoke(this);
		}

		internal void NotifyItemTreeChanged()
		{
			this.onItemTreeChanged?.Invoke(this);
			HandleEffectsActive();
		}

		private void HandleEffectsActive()
		{
			if (effects == null)
			{
				return;
			}
			bool active = IsCharacter || PluggedIntoSlot != null;
			if (UseDurability && Durability <= 0f)
			{
				active = false;
			}
			foreach (Effect effect in effects)
			{
				if (!(effect == null))
				{
					effect.gameObject.SetActive(active);
				}
			}
		}

		internal void InitiateNotifyItemTreeChanged()
		{
			List<Item> allConnected = this.GetAllConnected();
			if (allConnected == null)
			{
				return;
			}
			foreach (Item item in allConnected)
			{
				item.NotifyItemTreeChanged();
			}
		}

		internal void NotifyChildChanged()
		{
			RecalculateTotalWeight();
			this.onChildChanged?.Invoke(this);
			Item parentItem = ParentItem;
			if (parentItem != null)
			{
				parentItem.NotifyChildChanged();
			}
		}

		internal void NotifySlotTreeChanged()
		{
			this.onSlotTreeChanged?.Invoke(this);
			Item parentItem = ParentItem;
			if (parentItem != null)
			{
				parentItem.NotifySlotTreeChanged();
			}
		}

		public void Use(object user)
		{
			this.onUse?.Invoke(this, user);
			Item.onUseStatic?.Invoke(this, user);
			usageUtilities.Use(this, user);
		}

		public CustomData GetVariableEntry(string variableKey)
		{
			return Variables.GetEntry(variableKey);
		}

		public CustomData GetVariableEntry(int hash)
		{
			return Variables.GetEntry(hash);
		}

		public float GetFloat(string key, float defaultResult = 0f)
		{
			return Variables.GetFloat(key, defaultResult);
		}

		public int GetInt(string key, int defaultResult = 0)
		{
			return Variables.GetInt(key, defaultResult);
		}

		public bool GetBool(string key, bool defaultResult = false)
		{
			return Variables.GetBool(key, defaultResult);
		}

		public string GetString(string key, string defaultResult = null)
		{
			return Variables.GetString(key, defaultResult);
		}

		public float GetFloat(int hash, float defaultResult = 0f)
		{
			return Variables.GetFloat(hash, defaultResult);
		}

		public int GetInt(int hash, int defaultResult = 0)
		{
			return Variables.GetInt(hash, defaultResult);
		}

		public bool GetBool(int hash, bool defaultResult = false)
		{
			return Variables.GetBool(hash, defaultResult);
		}

		public string GetString(int hash, string defaultResult = null)
		{
			return Variables.GetString(hash, defaultResult);
		}

		public void SetFloat(string key, float value, bool createNewIfNotExist = true)
		{
			Variables.Set(key, value, createNewIfNotExist);
		}

		public void SetInt(string key, int value, bool createNewIfNotExist = true)
		{
			Variables.Set(key, value, createNewIfNotExist);
		}

		public void SetBool(string key, bool value, bool createNewIfNotExist = true)
		{
			Variables.Set(key, value, createNewIfNotExist);
		}

		public void SetString(string key, string value, bool createNewIfNotExist = true)
		{
			Variables.Set(key, value, createNewIfNotExist);
		}

		public void SetFloat(int hash, float value)
		{
			Variables.Set(hash, value);
		}

		public void SetInt(int hash, int value)
		{
			Variables.Set(hash, value);
		}

		public void SetBool(int hash, bool value)
		{
			Variables.Set(hash, value);
		}

		public void SetString(int hash, string value)
		{
			Variables.Set(hash, value);
		}

		internal void ForceSetStackCount(int value)
		{
			UnityEngine.Debug.LogWarning($"正在强制将物品 {DisplayName} 的 Stack Count 设置为 {value}。");
			SetInt(StackCountVariableHash, value);
			this.onSetStackCount?.Invoke(this);
		}

		public void Combine(Item incomingItem)
		{
			if (incomingItem == null || incomingItem == this)
			{
				return;
			}
			if (!Stackable)
			{
				UnityEngine.Debug.LogError("正在尝试组合物品，但物品 " + DisplayName + " 不能堆叠。");
				return;
			}
			if (TypeID != incomingItem.TypeID)
			{
				UnityEngine.Debug.LogError("物品 " + DisplayName + " 与 " + incomingItem.DisplayName + " 类型不同，无法组合。");
				return;
			}
			int num = MaxStackCount - StackCount;
			if (num <= 0)
			{
				return;
			}
			_ = StackCount;
			_ = incomingItem.StackCount;
			int num2 = ((incomingItem.StackCount >= num) ? num : incomingItem.StackCount);
			int num3 = incomingItem.StackCount - num2;
			StackCount += num2;
			incomingItem.StackCount = num3;
			if (num3 <= 0)
			{
				incomingItem.Detach();
				if (Application.isPlaying)
				{
					incomingItem.DestroyTree();
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(incomingItem);
				}
			}
		}

		public void CombineInto(Item otherItem)
		{
			otherItem.Combine(this);
		}

		public async UniTask<Item> Split(int count)
		{
			if (!Stackable)
			{
				UnityEngine.Debug.LogError("物品 " + DisplayName + " 无法被分割。");
			}
			if (count <= 0)
			{
				return null;
			}
			if (count > StackCount)
			{
				UnityEngine.Debug.LogError($"物品 {DisplayName} 数量为{StackCount}，不足以分割出 {count} 。");
				return null;
			}
			if (count == StackCount)
			{
				UnityEngine.Debug.LogError($"正在尝试分割物品 {DisplayName} ，但目标数量 {count} 与该物品总数量相同。无法分割。");
				return null;
			}
			StackCount -= count;
			Item item = await ItemAssetsCollection.InstantiateAsync(TypeID);
			if (item == null)
			{
				UnityEngine.Debug.LogWarning($"物体 ID:{TypeID} ({DisplayName}) 创建失败。");
				return null;
			}
			item.Initialize();
			item.StackCount = count;
			item.Inspected = true;
			return item;
		}

		public override string ToString()
		{
			return displayName + " (物品)";
		}

		public void MarkDestroyed()
		{
			isBeingDestroyed = true;
		}

		private void OnDestroy()
		{
			isBeingDestroyed = true;
			Detach();
			agentUtilities.ReleaseActiveAgent();
			this.onDestroy?.Invoke(this);
		}

		public Stat GetStat(int hash)
		{
			if (Stats == null)
			{
				return null;
			}
			return Stats?.GetStat(hash);
		}

		public Stat GetStat(string key)
		{
			return Stats?.GetStat(key);
		}

		public float GetStatValue(int hash)
		{
			return GetStat(hash)?.Value ?? 0f;
		}

		public static Stat GetStat(Item item, int hash)
		{
			if (item == null)
			{
				return null;
			}
			return item.GetStat(hash);
		}

		public static float GetStatValue(Item item, int hash)
		{
			if (item == null)
			{
				return 0f;
			}
			return GetStat(item, hash)?.Value ?? 0f;
		}

		private void OnValidate()
		{
			base.transform.hideFlags = HideFlags.HideInInspector;
		}

		public void Validate(SelfValidationResult result)
		{
			if (Stats != null && Stats.gameObject != base.gameObject)
			{
				result.AddError("引用了其他物体上的Stats组件。").WithFix("改为引用本物体的Stats组件", delegate
				{
					stats = GetComponent<StatCollection>();
				});
			}
			if (Slots != null && Slots.gameObject != base.gameObject)
			{
				result.AddError("引用了其他物体上的Slots组件。").WithFix("改为引用本物体的Slots组件", delegate
				{
					slots = GetComponent<SlotCollection>();
				});
			}
			if (Modifiers != null && Modifiers.gameObject != base.gameObject)
			{
				result.AddError("引用了其他物体上的Modifiers组件。").WithFix("改为引用本物体的Modifiers组件", delegate
				{
					modifiers = GetComponent<ModifierDescriptionCollection>();
				});
			}
			if (Inventory != null && Inventory.gameObject != base.gameObject)
			{
				result.AddError("引用了其他物体上的Inventory组件。").WithFix("改为引用本物体的Inventory组件", delegate
				{
					inventory = GetComponent<Inventory>();
				});
			}
			if (Effects.Any((Effect e) => e == null))
			{
				result.AddError("Effects列表中有空物体。").WithFix("移除空Effect项目", delegate
				{
					Effects.RemoveAll((Effect e) => e == null);
				});
			}
			if (Effects.Any((Effect e) => !e.transform.IsChildOf(base.transform)))
			{
				result.AddError("引用了其他物体上的Effects。").WithFix("移除不正确的Effects", delegate
				{
					Effects.RemoveAll((Effect e) => !e.transform.IsChildOf(base.transform));
				});
			}
			if (Stackable)
			{
				if (Slots != null || Inventory != null)
				{
					result.AddError("可堆叠物体不应包含Slot、Inventory等独特信息。").WithFix("变为不可堆叠物体", delegate
					{
						maxStackCount = 1;
					});
				}
				if (Variables.Any((CustomData e) => e.Key != "Count"))
				{
					result.AddError("可堆叠物体不应包含特殊变量。");
				}
				if (!Variables.Any((CustomData e) => e.Key == "Count"))
				{
					result.AddWarning("可堆叠物体应包含Count变量，记录当前具体数量。(默认数量)").WithFix("添加Count变量。", delegate
					{
						variables.Add(new CustomData("Count", MaxStackCount));
					});
				}
			}
			else if (Variables.Any((CustomData e) => e.Key == "Count"))
			{
				result.AddWarning("不可堆叠物体包含了Count变量。建议删除。").WithFix("删除Count变量。", delegate
				{
					variables.Remove(variables.GetEntry("Count"));
				});
			}
		}

		public float RecalculateTotalWeight()
		{
			float num = 0f;
			num += SelfWeight;
			if (inventory != null)
			{
				inventory.RecalculateWeight();
				float cachedWeight = inventory.CachedWeight;
				num += cachedWeight;
			}
			if (slots != null)
			{
				foreach (Slot slot in slots)
				{
					if (slot != null && slot.Content != null)
					{
						float totalWeight = slot.Content.TotalWeight;
						num += totalWeight;
					}
				}
			}
			_cachedTotalWeight = num;
			return num;
		}

		public void AddEffect(Effect instance)
		{
			instance.SetItem(this);
			if (!effects.Contains(instance))
			{
				effects.Add(instance);
			}
		}

		private void CreateNewEffect()
		{
			GameObject obj = new GameObject("New Effect");
			obj.transform.SetParent(base.transform, worldPositionStays: false);
			Effect instance = obj.AddComponent<Effect>();
			AddEffect(instance);
		}

		public int GetTotalRawValue()
		{
			float num = Value;
			if (UseDurability && MaxDurability > 0f)
			{
				num = ((!(MaxDurability > 0f)) ? 0f : (num * (Durability / MaxDurability)));
			}
			int num2 = Mathf.FloorToInt(num) * ((!Stackable) ? 1 : StackCount);
			if (Slots != null)
			{
				foreach (Slot slot in Slots)
				{
					if (slot != null)
					{
						Item content = slot.Content;
						if (!(content == null))
						{
							num2 += content.GetTotalRawValue();
						}
					}
				}
			}
			if (Inventory != null)
			{
				foreach (Item item in Inventory)
				{
					if (!(item == null))
					{
						num2 += item.GetTotalRawValue();
					}
				}
			}
			return num2;
		}

		public int RemoveAllModifiersFrom(object endowmentEntry)
		{
			if (stats == null)
			{
				return 0;
			}
			int num = 0;
			foreach (Stat stat in stats)
			{
				if (stat != null)
				{
					num += stat.RemoveAllModifiersFromSource(endowmentEntry);
				}
			}
			return num;
		}

		public bool AddModifier(string statKey, Modifier modifier)
		{
			if (stats == null)
			{
				return false;
			}
			Stat stat = stats[statKey];
			if (stat == null)
			{
				return false;
			}
			stat.AddModifier(modifier);
			return true;
		}
	}
	public static class ItemTreeExtensions
	{
		public static List<Item> GetAllChildren(this Item item, bool includingGrandChildren = true, bool excludeSelf = false)
		{
			if (item == null)
			{
				return new List<Item>();
			}
			List<Item> children = new List<Item>();
			Stack<Item> pendingItems = new Stack<Item>();
			PushAllInSlots(item);
			PushAllInInventory(item);
			if (includingGrandChildren)
			{
				while (pendingItems.Count > 0)
				{
					Item item2 = pendingItems.Pop();
					PushAllInSlots(item2);
					PushAllInInventory(item2);
				}
			}
			if (!excludeSelf)
			{
				children.Add(item);
			}
			return children;
			void Push(Item pendingItem)
			{
				if (!(pendingItem == null))
				{
					if (pendingItem == item)
					{
						UnityEngine.Debug.LogWarning("Item Loop Detected! Aborting!");
					}
					else
					{
						children.Add(pendingItem);
						pendingItems.Push(pendingItem);
					}
				}
			}
			void PushAllInInventory(Item item3)
			{
				if (item3 == null || item3.Inventory == null)
				{
					return;
				}
				foreach (Item item3 in item3.Inventory)
				{
					Push(item3);
				}
			}
			void PushAllInSlots(Item item3)
			{
				if (item3 == null || item3.Slots == null)
				{
					return;
				}
				foreach (Slot slot in item3.Slots)
				{
					Push(slot.Content);
				}
			}
		}

		public static List<Item> GetAllParents(this Item item, bool excludeSelf = false)
		{
			List<Item> list = new List<Item>();
			if (item == null)
			{
				return list;
			}
			Item parentItem = item.ParentItem;
			while (parentItem != null)
			{
				if (list.Contains(parentItem))
				{
					UnityEngine.Debug.LogError("Item parenting loop detected!");
					break;
				}
				list.Add(parentItem);
				parentItem = parentItem.ParentItem;
			}
			if (!excludeSelf)
			{
				list.Insert(0, item);
			}
			return list;
		}

		public static Item GetRoot(this Item item)
		{
			if (item == null)
			{
				return null;
			}
			int num = 0;
			while (item.ParentItem != null)
			{
				item = item.ParentItem;
				num++;
				if (num >= 32)
				{
					UnityEngine.Debug.LogError("Too much layers in Item. Check if item reference loop occurred!");
					break;
				}
			}
			return item;
		}

		public static void DestroyTree(this Item item)
		{
			if (!(item == null))
			{
				item.MarkDestroyed();
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(item.gameObject);
				}
			}
		}

		public static void DestroyTreeImmediate(this Item item)
		{
			if (!(item == null))
			{
				UnityEngine.Object.DestroyImmediate(item.gameObject);
			}
		}

		public static List<Item> GetAllConnected(this Item item)
		{
			if (item == null)
			{
				return null;
			}
			return item.GetRoot().GetAllChildren();
		}
	}
	[Serializable]
	public class ModifierDescription
	{
		[NonSerialized]
		private ModifierDescriptionCollection collection;

		[SerializeField]
		private ModifierTarget target = ModifierTarget.Parent;

		[Tooltip("在背包中是否生效")]
		[SerializeField]
		private bool enableInInventory;

		[Tooltip("Target Stat Key")]
		[SerializeField]
		private string key;

		[Tooltip("Target Stat Key")]
		[SerializeField]
		private bool display;

		[SerializeField]
		private ModifierType type;

		[SerializeField]
		private float value;

		[Tooltip("Order Override")]
		[SerializeField]
		private bool overrideOrder;

		[SerializeField]
		private int order;

		private Modifier activeModifier;

		private static Regex reg = new Regex("(?'instructions'(\\[\\w+\\])*)(?'Target'[a-zA-Z]+)/(?'Key'[a-zA-Z_]+)\\s*(?'Operation'[*+-]+)\\s*(?'Value'[-\\d\\.]+)");

		private Item Master => collection?.Master;

		private StringList referenceStatKeys => StringLists.StatKeys;

		private string displayNamekey => "Stat_" + key;

		private int ResultOrder
		{
			get
			{
				if (overrideOrder)
				{
					return order;
				}
				return (int)type;
			}
		}

		public string Key => key;

		public ModifierType Type => type;

		public float Value => value;

		public bool IsOverrideOrder => overrideOrder;

		public int Order => order;

		public bool Display => display;

		public string DisplayName => displayNamekey.ToPlainText();

		public Modifier CreateModifier(object source)
		{
			return new Modifier(type, value, overrideOrder, order, source);
		}

		public void ReapplyModifier(ModifierDescriptionCollection collection)
		{
			if (this.collection != null && collection != this.collection)
			{
				UnityEngine.Debug.LogWarning("One Modifier Description seem to be used in different collections! This could cause errors in the future.");
			}
			this.collection = collection;
			if (activeModifier != null)
			{
				activeModifier.RemoveFromTarget();
			}
			Item targetItem = GetTargetItem();
			if (!(targetItem == null) && !(targetItem.Stats == null))
			{
				Stat stat = targetItem.Stats.GetStat(key);
				if (stat == null)
				{
					Stat stat2 = new Stat(key, 0f);
					targetItem.Stats.Add(stat2);
					stat = stat2;
				}
				Modifier modifier = CreateModifier(Master);
				stat.AddModifier(modifier);
				activeModifier = modifier;
			}
		}

		public Item GetTargetItem()
		{
			if (Master == null)
			{
				return null;
			}
			if (target == ModifierTarget.Self)
			{
				return Master;
			}
			if (!enableInInventory)
			{
				if (target == ModifierTarget.Character && !Master.IsInCharacterSlot())
				{
					return null;
				}
				if (target == ModifierTarget.Parent && Master.PluggedIntoSlot == null)
				{
					return null;
				}
			}
			switch (target)
			{
			case ModifierTarget.Parent:
				return Master.ParentItem;
			case ModifierTarget.Character:
				return Master.GetCharacterItem();
			default:
				UnityEngine.Debug.LogWarning("Invalid Modifier Target Type!");
				return null;
			}
		}

		public ModifierDescription(ModifierTarget target, string key, ModifierType type, float value, bool overrideOrder = false, int overrideOrderValue = 0)
		{
			this.target = target;
			this.key = key;
			this.type = type;
			this.value = value;
			this.overrideOrder = overrideOrder;
			order = overrideOrderValue;
		}

		public ModifierDescription()
		{
		}

		public static ModifierDescription FromString(string str)
		{
			ModifierDescription modifierDescription = new ModifierDescription();
			string text = str;
			str = str.Trim();
			Match match = reg.Match(str);
			if (!match.Success)
			{
				UnityEngine.Debug.LogError("无法解析Modifier: " + text);
				return null;
			}
			GroupCollection groups = match.Groups;
			string text2 = groups["instructions"].Value;
			string text3 = groups["Target"].Value;
			string text4 = groups["Key"].Value;
			string text5 = groups["Operation"].Value;
			string text6 = groups["Value"].Value;
			modifierDescription.display = true;
			string[] array = text2.Split(']');
			foreach (string text7 in array)
			{
				if (!string.IsNullOrWhiteSpace(text7) && text7.Trim('[', ']') == "hide")
				{
					modifierDescription.display = false;
				}
			}
			switch (text3)
			{
			case "Self":
				modifierDescription.target = ModifierTarget.Self;
				break;
			case "Parent":
				modifierDescription.target = ModifierTarget.Parent;
				break;
			case "Character":
				modifierDescription.target = ModifierTarget.Character;
				break;
			default:
				UnityEngine.Debug.LogError("无法解析Modifier目标 " + text3 + "\n" + text);
				return null;
			}
			modifierDescription.key = text4;
			bool flag = false;
			switch (text5)
			{
			case "+":
				modifierDescription.type = ModifierType.Add;
				break;
			case "-":
				modifierDescription.type = ModifierType.Add;
				flag = true;
				break;
			case "*+":
				modifierDescription.type = ModifierType.PercentageAdd;
				break;
			case "*-":
				modifierDescription.type = ModifierType.PercentageAdd;
				flag = true;
				break;
			case "*":
				modifierDescription.type = ModifierType.PercentageMultiply;
				break;
			default:
				UnityEngine.Debug.LogError("无法解析Modifier的operation: " + text5 + " \n" + text);
				return null;
			}
			if (!float.TryParse(text6, out var result))
			{
				UnityEngine.Debug.LogError("无法解析Modifier的Value: " + text6 + " \n" + text);
			}
			if (flag)
			{
				result = 0f - result;
			}
			modifierDescription.value = result;
			return modifierDescription;
		}

		internal void Release()
		{
			if (activeModifier != null)
			{
				activeModifier.RemoveFromTarget();
			}
		}

		public override string ToString()
		{
			return string.Format("{0} {1} {2} {3} {4}", target, key, type, value, overrideOrder ? "" : $" override order:{order}");
		}

		public string GetDisplayValueString(string format = "0.##")
		{
			return type switch
			{
				ModifierType.Add => ((Value > 0f) ? "+" : "") + Value.ToString(format), 
				ModifierType.PercentageAdd => string.Format("{0}{1:0.##}%", (Value > 0f) ? "+" : "", Value * 100f), 
				ModifierType.PercentageMultiply => $"x{100f + Value * 100f:0.##}%", 
				_ => $"?{Value}", 
			};
		}
	}
	public enum ModifierTarget
	{
		Self,
		Parent,
		Character
	}
	public class ModifierDescriptionCollection : ItemComponent, ICollection<ModifierDescription>, IEnumerable<ModifierDescription>, IEnumerable
	{
		private bool _modifierEnableCache = true;

		[SerializeField]
		private List<ModifierDescription> list;

		public int Count => list.Count;

		public bool ModifierEnable
		{
			get
			{
				return _modifierEnableCache;
			}
			set
			{
				_modifierEnableCache = value;
				ReapplyModifiers();
			}
		}

		public bool IsReadOnly => false;

		internal override void OnInitialize()
		{
			base.Master.onItemTreeChanged += OnItemTreeChange;
			base.Master.onDurabilityChanged += OnDurabilityChange;
		}

		private void OnDurabilityChange(Item item)
		{
			ReapplyModifiers();
		}

		private void OnDestroy()
		{
			if ((bool)base.Master)
			{
				base.Master.onItemTreeChanged -= OnItemTreeChange;
				base.Master.onDurabilityChanged -= OnDurabilityChange;
			}
		}

		private void OnItemTreeChange(Item item)
		{
			ReapplyModifiers();
		}

		public void ReapplyModifiers()
		{
			if (base.Master == null)
			{
				return;
			}
			bool flag = ModifierEnable;
			if (base.Master.UseDurability && base.Master.Durability <= 0f)
			{
				flag = false;
			}
			if (!flag)
			{
				foreach (ModifierDescription item in list)
				{
					item.Release();
				}
				return;
			}
			foreach (ModifierDescription item2 in list)
			{
				item2.ReapplyModifier(this);
			}
		}

		public void Add(ModifierDescription item)
		{
			list.Add(item);
		}

		public void Clear()
		{
			if (list == null)
			{
				list = new List<ModifierDescription>();
			}
			foreach (ModifierDescription item in list)
			{
				item.Release();
			}
			list.Clear();
		}

		public bool Contains(ModifierDescription item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ModifierDescription[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ModifierDescription item)
		{
			if (item != null && list.Contains(item))
			{
				item.Release();
			}
			return list.Remove(item);
		}

		public IEnumerator<ModifierDescription> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		public ModifierDescription Find(Predicate<ModifierDescription> predicate)
		{
			return list.Find(predicate);
		}
	}
	public enum Polarity
	{
		Negative = -1,
		Neutral,
		Positive
	}
	[Serializable]
	public class Stat
	{
		[NonSerialized]
		private StatCollection collection;

		[Tooltip("Stat Key")]
		[SerializeField]
		private string key;

		[SerializeField]
		private bool display;

		[Tooltip("Base Value")]
		[SerializeField]
		private float baseValue;

		private List<Modifier> modifiers = new List<Modifier>();

		private bool _dirty;

		private float cachedBaseValue = float.NaN;

		private float cachedValue;

		public Item Master => collection.Master;

		private StringList referenceKeys => StringLists.StatKeys;

		public string Key => key;

		public string DisplayNameKey => "Stat_" + key;

		public string DisplayName => DisplayNameKey.ToPlainText();

		public float BaseValue
		{
			get
			{
				return baseValue;
			}
			set
			{
				baseValue = value;
			}
		}

		public List<Modifier> Modifiers => modifiers;

		private bool Dirty
		{
			get
			{
				return _dirty;
			}
			set
			{
				_dirty = value;
				if (value)
				{
					this.OnSetDirty?.Invoke(this);
				}
			}
		}

		public float Value
		{
			get
			{
				if (Dirty || cachedBaseValue != BaseValue)
				{
					Recalculate();
				}
				return cachedValue;
			}
		}

		private string ValueToolTip
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine($"基础:{BaseValue}");
				foreach (Modifier modifier in modifiers)
				{
					stringBuilder.AppendLine(modifier.ToString());
				}
				return stringBuilder.ToString();
			}
		}

		public bool Display => display;

		public event Action<Stat> OnSetDirty;

		private void Recalculate()
		{
			cachedBaseValue = baseValue;
			modifiers.RemoveAll((Modifier e) => e == null);
			modifiers.Sort(Modifier.OrderComparison);
			float result = baseValue;
			float percentageAddValue = 0f;
			bool percentageAdding = false;
			int num = int.MinValue;
			for (int num2 = 0; num2 < modifiers.Count; num2++)
			{
				Modifier modifier = modifiers[num2];
				int order = modifier.Order;
				if (percentageAdding && (order != num || modifier.Type != ModifierType.PercentageAdd))
				{
					ApplyPercentageAdd();
				}
				num = modifier.Order;
				switch (modifier.Type)
				{
				case ModifierType.Add:
					result += modifier.Value;
					break;
				case ModifierType.PercentageAdd:
					percentageAdding = true;
					percentageAddValue += modifier.Value;
					break;
				case ModifierType.PercentageMultiply:
					result *= Mathf.Max(0f, 1f + modifier.Value);
					break;
				}
			}
			if (percentageAdding)
			{
				ApplyPercentageAdd();
			}
			cachedValue = result;
			_dirty = false;
			void ApplyPercentageAdd()
			{
				Mathf.Max(0f, 1f + percentageAddValue);
				result *= Mathf.Max(0f, 1f + percentageAddValue);
				percentageAddValue = 0f;
				percentageAdding = false;
			}
		}

		public void AddModifier(Modifier modifier)
		{
			modifiers.Add(modifier);
			modifier.NotifyAddedToStat(this);
			Dirty = true;
		}

		public bool RemoveModifier(Modifier modifier)
		{
			bool result = modifiers.Remove(modifier);
			Dirty = true;
			return result;
		}

		public int RemoveAllModifiersFromSource(object source)
		{
			int result = modifiers.RemoveAll((Modifier e) => e.Source == source);
			Dirty = true;
			return result;
		}

		internal void Initialize(StatCollection collection)
		{
			this.collection = collection;
			Recalculate();
		}

		internal void SetDirty()
		{
			Dirty = true;
		}

		public Stat()
		{
		}

		public Stat(string key, float value, bool display = false)
		{
			this.key = key;
			baseValue = value;
			this.display = display;
		}
	}
	public class StatCollection : ItemComponent, ICollection<Stat>, IEnumerable<Stat>, IEnumerable
	{
		[SerializeField]
		private List<Stat> list;

		private Dictionary<int, Stat> _cachedStatsDictionary;

		private Dictionary<int, Stat> statsDictionary
		{
			get
			{
				if (_cachedStatsDictionary == null)
				{
					BuildDictionary();
				}
				return _cachedStatsDictionary;
			}
		}

		public int Count => list.Count;

		public bool IsReadOnly => false;

		public Stat this[int hash] => GetStat(hash);

		public Stat this[string key] => GetStat(key);

		public Stat GetStat(int hash)
		{
			if (statsDictionary.TryGetValue(hash, out var value))
			{
				return value;
			}
			return null;
		}

		public Stat GetStat(string key)
		{
			int hashCode = key.GetHashCode();
			Stat stat = GetStat(hashCode);
			if (stat == null)
			{
				stat = list.Find((Stat e) => e.Key == key);
			}
			return stat;
		}

		private void BuildDictionary()
		{
			if (_cachedStatsDictionary == null)
			{
				_cachedStatsDictionary = new Dictionary<int, Stat>();
			}
			_cachedStatsDictionary.Clear();
			foreach (Stat item in list)
			{
				int hashCode = item.Key.GetHashCode();
				_cachedStatsDictionary[hashCode] = item;
			}
		}

		internal override void OnInitialize()
		{
			foreach (Stat item in list)
			{
				item.Initialize(this);
			}
		}

		public IEnumerator<Stat> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		public void Add(Stat item)
		{
			list.Add(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		public bool Contains(Stat item)
		{
			return list.Contains(item);
		}

		public void CopyTo(Stat[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(Stat item)
		{
			return list.Remove(item);
		}
	}
	public class LogWhenUsed : UsageBehavior
	{
		public override bool CanBeUsed(Item item, object user)
		{
			return true;
		}

		protected override void OnUse(Item item, object user)
		{
			UnityEngine.Debug.Log(item.name);
		}
	}
	public abstract class UsageBehavior : MonoBehaviour
	{
		public struct DisplaySettingsData
		{
			public bool display;

			public string description;

			public string Description => description;
		}

		public virtual DisplaySettingsData DisplaySettings => default(DisplaySettingsData);

		public abstract bool CanBeUsed(Item item, object user);

		protected abstract void OnUse(Item item, object user);

		public void Use(Item item, object user)
		{
			OnUse(item, user);
		}
	}
	public class UsageUtilities : ItemComponent
	{
		[SerializeField]
		private float useTime;

		public List<UsageBehavior> behaviors = new List<UsageBehavior>();

		public bool hasSound;

		public string actionSound;

		public string useSound;

		public bool useDurability;

		public int durabilityUsage = 1;

		public float UseTime => useTime;

		public static event Action<Item> OnItemUsedStaticEvent;

		public bool IsUsable(Item item, object user)
		{
			if (!item)
			{
				return false;
			}
			if (useDurability && item.Durability < (float)durabilityUsage)
			{
				return false;
			}
			foreach (UsageBehavior behavior in behaviors)
			{
				if (!(behavior == null) && behavior.CanBeUsed(item, user))
				{
					return true;
				}
			}
			return false;
		}

		public void Use(Item item, object user)
		{
			foreach (UsageBehavior behavior in behaviors)
			{
				if (!(behavior == null) && behavior.CanBeUsed(item, user))
				{
					behavior.Use(item, user);
				}
			}
			if (useDurability && item.Durability > 0f)
			{
				item.Durability -= durabilityUsage;
			}
			UsageUtilities.OnItemUsedStaticEvent?.Invoke(item);
		}
	}
}
namespace ItemStatsSystem.Stats
{
	public class Modifier
	{
		private Stat target;

		[SerializeField]
		private ModifierType type;

		[SerializeField]
		private float value;

		[SerializeField]
		private bool overrideOrder;

		[SerializeField]
		private int overrideOrderValue;

		[SerializeField]
		private object source;

		public static readonly Comparison<Modifier> OrderComparison = (Modifier a, Modifier b) => a.Order - b.Order;

		public int Order
		{
			get
			{
				if (overrideOrder)
				{
					return overrideOrderValue;
				}
				return (int)type;
			}
		}

		public ModifierType Type => type;

		public float Value
		{
			get
			{
				return value;
			}
			set
			{
				if (value != this.value)
				{
					this.value = value;
					if (target != null)
					{
						target.SetDirty();
					}
				}
			}
		}

		public object Source => source;

		public Modifier(ModifierType type, float value, object source)
			: this(type, value, overrideOrder: false, 0, source)
		{
		}

		public Modifier(ModifierType type, float value, bool overrideOrder, int overrideOrderValue, object source)
		{
			this.type = type;
			this.value = value;
			this.overrideOrder = overrideOrder;
			this.overrideOrderValue = overrideOrderValue;
			this.source = source;
		}

		public void NotifyAddedToStat(Stat stat)
		{
			if (target != null && target != stat)
			{
				UnityEngine.Debug.LogError("Modifier被赋予给了多了个不同的Stat");
				target.RemoveModifier(this);
			}
			target = stat;
		}

		public void RemoveFromTarget()
		{
			if (target != null)
			{
				target.RemoveModifier(this);
				target = null;
			}
		}

		public override string ToString()
		{
			string text = "";
			bool flag = value > 0f;
			switch (type)
			{
			case ModifierType.Add:
				text = string.Format("{0}{1}", flag ? "+" : "", value);
				break;
			case ModifierType.PercentageAdd:
				text = string.Format("x(..{0}{1})", flag ? "+" : "", value);
				break;
			case ModifierType.PercentageMultiply:
				text = string.Format("x(1{0}{1})", flag ? "+" : "", value);
				break;
			}
			string text2 = (flag ? "#55FF55" : "#FF5555");
			text = "<color=" + text2 + ">" + text + "</color>";
			return text + " 来自 " + source.ToString();
		}
	}
	public enum ModifierType
	{
		Add = 0,
		PercentageAdd = 100,
		PercentageMultiply = 200
	}
}
namespace ItemStatsSystem.Items
{
	[Serializable]
	public class Slot
	{
		[NonSerialized]
		private SlotCollection collection;

		[SerializeField]
		private string key;

		[SerializeField]
		private Sprite slotIcon;

		private Item content;

		public List<Tag> requireTags = new List<Tag>();

		public List<Tag> excludeTags = new List<Tag>();

		[SerializeField]
		private bool forbidItemsWithSameID;

		public Item Master => collection?.Master;

		public Item Content => content;

		private StringList referenceKeys => StringLists.SlotNames;

		public Sprite SlotIcon
		{
			get
			{
				return slotIcon;
			}
			set
			{
				slotIcon = value;
			}
		}

		public bool ForbidItemsWithSameID => forbidItemsWithSameID;

		public string Key => key;

		public string DisplayName
		{
			get
			{
				if (requireTags == null || requireTags.Count < 1)
				{
					return "?";
				}
				Tag tag = requireTags[0];
				if (tag == null)
				{
					return "?";
				}
				return tag.DisplayName;
			}
		}

		public event Action<Slot> onSlotContentChanged;

		public void Initialize(SlotCollection collection)
		{
			this.collection = collection;
		}

		public void ForceInvokeSlotContentChangedEvent()
		{
			this.onSlotContentChanged?.Invoke(this);
		}

		public bool Plug(Item otherItem, out Item unpluggedItem)
		{
			unpluggedItem = null;
			if (!CheckAbleToPlug(otherItem))
			{
				UnityEngine.Debug.Log("Unable to Plug");
				return false;
			}
			if (content != null)
			{
				if (content.Stackable && content.TypeID == otherItem.TypeID)
				{
					content.Combine(otherItem);
					Master.NotifySlotPlugged(this);
					this.onSlotContentChanged?.Invoke(this);
					content.InitiateNotifyItemTreeChanged();
					if (otherItem.StackCount <= 0)
					{
						return true;
					}
					return false;
				}
				unpluggedItem = Unplug();
			}
			if (otherItem.PluggedIntoSlot != null)
			{
				otherItem.Detach();
			}
			if (otherItem.InInventory != null)
			{
				otherItem.Detach();
			}
			content = otherItem;
			otherItem.transform.SetParent(collection.transform);
			otherItem.NotifyPluggedTo(this);
			Master.NotifySlotPlugged(this);
			otherItem.InitiateNotifyItemTreeChanged();
			this.onSlotContentChanged?.Invoke(this);
			return true;
		}

		private bool CheckAbleToPlug(Item otherItem)
		{
			if (otherItem == null)
			{
				return false;
			}
			if (otherItem == content)
			{
				return false;
			}
			if (forbidItemsWithSameID && collection != null)
			{
				foreach (Slot item2 in collection)
				{
					if (item2 != null && item2 != this && item2.ForbidItemsWithSameID)
					{
						Item item = item2.Content;
						if (!(item == null) && !(item == otherItem) && item.TypeID == otherItem.TypeID)
						{
							return false;
						}
					}
				}
			}
			if (Master.GetAllParents().Contains(otherItem))
			{
				return false;
			}
			if (!otherItem.Tags.Check(requireTags, excludeTags))
			{
				return false;
			}
			return true;
		}

		public Item Unplug()
		{
			Item item = content;
			content = null;
			if (item != null)
			{
				if (!item.IsBeingDestroyed)
				{
					item.transform.SetParent(null);
				}
				item.NotifyUnpluggedFrom(this);
				Master.NotifySlotUnplugged(this);
				item.InitiateNotifyItemTreeChanged();
				Master.InitiateNotifyItemTreeChanged();
				this.onSlotContentChanged?.Invoke(this);
			}
			return item;
		}

		public bool CanPlug(Item item)
		{
			if (item == null)
			{
				return false;
			}
			return CheckAbleToPlug(item);
		}

		public Slot()
		{
		}

		public Slot(string key)
		{
			this.key = key;
		}
	}
	public class SlotCollection : ItemComponent, ICollection<Slot>, IEnumerable<Slot>, IEnumerable
	{
		public Action<Slot> OnSlotContentChanged;

		public List<Slot> list;

		private Dictionary<int, Slot> _cachedSlotsDictionary;

		private Dictionary<int, Slot> slotsDictionary
		{
			get
			{
				if (_cachedSlotsDictionary == null)
				{
					BuildDictionary();
				}
				return _cachedSlotsDictionary;
			}
		}

		public int Count
		{
			get
			{
				if (list != null)
				{
					return list.Count;
				}
				return 0;
			}
		}

		public bool IsReadOnly => false;

		public Slot this[string key] => GetSlot(key);

		public Slot this[int index] => GetSlotByIndex(index);

		public Slot GetSlotByIndex(int index)
		{
			return list[index];
		}

		public Slot GetSlot(int hash)
		{
			if (slotsDictionary.TryGetValue(hash, out var value))
			{
				return value;
			}
			return null;
		}

		public Slot GetSlot(string key)
		{
			int hashCode = key.GetHashCode();
			Slot slot = GetSlot(hashCode);
			if (slot == null)
			{
				slot = list.Find((Slot e) => e.Key == key);
			}
			return slot;
		}

		private void BuildDictionary()
		{
			if (_cachedSlotsDictionary == null)
			{
				_cachedSlotsDictionary = new Dictionary<int, Slot>();
			}
			_cachedSlotsDictionary.Clear();
			foreach (Slot item in list)
			{
				int hashCode = item.Key.GetHashCode();
				_cachedSlotsDictionary[hashCode] = item;
			}
		}

		internal override void OnInitialize()
		{
			foreach (Slot item in list)
			{
				item.Initialize(this);
			}
		}

		public IEnumerator<Slot> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		public void Add(Slot item)
		{
			list.Add(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		public bool Contains(Slot item)
		{
			return list.Contains(item);
		}

		public void CopyTo(Slot[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(Slot item)
		{
			return list.Remove(item);
		}
	}
}
namespace ItemStatsSystem.Data
{
	[Serializable]
	public class ItemTreeData
	{
		[Serializable]
		public class DataEntry
		{
			public int instanceID;

			public int typeID;

			public List<CustomData> variables = new List<CustomData>();

			public List<SlotInstanceIDPair> slotContents = new List<SlotInstanceIDPair>();

			public List<InventoryDataEntry> inventory = new List<InventoryDataEntry>();

			public List<int> inventorySortLocks = new List<int>();

			public string TypeName => $"TYPE_{typeID}";

			public int StackCount
			{
				get
				{
					CustomData customData = variables.Find((CustomData e) => e.Key == "Count");
					if (customData == null)
					{
						return 1;
					}
					if (customData.DataType != CustomDataType.Int)
					{
						return 1;
					}
					return customData.GetInt();
				}
			}
		}

		public class SlotInstanceIDPair
		{
			public string slot;

			public int instanceID;

			public SlotInstanceIDPair(string slot, int instanceID)
			{
				this.slot = slot;
				this.instanceID = instanceID;
			}
		}

		public class InventoryDataEntry
		{
			public int position;

			public int instanceID;

			public InventoryDataEntry(int position, int instanceID)
			{
				this.position = position;
				this.instanceID = instanceID;
			}
		}

		public int rootInstanceID;

		public List<DataEntry> entries = new List<DataEntry>();

		public DataEntry RootData
		{
			get
			{
				DataEntry dataEntry = entries.Find((DataEntry e) => e.instanceID == rootInstanceID);
				if (dataEntry == null)
				{
					return null;
				}
				return dataEntry;
			}
		}

		public int RootTypeID => entries.Find((DataEntry e) => e.instanceID == rootInstanceID)?.typeID ?? 0;

		public static event Action<Item> OnItemLoaded;

		public static ItemTreeData FromItem(Item item)
		{
			ItemTreeData itemTreeData = new ItemTreeData();
			Dictionary<int, DataEntry> dictionary = new Dictionary<int, DataEntry>();
			itemTreeData.rootInstanceID = item.GetInstanceID();
			List<Item> allChildren = item.GetAllChildren();
			foreach (Item item3 in allChildren)
			{
				DataEntry dataEntry = new DataEntry
				{
					instanceID = item3.GetInstanceID(),
					typeID = item3.TypeID
				};
				foreach (CustomData variable in item3.Variables)
				{
					dataEntry.variables.Add(new CustomData(variable));
				}
				if (item3.Inventory != null)
				{
					int lastItemPosition = item3.Inventory.GetLastItemPosition();
					for (int i = 0; i <= lastItemPosition; i++)
					{
						Item item2 = item3.Inventory[i];
						if (item2 != null)
						{
							dataEntry.inventory.Add(new InventoryDataEntry(i, item2.GetInstanceID()));
						}
					}
					dataEntry.inventorySortLocks = new List<int>(item3.Inventory.lockedIndexes);
				}
				dictionary.Add(dataEntry.instanceID, dataEntry);
				itemTreeData.entries.Add(dataEntry);
			}
			foreach (Item item4 in allChildren)
			{
				DataEntry dataEntry2 = dictionary[item4.GetInstanceID()];
				if (item4.Slots == null)
				{
					continue;
				}
				foreach (Slot slot in item4.Slots)
				{
					if (slot.Content != null)
					{
						dataEntry2.slotContents.Add(new SlotInstanceIDPair(slot.Key, slot.Content.GetInstanceID()));
					}
				}
			}
			return itemTreeData;
		}

		public static async UniTask<Item> InstantiateAsync(ItemTreeData data)
		{
			if (data == null)
			{
				return null;
			}
			Dictionary<int, Item> instanceDic = new Dictionary<int, Item>();
			Scene beginningScene = SceneManager.GetActiveScene();
			bool beginningSceneLoaded = beginningScene.isLoaded;
			bool playing = Application.isPlaying;
			bool abort = false;
			foreach (DataEntry curData in data.entries)
			{
				if ((beginningSceneLoaded && !beginningScene.isLoaded) || Application.isPlaying != playing)
				{
					abort = true;
					break;
				}
				Item item = await ItemAssetsCollection.InstantiateAsync(curData.typeID);
				if (item == null)
				{
					UnityEngine.Debug.LogError($"Failed to create item {data.rootInstanceID}, type:{curData.typeID}");
					continue;
				}
				instanceDic.Add(curData.instanceID, item);
				foreach (CustomData variable in curData.variables)
				{
					item.Variables.SetRaw(variable.Key, variable.DataType, variable.GetRawCopied());
				}
				ItemTreeData.OnItemLoaded?.Invoke(item);
			}
			if (abort)
			{
				UnityEngine.Debug.LogWarning("Item Instantiate Aborted");
				Item[] array = instanceDic.Values.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					UnityEngine.Object.Destroy(array[i].gameObject);
				}
				return null;
			}
			foreach (DataEntry entry in data.entries)
			{
				if (!instanceDic.TryGetValue(entry.instanceID, out var value))
				{
					continue;
				}
				foreach (SlotInstanceIDPair slotContent in entry.slotContents)
				{
					if (value.Slots == null)
					{
						UnityEngine.Debug.LogError($"Trying to plug item to slot {value.name}({value.TypeID}-{value.DisplayName})/{slotContent.slot}, but the slot doesn't exist.");
						break;
					}
					Slot slot = value.Slots[slotContent.slot];
					instanceDic.TryGetValue(slotContent.instanceID, out var value2);
					if (slot != null && !(value2 == null))
					{
						slot.Plug(value2, out var unpluggedItem);
						if (unpluggedItem != null)
						{
							UnityEngine.Debug.LogError("Found Unplugged Item while Loading Item Tree!");
						}
					}
				}
				if (entry.inventory.Count > 0)
				{
					if (value.Inventory == null)
					{
						UnityEngine.Debug.LogError("尝试加载Inventory数据，但物品的Inventory不存在。");
					}
					else
					{
						foreach (InventoryDataEntry item2 in entry.inventory)
						{
							if (instanceDic.TryGetValue(item2.instanceID, out var value3))
							{
								value.Inventory.AddAt(value3, item2.position);
							}
							else
							{
								UnityEngine.Debug.LogError($"加载Inventory时找不到物品实例 {item2.instanceID}");
							}
						}
					}
				}
				if ((bool)value.Inventory && entry.inventorySortLocks != null)
				{
					value.Inventory.lockedIndexes.Clear();
					value.Inventory.lockedIndexes.AddRange(entry.inventorySortLocks);
				}
			}
			if (instanceDic.TryGetValue(data.rootInstanceID, out var value4))
			{
				return value4;
			}
			UnityEngine.Debug.LogError($"Missing Item {data.rootInstanceID} \n {data.ToString()}");
			return null;
		}

		public DataEntry GetEntry(int instanceID)
		{
			return entries.Find((DataEntry e) => e.instanceID == instanceID);
		}

		public override string ToString()
		{
			DataEntry dataEntry = entries.Find((DataEntry e) => e.instanceID == rootInstanceID);
			if (dataEntry == null)
			{
				UnityEngine.Debug.LogError("No Root Entry in Tree");
				return "Invalid Item Tree";
			}
			int indent = 0;
			string result = "";
			PrintEntry(dataEntry);
			return result;
			void MakeIndent()
			{
				result += new string('\t', indent);
			}
			void Print(string content)
			{
				result += content;
			}
			void PrintEntry(DataEntry dataEntry2)
			{
				MakeIndent();
				PrintLine($"{dataEntry2.typeID}-{dataEntry2.TypeName} ({dataEntry2.instanceID})");
				indent++;
				if (dataEntry2.slotContents.Count > 0)
				{
					Print("[Slots]\n");
				}
				foreach (SlotInstanceIDPair slotContent in dataEntry2.slotContents)
				{
					DataEntry entry = GetEntry(slotContent.instanceID);
					MakeIndent();
					Print(slotContent.slot + ":\n");
					PrintEntry(entry);
				}
				if (dataEntry2.inventory.Count > 0)
				{
					Print("[Inventory]\n");
				}
				foreach (InventoryDataEntry item in dataEntry2.inventory)
				{
					DataEntry entry2 = GetEntry(item.instanceID);
					MakeIndent();
					PrintEntry(entry2);
				}
				indent--;
			}
			void PrintLine(string content)
			{
				result = result + content + "\n";
			}
		}
	}
	[Serializable]
	public class InventoryData
	{
		[Serializable]
		public class Entry
		{
			public int inventoryPosition;

			public ItemTreeData itemTreeData;
		}

		public int capacity = 16;

		public List<Entry> entries = new List<Entry>();

		public List<int> lockedIndexes = new List<int>();

		public static InventoryData FromInventory(Inventory inventory)
		{
			InventoryData inventoryData = new InventoryData();
			inventoryData.capacity = inventory.Capacity;
			int lastItemPosition = inventory.GetLastItemPosition();
			for (int i = 0; i <= lastItemPosition; i++)
			{
				Item itemAt = inventory.GetItemAt(i);
				if (!(itemAt == null))
				{
					Entry entry = new Entry();
					entry.inventoryPosition = i;
					entry.itemTreeData = ItemTreeData.FromItem(itemAt);
					inventoryData.entries.Add(entry);
				}
			}
			inventoryData.lockedIndexes = new List<int>(inventory.lockedIndexes);
			return inventoryData;
		}

		public static async UniTask LoadIntoInventory(InventoryData data, Inventory inventoryInstance)
		{
			if (data == null)
			{
				return;
			}
			foreach (Entry entry in data.entries)
			{
				int position = entry.inventoryPosition;
				Item item = await ItemTreeData.InstantiateAsync(entry.itemTreeData);
				if (item == null)
				{
					UnityEngine.Debug.LogError("物品加载失败");
				}
				else if (!inventoryInstance.AddAt(item, position))
				{
					UnityEngine.Debug.LogError("向 Inventory " + inventoryInstance.name + " 中添加物品失败。");
				}
			}
			if (data.lockedIndexes != null)
			{
				inventoryInstance.lockedIndexes.Clear();
				inventoryInstance.lockedIndexes.AddRange(data.lockedIndexes);
			}
		}
	}
}
