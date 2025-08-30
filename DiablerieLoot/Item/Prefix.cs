using System.Collections.Generic;


namespace DiablerieLoot
{
    public static class Prefix
    {
        public static Component GetPrefix(int cr, int startPrefixIndex, int endPrefixIndex)
        {
            Component result;
            var options = Categories();
            var rolledOption = options[DiceRoller.RandNumber(startPrefixIndex - 1, endPrefixIndex - 1, "Prefix group")];
            if (rolledOption == "Improves Armor Class")
            {
                result = ImprovesArmorClass(cr);
            }
            else if (rolledOption == "Improves saving throws")
            {
                result = ImprovesSavingThrows(cr);
            }
            else if (rolledOption == "Affects foe's reactions")
            {
                result = AffectsFoesReactions(cr);
            }
            else if (rolledOption == "Affects fatigue")
            {
                result = AffectsFatigue(cr);
            }
            else if (rolledOption == "Improves skills and spells")
            {
                result = ImprovesSkillsAndSpells(cr);
            }
            else if (rolledOption == "Cursed")
            {
                result = Cursed(startPrefixIndex, endPrefixIndex);
            }
            else if (rolledOption == "Capricious")
            {
                // SPECIAL
                result = GetPrefix(cr, 1, 100);
            }
            else if (rolledOption == "Affects visibility")
            {
                result = AffectsVisibility(cr);
            }
            else if (rolledOption == "Affects number of castable spells")
            {
                result = AffectsNumberOfCastableSpells(cr);
            }
            else if (rolledOption == "Affects magical items")
            {
                result = AffectsMagicalItems(cr);
            }
            else if (rolledOption == "Affects the user's personal statistics")
            {
                result = AffectsTheUsersPersonalStatistics(cr);
            }
            else if (rolledOption == "Improves attack scores")
            {
                result = ImprovesAttackScores(cr);
            }
            else if (rolledOption == "Has improved damage")
            {
                result = HasImprovedDamage(cr);
            }
            else if (rolledOption == "Improves attack scores and has improved damage")
            {
                result = ImprovesAttackScoresAndHasImprovedDamage(cr);
            }
            else if (rolledOption == "Affects item's charges")
            {
                result = AffectsItemsCharges(cr);
            }
            else
            {
                result = null;
            }
            if (result != null)
            {
                return result;
            }
            ItemRoller.Owner.WriteToLog("rolled_option = " + rolledOption);
            return new Component("PREFIX_ERROR", "PREFIX_ERROR", -1);
        }

        public static List<string> Categories()
        {
            var options = new List<string>();
            options.Extend(new List<string> {
                "Improves Armor Class"
            }, 20);
            options.Extend(new List<string> {
                "Improves saving throws"
            }, 15);
            options.Extend(new List<string> {
                "Affects foe's reactions"
            }, 4);
            options.Extend(new List<string> {
                "Affects fatigue"
            }, 1);
            options.Extend(new List<string> {
                "Improves skills and spells"
            }, 5);
            options.Extend(new List<string> {
                "Cursed"
            }, 4);
            options.Extend(new List<string> {
                "Capricious"
            }, 1);
            options.Extend(new List<string> {
                "Affects visibility"
            }, 5);
            options.Extend(new List<string> {
                "Affects number of castable spells"
            }, 5);
            options.Extend(new List<string> {
                "Affects magical items"
            }, 2);
            options.Extend(new List<string> {
                "Affects the user's personal statistics"
            }, 8);
            options.Extend(new List<string> {
                "Improves attack scores"
            }, 7);
            options.Extend(new List<string> {
                "Has improved damage"
            }, 5);
            options.Extend(new List<string> {
                "Improves attack scores and has improved damage"
            }, 8);
            options.Extend(new List<string> {
                "Affects item's charges"
            }, 10);
            return options;
        }

        public static Component ImprovesArmorClass(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Sturdy", "+1 AC", 2000)
            }, 5);
            options.Extend(new List<Component> {
                new Component("Fine", "+1 AC", 2500)
            }, 5);
            options.Extend(new List<Component> {
                new Component("Strong", "+1 AC, +2 against missiles", 3750)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Grand", "+2AC", 5000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Valiant", "+2 AC, +3 against missiles", 6250)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Glorious", "+3AC", 7500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Blessed", "+3 AC, +4 against missiles", 8750)
            }, 1);
            options.Extend(new List<Component> {
                new Component("Awesome", "+4AC", 10000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Saintly", "+4 AC, +5 against missiles", 12500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Holy", "+5AC", 15000)
            }, 2);
            var roll = DiceRoller.RandNumber20SidedDice("Improves Armor Class") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Godly", "+5 AC. +6 against missiles", 17500);
            }
            return prefix;
        }

        public static Component ImprovesSavingThrows(int cr)
        {
            Component prefix;
            var options = new List<Component> {
                new Component("Tawny", "+1 save vs. acid", 2000),
                new Component("Azure", "+1 save vs. cold", 2000),
                new Component("Crimson", "+1 save vs. fire", 2000),
                new Component("Ocher", "+1 save vs. lightning", 2000),
                new Component("Pearl", "+1 save vs. mind-influencing effects", 2000),
                new Component("Beryl", "+1 save vs. poison", 2000),
                new Component("Coal", "+1 save vs. spells", 2000),
                new Component("Jasmine", "+2 save vs. acid", 4000),
                new Component("Lapis", "+2 save vs. cold", 4000),
                new Component("Burgundy", "+2 save vs. fire", 4000),
                new Component("Tangerine", "+2 save vs. lightning", 4000),
                new Component("Ivory", "+2 save VS. mind~influencing effects", 4000),
                new Component("Jade", "+2 save vs. poison", 4000),
                new Component("Jet", "+2 save vs. spells", 4000),
                new Component("Pyrite", "+3 save vs. acid and - 1/4 acid damage", 6000),
                new Component("Cobalt", "+3 save vs. cold and -1/4 cold damage", 6000),
                new Component("Garnet", "+3 save vs. fire and - 1/4 fire damage", 6000),
                new Component("Coral", "+3 save vs. lightning and - 1/4 lightning damage", 6000),
                new Component("Crystal", "+3 save vs. mind-influencing effects", 6000),
                new Component("Viridian", "+3 save vs. poison and ignore initial poison damage", 6000),
                new Component("Ebony", "+3 save vs. spells and - 1/4 spell damage", 6000),
                new Component("Crysolite", "+4 save vs. acid and - 1/2 acid damage", 8000),
                new Component("Sapphire", "+4 save vs. cold and -1/2 cold damage", 8000),
                new Component("Ruby", "+4 save vs. fire and - 1/2 fire damage", 8000),
                new Component("Amber", "+4 save vs. lightning and - 1/2 lightning damage", 8000),
                new Component("Diamond", "+4 save vs. mind-influencing effects", 8000),
                new Component("Emerald", "+4 save vs. poison and ignore secondary poison damage", 8000),
                new Component("Obsidian", "+4 save vs. speHs and - 1/2 spell damage", 8000),
                new Component("Topaz", "+ 2 to all saves", 10000),
                new Component("Prismatic", "+ 3 to all saves", 15000)
            };
            var roll = DiceRoller.RandNumber20SidedDice("Improves saving throws") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Skull", "+4 to all saves", 18000);
            }
            return prefix;
        }

        public static Component AffectsFoesReactions(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Subduing", "Chosen foe flatfooted next round; Will save (DC IS) negates", 5000)
            }, 6);
            options.Extend(new List<Component> {
                new Component("Wearying", "Chosen foe flatfooted ld4 rounds; Will save (DC 20) negates", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Phasing", "Chosen foe deals half damage 1d4 rounds; Will save (DC 25) negates", 10000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("Kicking", "Attacking unarmed does not provoke attacks of opportunity", 10000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("Depleting", "Chosen foe takes - 20 initiative penalty for 2d4 rounds; Will save (DC 25) negates", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Howling", "Chosen foe takes fear effect (see PH); Will save (DC 18) negates", 12500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Chaos", "Chosen foe changes to random new alignment for 1d4 +1 rounds; Will save (DC 20) negates", 12500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("Subjugating", "Chosen foe can take only partial actions for 2d4 rounds; Will save (DC 28) negates", 12500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Fatiguing", "Chosen foe takes decrepify effect for 1d4 rounds; Will save (DC 25) negates", 12500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Exhausting", "Chosen foe takes decrepify effect for 2d4 rounds; Will save (DC 28) negates", 15000)
            }, 3);
            var roll = DiceRoller.RandNumber20SidedDice("Affects foe's reactions") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Overwhelming", "Chosen foe takes decrepify effect for 3d4 rounds; Will save (DC 30) negates", 17500);
            }
            return prefix;
        }

        public static Component AffectsFatigue(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Tireless", "You recover from being tired in half the time", 2000)
            }, 10);
            var roll = DiceRoller.RandNumber20SidedDice("Affects fatigue") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Rugged", "You are immune to fatigue", 4000);
            }
            return prefix;
        }

        public static Component ImprovesSkillsAndSpells(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Fletcher's", "+1 ranged attack/rank with class skills (amazons only)", 2500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Slayer's", "+1 melee attack/rank with class skills (barbarians only)", 2500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Summoner's", "+1 spell level/rank with class skills (necromancers only)", 2500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Monk's", "+1 melee attack/rank with class skills (paladins only)", 2500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Angel 's", "+1 spell level/rank with class skills (sorceresses only)", 2500)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Archer's", "+2 ranged attack/ranks with class skills (amazons only)", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Berserker's", "+2 melee attack/ranks with class skills (barbarians only)", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Necromancer's", "+2 spell levels/ranks with class skills (necromancers only)", 5000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Priest's", "+2 melee attack/ranks with class skills (paladins only)", 5000)
            }, 2);
            var roll = DiceRoller.RandNumber20SidedDice("Improves skills and spells") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Arch-Angel's", "+2 spell levels/ranks with class skills (sorceresses only)", 5000);
            }
            return prefix;
        }

        public static Component Cursed(int start, int end)
        {
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Rusted", "-1 AC", 1)
            }, 15);
            options.Extend(new List<Component> {
                new Component("Vulnerable", "-2 AC", 1)
            }, 10);
            options.Extend(new List<Component> {
                new Component("Glass", "-2 to all saves", 1)
            }, 10);
            options.Extend(new List<Component> {
                new Component("Hyena's", "User cannot cast spells", 1)
            }, 10);
            options.Extend(new List<Component> {
                new Component("Frog's", "-1 spell level (if the user can cast such spells)", 1)
            }, 10);
            options.Extend(new List<Component> {
                new Component("Pitch", "Any light source carried by user has a -10ft. radius", 1)
            }, 15);
            options.Extend(new List<Component> {
                new Component("Brass", "-1 attack", 1)
            }, 5);
            options.Extend(new List<Component> {
                new Component("Tin", "-2 attack", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Crystalline", "When weapon deals damage roll 1d6; on a 6, the weapon deals no damage and is destroyed", 1)
            }, 1);
            options.Extend(new List<Component> {
                new Component("Weak", "Base damage is halved (round down)", 1)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Bent", "Base damage is reduced to 1", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Useless", "Attacking with this item causes no damage", 1)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Dull", "-1 attack and base damage is halved (round down)", 1)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Clumsy", "-2 attack and base damage is reduced to 1", 1)
            }, 12);
            var roll = DiceRoller.RandNumber(start, end, "Cursed");
            var prefix = options[roll];
            return prefix;
        }

        public static Component AffectsVisibility(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Glowing", "Glows to a 30-ft. radius", 2500)
            }, 6);
            options.Extend(new List<Component> {
                new Component("Oracular", "Constant see invisibility to 60 ft.", 5000)
            }, 6);
            options.Extend(new List<Component> {
                new Component("Unseen", "User is invisible to all beings more than 30 ft. away", 7500)
            }, 5);
            options.Extend(new List<Component> {
                new Component("Hidden", "User is invisible to all beings more than 20 ft. away", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Veiled", "User is invisible to all beings more than 10ft. away", 12500)
            }, 3);
            var roll = DiceRoller.RandNumber20SidedDice("Affects visibility") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("StalkIng", "User is invisible on any round he or she does not move, attack or cast a spell", 15000);
            }
            return prefix;
        }

        public static Component AffectsNumberOfCastableSpells(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Lizard's", "+1 spell level (if user can cast spells)", 2500)
            }, 5);
            options.Extend(new List<Component> {
                new Component("Spider's", "+2 spell levels per day (if user can cast spells)", 5000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Raven's", "+3 spell levels per day (if user can cast spells)", 7500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Snake's", "+4 spell levels per day (if user can cast spells)", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Serpent's", "+5 spell levels per day (if user can cast spells)", 12500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Drake's", "+6 spell levels per day (if user can cast spells)", 15000)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Dragon's", "+ 7 spell levels per day (if user can cast spells)", 17500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Wyrm's", "+8 spell levels per day (if user can cast spells)", 20000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("Hydra's", "+9 spell levels per day (if user can cast spells)", 22500)
            }, 1);
            options.Extend(new List<Component> {
                new Component("Devious", "When user casts a spell , there is a 1 in 10 that full preparation is restored", 22500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Fortified", "When user casts a spell, there is a 1 in 4 chance that full preparation is restored", 25000)
            }, 1);
            options.Extend(new List<Component> {
                new Component("Triumphant", "When you kill a foe in melee. you gain back 1 spell of your choice", 25000)
            }, 1);
            var roll = DiceRoller.RandNumber20SidedDice("Affects number of Castable spells") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Vulpine", "User reduces any damage by 1/4 if he/she loses one prepared spell", 27500);
            }
            return prefix;
        }

        public static Component AffectsMagicalItems(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Extending", "Doubles the duration of herbs", 2500)
            }, 6);
            options.Extend(new List<Component> {
                new Component("Chrono", "Doubles the duration of oils and resins", 2500)
            }, 6);
            options.Extend(new List<Component> {
                new Component("Fortuitous", "+1 to CR on base treasure table", 5000)
            }, 3);
            options.Extend(new List<Component> {
                new Component("Augmenting", "Doubles the effect of herbs", 5000)
            }, 4);
            var roll = DiceRoller.RandNumber20SidedDice("Affects magical items") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Catalyzing", "Doubles the effect of oils and resins", 5000);
            }
            return prefix;
        }

        public static Component AffectsTheUsersPersonalStatistics(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Blue", "+1 save vs. cold", 2000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Red", "+1 save vs. fire", 2000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Orange", "+1 save vs. lightning", 2000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("White", "+1 save vs. mind-influencing effects", 2000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Green", "+1 save vs. poison", 2000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Black", "+1 save vs. spell", 2000)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Tough", "+1 Constitution", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Swift", "+1 Dexterity", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Brilliant", "+1 Intelligence", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Mighty", "+1 Strength", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Vibrant", "+1 Wisdom", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Forceful", "+1 Charisma", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Resilient", "+1 AC", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Silver", "+1 attack", 2500)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Muscular", "+2 melee damage, +5 hit points", 2500)
            }, 2);
            var roll = DiceRoller.RandNumber20SidedDice("Affects the user's personal statistics") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Healthy", "+5 hit points", 2500);
            }
            return prefix;
        }

        public static Component ImprovesAttackScores(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Bronze", "+1 attack", 2500)
            }, 6);
            options.Extend(new List<Component> {
                new Component("Iron", "+1 attack, +2 vs. undead and demonic creatures", 3750)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Silver", "+2 attack", 5000)
            }, 5);
            options.Extend(new List<Component> {
                new Component("Steel", "+2 attack, +3 vs. undead and demonic creatures", 6250)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Gold", "+3 attack", 7500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Platinum", "+ 3 attack, +4 vs. undead and demonic creatures", 8750)
            }, 2);
            options.Extend(new List<Component> {
                new Component("Mithril", "+4 attack", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Meteoric", "+5 attack", 12500)
            }, 5);
            var roll = DiceRoller.RandNumber20SidedDice("Improves attack scores") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Weird", "+5 attack, extra successful hit on a natural 20", 1500);
            }
            return prefix;
        }

        public static Component HasImprovedDamage(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Jagged", "+1 damage", 2500)
            }, 5);
            options.Extend(new List<Component> {
                new Component("Deadly", "+ 1 damage, increase threat range by 1", 5000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Vicious", "+2 damage", 5000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Heavy", "+2 damage. increase threat range by 1", 7500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Brutal", "+3 damage", 7500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Massive", "+3 damage, increase threat range by 1", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Savage", "+4 damage. increase threat range by 1", 12500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Ruthless", "+4 damage, increase threat range by 2", 15000)
            }, 4);
            var roll = DiceRoller.RandNumber20SidedDice("Has improved damage") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Merciless", "+5 damage, increase threat range by 2", 17500);
            }
            return prefix;
        }

        public static Component ImprovesAttackScoresAndHasImprovedDamage(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Sharp", "+ 1 attack; increase threat range by 1", 5000)
            }, 5);
            options.Extend(new List<Component> {
                new Component("Fine", "+ 1 attack; increase threat range by 2", 7500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Warrior's", "+2 attack; increase threat range by I", 10000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Soldier's", "+2 attack; increase threat range by 2", 12500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Knight's", "+3 attack; increase threat range by I", 15000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Master's", "+3 attack; increase threat range by 2", 17500)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Doppelganger's", "for each attack, roll a ld4 and add it to attack and damage totals", 20000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Lord's", "+4 attack; increase threat range by 1", 20000)
            }, 4);
            options.Extend(new List<Component> {
                new Component("Champion's", "+4 attack; increase threat range by 2", 22500)
            }, 4);
            var roll = DiceRoller.RandNumber20SidedDice("Improves attack scores and has improved damage") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("King's", "+5 attack; increase threat range by 1", 25000);
            }
            return prefix;
        }

        public static Component AffectsItemsCharges(int cr)
        {
            Component prefix;
            var options = new List<Component>();
            options.Extend(new List<Component> {
                new Component("Plentiful", "Twice normal maximum charges", 7500)
            }, 15);
            options.Extend(new List<Component> {
                new Component("Jester's", "Casts a random spell from Suffix table 91-00", 10000)
            }, 1);
            var roll = DiceRoller.RandNumber20SidedDice("Affects items charges") + cr;
            if (roll < options.Count)
            {
                prefix = options[roll];
            }
            else
            {
                prefix = new Component("Bountiful", "Three times normal maximum charges", 12500);
            }
            return prefix;
        }
    }
}
