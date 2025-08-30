using System;
using System.Collections.Generic;


namespace DiablerieLoot
{
    public static class Suffix
    {
        public static Component GetSuffix(int cr, int startSuffixIndex, int endSuffixIndex)
        {
            Component result;
            var options = Categories();
            var rolled_option = options[DiceRoller.RandNumber(startSuffixIndex - 1, endSuffixIndex - 1, "Suffix group")];
            if (rolled_option == "Reduces damage taken")
            {
                result = ReducesDamageTaken(cr);
            }
            else if (rolled_option == "Has an effect when attacked")
            {
                result = HasAnEffectWhenAttacked(cr);
            }
            else if (rolled_option == "Improves durability")
            {
                result = ImprovesDurability(cr);
            }
            else if (rolled_option == "Affects movement")
            {
                result = AffectsMovement(cr);
            }
            else if (rolled_option == "Increases hit points")
            {
                result = IncreasesHitPoints(cr);
            }
            else if (rolled_option == "Increases ability scores")
            {
                result = IncreasesAbilityScores(cr);
            }
            else if (rolled_option == "Cursed")
            {
                result = Cursed(startSuffixIndex, endSuffixIndex);
            }
            else if (rolled_option == "Capricious")
            {
                // SPECIAL
                result = GetSuffix(cr, 1, 90);
            }
            else if (rolled_option == "Improves recovery")
            {
                result = ImprovesRecovery(cr);
            }
            else if (rolled_option == "Affects spell preparation")
            {
                result = AffectsSpellPreparation(cr);
            }
            else if (rolled_option == "Affects spell casting in combat")
            {
                result = AffectsSpellCastingInCombat(cr);
            }
            else if (rolled_option == "Improves treasure finding")
            {
                result = ImprovesTreasureFinding(cr);
            }
            else if (rolled_option == "Improves light sources")
            {
                result = ImprovesLightSources(cr);
            }
            else if (rolled_option == "Reduces effects of hazards")
            {
                result = ReducesEffectsOfHazards(cr);
            }
            else if (rolled_option == "Increases damage")
            {
                result = IncreasesDamage(cr);
            }
            else if (rolled_option == "Improves minimum damage")
            {
                result = ImprovesMinimumDamage(cr);
            }
            else if (rolled_option == "Affects attack speed")
            {
                result = AffectsAttackSpeed(cr);
            }
            else if (rolled_option == "Adds effects to damaged foe")
            {
                result = AddsEffectsToDamagedFoe(cr);
            }
            else if (rolled_option == "Restores on a successful hit")
            {
                result = RestoresOnASuccessfulHit(cr);
            }
            else if (rolled_option == "Causes damage to armor or weapons")
            {
                result = CausesDamageToArmorOrWeapons(cr);
            }
            else if (rolled_option == "Affects weapon proficiencies")
            {
                result = AffectsWeaponProficiencies(cr);
            }
            else if (rolled_option == "Affects available uses")
            {
                result = AffectsAvailableUses(cr);
            }
            else
            {
                // elif rolled_option == "Allows the casting of a spell":
                //    return Suffix.allows_the_casting_of_a_spell(cr)
                result = null;
            }
            if (result != null)
            {
                return result;
            }
            ItemRoller.Owner.WriteToLog("rolled_option = " + rolled_option);
            return new Component("SUFFIX_ERROR", "SUFFIX_ERROR", -1);
        }

        public static List<String> Categories()
        {
            var options = new List<String>();
            options.Extend(new List<String> {
                "Reduces damage taken"
            }, 20);
            options.Extend(new List<String> {
                "Has an effect when attacked"
            }, 5);
            options.Extend(new List<String> {
                "Improves durability"
            }, 2);
            options.Extend(new List<String> {
                "Affects movement"
            }, 3);
            options.Extend(new List<String> {
                "Increases hit points"
            }, 5);
            options.Extend(new List<String> {
                "Increases ability scores"
            }, 10);
            options.Extend(new List<String> {
                "Cursed"
            }, 4);
            options.Extend(new List<String> {
                "Capricious"
            }, 1);
            options.Extend(new List<String> {
                "Improves recovery"
            }, 3);
            options.Extend(new List<String> {
                "Affects spell preparation"
            }, 3);
            options.Extend(new List<String> {
                "Affects spell casting in combat"
            }, 4);
            options.Extend(new List<String> {
                "Improves treasure finding"
            }, 3);
            options.Extend(new List<String> {
                "Improves light sources"
            }, 4);
            options.Extend(new List<String> {
                "Reduces effects of hazards"
            }, 3);
            options.Extend(new List<String> {
                "Increases damage"
            }, 3);
            options.Extend(new List<String> {
                "Improves minimum damage"
            }, 2);
            options.Extend(new List<String> {
                "Affects attack speed"
            }, 2);
            options.Extend(new List<String> {
                "Adds effects to damaged foe"
            }, 3);
            options.Extend(new List<String> {
                "Restores on a successful hit"
            }, 2);
            options.Extend(new List<String> {
                "Causes damage to armor or weapons"
            }, 2);
            options.Extend(new List<String> {
                "Affects weapon proficiencies"
            }, 1);
            options.Extend(new List<String> {
                "Affects available uses"
            }, 5);
            // options.Extend(["Allows the casting of a spell"] * 10)
            return options;
        }

        public static Component ReducesDamageTaken(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Health", "-1 point of damage taken from each attack", 2500)
            }, 11);
            options.Extend(new List<Component> {
                new Component("of Protection", "-2 points of damage taken from each attack", 5000)
            }, 6);
            options.Extend(new List<Component> {
                new Component("of Absorption", "-3 points of damage taken from each attack", 7500)
            }, 5);
            options.Extend(new List<Component> {
                new Component("of Life", "-4 points of damage taken from each attack", 10000)
            }, 4);
            var roll = DiceRoller.RandNumber20SidedDice("Reduces damage taken") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Deflection", "-5 points of damage taken from each attack", 12500);
            }
            return suffix;
        }

        public static Component HasAnEffectWhenAttacked(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Thorns", "Successful melee attacks against the wearer deal Id4 points of damage to the attacker", 5000)
            }, 10);
            options.Extend(new List<Component> {
                new Component("of Spikes", "Successful melee attacks against the wearer deal 2d4 points of damage to the attacker", 7500)
            }, 8);
            var roll = DiceRoller.RandNumber20SidedDice("Has an effect when attacked") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Blocking", "+2 AC when attacking; +4 AC when not attacking", 10000);
            }
            return suffix;
        }

        public static Component ImprovesDurability(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Sturdiness", "Item gains +3 hardness rating. +6 Durability.", 2500)
            }, 10);
            options.Extend(new List<Component> {
                new Component("of Structure", "Item gains +5 hardness rating, + 12 Durability.", 5000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of the Ages", "Item cannot be damaged or destroyed", 7500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of Bonding", "All items carried gain +3 hardness rating, +6 Durability.", 7500)
            }, 2);
            var roll = DiceRoller.RandNumber20SidedDice("Improves durability") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Unity", "All items carried gain +5 hardness rating, + 12 Durability.", 10000);
            }
            return suffix;
        }

        public static Component AffectsMovement(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Pacing", "+50% Move", 2000)
            }, 8);
            options.Extend(new List<Component> {
                new Component("of the Horse", "Halve all exhaustion penalties from movement", 3000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Ox", "Running doesn't cause exhaustion", 5000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of Speed", "+100% Move. +2 dodge bonus. can't be caught flat-footed", 10000)
            }, 5);
            var roll = DiceRoller.RandNumber20SidedDice("Affects movement") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Haste", "+150% Move, +4 dodge bonus, 1 extra partial action per round", 15000);
            }
            return suffix;
        }

        public static Component IncreasesHitPoints(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of the Jackal", "+4 hit points", 2500)
            }, 8);
            options.Extend(new List<Component> {
                new Component("of the Fox", "+6 hit points", 5000)
            }, 5);
            options.Extend(new List<Component> {
                new Component("of the Jaguar", "+8 hit points", 7500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of the Wolf", "+10 hit points", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of the Eagle", "+12 hit points", 12500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Tiger", "+15 hit points", 15000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Lion", "+118 hit points", 17500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Mammoth", "+20 hit points", 20000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Whale", "+25 hit points", 22500)
            }, 2);
            var roll = DiceRoller.RandNumber20SidedDice("Increases hit points") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of the Colossus", "+30 hit points", 25000);
            }
            return suffix;
        }

        public static Component IncreasesAbilityScores(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Vitality", "+1 Constitution", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Dexterity", "+1 Dexterity", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Energy", "+1 Intelligence", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Strength", "+1 Strength", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Lynx", "+1 Wisdom", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Zest", "+2 Constitution", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Skill", "+ 2 Dexterity", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Mind", "+2 Intelligence", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Might", "+2 Strength", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Leopard", "+2 Wisdom", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Vim", "+3 Constitution", 7500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Accuracy", "+3 Dexterity", 7500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Brilliance", "+3 Intelligence", 7500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Power", "+3 Strength", 7500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Jaguar", "+3 Wisdom", 7500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Vigor", "+4 Constitution", 10000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Precision", "+4 Dexterity", 10000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Sorcery", "+4 Intelligence", 10000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Giant", "+4 Strength", 10000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Tiger", "+4 Wisdom", 10000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Life", "+5 Constitution", 12500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Perfection", "+ 5 Dexterity", 12500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Wizardry", "+5 Intelligence", 12500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Titan", "+5 Strength", 12500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Lion", "+5 Wisdom", 12500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Sky", "+1 to all ability scores", 15000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Moon", "+2 to all ability scores", 20000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Stars", "+3 to all ability scores", 30000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Heavens", "+4 to all ability scores", 40000)
            }, 1);
            var roll = DiceRoller.RandNumber20SidedDice("Increases ability scores") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of the Zodiac", "+5 to all ability scores", 50000);
            }
            return suffix;
        }

        public static Component Cursed(int start, int end)
        {
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Tears", "+1 point of damage taken with each attack", 1)
            }, 15);
            options.Extend(new List<Component> {
                new Component("of Pain", "+2 points of damage taken with each attack", 1)
            }, 10);
            options.Extend(new List<Component> {
                new Component("of Brittleness", "Item's usual hardness reduced to 0", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Decay", "+2 damage, item's usual hardness rating is reduced to 0", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Fragility", "On the first use in combat, item is destroyed", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Vulture", "-ld6 hit points", 1)
            }, 10);
            options.Extend(new List<Component> {
                new Component("of Disease", "-1 Constitution", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Atrophy", "-1 Dexterity", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Dyslexia", "-1 Intelligence", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Weakness", "-1 Strength 1", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Cat", "-1 Wisdom", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Pit", "-1 to all ability scores", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Illness", "-2 Constitution", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Paralysis", "-2 Dexterity", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Draining", "-2 Intelligence", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Frailty", "-2 Strength", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Rat", "-2 Wisdom", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Trouble", "-2 to all ability scores", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Pox Owner", "cannot regain hit points while item is carried", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Corruption", "Owner cannot restore cast spells while item is carried", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Infection", "Spells that affect the user's mind last until dispelled ", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Ruin", "1 spell per day must be prepared as if 1 level higher ", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Exposed", "2 spells per day must be prepared as if 1 leve l higher", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Discord", "Spells cast in one action now take fu ll round", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Night", "Any light source carried by user has a - 10 ft. radius", 1)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of the Dark", "Any light source carried by user has a - 20 ft. radius", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Void", "Any light source carried by user has a -30 ft. radius", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Passivity", "-4 penalty when attacking with this item", 1)
            }, 10);
            options.Extend(new List<Component> {
                new Component("of the Snail", "User attacks once per two rounds when using this item", 1)
            }, 10);
            options.Extend(new List<Component> {
                new Component("of the Fool", "One random spell per day vanishes after spell preparation", 1)
            }, 10);
            var roll = DiceRoller.RandNumber(start, end, "Cursed");
            var suffix = options[roll];
            return suffix;
        }

        public static Component ImprovesRecovery(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Regeneration", "User regains 1 lost hit point per round", 10000)
            }, 15);
            var roll = DiceRoller.RandNumber20SidedDice("Improves recovery") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Regrowth", "User regains 1 temporary ability damage per 10 minutes", 17500);
            }
            return suffix;
        }

        public static Component AffectsSpellPreparation(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Warding", "1 spell per day prepared as if 1 level lower", 5000)
            }, 10);
            options.Extend(new List<Component> {
                new Component("of the Sentinel", "2 spells per day prepared as if each 1 level lower", 7500)
            }, 12);
            options.Extend(new List<Component> {
                new Component("of Guarding", "3 spells per day prepared as if each 1 level lower", 10000)
            }, 6);
            options.Extend(new List<Component> {
                new Component("of Negation", "4 spells per day prepared as if each 1 level lower", 12500)
            }, 6);
            var roll = DiceRoller.RandNumber20SidedDice("Affects spell preparation") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Osmosis", "5 spells per day prepared as if each 1 level lower", 15000);
            }
            return suffix;
        }

        public static Component AffectsSpellCastingInCombat(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of the Apprentice", "+2 enhancement bonus to Concentration skill checks", 2500)
            }, 9);
            options.Extend(new List<Component> {
                new Component("of the Magus", "+4 enhancement bonus to Concentration skill checks", 5000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of Balance", "Immunity to trip attacks and entanglements", 7500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of Stability", "Immunity to stuns, trip attacks, and entanglements", 10000)
            }, 2);
            var roll = DiceRoller.RandNumber20SidedDice("Affects spell casting in combat") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Harmony", "Immunity to stuns, disarms, trip attacks, and entanglements", 20000);
            }
            return suffix;
        }

        public static Component ImprovesTreasureFinding(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Greed", "CR is +2 for random gold on Base table", 7500)
            }, 10);
            options.Extend(new List<Component> {
                new Component("of Chance", "CR is + 2 for random magic item on tables", 10000)
            }, 8);
            options.Extend(new List<Component> {
                new Component("of Wealth", "CR is +4 for random gold on Base table", 10000)
            }, 8);
            var roll = DiceRoller.RandNumber20SidedDice("Improves treasure finding") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Fortune", "CR is +4 for random magic item on tables", 12500);
            }
            return suffix;
        }

        public static Component ImprovesLightSources(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Light", "Any light source carried by user is + 10ft. radius", 2500)
            }, 13);
            options.Extend(new List<Component> {
                new Component("of Radiance", "Any light source carried by user is +20 ft. radius", 3750)
            }, 5);
            var roll = DiceRoller.RandNumber20SidedDice("Improves light sources") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of the Sun", "Any light source carried by user is +30 ft. radius", 5000);
            }
            return suffix;
        }

        public static Component ReducesEffectsOfHazards(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of the Thief", "+5 to Disable Device checks; 1/2 damage from traps", 3750)
            }, 8);
            options.Extend(new List<Component> {
                new Component("of Warmth", "Immune to nondamaging cold effects", 5000)
            }, 6);
            options.Extend(new List<Component> {
                new Component("of Remedy", "+2 save vs. poison", 5000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of Amelioration", "+5 save vs. poison", 7500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of Defiance", "+8 save vs. poison", 10000)
            }, 2);
            var roll = DiceRoller.RandNumber20SidedDice("Reduces effects of hazards") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Purging", "+3 save vs. poison; 1/day slow poison (the spell) for 1d4 hours", 12500);
            }
            return suffix;
        }

        public static Component IncreasesDamage(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Craftsmanship", "+1 damage", 2500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of Quality", "+1 damage, +2 damage vs. Large or bigger creatures", 3750)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of Maiming", "+2 damage", 5000)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of Slaying", "+2 damage, +3 damage vs. Large or bigger creatures", 6250)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of Gore", "+3 damage", 7500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of Devastation", "If maximum base damage is rolled then triple damage", 8750)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Jester", "Multiply damage by Id4; on a 4, no damage is dealt", 10000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Carnage", "+4 damage", 10000)
            }, 3);
            var roll = DiceRoller.RandNumber20SidedDice("Increases damage") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Slaughter", "+5 damage", 12500);
            }
            return suffix;
        }

        public static Component ImprovesMinimumDamage(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Measure", "Minimum base damage with th is item is 2", 2500)
            }, 8);
            options.Extend(new List<Component> {
                new Component("of Worth", "Minimum base damage with this item is 3", 5000)
            }, 7);
            options.Extend(new List<Component> {
                new Component("of Excellence", "Minimum base damage with this item is 4", 7500)
            }, 5);
            var roll = DiceRoller.RandNumber20SidedDice("Improves minimum damage") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Performance", "Minimum base damage with this item is 5", 10000);
            }
            return suffix;
        }

        public static Component AffectsAttackSpeed(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Readiness", "+1 speed initiative bonus", 2500)
            }, 8);
            options.Extend(new List<Component> {
                new Component("of Alacrity", "+2 speed initiative bonus", 3750)
            }, 7);
            options.Extend(new List<Component> {
                new Component("of Swiftness", "+3 speed initiative bonus", 5000)
            }, 4);
            var roll = DiceRoller.RandNumber20SidedDice("Affects attack speed") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Quickness", "+4 speed initiative bonus", 6750);
            }
            return suffix;
        }

        public static Component AddsEffectsToDamagedFoe(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Frost +ld6 points of cold damage", "+ld6 points of cold damage", 2500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of Flame", "+ld6 points of fire damage", 2500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of Shock", "+ld6 points of lightning damage", 2500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of Blight", "+1d6 points of damage", 2500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of Ice", "+2d6 points of cold damage", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Fire", "+2d6 points of fire damage", 15000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Lightning", "+2d6 points of lightning damage", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of Venom", "+2d6 points of damage", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("of the Glacier", "+3d6 points of cold damage", 7500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Burning", "+3d6 points of fire damage", 7500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Thunder", "+3d6 points of lightning damage", 7500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Pestilence", "+3d6 points of damage", 7500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Vileness", "Wounds caused must be healed magically, negates regeneration", 7500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Crusaders", "+1 cumulative damage per successful consecutive attack against same foe", 10000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Destruction", "Foe takes extra damage equal to 20 - foe's AC (min 0)", 10000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of Peril", "Foe takes double damage, wielder takes normal damage", 12500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("of the Bear", "Hit knocks foe 10 ft. back (out of melee range)", 12500)
            }, 2);
            var roll = DiceRoller.RandNumber20SidedDice("Adds effects to damaged foe") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of the Grizzly", "Hit knocks foe back 20 ft. (out of melee range)", 15000);
            }
            return suffix;
        }

        public static Component RestoresOnASuccessfulHit(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of the Leech", "Successful hit heals user Id4 hit points", 7500)
            }, 5);
            options.Extend(new List<Component> {
                new Component("of the Claw", "Successful hit against spellcaster restores 3 spell levels of user's sorceress spells", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of the Bat", "Successful hit against a spellcaster restores 3 spell levels of user's necromancer spells", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of Blood", "Successful hit heals user ld6 hit points", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("of the Talon", "Successful hit against a spellcaster restores one of user's cast sorceress spells", 12500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("of the Vampire", "Successful hit against a spellcaster restores one of user's cast necromancer spells", 12500)
            }, 3);
            var roll = DiceRoller.RandNumber20SidedDice("Restores on a successful hit") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of the Locust", "Successful hit heals user 2d4 hit points", 15000);
            }
            return suffix;
        }

        public static Component CausesDamageToArmorOrWeapons(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Piercing", "Foe's armor destroyed, Fortitude save negates (DC is damage dealt)", 10000)
            }, 7);
            options.Extend(new List<Component> {
                new Component("of Breaking", "Foe's weapon destroyed, Fortitude save negates (DC is damage dealt)", 12500)
            }, 7);
            options.Extend(new List<Component> {
                new Component("of Puncturing", "Foe's armor destroyed, Fortitude save negates (DC is damage dealt + 5)", 12500)
            }, 7);
            options.Extend(new List<Component> {
                new Component("of Smashing", "Foe 's weapon destroyed, Fortitude save negates (DC is damage dealt + 5)", 15000)
            }, 7);
            var roll = DiceRoller.RandNumber20SidedDice("Causes damage to armor or weapons") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Bashing", "Foe's armor destroyed, Fort. save negates (DC is damage dealt + 10)", 17500);
            }
            return suffix;
        }

        public static Component AffectsWeaponProficiencies(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Ease", "User gains proficiency for item", 5000)
            }, 13);
            var roll = DiceRoller.RandNumber20SidedDice("Affects weapon proficiencies") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Simplicity", "User gains proficiency and Weapon Focus for item", 10000);
            }
            return suffix;
        }

        public static Component AffectsAvailableUses(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("of Many", "Fire one charge/arrow per round for free (others cost/must be provided)", 7500)
            }, 13);
            var roll = DiceRoller.RandNumber20SidedDice("Affects available uses") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = new Component("of Plenty", "Fire two charges/arrows per round for free (others cost/must be provided)", 15000);
            }
            return suffix;
        }

        // NOT USED
        public static Component AllowsTheCastingOfASpell(int cr)
        {
            Component suffix;
            var options = new List<Component>();
            var roll = DiceRoller.RandNumber20SidedDice("Allows the casting of a spell") + cr;
            if (roll < options.Count)
            {
                suffix = options[roll];
            }
            else
            {
                suffix = null;
            }
            return suffix;
        }
    }
}
