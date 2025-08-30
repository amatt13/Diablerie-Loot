using System;
using System.Collections.Generic;


namespace DiablerieLoot
{
    public class ItemRoller
    {
        // Base Treasure
        public static int BT_TRAP = 1;
        public static int BT_NO_TREASURE = 10;
        public static int BT_HEALING_POTION = 11;
        public static int BT_GOLD = 17;
        public static int BT_ITEM = 20;

        // Trap
        public static int TRAP_FIRE_BOLT = 15;
        public static int TRAP_MISSILE = 19;
        public static int TRAP_GAS = 20;
        public static int TRAP_GAS_CHOKING = 2;
        public static int TRAP_GAS_RANCID = 4;
        public static int TRAP_GAS_STRANGLING = 6;

        // Healing Potion
        public static int HP_MINOR = 5;
        public static int HP_LIGHT = 10;
        public static int HP_HEALING = 20;
        public static int HP_GREATER = 30;
        public static int HP_SUPER = 9999;

        // Item
        public static int ITEM_BASE_ONLY = 15;
        public static int ITEM_PREFIX = 17;
        public static int ITEM_SUFFIX = 19;
        public static int ITEM_PREFIX_AND_SUFFIX = 20;

        public static Main Owner;

        public static ItemDescription RollResult(string treasure_type, int challenge_rating, bool verbose)
        {
            ItemDescription result;
            if (treasure_type == "Container")
            {
                result = BaseTreasure(challenge_rating, verbose);
            }
            else if (treasure_type == "Monster")
            {
                result = Item("Monster", challenge_rating, verbose);
            }
            else if (treasure_type == "Item")
            {
                result = Item("Item", challenge_rating, verbose);
            }
            else if (treasure_type == "Trap")
            {
                result = Trap(challenge_rating, verbose);
            }
            else if (treasure_type == "Healing Potion")
            {
                result = HealingPotion(challenge_rating, verbose);
            }
            else// (treasure_type == "Gold")
                result = Gold(challenge_rating, verbose);

            return result;
        }

        public static ItemDescription BaseTreasure(int challenge_rating, bool verbose)
        {
            ItemDescription result;

            if (verbose)
                Owner.WriteToLog("Generating result for Container");

            var bt_roll = DiceRoller.RandNumber(1, 20, "Base treasure group");
            if (bt_roll <= BT_TRAP)
            {
                result = Trap(challenge_rating, verbose);
            }
            else if (bt_roll <= BT_NO_TREASURE)
            {
                result = new ItemDescription { Item = new Component($"Rolled no treasure (roll = { bt_roll })", null, 0.0f) };
            }
            else if (bt_roll <= BT_HEALING_POTION)
            {
                result = HealingPotion(challenge_rating, verbose);
            }
            else if (bt_roll <= BT_GOLD)
            {
                result = Gold(challenge_rating, verbose);
            }
            else //if (BT_GOLD < bt_roll)
            {
                result = Item("Container", challenge_rating, verbose);
            }

            return result;
        }

        public static ItemDescription Trap(int challenge_rating, bool verbose)
        {
            ItemDescription result;

            if (verbose)
                Owner.WriteToLog("Generating result for Trap");

            var trap_roll = DiceRoller.RandNumber(1, 20, "Trap") + challenge_rating;
            var trapDmgText = "Trap damage";
            if (trap_roll <= TRAP_FIRE_BOLT)
            {
                var fire_dmg = DiceRoller.RandNumber(1, 6, trapDmgText) * challenge_rating;
                result = new ItemDescription { Item = new Component($"Rolled fire trap (roll = { trap_roll })", $"{ fire_dmg } points of fire damage to all within 5 feet, Reflex save (DC 10) for half damage", 0.0f) };
            }
            else if (trap_roll <= TRAP_MISSILE)
            {
                var missile_dmg = DiceRoller.RandNumber(1, 4, trapDmgText) + challenge_rating;
                result = new ItemDescription { Item = new Component($"Rolled missile trap (roll = { trap_roll })", $"{ missile_dmg } points of damage, Reflex save (DC { 10 + challenge_rating }) for half damage", 0.0f) };
            }
            else// if (TRAP_MISSILE > trap_roll)
            {
                var description = $"Rolled gas trap (roll = { trap_roll }) see chapter 2 for details";
                var effect = String.Empty;

                var gasType = DiceRoller.RandNumber(1, 6, "Gas type");
                if (gasType <= TRAP_GAS_CHOKING)
                {
                    effect = "Effect Choking";
                }
                else if (TRAP_GAS_CHOKING < gasType && gasType <= TRAP_GAS_RANCID)
                {
                    effect = "Effect Rancid";
                }
                else if (TRAP_GAS_RANCID < gasType && gasType <= TRAP_GAS_STRANGLING)
                    effect = "Effect Strangling";

                result = new ItemDescription { Item = new Component(description, effect, 0.0f) };
            }

            return result;
        }

        public static ItemDescription HealingPotion(int challenge_rating, bool verbose)
        {
            string description;

            if (verbose)
                Owner.WriteToLog("Generating result for Healing Potion");

            var hpRoll = DiceRoller.RandNumber(1, 20, "Healing potion group") + challenge_rating;
            if (hpRoll <= HP_MINOR)
            {
                description = $"Minor healing potion (roll = { hpRoll })";
            }
            else if (hpRoll <= HP_LIGHT)
            {
                description = $"Light healing potion (roll = { hpRoll })";
            }
            else if (hpRoll <= HP_HEALING)
            {
                description = $"Normal healing potion (roll = { hpRoll })";
            }
            else if (hpRoll <= HP_GREATER)
            {
                description = $"Greater healing potion (roll = { hpRoll })";
            }
            else //if (HP_GREATER < hpRoll)
                description = $"Super Healing potion (roll = { hpRoll })";

            return new ItemDescription { Item = new Component(description, String.Empty, 0.0f) };
        }

        public static ItemDescription Gold(int challenge_rating, bool verbose)
        {
            if (verbose)
                Owner.WriteToLog("Generating result for Gold");

            var gold_roll = DiceRoller.RandNumber(1, 20, "Gold");
            float gold_amount = gold_roll * challenge_rating * 25;
            var effect = gold_amount == 0.0f ? "No gp rolled" : String.Empty;

            var result = new ItemDescription { Item = new Component("Rolled gp", effect, gold_amount) };

            return result;
        }

        public static ItemDescription Item(string param, int challenge_rating, bool verbose)
        {
            if (verbose)
                Owner.WriteToLog("Generating result for " + param);

            bool prefix = false, suffix = false;
            var item_quality_roll = DiceRoller.RandNumber(1, 20, "Item quality") + challenge_rating;
            if (ITEM_BASE_ONLY < item_quality_roll && item_quality_roll <= ITEM_PREFIX)
            {
                prefix = true;
            }
            else if (item_quality_roll <= ITEM_SUFFIX)
            {
                suffix = true;
            }
            else if (item_quality_roll > ITEM_SUFFIX)
            {
                prefix = true;
                suffix = true;
            }

            if (verbose)
                Owner.WriteToLog($"Item quality roll = { item_quality_roll }");

            return DiablerieLoot.Item.GetItem(challenge_rating, prefix, suffix, verbose);
        }

        public static List<ItemDescription> Start(Main owner, bool manuelDiceRoll, bool verbose, int challengeRating, string treasureType, int repeat)
        {
            Owner = owner;
            var result = new List<ItemDescription>();
            DiceRoller.ManuelRoll = manuelDiceRoll;

            if (verbose)
            {
                owner.WriteToLog("verbosity turned on");
                Owner.WriteToLog($"cr = { challengeRating }, type = { treasureType }, n = { repeat }");
            }

            for (var i = 0; i < repeat; i++)
            {
                var roll = RollResult(treasureType, challengeRating, verbose);
                Owner.WriteToLog(roll);
                Owner.WriteToLog(String.Empty);
                result.Add(roll);
            }

            return result;
        }
    }
}
