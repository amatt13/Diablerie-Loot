using System;
using System.Collections.Generic;


namespace DiablerieLoot
{
    public static class Item
    {
        public static ItemDescription GetItem(int cr, bool prefix, bool suffix, bool verbose = false)
        {
            var baseItemType = DiceRoller.RandNumber(1, 80, "Item group", verbose);

            if (0 < baseItemType && baseItemType <= 8)
            {
                return BodyArmor(cr, prefix, suffix);
            }
            else if (8 < baseItemType && baseItemType <= 13)
            {
                return HeadGear(cr, prefix, suffix);
            }
            else if (13 < baseItemType && baseItemType <= 16)
            {
                return Feet(cr, prefix, suffix);
            }
            else if (16 < baseItemType && baseItemType <= 18)
            {
                return Hands(cr, prefix, suffix);
            }
            else if (18 < baseItemType && baseItemType <= 20)
            {
                return Belts(cr, prefix, suffix);
            }
            else if (20 < baseItemType && baseItemType <= 25)
            {
                return Shields(cr, prefix, suffix);
            }
            else if (25 < baseItemType && baseItemType <= 30)
            {
                return Daggers(cr, prefix, suffix);
            }
            else if (30 < baseItemType && baseItemType <= 40)
            {
                return Swords(cr, prefix, suffix);
            }
            else if (40 < baseItemType && baseItemType <= 44)
            {
                return Clubs(cr, prefix, suffix);
            }
            else if (44 < baseItemType && baseItemType <= 48)
            {
                return JavelinsSpears(cr, prefix, suffix);
            }
            else if (48 < baseItemType && baseItemType <= 50)
            {
                return Polearms(cr, prefix, suffix);
            }
            else if (50 < baseItemType && baseItemType <= 55)
            {
                return Axes(cr, prefix, suffix);
            }
            else if (55 < baseItemType && baseItemType <= 63)
            {
                return Bows(cr, prefix, suffix);
            }
            else if (63 < baseItemType && baseItemType <= 65)
            {
                return Crossbows(cr, prefix, suffix);
            }
            else if (65 < baseItemType && baseItemType <= 70)
            {
                return Wands(cr, prefix, suffix);
            }
            else if (70 < baseItemType && baseItemType <= 75)
            {
                return Staves(cr, prefix, suffix);
            }
            else if (75 < baseItemType && baseItemType <= 79)
            {
                return Accessories(cr, prefix, suffix);
            }
            else if (79 < baseItemType && baseItemType <= 80)
            {
                return Gems(cr, prefix, suffix);
            }
            // elif 80 < base_item_type <= 90:
            //    return inscribed_spells(cr, suffix)
            throw new Exception("ERROR_ITEM");
        }

        public static ItemDescription BodyArmor(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var rags = 3;
            var cape = 2 + rags;
            var cloak = 2 + cape;
            var robe = 4 + cloak;
            var quiltedArmor = 3 + robe;
            var leatherArmor = 2 + quiltedArmor;
            var hardLeatherArmor = 2 + leatherArmor;
            var studdedLeatherArmor = 3 + hardLeatherArmor;
            var ringMail = 2 + studdedLeatherArmor;
            var scaleMail = 2 + ringMail;
            var chainMail = 2 + scaleMail;
            var breastPlate = 1 + chainMail;
            var splintMail = 2 + breastPlate;
            var plateMail = 2 + splintMail;
            var fieldPlate = 1 + plateMail;
            var ancientArmor = 1 + fieldPlate;
            var gothicPlate = 1 + ancientArmor;
            var roll = DiceRoller.RandNumber20SidedDice("Body armor") + cr;

            if (roll > gothicPlate)
                item_component = new Component("Full Plate Mail", "+11 AC", 5000);
            else if (gothicPlate <= roll)
                item_component = new Component("Gothic Plate", "+10 AC", 4000);
            else if (ancientArmor <= roll)
                item_component = new Component("Ancient Armor", "+9 AC, absorbs 1 point of damage per attack", 3750);
            else if (fieldPlate <= roll)
                item_component = new Component("Field Plate", "+8 AC", 2000);
            else if (plateMail <= roll)
                item_component = new Component("Plate Mail", "+7 AC", 600);
            else if (splintMail <= roll)
                item_component = new Component("Splint Mail", "+6 AC", 250);
            else if (breastPlate <= roll)
                item_component = new Component("Breast Plate", "+5 AC", 200);
            else if (chainMail <= roll)
                item_component = new Component("Chain Mail", "+5 AC", 150);
            else if (scaleMail <= roll)
                item_component = new Component("Scale Mail", "+4 AC", 120);
            else if (ringMail <= roll)
                item_component = new Component("Ring Mail", "+4 AC", 100);
            else if (studdedLeatherArmor <= roll)
                item_component = new Component("Studded Leather Armor", "+3 AC", 50);
            else if (hardLeatherArmor <= roll)
                item_component = new Component("Hard Leather Armor", "+3 AC", 40);
            else if (leatherArmor <= roll)
                item_component = new Component("Leather Armor", "+2 AC", 30);
            else if (quiltedArmor <= roll)
                item_component = new Component("Quilted Armor", "+1 AC", 25);
            else if (robe <= roll)
                item_component = new Component("Robe", "+1 AC", 20);
            else if (cloak <= roll)
                item_component = new Component("Cloak", "+1 AC", 15);
            else if (cape <= roll)
                item_component = new Component("Cape", "+ I AC", 5);
            else
                item_component = new Component("Rags", "+1 AC (-1 penalty to Charisma checks)", 1);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 1, endPrefixIndex: 60);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 1, 60);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription HeadGear(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var cap = 10;
            var skullCap = 4 + cap;
            var helm = 4 + skullCap;
            var mask = 2 + helm;
            var fullHelm = 5 + mask;
            var crown = 4 + fullHelm;
            var boneHelm = 3 + crown;
            var roll = DiceRoller.RandNumber20SidedDice("Head gear") + cr;

            if (roll > boneHelm)
                item_component = new Component("Great Helm", "+4 AC (not cumulative with armor)", 150);
            else if (roll <= boneHelm)
                item_component = new Component("Bone Helm", "+3 AC (not cumulative with armor)", 100);
            else if (roll <= crown)
                item_component = new Component("Crown", "+3 AC (not cumulative with armor)", 50);
            else if (roll <= fullHelm)
                item_component = new Component("Full Helm", "+2 AC (not cumulative with armor)", 30);
            else if (roll <= mask)
                item_component = new Component("Mask", "+1 AC (not cumulative with armor)", 20);
            else if (roll <= helm)
                item_component = new Component("Helm", "+1 AC (not cumulative with armor)", 15);
            else if (roll <= skullCap)
                item_component = new Component("Skull Cap", "+1 AC (not cumulative with armor)", 10);
            else
                item_component = new Component("Cap", "+1 AC (not cumulative with any protection)", 5);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 1, endPrefixIndex: 60);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 1, 60);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Feet(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var LeatherBoots = 12;
            var HeavyBoots = 9 + LeatherBoots;
            var ChainBoots = 6 + HeavyBoots;
            var LtPlateBoots = 5 + ChainBoots;
            var roll = DiceRoller.RandNumber20SidedDice("Feet") + cr;

            if (roll > LtPlateBoots)
                item_component = new Component("Greaves", "+2 AC (not cumulative with armor)", 30);
            else if (roll <= LtPlateBoots)
                item_component = new Component("Lt. Plate Boots", "+1 AC (not cumulative with armor)", 20);
            else if (roll <= ChainBoots)
                item_component = new Component("Chain Boots", "+1 AC (not cumulative with armor)", 15);
            else if (roll <= HeavyBoots)
                item_component = new Component("Heavy Boots", "+1 AC (not cumulative with armor)", 10);
            else
                item_component = new Component("Leather Boots", "+1 AC (not cumulative with any protection/armor)", 5);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 1, endPrefixIndex: 60);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 1, 60);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Hands(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var gloves = 12;
            var heavyGloves = 9 + gloves;
            var chainGloves = 6 + heavyGloves;
            var lightGauntlets = 5 + chainGloves;
            var roll = DiceRoller.RandNumber20SidedDice("Hands") + cr;

            if (roll > lightGauntlets)
                item_component = new Component("Gauntlets", "+2 AC (not cumulative with armor or shield)", 20);
            else if (lightGauntlets <= roll)
                item_component = new Component("Light Gauntlets", "+1 AC (not cumulative with armor or shield)", 15);
            else if (chainGloves <= roll)
                item_component = new Component("Chain Gloves", "+1 AC (not cumulative with armor or shield)", 10);
            else if (heavyGloves <= roll)
                item_component = new Component("Heavy Gloves", "+1 AC (not cumulative with armor or shield)", 5);
            else
                item_component = new Component("Gloves", "+1 AC (not cumulative with any protection)", 30);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 1, endPrefixIndex: 60);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 1, 60);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Belts(int cr, bool prefix, bool suffix)
        {
            Component item_component;

            var roll = DiceRoller.RandNumber20SidedDice("Belts") + cr;
            var sash = 12;
            var lightBelt = 9 + sash;
            var belt = 6 + lightBelt;
            var heavyBelt = 5 + belt;

            if (roll > heavyBelt)
                item_component = new Component("Plate Belt", "+2 AC {not cumulative with armor}", 30);
            else if (heavyBelt <= roll)
                item_component = new Component("Heavy Belt", "+1 AC (not cumulative with armor)", 20);
            else if (belt <= roll)
                item_component = new Component("Belt", "+1 AC (not cumulative with armor)", 15);
            else if (lightBelt <= roll)
                item_component = new Component("Light Belt", "+1 AC (not cumulative with armor)", 10);
            else
                item_component = new Component("Sash", "+1 AC (not cumulative with any protection/armor)", 5);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 1, endPrefixIndex: 60);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 1, 60);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Shields(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var buckler = 10;
            var smallShield = 6 + buckler;
            var largeShield = 5 + smallShield;
            var kiteShield = 4 + largeShield;
            var spikedShield = 2 + kiteShield;
            var stoneShield = 2 + spikedShield;
            var towerShieldSmall = 3 + stoneShield;
            var roll = DiceRoller.RandNumber20SidedDice("Shields") + cr;

            if (roll > towerShieldSmall)
                item_component = new Component("Gothic Shield", "+2 AC (negates hand protection)", 500);
            else if (towerShieldSmall <= roll)
                item_component = new Component("Tower Shield (Small)", "+4 AC (negates hand protection)", 250);
            else if (stoneShield <= roll)
                item_component = new Component("Stone Shield", "+3 AC (negates hand protection)", 150);
            else if (spikedShield <= roll)
                item_component = new Component("Spiked Shield", "+2 AC (used as 1d6 (x2) piercing weapon, negates hand protection)", 100);
            else if (kiteShield <= roll)
                item_component = new Component("Kite Shield", "+3 AC (negates hand protection)", 50);
            else if (largeShield <= roll)
                item_component = new Component("Large Shield", "+2 AC (negates hand protection)", 20);
            else if (smallShield <= roll)
                item_component = new Component("Small Shield", "+1 AC (negates hand protectIon)", 15);
            else
                item_component = new Component("Buckler", "+ 1 AC(negates hand protection)", 10);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 1, endPrefixIndex: 60);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 1, 60);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Daggers(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var throwingKnife = 10;
            var dagger = 5 + throwingKnife;
            var dirk = 2 + dagger;
            var kris = 3 + dirk;
            var balancedKnife = 11 + kris;
            var roll = DiceRoller.RandNumber20SidedDice("Daggers") + cr;

            if (roll > balancedKnife)
                item_component = new Component("Blade", "1d6, crit 19-20/x2, 2 Ibs. Small, Piercing/Slashing", 20);
            else if (balancedKnife <= roll)
                item_component = new Component("Balanced Knife", "(2d6) 1d4, crit 19- 20/x3, lib. Small, Piercing", 300);
            else if (kris <= roll)
                item_component = new Component("Kris", "1d4 , crit 18- 20/x3, 2 Ibs. T iny, Piercing", 15);
            else if (dirk <= roll)
                item_component = new Component("Dirk", "1d4, crit 19- 20/x2, 2 Ibs., Small, Piercing/Slashing", 10);
            else if (dagger <= roll)
                item_component = new Component("Dagger", "1d4 , crit 19-20/x2, lIb. , Tiny, Piercing", 5);
            else
                item_component = new Component("Throwing Knife", "(2d6) 1d3, crit 19- 20/x2, lib., Small, Piercing", 200);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 26, endPrefixIndex: 85);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 26, 86);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Swords(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var shortSword = 4;
            var saber = 3 + shortSword;
            var scimitar = 3 + saber;
            var falchion = 3 + scimitar;
            var broadSword = 2 + falchion;
            var longsword = 2 + broadSword;
            var crystalSword = 1 + longsword;
            var claymore = 2 + crystalSword;
            var twoHandedSword = 4 + claymore;
            var warSword = 2 + twoHandedSword;
            var giantSword = 2 + warSword;
            var bastardSword = 2 + giantSword;
            var flamberge = 2 + bastardSword;
            var roll = DiceRoller.RandNumber20SidedDice("Swords") + cr;

            if (roll > flamberge)
                item_component = new Component("Great Sword", "2dl0 , crit 19-20/x2, 151bs., Large, Slashing", 500);
            else if (flamberge <= roll)
                item_component = new Component("Flamberge", "2d8', crit 19-20/x2, 151bs., Large, Slashing", 300);
            else if (bastardSword <= roll)
                item_component = new Component("Bastard Sword", "2d6', crit 19-20/x2 , 10 Ibs., Large, Slashing", 250);
            else if (giantSword <= roll)
                item_component = new Component("Giant Sword", "2d6', crit 19-20/x2, 15 1bs., Large, Slashing", 250);
            else if (warSword <= roll)
                item_component = new Component("War Sword", "1dl0, crit 19-20x2, 4lbs. , Medium, Slashing", 200);
            else if (twoHandedSword <= roll)
                item_component = new Component("Two-Handed Sword", "1dl0' , crit 19-20x2, 151bs. , Large, Slashing", 175);
            else if (claymore <= roll)
                item_component = new Component("Claymore", "1dl0' , crit 19-20x2, 15 Ibs., Large, Slashing", 150);
            else if (crystalSword <= roll)
                item_component = new Component("Crystal Sword", "1d8, crit 19-20/x3, S ibs., Medium, Slashing", 150);
            else if (longsword <= roll)
                item_component = new Component("Longsword", "1d8, crit 19-20x2, 4lbs., Medium, Slashing", 100);
            else if (broadSword <= roll)
                item_component = new Component("Broad Sword", "1d8, crit 19-20/x2, 4 Ibs. Medium, Slashing", 75);
            else if (falchion <= roll)
                item_component = new Component("Falchion", "1d6, crit 18-20/x2, 6lbs., Medium, Slashing", 35);
            else if (scimitar <= roll)
                item_component = new Component("Scimitar", "1d6, crit 19-20/x2, 4 Ibs. Medium, SlashIng", 20);
            else if (saber <= roll)
                item_component = new Component("Saber", "1d6 crit 19-20/x2, 4lbs., Medium, Slashing", 30);
            else
                item_component = new Component("Short Sword", "1d6 crit 19-20/x2, 3lbs., Small, Pier6ng", 10);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 26, endPrefixIndex: 85);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 26, 86);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Clubs(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var club = 7;
            var spikedClub = 2 + club;
            var maceLight = 4 + spikedClub;
            var scepter = 4 + maceLight;
            var morningStar = 2 + scepter;
            var grandScepter = 4 + morningStar;
            var flailLight = 2 + grandScepter;
            var warHammer = 3 + flailLight;
            var maul = 2 + warHammer;
            var warScepter = 2 + maul;
            var roll = DiceRoller.RandNumber20SidedDice("Clubs") + cr;

            if (roll > warScepter)
                item_component = new Component("Great Maul", "2d6*, crit x3, 30 lbs., Large, Bludgeoning", 250);
            else if (warScepter <= roll)
                item_component = new Component("War Scepter", "ldl0. crit x2, 61bs., Medium, Bludgeoning", 200);
            else if (maul <= roll)
                item_component = new Component("Maul", "1dl0* , crit x3, 25lbs .. Large, Bludgeoning", 100);
            else if (warHammer <= roll)
                item_component = new Component("War Hammer", "1d8, crit x3, 8lbs. , Medium. Bludgeoning", 60);
            else if (flailLight <= roll)
                item_component = new Component("Flail (Light)", "1d5, crit x2, S lbs., Medium, Bludgeoning", 50);
            else if (grandScepter <= roll)
                item_component = new Component("Grand Scepter", "1d5, crit x2, 6 lbs., Medium, Bludgeoning", 40);
            else if (morningStar <= roll)
                item_component = new Component("Morning Star", "1d8, crit x2, 8 lbs., Medium, Bludgeoning/Piercing", 30);
            else if (scepter <= roll)
                item_component = new Component("Scepter", "1d6, crit x2, 4 lbs., Medium, Bludgeoning", 20);
            else if (maceLight <= roll)
                item_component = new Component("Mace (Light)", "1d6. crit x2. 6 lbs., Small. Bludgeoning", 10);
            else if (spikedClub <= roll)
                item_component = new Component("Spiked Club", "1d6, crit x3 . 5 lbs., Medium, Bludgeoning/Piercing", 5);
            else
                item_component = new Component("Club", "1d6, crit x2, 3 lbs., Medium, Bludgeoning", 1);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 26, endPrefixIndex: 85);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 26, 86);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription JavelinsSpears(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var javelinLight = 7;
            var shortSpear = 3 + javelinLight;
            var longSpear = 3 + shortSpear;
            var pilum = 4 + longSpear;
            var trident = 3 + pilum;
            var glaiveLight = 3 + trident;
            var brandistock = 3 + glaiveLight;
            var throwingSpear = 3 + brandistock;
            var spetum = 3 + throwingSpear;
            var roll = DiceRoller.RandNumber20SidedDice("Javelins and Spears") + cr;

            if (roll > spetum)
                item_component = new Component("Pike (Heavy) 2d6*", "crit x3, 12 lbs., Large, Piercing", 200);
            else if (spetum <= roll)
                item_component = new Component("Septum", "1dl2*, crit x3. 15 lbs., Large, Piercing/Slashing", 120);
            else if (throwingSpear <= roll)
                item_component = new Component("Throwing Spear (2d4)", "1d8, crit x2, Range 30 ft., 3 lbs., Medium, Piercing", 5);
            else if (brandistock <= roll)
                item_component = new Component("Brandistock", "2d6*, crit x3, 15 lbs., Large, Piercing/Slashing", 100);
            else if (glaiveLight <= roll)
                item_component = new Component("Glaive (Light, 2d4)", "1d8, crit x2, Range 10 ft., 4 lbs., Medium, Piercing", 4);
            else if (trident <= roll)
                item_component = new Component("Trident", "1d12*, crit x2, 15lbs., Large, Piercing", 80);
            else if (pilum <= roll)
                item_component = new Component("Pilum (2d4)", "1d6, crit x2, Range 20 ft., 41bs., Medium, Piercing", 3);
            else if (longSpear <= roll)
                item_component = new Component("Long Spear", "1d8*, crit x3, 91bs., Large, Piercing", 40);
            else if (shortSpear <= roll)
                item_component = new Component("Short Spear", "1d6, crit x3, 3lbs., Range 20 ft., Medium, Piercing", 20);
            else
                item_component = new Component("Javelin (Light, 2d4)", "1d4, crit x2, Range 30 ft., 1 lb., Medium, Piercing", 2);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 26, endPrefixIndex: 85);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 26, 86);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Polearms(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var bardiche = 8;
            var voulge = 6 + bardiche;
            var scythe = 6 + voulge;
            var poleaxe = 6 + scythe;
            var halberdHeavy = 6 + poleaxe;
            var roll = DiceRoller.RandNumber20SidedDice("Polearms") + cr;

            if (roll > halberdHeavy)
                item_component = new Component("War Scythe", "2d6, crit x4, 15lbs., Large, Piercing/Slashing", 250);
            else if (halberdHeavy <= roll)
                item_component = new Component("Halberd (Heavy)", "2d6*, crit x3, 15 lbs., Large, Piercing/ Slashing", 200);
            else if (poleaxe <= roll)
                item_component = new Component("Poleaxe", "1d1O*, crit x3, 15lbs., Large, Slashing", 150);
            else if (scythe <= roll)
                item_component = new Component("Scythe", "2d4*, crit x4, 12lbs., Large, Piercing/Slashing", 80);
            else if (voulge <= roll)
                item_component = new Component("Voulge", "2d4*, crit x3, 15lbs., Large, Slashing", 40);
            else
                item_component = new Component("Bardiche", "1d8*, crit x3, 10 lbs., Large, Slashing", 20);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 26, endPrefixIndex: 85);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 26, 86);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Axes(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var handAxe = 5;
            var axe = 4 + handAxe;
            var throwingAxe = 3 + axe;
            var largeAxe = 4 + throwingAxe;
            var doubleAxe = 4 + largeAxe;
            var militaryPick = 2 + doubleAxe;
            var broadAxe = 2 + militaryPick;
            var battleAxe = 3 + broadAxe;
            var balancedAxe = 4 + battleAxe;
            var warAxe = 4 + balancedAxe;
            var greatAxe = 2 + warAxe;
            var roll = DiceRoller.RandNumber20SidedDice("Axes") + cr;

            if (roll > greatAxe)
                item_component = new Component("Giant Axe", "2dl0, crit x3, 25 lbs., Large, Slashing", 450);
            else if (greatAxe <= roll)
                item_component = new Component("Great Axe", "2d8* crit x3, 20 lbs., Large, Slashing", 350);
            else if (warAxe <= roll)
                item_component = new Component("War Axe", "1d10 , crit x3, 10 lbs., Medium, Slashing", 100);
            else if (balancedAxe <= roll)
                item_component = new Component("Balanced Axe (Throwing, 2d4)", "1d6, crit x2, Range 10 ft., 4 lbs., Medium, Slashing", 4);
            else if (battleAxe <= roll)
                item_component = new Component("Battle Axe (Heavy)", "2d6', crit x3, 15 lbs., Large, Slashing", 250);
            else if (broadAxe <= roll)
                item_component = new Component("Broad Axe", "1dl2' , crit x3, 15 lbs., Large, Slashing", 200);
            else if (militaryPick <= roll)
                item_component = new Component("Military Pick", "1d6, crit x4, 6 lbs., Medium, Piercing", 40);
            else if (doubleAxe <= roll)
                item_component = new Component("Double Axe", "1d8, crit x3, 7 lbs., Medium, Slashing", 40);
            else if (largeAxe <= roll)
                item_component = new Component("Large Axe", "2d4' , crit x3, 12 lbs., Large, Slashing", 100);
            else if (throwingAxe <= roll)
                item_component = new Component("Throwing Axe (Light, 2d4)", "1d4, crit x2, Range 10 ft., 2 lbs., Small. Slashing", 3);
            else if (axe <= roll)
                item_component = new Component("Axe (Hand)", "1d6, crit x3, 4 lbs., Medium, Slashing", 20);
            else
                item_component = new Component("Hand Axe (Light)", "1d4, crit x3, 2 lbs., Small, Slashing", 10);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 26, endPrefixIndex: 85);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 26, 86);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Bows(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var shortBow = 7;
            var huntersBow = 3 + shortBow;
            var longBow = 3 + huntersBow;
            var arrows = 7 + longBow;
            var compositeBow = 3 + arrows;
            var shortBattleBow = 3 + compositeBow;
            var shortWarBow = 3 + shortBattleBow;
            var longBattleBow = 3 + shortWarBow;
            var roll = DiceRoller.RandNumber20SidedDice("Bows") + cr;

            if (roll > longBattleBow)
                item_component = new Component("Long War Bow", "1d8 (+2 Strength bow)*, crit x4, Range 110 ft., 3 lbs., Large, Piercing", 300);
            else if (longBattleBow <= roll)
                item_component = new Component("Long Battle Bow", "1d8 (+1 Strength bow)*, crit x3, Range 110 ft., 3 lbs., Large, Piercing", 250);
            else if (shortWarBow <= roll)
                item_component = new Component("Short War Bow", "1d6 (+2 Strength bow)*, crit x4, Range 70 ft., 2 lbs ., Medium, Piercing", 200);
            else if (shortBattleBow <= roll)
                item_component = new Component("Short Battle Bow", "1d6 (+1 Strength bow)*, crit x3, Range 70 ft., 2 lbs., Medium, Piercing", 150);
            else if (compositeBow <= roll)
                item_component = new Component("Composite Bow", "1d8*, crit x3, Range 110 ft., 3lbs., Large, Piercing", 100);
            else if (arrows <= roll)
                item_component = new Component("Arrows (4d8)", "Damage as per bow", 1);
            else if (longBow <= roll)
                item_component = new Component("Long Bow", "1d5* , crit x3, Range 100 ft., 3 lbs., Large, Piercing", 75);
            else if (huntersBow <= roll)
                item_component = new Component("Hunter's Bow", "1d6*, crit x3, Range 70 ft., 2 lbs., Medium, Piercing", 50);
            else
                item_component = new Component("Short Bow", "1d6* , crit x3, Range 60 ft., 2 lbs., Medium, Piercing", 30);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 31, endPrefixIndex: 90);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 31, 90);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Crossbows(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var Bolts1 = 5;
            var lightCrossbow = 12 + Bolts1;
            var Bolts2 = 5 + lightCrossbow;
            var crossbow = 10 + Bolts2;
            var roll = DiceRoller.RandNumber20SidedDice("Crossbows") + cr;

            if (roll > crossbow)
                item_component = new Component("Bolts (3d6)", "Damage as per crossbow", 100);
            else if (crossbow <= roll)
                item_component = new Component("Crossbow (Heavy)", "1dl0 ,crit 19-20/x2, Range 120 ft., 9Ibs., Medium, Piercing", 150);
            else if (Bolts2 <= roll)
                item_component = new Component("Bolts (3d6) ", "Damage as per crossbow", 100);
            else if (lightCrossbow <= roll)
                item_component = new Component("Light Crossbow", "1d8', crit 19-20/x2, Range 80 ft., 6Ibs. , Small, Piercing", 70);
            else
                item_component = new Component("Bolts (3d6)", "Damage as per crossbow", 100);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 31, endPrefixIndex: 90);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 31, 90);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Wands(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var wand = 13;
            var boneWand = 7 + wand;
            var yewWand = 5 + boneWand;
            var roll = DiceRoller.RandNumber20SidedDice("Wands") + cr;

            if (roll > yewWand)
                item_component = new Component("Grim Wand", "1d4, crit x2, 1 lb., Small, Bludgeoning", 100);
            else if (yewWand <= roll)
                item_component = new Component("Yew Wand", "1d3 , crit x2, 1 lb., Small, Bludgeoning", 60);
            else if (boneWand <= roll)
                item_component = new Component("Bone Wand", "1d3, crit x2, 1 lb., Small, Bludgeoning", 30);
            else
                item_component = new Component("Wand", "1d2, crit x2, 1 lb., Small, Bludgeoning", 10);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 41, endPrefixIndex: 90);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 41, 90);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Staves(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var shortStaff = 10;
            var longStaff = 9 + shortStaff;
            var gnarledStaff = 7 + longStaff;
            var battleStaff = 6 + gnarledStaff;
            var roll = DiceRoller.RandNumber20SidedDice("Staves") + cr;

            if (roll > battleStaff)
                item_component = new Component("War Staff", "1d10', crit x2, 10 Ibs., Large, Bludgeoning", 200);
            else if (battleStaff <= roll)
                item_component = new Component("Battle Staff", "2d4, crit x2, 6ibs., Large, Bludgeoning", 100);
            else if (gnarledStaff <= roll)
                item_component = new Component("Gnarled Staff", "1d8, crit x2, 6Ibs., Large, Bludgeoning", 50);
            else if (longStaff <= roll)
                item_component = new Component("Long Staff", "1d6 , crit x2 , 6 Ibs., Large, Bludgeoning", 30);
            else
                item_component = new Component("Short Staff", "1d4, crit x2, 3 Ibs., Medium, Bludgeoning", 10);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 41, endPrefixIndex: 90);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 41, 90);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Accessories(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var charm = 6;
            var ring = 11 + charm;
            var flag = 1 + ring;
            var orb = 1 + flag;
            var roll = DiceRoller.RandNumber20SidedDice("Accessories") + cr;

            if (roll > orb)
                item_component = new Component("Amulet", "Worn on neck, one per character", 200);
            else if (orb <= roll)
                item_component = new Component("Orb", "Worn on arm, one per character, can't use both shield and orb", 150);
            else if (flag <= roll)
                item_component = new Component("Flag", "Draped over body, one per character", 100);
            else if (ring <= roll)
                item_component = new Component("Ring", "Worn on hand, one per hand", 75);
            else
                item_component = new Component("Charm", "Has its effect if carried on person", 50);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);

            // Make sure accessories are always magic
            if (!prefix && !suffix)
            {
                prefix = true;
            }
            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 31, endPrefixIndex: 70);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 31, 70);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        public static ItemDescription Gems(int cr, bool prefix, bool suffix)
        {
            Component item_component;
            var gemType = GemsHelper();
            var chippedJewel = 7;
            var flawedJewel = 6 + chippedJewel;
            var jewel = 6 + flawedJewel;
            var flawlessJewel = 6 + jewel;
            var roll = DiceRoller.RandNumber20SidedDice("Gems") + cr;

            if (roll > flawlessJewel)
                item_component = new Component("Perfect Jewel", gemType, 1000);
            else if (flawlessJewel <= roll)
                item_component = new Component("Flawless Jewel", gemType, 500);
            else if (jewel <= roll)
                item_component = new Component("Jewel", gemType, 250);
            else if (flawedJewel <= roll)
                item_component = new Component("Flawed Jewel", gemType, 100);
            else
                item_component = new Component("Chipped Jewel", gemType, 50);

            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);


            if (prefix)
                prefix_component = Prefix.GetPrefix(cr, startPrefixIndex: 31, endPrefixIndex: 70);

            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 31, 70);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }

        private static string GemsHelper()
        {
            var gem_types = new List<String> {
                "amethyst",
                "diamond",
                "emerald",
                "ruby",
                "sapphire",
                "topaz"
            };
            var roll = DiceRoller.RandNumber(1, 6, "type of gem");
            return gem_types[roll - 1];
        }

        // NOT USED
        public static object InscribedSpells(int cr, bool suffix)
        {
            Component item_component;
            // options.extend([item_component = new Component("Scroll", "Can be read once to cast the spell, at minimum level necessary to cast spell", 25)] *
            // options.extend([item_component = new Component("Rune", "Set once as a trap, acts as a glyph of warding with the listed spell's effect", 50)] *
            // options.extend([item_component = new Component("Book", "Can be read once to gain the spell, allows one improvement class for its spell", 100)] *
            var prefix_component = new Component(String.Empty, String.Empty, 0);
            var suffix_component = new Component(String.Empty, String.Empty, 0);
            var roll = DiceRoller.RandNumber20SidedDice("Inscribed Spells") + cr;
            if (roll < -1)
            {
                item_component = null;//options[roll];
            }
            else
                item_component = null;
            if (suffix)
                suffix_component = Suffix.GetSuffix(cr, 91, 100);

            return new ItemDescription(item_component, prefix_component, suffix_component);
        }
    }
}
