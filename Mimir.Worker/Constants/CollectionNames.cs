using Mimir.Worker.Models;
using Mimir.Worker.Models.State.AdventureBoss;

namespace Mimir.Worker.Constants
{
    public static class CollectionNames
    {
        public static readonly Dictionary<Type, string> CollectionMappings = new();

        static CollectionNames()
        {
            CollectionMappings.Add(typeof(AgentState), "agent");
            CollectionMappings.Add(typeof(AvatarState), "avatar");
            CollectionMappings.Add(typeof(InventoryState), "inventory");
            CollectionMappings.Add(typeof(QuestListState), "quest_list");
            CollectionMappings.Add(typeof(WorldInformationState), "world_information");
            CollectionMappings.Add(typeof(ActionPointState), "action_point");
            CollectionMappings.Add(typeof(SheetState), "table_sheet");
            CollectionMappings.Add(typeof(ArenaScoreState), "arena_score");
            CollectionMappings.Add(typeof(ArenaInformationState), "arena_information");
            CollectionMappings.Add(typeof(AllRuneState), "all_rune");
            CollectionMappings.Add(typeof(CollectionState), "collection");
            CollectionMappings.Add(typeof(DailyRewardState), "daily_reward");
            CollectionMappings.Add(typeof(ProductsState), "products");
            CollectionMappings.Add(typeof(ProductState), "product");
            CollectionMappings.Add(typeof(ItemSlotState), "item_slot");
            CollectionMappings.Add(typeof(RuneSlotState), "rune_slot");
            CollectionMappings.Add(typeof(WorldBossState), "world_boss");
            CollectionMappings.Add(
                typeof(WorldBossKillRewardRecordState),
                "world_boss_kill_reward_record"
            );
            CollectionMappings.Add(typeof(RaiderState), "raider");
            CollectionMappings.Add(typeof(StakeState), "stake");
            CollectionMappings.Add(typeof(CombinationSlotState), "combination_slot");
            CollectionMappings.Add(typeof(PetState), "pet_state");
            CollectionMappings.Add(typeof(BountyBoardState), "adventure_boss_bounty_board");
            CollectionMappings.Add(typeof(ExploreBoardState), "adventure_boss_explore_board");
            CollectionMappings.Add(typeof(ExplorerListState), "adventure_boss_explorer_list");
            CollectionMappings.Add(typeof(ExplorerState), "adventure_boss_explorer");
            CollectionMappings.Add(typeof(SeasonInfoState), "adventure_boss_season_info");

            // The `Raw` fields of the documents' in 'balances' collection,
            // will not have the original state.  In Libplanet implementation,
            // each currency has an account trie. And their states' raw value
            // may be `Bencodex.Types.Integer`-typed. But `BalanceState` stores
            // serialized `FungibleAssetValue` instead of `Integer` to query
            // easily without fetching `Currency` from other source.
            CollectionMappings.Add(typeof(BalanceState), "balances");
        }

        public static string GetCollectionName<T>()
        {
            if (!CollectionMappings.TryGetValue(typeof(T), out var collectionName))
            {
                throw new InvalidOperationException(
                    $"No collection mapping found for state type: {typeof(T).Name}"
                );
            }

            return collectionName;
        }

        public static string GetCollectionName(Type type)
        {
            if (!CollectionMappings.TryGetValue(type, out var collectionName))
            {
                throw new InvalidOperationException(
                    $"No collection mapping found for state type: {type.Name}"
                );
            }

            return collectionName;
        }
    }
}
