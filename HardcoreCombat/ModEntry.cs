﻿using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Buffs;
using System.Collections.Generic;
using System.Linq;

namespace HardcoreCombat
{
    internal class ModEntry : Mod
    {
        private HardcoreCombatConfig config;
        private Dictionary<int, string> difficultiesRanges = new Dictionary<int, string>();
        private List<Translation> translations = new List<Translation>();
        public Buff chillDifficultyBuff = new Buff(
                        id: "Chill_Difficulty_Buff",
                        source: "Relax and kill everyone, you are god (+100 defense, +10 immunity, x5 damage)",
                        displaySource: "Relax and kill everyone, you are god (+100 defense, +10 immunity, x5 damage)",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            Defense = { 100 },
                            Immunity = { 10 },
                            AttackMultiplier = { 5 },
                            WeaponSpeedMultiplier = { 5 },
                            KnockbackMultiplier = { 5 }
                        }
                    );
        public Buff easyDifficultyBuff = new Buff(
                        id: "Easy_Difficulty_Buff",
                        source: "Slightly easier to play (+5 defense, +20% damage)",
                        displaySource: "Slightly easier to play (+5 defense, +20% damage)",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            Defense = { 5 },
                            AttackMultiplier = { 0.2f }
                        }
                    );

        public override void Entry(IModHelper helper)
        {
            config = helper.ReadConfig<HardcoreCombatConfig>();
            config.getCombatDifficultiesRanges(out difficultiesRanges);
            translations = helper.Translation.GetTranslations().ToList();
            changeBuffsDisplayText();
            helper.Events.GameLoop.GameLaunched += this.onGameLoaded;
            helper.Events.GameLoop.OneSecondUpdateTicked += this.onUpdateTicked;
            helper.Events.Content.LocaleChanged += this.onLocaleChanged;
        }

        private void changeBuffsDisplayText()
        {
            chillDifficultyBuff.displaySource = translations[2];
            easyDifficultyBuff.displaySource = translations[3];
        }

        private void onUpdateTicked(object sender, OneSecondUpdateTickedEventArgs e)
        {
            if (!Context.IsWorldReady)
            {
                return;
            }

            if (!Game1.player.currentLocation.DisplayName.Contains("UndergroundMine") &&
                !Game1.player.currentLocation.DisplayName.Contains("VolcanoDungeon") &&
                Game1.player.currentLocation.DisplayName != "BugLand")
            {
                return;
            }

            if (config.difficulty == translations[4])
            {
                chillDifficultyBuff.millisecondsDuration = Buff.ENDLESS;
                Game1.player.applyBuff(chillDifficultyBuff);
                Game1.player.applyBuff(Buff.yobaBlessing);
            }
            else
            {
                chillDifficultyBuff.millisecondsDuration = 1;
                Game1.player.applyBuff(chillDifficultyBuff);
            }

            if (config.difficulty == translations[5])
            {
                easyDifficultyBuff.millisecondsDuration = Buff.ENDLESS;
                Game1.player.applyBuff(easyDifficultyBuff);
            }
            else
            {
                easyDifficultyBuff.millisecondsDuration = 1;
                Game1.player.applyBuff(easyDifficultyBuff);
            }

            if (config.difficulty == translations[7])
            {
                Game1.player.applyBuff("14");
            }

            if (config.difficulty == translations[8])
            {
                Game1.player.applyBuff("14");
                Game1.player.applyBuff(Buff.spawnMonsters);
                Game1.player.applyBuff(Buff.fear);
            }

            if (config.difficulty == translations[9])
            {
                Game1.player.applyBuff(Buff.fear);
                Game1.player.applyBuff(Buff.darkness);
                Game1.player.applyBuff(Buff.spawnMonsters);
                Game1.player.applyBuff("14");
            }

            if (config.difficulty == translations[10])
            {
                Game1.player.applyBuff(Buff.weakness);
                Game1.player.applyBuff(Buff.darkness);
                Game1.player.applyBuff(Buff.spawnMonsters);
                Game1.player.applyBuff(Buff.tipsy);
                Game1.player.applyBuff("14");
            }

            if (config.difficulty == translations[11])
            {
                Game1.player.applyBuff(Buff.nauseous);
                Game1.player.applyBuff(Buff.darkness);
                Game1.player.applyBuff(Buff.weakness);
                Game1.player.applyBuff(Buff.spawnMonsters);
                Game1.player.applyBuff("14");
                Game1.player.applyBuff("12");
            }
        }

        private void onGameLoaded(object sender, GameLaunchedEventArgs e)
        {
            RegisterWithGmcm();
        }

        private void onLocaleChanged(object sender, LocaleChangedEventArgs e)
        {
            translations = Helper.Translation.GetTranslations().ToList();
            changeBuffsDisplayText();
            UnregisterMenu();
            config.difficulty = translations[6];
            RegisterWithGmcm();
        }

        private void RegisterWithGmcm()
        {
            var configMenuApi = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");

            if (configMenuApi != null)
            {
                configMenuApi.Register(this.ModManifest,
                    () => this.config = new HardcoreCombatConfig(),
                    () => this.Helper.WriteConfig(this.config));

                configMenuApi.AddSectionTitle(
                    this.ModManifest,
                    () => translations[0]);

                configMenuApi.AddTextOption(
                    mod: this.ModManifest,
                    name: () => translations[1],
                    getValue: () => this.config.difficulty,
                    setValue: i =>
                    {
                        this.difficultiesRanges[0] = i;
                        this.config.difficulty = i;
                    },
                    allowedValues: new string[] { translations[4], translations[5], translations[6],
                        translations[7], translations[8], translations[9], translations[10], translations[11] }
                );
            }
            else
            {
                Monitor.Log("Generic Mod Config Menu Not Installed", LogLevel.Info);
            }
        }

        private void UnregisterMenu()
        {
            var configMenuApi = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");

            if (configMenuApi != null)
            {
                configMenuApi.Unregister(this.ModManifest);
            }
            else
            {
                Monitor.Log("Generic Mod Config Menu Not Installed", LogLevel.Info);
            }
        }
    }
}
