using StardewModdingAPI.Events;
using StardewModdingAPI;
using StardewValley;
using Microsoft.Xna.Framework;

namespace TeleportationTool
{
    internal sealed class ModEntry : Mod
    {
        private string teleportationToolId = "(O)jeWel.TeleportationToolMod_TeleportationTool";
        private string galaxyTeleportationToolId = "(O)jeWel.TeleportationToolMod_GalaxyTeleportationTool";
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet, in menu or cutscene
            if (!Context.IsWorldReady || !Context.CanPlayerMove || Game1.player.ActiveItem == null)
                return;

            if (Game1.player.ActiveItem.QualifiedItemId == teleportationToolId && e.Button.IsUseToolButton())
            {
                Vector2 teleportationCoordinates = e.Cursor.Tile;
                Game1.warpFarmer(Game1.player.currentLocation.Name,
                    (int) teleportationCoordinates.X,
                    (int) teleportationCoordinates.Y,
                    false);
            }

            if (Game1.player.ActiveItem.QualifiedItemId == galaxyTeleportationToolId && e.Button.IsUseToolButton())
            {
                Game1.player.position.X = e.Cursor.AbsolutePixels.X - 32;
                Game1.player.position.Y = e.Cursor.AbsolutePixels.Y;
            }
        }
    }
}
