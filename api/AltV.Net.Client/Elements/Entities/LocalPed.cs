using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class LocalPed : Ped, ILocalPed
{
    public IntPtr LocalPedNativePointer { get; }
    public override IntPtr NativePointer => LocalPedNativePointer;

    private static IntPtr GetPedPointer(ICore core, IntPtr nativePointer)
    {
        unsafe
        {
            return core.Library.Client.LocalPed_GetPed(nativePointer);
        }
    }

    public LocalPed(ICore core, IntPtr nativePointer, uint id) : base(core, GetPedPointer(core, nativePointer), BaseObjectType.LocalPed, id)
    {
        LocalPedNativePointer = nativePointer;
    }

    public uint Model
    {
        get
        {
            return base.Model;
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.LocalPed_SetModel(LocalPedNativePointer, value);
            }
        }
    }

    public uint StreamingDistance
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.LocalPed_GetStreamingDistance(LocalPedNativePointer);
            }
        }
    }

    public bool Visible
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.LocalPed_IsVisible(LocalPedNativePointer) == 1;
            }
        }
        set
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.LocalPed_SetVisible(LocalPedNativePointer, value ? (byte)1:(byte)0);
            }
        }
    }

    public bool IsStreamedIn
    {
        get
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Client.LocalPed_IsStreamedIn(LocalPedNativePointer) == 1;
            }
        }
    }
}