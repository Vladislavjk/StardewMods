using ContentPatcher;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Buffs;
using StardewValley.GameData.GarbageCans;
using System.Collections.Generic;
using System.Linq;

namespace ExtraBooks // TODO update old items for daggers and rice
{
    internal class ModEntry : Mod
    {
        internal static IMonitor ModMonitor { get; private set; } = null;
        internal static MoreBooksConfig Config { get; private set; } = null;
        internal static IContentPatcherAPI ContentPatcher { get; private set; } = null;
        private static bool garbageCanPatchUsed = false;
        private string immunityBookId = "jeWel.MoreBooks_Book_Immunity";
        private string luckBookId = "jeWel.MoreBooks_Book_Luck";
        private string speedBookId = "jeWel.MoreBooks_Book_Speed";
        private string fishingBookId = "jeWel.MoreBooks_Book_Fishing";
        private string magnetBookId = "jeWel.MoreBooks_Book_Magnet";
        private string lewisShortsBookId = "jeWel.MoreBooks_Book_Lewis_shorts";
        private string carpenterCatalogueId = "jeWel.MoreBooks_Book_Carpenter_Catalogue";
        private string oreCatalogueId = "jeWel.MoreBooks_Book_Ore_Catalogue";
        private string riceBookId = "jeWel.MoreBooks_Book_Rice";
        private string daggerBookId = "jeWel.MoreBooks_Book_Dagger";
        private string greenTeaBookId = "jeWel.MoreBooks_Book_Green_Tea";
        private string garbageCanBookId = "jeWel.MoreBooks_Book_Garbage_Can";
        private Buff immunityBookBuff = new Buff(
                        id: "Immunity_Book_Buff",
                        source: "Immunity Book",
                        displaySource: "Immunity Book",
                        duration: Buff.ENDLESS,
                        effects: new BuffEffects
                        {
                            Immunity = { 1 }
                        }
                    );
        private Buff luckBookBuff = new Buff(
                        id: "Luck_Book_Buff",
                        source: "Lucky Book",
                        displaySource: "Lucky Book",
                        duration: Buff.ENDLESS,
                        effects: new BuffEffects
                        {
                            LuckLevel = { 1 }
                        }
                    );
        private Buff speedBookBuff = new Buff(
                        id: "Speed_Book_Buff",
                        source: "Speed Book",
                        displaySource: "Speed Book",
                        duration: Buff.ENDLESS,
                        effects: new BuffEffects
                        {
                            Speed = { 0.5f },
                            
                        }
                    );
        private Buff fishingBookBuff = new Buff(
                        id: "Fishing_Book_Buff",
                        source: "Fishing Book",
                        displaySource: "Fishing Book",
                        duration: Buff.ENDLESS,
                        effects: new BuffEffects
                        {
                            FishingLevel = { 1 }
                        }
                    );
        private Buff magnetBookBuff = new Buff(
                        id: "Magnet_Book_Buff",
                        source: "Magnet Book",
                        displaySource: "Magnet Book",
                        duration: Buff.ENDLESS,
                        effects: new BuffEffects
                        {
                            MagneticRadius = { 128 }
                        }
                    );

        private void makeBuffsUnvisible()
        {
            immunityBookBuff.visible = false;
            luckBookBuff.visible = false;
            speedBookBuff.visible = false;
            fishingBookBuff.visible = false;
            magnetBookBuff.visible = false;
        }

        public override void Entry(IModHelper helper)
        {
            ModMonitor = Monitor;
            Config = helper.ReadConfig<MoreBooksConfig>();
            makeBuffsUnvisible();
            helper.Events.GameLoop.OneSecondUpdateTicked += this.onSecondTicked;
            helper.Events.GameLoop.DayStarted += this.onDayStart;
            helper.Events.GameLoop.GameLaunched += this.onGameLaunched;
            helper.Events.Content.AssetRequested += this.onAssetRequested;
        }

        private void onSecondTicked(object sender, OneSecondUpdateTickedEventArgs e)
        {

            if (!Context.IsWorldReady)
            {
                return;
            }

            if (Game1.player.stats.Get(immunityBookId) > 0)
            {
                Game1.player.applyBuff(immunityBookBuff);
            }

            if (Game1.player.stats.Get(luckBookId) > 0)
            {
                Game1.player.applyBuff(luckBookBuff);
            }

            if (Game1.player.stats.Get(speedBookId) > 0)
            {
                Game1.player.applyBuff(speedBookBuff);
            }

            if (Game1.player.stats.Get(fishingBookId) > 0)
            {
                Game1.player.applyBuff(fishingBookBuff);
            }

            if (Game1.player.stats.Get(magnetBookId) > 0)
            {
                Game1.player.applyBuff(magnetBookBuff);
            }

            if (Game1.player.stats.Get(garbageCanBookId) > 0 && !garbageCanPatchUsed)
            {
                Helper.GameContent.InvalidateCache("Data/GarbageCans");
                garbageCanPatchUsed = true;
            }

            if (Game1.player.stats.Get(lewisShortsBookId) > 0 && !Config.LewisBookRead)
            {
                Config.LewisBookRead = true;
            }

            if (Game1.player.stats.Get(carpenterCatalogueId) > 0 && !Config.CarpenterCatalogueRead)
            {
                Config.CarpenterCatalogueRead = true;
            }

            if (Game1.player.stats.Get(oreCatalogueId) > 0 && !Config.OreCatalogueRead)
            {
                Config.OreCatalogueRead = true;
            }

            if (Game1.player.stats.Get(riceBookId) > 0 && !Config.RiceBookRead)
            {
                Config.RiceBookRead = true;
            }

            if (Game1.player.stats.Get(daggerBookId) > 0 && !Config.DaggerBookRead)
            {
                Config.DaggerBookRead = true;
            }

            if (Game1.player.stats.Get(greenTeaBookId) > 0 && !Config.GreenTeaBookRead)
            {
                Config.GreenTeaBookRead = true;
            }
        }

        private void onGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            ContentPatcher = Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");
            if (ContentPatcher == null)
            {
                ModMonitor.Log("ContentPatcher not found.", LogLevel.Error);
                return;
            }

            ContentPatcher.RegisterToken(
                mod: ModManifest,
                name: "ConfigLewisBookRead",
                getValue: () =>
                {
                    return new[]
                    {
                        Config.LewisBookRead.ToString()
                    };
                }
            );

            ContentPatcher.RegisterToken(
                mod: ModManifest,
                name: "ConfigCarpenterCatalogueRead",
                getValue: () =>
                {
                    return new[]
                    {
                        Config.CarpenterCatalogueRead.ToString()
                    };
                }
            );

            ContentPatcher.RegisterToken(
                mod: ModManifest,
                name: "ConfigOreCatalogueRead",
                getValue: () =>
                {
                    return new[]
                    {
                        Config.OreCatalogueRead.ToString()
                    };
                }
            );

            ContentPatcher.RegisterToken(
                mod: ModManifest,
                name: "ConfigRiceBookRead",
                getValue: () =>
                {
                    return new[]
                    {
                        Config.RiceBookRead.ToString()
                    };
                }
            );

            ContentPatcher.RegisterToken(
                mod: ModManifest,
                name: "ConfigDaggerBookRead",
                getValue: () =>
                {
                    return new[]
                    {
                        Config.DaggerBookRead.ToString()
                    };
                }
            );

            ContentPatcher.RegisterToken(
                mod: ModManifest,
                name: "ConfigGreenTeaBookRead",
                getValue: () =>
                {
                    return new[]
                    {
                        Config.GreenTeaBookRead.ToString()
                    };
                }
            );
        }

        private void onDayStart(object sender, DayStartedEventArgs e)
        {
            Helper.GameContent.InvalidateCache("Data/GarbageCans");
            garbageCanPatchUsed = false;
            Config.LewisBookRead = false;
            Config.CarpenterCatalogueRead = false;
            Config.OreCatalogueRead = false;
            Config.RiceBookRead = false;
            Config.DaggerBookRead = false;
            Config.GreenTeaBookRead = false;
        }

        private void onAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale.IsEquivalentTo("Data/GarbageCans") && Game1.player.stats.Get(garbageCanBookId) > 0)
            {
                e.Edit(editor =>
                {
                    var gcd = editor.GetData<GarbageCanData>();
                    List<string> garbageCanLocations = new List<string>() 
                    { "Evelyn", "JodiAndKent", "EmilyAndHaley", "Mayor", "Museum", "Blacksmith", "Saloon", "JojaMart" };
                    List<string> garbageItemIds = new List<string>()
                    { "60", "62", "64", "66", "68", "70", "72"};
                    foreach (string location in garbageCanLocations)
                    {
                        foreach (string itemId in garbageItemIds)
                        {
                            gcd.GarbageCans[location].Items.Add(new GarbageCanItemData()
                            {
                                ItemId = itemId,
                                IgnoreBaseChance = true,
                                Condition = "RANDOM 0.01",
                                Id = itemId,
                            });
                        }
                    }
                });
            }
        }
    }
}
