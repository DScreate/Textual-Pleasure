using Engine.Common;
using Engine.Model.Character;
using Engine.Model.Dice;
using Engine.Model.Factories;
using Engine.Model.Items;
using Engine.ViewModel;

namespace Engine.Model.Battle
{
    public class BattleInstance
    {
        public GameSession CurrentSession { get; set; }
        public PlayerCharacter CurrentPlayer { get; set; }
        public BaseMonster CurrentMonster { get; set; }
        public Roller DiceRoller { get; set; }

        public BattleInstance(GameSession session, PlayerCharacter player, BaseMonster monster)
        {
            CurrentSession = session;
            
            CurrentSession.ButtonContext = new BattleButtonContext(CurrentSession, this);

            CurrentPlayer = player;
            CurrentMonster = monster;
            DiceRoller = new Roller();
        }

        
        public void AttackCurrentMonster()
        {

            // Determine damage to monster
            RollResults PlayerDamage = DiceRoller.RollDiceAgainstThreshold((int) CurrentPlayer.StrengthAttackPower);
            RollResults MonsterToughness =
                DiceRoller.RollDiceAgainstThreshold((int) CurrentMonster.myStats.Toughness.Value);

            int damageToMonster = (PlayerDamage.Hits + (2 * PlayerDamage.Crits)) - MonsterToughness.Hits/2;

            if (damageToMonster == 0)
            {
                RaiseMessage($"You missed {CurrentMonster.Name}.");
            }
            else
            {
                CurrentMonster.CurrentHealth -= damageToMonster;
                RaiseMessage($"You hit {CurrentMonster.Name} for {damageToMonster} points.");
            }

            // If monster if killed, collect rewards and loot
            if (CurrentMonster.CurrentHealth <= 0)
            {
                RaiseMessage("");
                RaiseMessage($"You defeated {CurrentMonster.Name}!");

                CurrentPlayer.Experience += CurrentMonster.RewardExperiencePoints;
                RaiseMessage($"You receive {CurrentMonster.RewardExperiencePoints} experience points.");

                CurrentPlayer.Gold += CurrentMonster.RewardGold;
                RaiseMessage($"You receive {CurrentMonster.RewardGold} gold.");

                CurrentSession.ButtonContext = new ExploreButtonContext(CurrentSession);


            }
            else
            {
                RollResults MonsterDamage = DiceRoller.RollDiceAgainstThreshold((int)CurrentMonster.StrengthAttackPower);
                RollResults PlayerToughness =
                    DiceRoller.RollDiceAgainstThreshold((int)CurrentPlayer.myStats.Toughness.Value);
                // If monster is still alive, let the monster attack
                int damageToPlayer = (MonsterDamage.Hits + (2 * MonsterDamage.Crits)) - PlayerToughness.Hits;

                if (damageToPlayer <= 0)
                {
                    RaiseMessage("The monster attacks, but misses you.");
                }
                else
                {
                    CurrentPlayer.CurrentHealth -= damageToPlayer;
                    RaiseMessage($"{CurrentMonster.Name} hit you for {damageToPlayer} points.");
                }

                // If player is killed, move them back to their home.
                if (CurrentPlayer.CurrentHealth <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"The {CurrentMonster.Name} defeated you...");

                    CurrentSession.CurrentLocation = CurrentSession.CurrentWorld.LocationAt(0, -1); // Player's home
                    CurrentPlayer.CurrentHealth = CurrentPlayer.MaxHealth; // Completely heal the player

                    CurrentSession.ButtonContext = new ExploreButtonContext(CurrentSession);

                }
            }
        }

        public void Guard()
        {
            // Determine how much we're blocking
            int GuardValue = DiceRoller.RollDiceAgainstThreshold((int) (CurrentPlayer.myStats.Endurance.Value * 1.5)).Hits;

            RollResults MonsterDamage = DiceRoller.RollDiceAgainstThreshold((int)CurrentMonster.StrengthAttackPower);



            // If monster is still alive, let the monster attack
            int damageToPlayer = (MonsterDamage.Hits + (2 * MonsterDamage.Crits)) - GuardValue/2;

                if (damageToPlayer <= 0)
                {
                    RaiseMessage("The monster attacks, but you block it!");
                }
                else
                {
                    CurrentPlayer.CurrentHealth -= damageToPlayer;
                    RaiseMessage($"The {CurrentMonster.Name} hit you for {damageToPlayer} points.");
                }

                // If player is killed, move them back to their home.
                if (CurrentPlayer.CurrentHealth <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"The {CurrentMonster.Name} defeated you...");

                    CurrentSession.CurrentLocation = CurrentSession.CurrentWorld.LocationAt(0, -1); // Player's home
                    CurrentPlayer.CurrentHealth = CurrentPlayer.MaxHealth; // Completely heal the player

                    CurrentSession.ButtonContext = new ExploreButtonContext(CurrentSession);
                }
            
        }

        private void RaiseMessage(string message)
        {
            CurrentSession.AddToDisplayText("\n"+message);
        }
        
    }
}