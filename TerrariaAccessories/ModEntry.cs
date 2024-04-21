using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Buffs;

namespace TerrariaAccessories
{
    internal sealed class ModEntry : Mod
    {
        private string ankletOfTheWindId = "jeWel.TerrariaAccessories_Anklet_Of_The_Wind";
        private string hermesBootsId = "jeWel.TerrariaAccessories_Hermes_Boots";
        private string bandOfRegenerationId = "jeWel.TerrariaAccessories_Band_Of_Regeneration";
        private string cobaltShieldId = "jeWel.TerrariaAccessories_Cobalt_Shield";
        private string crossNecklaceId = "jeWel.TerrariaAccessories_Cross_Necklace";
        private string eyeOfTheGolemId = "jeWel.TerrariaAccessories_Eye_of_the_Golem";
        private string feralClawsId = "jeWel.TerrariaAccessories_Feral_Claws";
        private string luckyHorseshoeId = "jeWel.TerrariaAccessories_Lucky_Horseshoe";
        private string obsidianSkullId = "jeWel.TerrariaAccessories_Obsidian_Skull";
        private string obsidianShieldId = "jeWel.TerrariaAccessories_Obsidian_Shield";
        private string mechanicalGloveId = "jeWel.TerrariaAccessories_Mechanical_Glove";
        private string powerGloveId = "jeWel.TerrariaAccessories_Power_Glove";
        private string titanGloveId = "jeWel.TerrariaAccessories_Titan_Glove";
        private string shackleId = "jeWel.TerrariaAccessories_Shackle";
        private string avengerEmblemId = "jeWel.TerrariaAccessories_Avenger_Emblem";
        private string destroyerEmblemId = "jeWel.TerrariaAccessories_Destroyer_Emblem";
        private string obsidianHorseshoeId = "jeWel.TerrariaAccessories_Obsidian_Horseshoe";
        private string magicConchId = "(O)jeWel.TerrariaAccessories_Magic_Conch";
        private bool activeHermesBootsBuff = false;
        private bool activeAnkletOfTheWindBuff = false;
        private bool activeCobaltShieldBuff = false;
        private bool activeEyeOfTheGolemBuff = false;
        private bool activeFeralClawsBuff = false;
        private bool activeLuckyHorseshoeBuff = false;
        private bool activeObsidianSkullBuff = false;
        private bool activeObsidianShieldBuff = false;
        private bool activeMechanicalGloveBuff = false;
        private bool activePowerGloveBuff = false;
        private bool activeTitanGloveBuff = false;
        private bool activeShackleBuff = false;
        private bool activeAvengerEmblemBuff = false;
        private bool activeDestroyerEmblemBuff = false;
        private bool activeObsidianHorseshoeBuff = false;
        private float currentHealthBuff = 0f;
        public Buff hermesBootsBuff = new Buff(
                        id: "Hermes_Boots_Buff",
                        source: "Hermes Boots",
                        displaySource: "Hermes Boots",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            Speed = { 1 }
                        }
                    );
        public Buff ankletOfTheWindBuff = new Buff(
                        id: "Anklet_Of_The_Wind_Buff",
                        source: "Anklet of the Wind",
                        displaySource: "Anklet of the Wind",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            Speed = { 0.5f }
                        }
                    );
        public Buff cobaltShieldBuff = new Buff(
                        id: "Cobalt_Shield_Buff",
                        source: "Cobalt Shield",
                        displaySource: "Cobalt Shield",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            Defense = { 3 },
                            Immunity = { 2 }
                        }
                    );
        public Buff eyeOfTheGolemBuff = new Buff(
                        id: "Eye_of_the_Golem_Buff",
                        source: "Eye of the Golem",
                        displaySource: "Eye of the Golem",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            CriticalChanceMultiplier = { 0.2f }
                        }
                    );
        public Buff feralClawsBuff = new Buff(
                        id: "Feral_Claws_Buff",
                        source: "Feral Claws",
                        displaySource: "Feral Claws",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            WeaponSpeedMultiplier = { 0.2f }
                        }
                    );
        public Buff luckyHorseshoeBuff = new Buff(
                        id: "Lucky_Horseshoe_Buff",
                        source: "Lucky Horseshoe",
                        displaySource: "Lucky Horseshoe",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            LuckLevel = {2}
                        }
                    );
        public Buff obsidianSkullBuff = new Buff(
                        id: "Obsidian_Skull_Buff",
                        source: "Obsidian Skull",
                        displaySource: "Obsidian Skull",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            Defense = { 2 },
                            Immunity = { 1 }
                        }
                    );
        public Buff obsidianShieldBuff = new Buff(
                        id: "Obsidian_Shield_Buff",
                        source: "Obsidian Shield",
                        displaySource: "Obsidian Shield",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            Defense = { 5 },
                            Immunity = { 3 }
                        }
                    );
        public Buff mechanicalGloveBuff = new Buff(
                        id: "Mechanical_Glove_Buff",
                        source: "Mechanical Glove",
                        displaySource: "Mechanical Glove",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            AttackMultiplier = {0.2f},
                            WeaponSpeedMultiplier = {0.2f},
                            KnockbackMultiplier = {0.4f}
                        }
                    );
        public Buff powerGloveBuff = new Buff(
                        id: "Power_Glove_Buff",
                        source: "Power Glove",
                        displaySource: "Power Glove",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            WeaponSpeedMultiplier = { 0.2f },
                            KnockbackMultiplier = { 0.4f }
                        }
                    );
        public Buff titanGloveBuff = new Buff(
                        id: "Titan_Glove_Buff",
                        source: "Titan Glove",
                        displaySource: "Titan Glove",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            KnockbackMultiplier = { 0.4f }
                        }
                    );
        public Buff shackleBuff = new Buff(
                        id: "Shackle_Buff",
                        source: "Shackle",
                        displaySource: "Shackle",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            Defense = {2}
                        }
                    );
        public Buff avengerEmblemBuff = new Buff(
                        id: "Avenger_Emblem_Buff",
                        source: "Avenger Emblem",
                        displaySource: "Avenger Emblem",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            AttackMultiplier = {0.2f}
                        }
                    );
        public Buff destroyerEmblemBuff = new Buff(
                        id: "Destroyer_Emblem_Buff",
                        source: "Destroyer Emblem",
                        displaySource: "Destroyer Emblem",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            AttackMultiplier = { 0.2f },
                            CriticalChanceMultiplier = {0.2f}
                        }
                    );
        public Buff obsidianHorseshoeBuff = new Buff(
                        id: "Obsidian_Horseshoe_Buff",
                        source: "Obsidian Horseshoe",
                        displaySource: "Obsidian Horseshoe",
                        duration: 1,
                        effects: new BuffEffects
                        {
                            LuckLevel = {2},
                            Defense = {2},
                            Immunity = {1}
                        }
                    );
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.GameLoop.DayStarted += this.onDayStarted;
            helper.Events.GameLoop.OneSecondUpdateTicked += this.onEverySecond;
        }

        private void handleBuff(ref bool isActiveBuff, bool noItemCondition, bool neededItemCondition, Buff buff)
        {
            if (!isActiveBuff && noItemCondition)
            {
                return;
            }
            else if (noItemCondition)
            {
                buff.millisecondsDuration = 1;
                Game1.player.applyBuff(buff);
                isActiveBuff = false;
                return;
            }
            else if (neededItemCondition)
            {
                if (isActiveBuff) return;
                buff.millisecondsDuration = Buff.ENDLESS;
                isActiveBuff = true;
            }
            else
            {
                if (!isActiveBuff) return;
                buff.millisecondsDuration = 1;
                isActiveBuff = false;
            }

            Game1.player.applyBuff(buff);
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            handleBuff(ref activeHermesBootsBuff,
                Game1.player.boots.Value == null,
                Game1.player.boots.Value == null ? false : Game1.player.boots.Value.ItemId == hermesBootsId,
                hermesBootsBuff);

            handleBuff(ref activeAnkletOfTheWindBuff,
                !Game1.player.isWearingRing(ankletOfTheWindId),
                Game1.player.isWearingRing(ankletOfTheWindId),
                ankletOfTheWindBuff);

            handleBuff(ref activeCobaltShieldBuff,
                !Game1.player.isWearingRing(cobaltShieldId),
                Game1.player.isWearingRing(cobaltShieldId),
                cobaltShieldBuff);

            handleBuff(ref activeEyeOfTheGolemBuff,
                !Game1.player.isWearingRing(eyeOfTheGolemId),
                Game1.player.isWearingRing(eyeOfTheGolemId),
                eyeOfTheGolemBuff);

            handleBuff(ref activeFeralClawsBuff,
                !Game1.player.isWearingRing(feralClawsId),
                Game1.player.isWearingRing(feralClawsId),
                feralClawsBuff);

            handleBuff(ref activeLuckyHorseshoeBuff,
                !Game1.player.isWearingRing(luckyHorseshoeId),
                Game1.player.isWearingRing(luckyHorseshoeId),
                luckyHorseshoeBuff);

            handleBuff(ref activeObsidianSkullBuff,
                !Game1.player.isWearingRing(obsidianSkullId),
                Game1.player.isWearingRing(obsidianSkullId),
                obsidianSkullBuff);

            handleBuff(ref activeObsidianShieldBuff,
                !Game1.player.isWearingRing(obsidianShieldId),
                Game1.player.isWearingRing(obsidianShieldId),
                obsidianShieldBuff);

            handleBuff(ref activeMechanicalGloveBuff,
                !Game1.player.isWearingRing(mechanicalGloveId),
                Game1.player.isWearingRing(mechanicalGloveId),
                mechanicalGloveBuff);

            handleBuff(ref activePowerGloveBuff,
                !Game1.player.isWearingRing(powerGloveId),
                Game1.player.isWearingRing(powerGloveId),
                powerGloveBuff);

            handleBuff(ref activeTitanGloveBuff,
                !Game1.player.isWearingRing(titanGloveId),
                Game1.player.isWearingRing(titanGloveId),
                titanGloveBuff);

            handleBuff(ref activeShackleBuff,
                !Game1.player.isWearingRing(shackleId),
                Game1.player.isWearingRing(shackleId),
                shackleBuff);

            handleBuff(ref activeAvengerEmblemBuff,
                !Game1.player.isWearingRing(avengerEmblemId),
                Game1.player.isWearingRing(avengerEmblemId),
                avengerEmblemBuff);

            handleBuff(ref activeDestroyerEmblemBuff,
                !Game1.player.isWearingRing(destroyerEmblemId),
                Game1.player.isWearingRing(destroyerEmblemId),
                destroyerEmblemBuff);

            handleBuff(ref activeObsidianHorseshoeBuff,
                !Game1.player.isWearingRing(obsidianHorseshoeId),
                Game1.player.isWearingRing(obsidianHorseshoeId),
                obsidianHorseshoeBuff);

            if (!Context.CanPlayerMove || Game1.player.ActiveItem == null)
            {
                return;
            }

            if (Game1.player.ActiveItem.QualifiedItemId == magicConchId && e.Button.IsUseToolButton())
            {
                Game1.warpFarmer("Beach", 24, 32, false);
            }
        }

        private void onEverySecond(object sender, OneSecondUpdateTickedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (Game1.player.isWearingRing(crossNecklaceId))
            {
                Game1.player.currentTemporaryInvincibilityDuration = 3200;
            }

            if (Game1.player.isWearingRing(bandOfRegenerationId))
            {
                currentHealthBuff += 0.1f;
                if (currentHealthBuff >= 1f)
                {
                    Game1.player.health += 1;
                    currentHealthBuff = 0f;
                }
            }

            //Monitor.Log(Game1.player.buffs.AttackMultiplier.ToString(), LogLevel.Debug);
            //Monitor.Log(Game1.player.buffs.WeaponSpeedMultiplier.ToString(), LogLevel.Debug);
            //Monitor.Log(Game1.player.buffs.KnockbackMultiplier.ToString(), LogLevel.Debug);
            //Monitor.Log(Game1.player.buffs.CriticalChanceMultiplier.ToString(), LogLevel.Debug);
            //Monitor.Log(Game1.player.buffs.Defense.ToString(), LogLevel.Debug);
            //Monitor.Log(Game1.player.buffs.Immunity.ToString(), LogLevel.Debug);
            //Monitor.Log(Game1.player.buffs.LuckLevel.ToString(), LogLevel.Debug);
        }

        private void onDayStarted(object sender, DayStartedEventArgs e)
        {
            if (activeHermesBootsBuff)
            {
                Game1.player.applyBuff(hermesBootsBuff);
            }

            if (activeAnkletOfTheWindBuff)
            {
                Game1.player.applyBuff(ankletOfTheWindBuff);
            }

            if (activeCobaltShieldBuff)
            {
                Game1.player.applyBuff(cobaltShieldBuff);
            }

            if (activeEyeOfTheGolemBuff)
            {
                Game1.player.applyBuff(eyeOfTheGolemBuff);
            }

            if (activeFeralClawsBuff)
            {
                Game1.player.applyBuff(feralClawsBuff);
            }

            if (activeLuckyHorseshoeBuff)
            {
                Game1.player.applyBuff(luckyHorseshoeBuff);
            }

            if (activeObsidianSkullBuff)
            {
                Game1.player.applyBuff(obsidianSkullBuff);
            }

            if (activeObsidianShieldBuff)
            {
                Game1.player.applyBuff(obsidianShieldBuff);
            }

            if (activeMechanicalGloveBuff)
            {
                Game1.player.applyBuff(mechanicalGloveBuff);
            }

            if (activePowerGloveBuff)
            {
                Game1.player.applyBuff(powerGloveBuff);
            }

            if (activeTitanGloveBuff)
            {
                Game1.player.applyBuff(titanGloveBuff);
            }

            if (activeShackleBuff)
            {
                Game1.player.applyBuff(shackleBuff);
            }

            if (activeAvengerEmblemBuff)
            {
                Game1.player.applyBuff(avengerEmblemBuff);
            }

            if (activeDestroyerEmblemBuff)
            {
                Game1.player.applyBuff(destroyerEmblemBuff);
            }

            if (activeObsidianHorseshoeBuff)
            {
                Game1.player.applyBuff(obsidianHorseshoeBuff);
            }
        }
    }

}
