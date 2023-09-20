using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffs
{
    public interface IBuff 
    {
        CharacterStats ApplyBuff(CharacterStats stats);
    }

    public interface IBuffable
    {
        void AddBuff(IBuff buff);
        void RemoveBuff(IBuff buff);
    }

    public struct CharacterStats
    {
        public int Health;
        public int Armor;
        public int Damage;
        public bool IsImmortal;
    }

    public class DamaeBuff : IBuff 
    {
        private int damageBonus; 

        public DamaeBuff(int damageBonus)
        {
            this.damageBonus = damageBonus;
        }

        public CharacterStats ApplyBuff(CharacterStats stats) 
        {
            var newStats = stats;
            newStats.Damage += damageBonus;
            
            if (newStats.Damage < 0)
                newStats.Damage = 0;

            return newStats;
        }
    }

    public class ImmortalityBuff : IBuff 
    {
        public CharacterStats ApplyBuff(CharacterStats stats) 
        {
            var newStats = stats;

            newStats.IsImmortal = true;

            return newStats;
        }
    }

    public class Character : IBuffable
    {
        public CharacterStats BaseStats { get; }
        public CharacterStats CurrentStats { get; private set; }
        
        private List<IBuff> buffs = new();

        public Character(CharacterStats stats)
        {
            BaseStats = stats;
            CurrentStats = stats;
        }

        public void AddBuff(IBuff buff) 
        {
            buffs.Add(buff);
            ApplyBuffs();
            Console.WriteLine($"Buff added: {buff}");
        }

        public void RemoveBuff(IBuff buff) 
        { 
            buffs.Remove(buff);
            ApplyBuffs();
            Console.WriteLine($"Buff removed: {buff}");
        }

        private void ApplyBuffs()
        {
            CurrentStats = BaseStats;

            foreach (IBuff buff in buffs) 
            {
                CurrentStats = buff.ApplyBuff(CurrentStats);
            }
        }
    }

    public class CharacterView
    {
        var stats = new CharacterStats
        {
            Damage = 20,
            Health = 20,
            Armor = 20,
            IsImmortal = false,
        };

        private Character character = new(stats);

        Console.WriteLine($"Character created : {character.CurrentStats.Damage}");

    }
}