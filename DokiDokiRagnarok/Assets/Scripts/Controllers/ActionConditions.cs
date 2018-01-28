namespace DokiDokiRagnarok.Controllers
{
    public enum ActionConditions
    {
        IsHappy = 1,
        MeadEqualsZero = 2,
        MeadGreaterZero = 4,
        MeadGreaterTwo = 8,
        IsSweatDrop = 16,
        IsAngry = 32,
        OdinEqualsZero = 64,
        OdinEqualsOne = 128,
        OdinGreaterZero = 256,
        OdinGreaterOne = 512,
        IsNotAngry = 1024,
        AttackedEnglandWhileAngry = 2048,
        AttackedEnglandWhileSweatDrop = 4096,
        IsShy = 8192,
        IsNotSweatDrop = 16384,
        AttackedEnglandEqualsZero = 32768,
        AttackedEnglandEqualsOne = 65536,
        AttackedEnglandGreaterOne = 131072,
        IsShyAndDrunk = IsShy | MeadGreaterZero,
        IsHappyAndDrunk = IsHappy | MeadGreaterZero,
        None = 262144,
        
    }
}