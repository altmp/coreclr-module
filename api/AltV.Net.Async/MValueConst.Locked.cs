using System.Collections;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static class MValueConstLocked
    {
        public static void CreateLocked(IPlayer player, out MValueConst mValue)
        {
            lock (player)
            {
                if (!player.Exists)
                {
                    mValue = MValueConst.Nil;
                    return;
                }

                Alt.Server.CreateMValuePlayer(out mValue, player);
            }
        }

        public static void CreateLocked(IVehicle vehicle, out MValueConst mValue)
        {
            lock (vehicle)
            {
                if (!vehicle.Exists)
                {
                    mValue = MValueConst.Nil;
                    return;
                }

                Alt.Server.CreateMValueVehicle(out mValue, vehicle);
            }
        }

        public static void CreateLocked(IBlip blip, out MValueConst mValue)
        {
            lock (blip)
            {
                if (!blip.Exists)
                {
                    mValue = MValueConst.Nil;
                    return;
                }

                Alt.Server.CreateMValueBlip(out mValue, blip);
            }
        }

        public static void CreateLocked(ICheckpoint checkpoint, out MValueConst mValue)
        {
            lock (checkpoint)
            {
                if (!checkpoint.Exists)
                {
                    mValue = MValueConst.Nil;
                    return;
                }

                Alt.Server.CreateMValueCheckpoint(out mValue, checkpoint);
            }
        }

        public static void CreateFromObjectLocked(object obj, out MValueConst mValue)
        {
            if (obj == null)
            {
                mValue = MValueConst.Nil;
                return;
            }

            int i;

            string[] dictKeys;
            MValueConst[] dictValues;
            MValueWriter2 writer;

            switch (obj)
            {
                case IPlayer player:
                    CreateLocked(player, out mValue);
                    return;
                case IVehicle vehicle:
                    CreateLocked(vehicle, out mValue);
                    return;
                case IBlip blip:
                    CreateLocked(blip, out mValue);
                    return;
                case ICheckpoint checkpoint:
                    CreateLocked(checkpoint, out mValue);
                    return;
                case bool value:
                    Alt.Server.CreateMValueBool(out mValue, value);
                    return;
                case int value:
                    Alt.Server.CreateMValueInt(out mValue, value);
                    return;
                case uint value:
                    Alt.Server.CreateMValueUInt(out mValue, value);
                    return;
                case long value:
                    Alt.Server.CreateMValueInt(out mValue, value);
                    return;
                case ulong value:
                    Alt.Server.CreateMValueUInt(out mValue, value);
                    return;
                case double value:
                    Alt.Server.CreateMValueDouble(out mValue, value);
                    return;
                case float value:
                    Alt.Server.CreateMValueDouble(out mValue, value);
                    return;
                case string value:
                    Alt.Server.CreateMValueString(out mValue, value);
                    return;
                case MValueConst value:
                    mValue = value;
                    return;
                case MValueConst[] value:
                    Alt.Server.CreateMValueList(out mValue, value, (ulong) value.Length);
                    return;
                case Invoker value:
                    Alt.Server.CreateMValueFunction(out mValue, value.NativePointer);
                    return;
                case MValueFunctionCallback value:
                    Alt.Server.CreateMValueFunction(out mValue, Alt.Server.Resource.CSharpResourceImpl.CreateInvoker(value));
                    return;
                case Net.Function function:
                    Alt.Server.CreateMValueFunction(out mValue,
                        Alt.Server.Resource.CSharpResourceImpl.CreateInvoker(function.call));
                    return;
                case IDictionary dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        if (key is string stringKey)
                        {
                            dictKeys[i++] = stringKey;
                        }
                        else
                        {
                            mValue = MValueConst.Nil;
                            return;
                        }
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        Alt.Server.CreateMValue(out var elementMValue, value);
                        dictValues[i++] = elementMValue;
                    }
                    
                    Alt.Server.CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictionary.Count; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }
                    return;
                case ICollection collection:
                    var length = (ulong) collection.Count;
                    var listValues = new MValueConst[length];
                    i = 0;
                    foreach (var value in collection)
                    {
                        Alt.Server.CreateMValue(out var elementMValue, value);
                        listValues[i++] = elementMValue;
                    }
                    
                    Alt.Server.CreateMValueList(out mValue, listValues, length);
                    for (ulong j = 0; j < length; j++)
                    {
                        listValues[j].Dispose();
                    }
                    return;
                case IDictionary<string, object> dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        dictKeys[i++] = key;
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        Alt.Server.CreateMValue(out var elementMValue, value);
                        dictValues[i++] = elementMValue;
                    }
                    
                    Alt.Server.CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictValues.Length; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }
                    return;
                case IWritable writable:
                    writer = new MValueWriter2();
                    writable.OnWrite(writer);
                    writer.ToMValue(out mValue);
                    return;
                case IMValueConvertible convertible:
                    writer = new MValueWriter2();
                    convertible.GetAdapter().ToMValue(obj, writer);
                    writer.ToMValue(out mValue);
                    return;
                case Position position:
                    var posValues = new MValueConst[3];
                    MValueConst positionMValue;
                    Alt.Server.CreateMValueDouble(out positionMValue, position.X);
                    posValues[0] = positionMValue;
                    Alt.Server.CreateMValueDouble(out positionMValue, position.Y);
                    posValues[1] = positionMValue;
                    Alt.Server.CreateMValueDouble(out positionMValue, position.Z);
                    posValues[2] = positionMValue;
                    var posKeys = new string[3];
                    posKeys[0] = "x";
                    posKeys[1] = "y";
                    posKeys[2] = "z";
                    Alt.Server.CreateMValueDict(out mValue, posKeys, posValues, 3);
                    for (int j = 0, dictLength = posValues.Length; j < dictLength; j++)
                    {
                        posValues[j].Dispose();
                    }
                    return;
                case Rotation rotation:
                    var rotValues = new MValueConst[3];
                    MValueConst rotationMValue;
                    Alt.Server.CreateMValueDouble(out rotationMValue, rotation.Roll);
                    rotValues[0] = rotationMValue;
                    Alt.Server.CreateMValueDouble(out rotationMValue, rotation.Pitch);
                    rotValues[1] = rotationMValue;
                    Alt.Server.CreateMValueDouble(out rotationMValue, rotation.Yaw);
                    rotValues[2] = rotationMValue;
                    var rotKeys = new string[3];
                    rotKeys[0] = "roll";
                    rotKeys[1] = "pitch";
                    rotKeys[2] = "yaw";
                    Alt.Server.CreateMValueDict(out mValue, rotKeys, rotValues, 3);
                    for (int j = 0, dictLength = rotValues.Length; j < dictLength; j++)
                    {
                        rotValues[j].Dispose();
                    }
                    return;
                case short value:
                    Alt.Server.CreateMValueInt(out mValue, value);
                    return;
                case ushort value:
                    Alt.Server.CreateMValueUInt(out mValue, value);
                    return;
                default:
                    Alt.Log("can't convert type:" + obj.GetType());
                    mValue = MValueConst.Nil;
                    return;
            }
        }

        internal static void CreateFromObjectsLocked(object[] objects, MValueConst[] mValues)
        {
            var length = objects.Length;
            for (var i = 0; i < length; i++)
            {
                CreateFromObjectLocked(objects[i], out var mValueElement);
                mValues[i] = mValueElement;
            }
        }
    }
}