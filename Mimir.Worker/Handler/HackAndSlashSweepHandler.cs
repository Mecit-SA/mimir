using Lib9c.Abstractions;
using Libplanet.Action;
using Mimir.Worker.CollectionUpdaters;
using Mimir.Worker.Services;
using Nekoyume.Model.EnumType;
using Serilog;

namespace Mimir.Worker.Handler;

public class HackAndSlashSweepHandler(IStateService stateService, MongoDbService store) :
    BaseActionHandler(
        stateService,
        store,
        "^hack_and_slash_sweep[0-9]*$",
        Log.ForContext<HackAndSlashSweepHandler>())
{
    protected override async Task HandleAction(long blockIndex, IAction action)
    {
        if (action is not IHackAndSlashSweepV3 hackAndSlashSweep)
        {
            throw new NotImplementedException(
                $"Action is not {nameof(IHackAndSlashSweepV3)}: {action.GetType()}");
        }

        await ItemSlotCollectionUpdater.UpdateAsync(
            Store,
            BattleType.Adventure,
            hackAndSlashSweep.AvatarAddress,
            hackAndSlashSweep.Costumes,
            hackAndSlashSweep.Equipments);
    }
}
