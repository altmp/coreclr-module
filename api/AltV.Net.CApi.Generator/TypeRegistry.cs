﻿using System.Collections.Generic;

namespace AltV.Net.CApi.Generator;

public static class TypeRegistry
{
    public static readonly SortedDictionary<string, string> CsTypes = new()
    {
        { "int", "int" },
        { "unsigned int", "uint" },
        { "unsigned long", "ulong" },
        { "unsigned short", "ushort" },
        { "unsigned char", "byte" },
        { "long", "long" },
        { "short", "short" },
        { "char", "char" },
        { "float", "float" },
        { "float*", "float*" },
        { "double", "double" },
        { "double&", "double*" },
        { "bool", "bool" },
        { "void", "void" },
        { "char*", "nint" },
        { "char[]", "nint" },
        { "char*&", "nint*" },
        { "char*[]", "nint[]" },
        { "int*", "int*" },
        { "alt::ICore*", "nint" },
        { "alt::ILocalPlayer*", "nint" },
        { "alt::IPlayer*", "nint" },
        { "alt::IPlayer**", "nint" },
        { "alt::IPed*", "nint" },
        { "alt::IPed**", "nint" },
        { "alt::IVirtualEntity*", "nint" },
        { "alt::IVirtualEntity**", "nint" },
        { "alt::IVirtualEntityGroup*", "nint" },
        { "alt::IVirtualEntityGroup**", "nint" },
        { "alt::IVehicle*", "nint" },
        { "alt::IAudioFilter*", "nint" },
        { "alt::INetworkObject*", "nint" },
        { "alt::ITextLabel*", "nint" },
        { "alt::IVehicle**", "nint" },
        { "alt::IHandlingData*", "nint" },
        { "alt::IHandlingData*&", "nint*" },
        { "alt::IWeaponData*", "nint" },
        { "alt::IWeaponData*&", "nint*" },
        { "alt::IObject*", "nint" },
        { "alt::Weapon*", "nint" },
        { "alt::IObject**", "nint" },
        { "alt::IObject*&", "nint*" },
        { "alt::IMapData*", "nint" },
        { "alt::IAudio*", "nint" },
        { "alt::IAudioOutput*", "nint" },
        { "alt::IAudioAttachedOutput*", "nint" },
        { "alt::IAudioFrontendOutput*", "nint" },
        { "alt::IAudioWorldOutput*", "nint" },
        { "alt::IFont*", "nint" },
        { "alt::ICustomTexture*", "nint" },
        { "alt::IHttpClient*", "nint" },
        { "alt::IWebSocketClient*", "nint" },
        { "alt::IEntity*", "nint" },
        { "alt::IWorldObject*", "nint" },
        { "alt::IBaseObject*", "nint" },
        { "alt::IResource*", "nint" },
        { "alt::IResource**", "nint" },
        { "alt::IConnectionInfo**", "nint" },
        { "alt::IWebView*", "nint" },
        { "alt::ILocalStorage*", "nint" },
        { "alt::IStatData*", "nint" },
        { "alt::IRmlDocument*", "nint" },
        { "alt::IRmlElement*", "nint" },
        { "alt::IRmlElement**", "nint" },
        { "alt::IRmlElement**&", "nint*" },
        { "alt::IMarker*", "nint" },
        { "alt::Metric*", "nint" },
        { "void**&", "nint*" },
        { "CSharpResourceImpl*", "nint" },
        { "void**", "nint*" },
        { "alt::MValueConst*", "nint" },
        { "alt::MValueConst**", "nint" },
        { "alt::MValueConst*[]", "nint[]" },
        { "alt::ILocalVehicle*", "nint" },
        { "alt::ILocalPed*", "nint" },
        { "int8_t", "sbyte" },
        { "int8_t&", "sbyte*" },
        { "uint8_t", "byte" },
        { "uint8_t[]", "byte[]" },
        { "uint8_t&", "byte*" },
        { "uint8_t*&", "nint*" },
        { "int16_t", "short" },
        { "int16_t&", "short*" },
        { "uint16_t", "ushort" },
        { "uint16_t&", "ushort*" },
        { "int32_t", "int" },
        { "int32_t&", "int*" },
        { "uint32_t", "uint" },
        { "uint32_t&", "uint*" },
        { "uint32_t*", "nint" },
        { "uint32_t*&", "nint*" },
        { "int64_t", "long" },
        { "int64_t&", "long*" },
        { "uint64_t", "ulong" },
        { "uint64_t&", "ulong*" },
        { "vector2_t", "Vector2" },
        { "vector2_t&", "Vector2*" },
        { "vector3_t", "Vector3" },
        { "vector3_t&", "Vector3*" },
        { "rgba_t", "Rgba" },
        { "rgba_t&", "Rgba*" },
        { "alt::Array<uint32_t>", "UIntArray*" },

        { "alt::Quaternion", "Quaternion" },
        { "alt::Quaternion&", "Quaternion*" },

        { "position_t&", "Vector3*" },
        { "position_t", "Vector3" },
        { "alt::Position", "Vector3" },
        { "rotation_t&", "Rotation*" },
        { "rotation_t", "Rotation" },
        { "alt::Rotation", "Rotation" },

        { "cloth_t&", "Cloth*" },
        { "cloth_t", "Cloth" },
        { "dlccloth_t&", "DlcCloth*" },
        { "dlccloth_t", "DlcCloth" },
        { "prop_t&", "Prop*" },
        { "prop_t", "Prop" },
        { "dlcprop_t&", "DlcProp*" },
        { "dlcprop_t", "DlcProp" },
        { "const char*", "nint" },
        { "alt::MValue&", "MValue*" },
        { "alt::MValue*", "MValue*" },
        { "const char*&", "nint*" },
        { "char**", "nint" },
        { "char**&", "nint*" },
        { "alt::Array<uint32_t>&", "UIntArray*" },
        { "alt::Array<uint32_t>*", "UIntArray*" },
        { "void*", "nint" },
        { "alt::IBaseObject::Type&", "BaseObjectType*" },
        { "player_struct_t*", "ReadOnlyPlayer*" },
        { "alt::RGBA", "Rgba" },
        { "bool*", "byte*" },
        { "alt::IColShape*", "nint" },
        { "alt::ColShapeType", "ColShapeType" },
        { "alt::IVoiceChannel*", "nint" },
        { "alt::IBlip*", "nint" },
        { "alt::IBlip**", "nint" },
        { "alt::Array<alt::String>&", "StringArray*" },
        //{ "alt::MValue::List&", "MValueWriter2.MValueArray*" },
        { "const alt::MValue&", "MValue*" },
        { "const char**", "string[]" },
        { "alt::IResource::Impl*", "nint" },
        { "alt::MValueFunction::Invoker*", "nint" },
        { "MValueFunctionCallback", "MValueFunctionCallback" }, //"MValue.Function",
        { "CustomInvoker*", "nint" },
        { "alt::MValue[]", "MValue[]" },
        { "alt::MValueList&", "MValue*" }, //no c# representation for MValue list memory layout yet
        { "const alt::MValueList&", "MValue*" }, //no c# representation for MValue list memory layout yet
        { "alt::MValueDict&", "MValue*" }, //no c# representation for MValue dictionary memory layout yet
        { "alt::ICheckpoint*", "nint" },
        {
            "alt::MValueFunction&", "MValue*"
        }, //no c# representation for MValue function memory layout yet, this is only in commented code and not required
        { "alt::CEvent::Type", "ushort" },
        { "alt::CEvent*", "nint" },
        { "alt::EventCallback", "EventCallback" },
        { "alt::TickCallback", "TickCallback" },
        { "alt::CommandCallback", "CommandCallback" },
        { "alt::Array<alt::IPlayer*>*", "PlayerPointerArray*" },
        { "alt::Array<alt::IVehicle*>*", "VehiclePointerArray*" },
        { "alt::Array<alt::IPlayer*>&", "PlayerPointerArray*" },
        { "alt::Array<alt::IVehicle*>&", "VehiclePointerArray*" },
        { "alt::Array<alt::StringView>*", "StringViewArray*" },
        { "alt::Array<alt::String>*", "StringArray*" },
        { "alt::Array<alt::MValue>*", "MValueWriter2.MValueArray*" },
        { "alt::MValue*[]", "nint[]" },
        { "alt::IPlayer*[]", "nint[]" },
        { "alt::IVehicle*[]", "nint[]" },
        { "alt::IPed*[]", "nint[]" },
        { "alt::IVirtualEntity*[]", "nint[]" },
        { "alt::IVirtualEntityGroup*[]", "nint[]" },
        { "alt::IBlip*[]", "nint[]" },
        { "alt::IBaseObject*[]", "nint[]" },
        { "alt::ICheckpoint*[]", "nint[]" },
        { "alt::ICheckpoint**", "nint" },
        { "alt::IWebView*[]", "nint[]" },
        { "alt::INetworkObject*[]", "nint[]" },
        { "alt::INetworkObject**", "nint" },
        { "alt::IColShape**", "nint" },
        { "alt::IAudio*[]", "nint[]" },
        { "alt::IMarker*[]", "nint[]" },
        { "alt::IColShape*[]", "nint[]" },
        { "alt::IAudioOutput*[]", "nint[]" },
        { "alt::IMarker**", "nint" },
        { "alt::IAudio**", "nint" },
        { "alt::IAudioOutput**", "nint" },
        { "uint8_t*", "byte*" },
        { "head_blend_data_t", "HeadBlendData" },
        { "head_blend_data_t&", "HeadBlendData*" },
        { "head_overlay_t", "HeadOverlay" },
        { "head_overlay_t&", "HeadOverlay*" },
        { "weapon_t*[]", "WeaponData[]" },
        { "alt::Array<weapon_t>&", "WeaponArray*" },
        { "vector2_t[]", "Vector2[]" },
        { "alt::IConnectionInfo*", "IntPtr" },
        { "ClrVehicleModelInfo*", "nint" },
        { "ClrPedModelInfo*", "nint" },
        { "ClrWeaponModelInfo*", "nint" },
        { "ClrDiscordUser*", "nint" },
        { "ClrConfigNodeData*", "nint" },
        { "ClrAmmoFlags*", "nint" }
    };
}