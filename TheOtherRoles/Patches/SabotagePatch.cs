using HarmonyLib;
using Hazel;

namespace TheOtherRoles.Patches
{
    [HarmonyPatch(typeof(HeliSabotageSystem), nameof(HeliSabotageSystem.RepairDamage))]
    class HeliSabotageSystemRepairDamagePatch
    {
        static void Postfix(HeliSabotageSystem __instance, PlayerControl player, byte amount)
        {
            HeliSabotageSystem.Tags tags = (HeliSabotageSystem.Tags)(amount & 240);
            if (tags != HeliSabotageSystem.Tags.ActiveBit)
            {
                if (tags == HeliSabotageSystem.Tags.DamageBit)
                {
                    __instance.Countdown = CustomOptionHolder.airshipReactorDuration.getFloat();
                }
            }
        }
    }

    [HarmonyPatch(typeof(ReactorSystemType), nameof(ReactorSystemType.RepairDamage))]
    class ReactorMiniGameRepairPatch
    {
        static void Postfix(ReactorSystemType __instance)
        {
            __instance.Countdown = CustomOptionHolder.ReactorDuration.getFloat();
        }
    }
}