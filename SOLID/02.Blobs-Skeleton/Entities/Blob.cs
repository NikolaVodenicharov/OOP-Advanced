namespace _02.Blobs.Entities
{
    using System;

    using _02.Blobs.Entities.Attacks;
    using _02.Blobs.Entities.Behaviors;
    using Interfaces;

    public class Blob
    {
        private string name;
        private int currentHealth;
        private int initialHealth;
        private int currentDamage;
        private IBehavior behavior;
        private ISpecialAttack specialAttack;

        private int triggerCount;

        public Blob(
            string name, 
            int health, 
            int damage, 
            IBehavior behavior, 
            ISpecialAttack specialAttack)
        {
            this.Name = name;
            this.CurrentHealth = health;
            this.initialHealth = health;
            this.CurrentDamage = damage;
            this.Behavior = behavior;
            this.specialAttack = specialAttack;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }
        public int CurrentHealth
        {
            get
            {
                return this.currentHealth;
            }
            set
            {
                this.currentHealth = Math.Max(0, value);

                if (!this.IsAlive())
                {
                    // it is dead, do something
                }

                if (this.CanTriggerBehavior())
                {
                    this.TriggerBehavior();
                }
            }
        }
        public int CurrentDamage
        {
            get
            {
                return this.currentDamage + this.behavior.DamageModificator;
            }
            set
            {
                this.currentDamage = value;
            }
        }
        public IBehavior Behavior
        {
            get
            {
                return this.behavior;
            }
            private set
            {
                this.behavior = value;
            }
        }
        public ISpecialAttack SpecialAttack
        {
            get
            {
                return this.specialAttack;
            }
            private set
            {
                this.specialAttack = value;
            }
        }

        public void DecreaseHealth(int damage)
        {
            this.CurrentHealth -= damage;
        }

        public int AttackDamage()
        {
            int attack = 0;

            return attack;
        }
    
        public void NextTurn()
        {
            this.behavior.ProcessNextTurn();
            this.currentHealth += behavior.HealthModificator;
            this.currentDamage += behavior.DamageModificator;
        }

        public override string ToString()
        {
            if (!this.IsAlive())
            {
                return $"IBlob {this.Name} KILLED";
            }

            return $"IBlob {this.Name}: {this.CurrentHealth} HP, {this.CurrentDamage} Damage";
        }

        private void TriggerBehavior()
        {
            this.behavior.Trigger(this);
        }
        private bool CanTriggerBehavior()
        {
            bool canTrigger = (this.currentHealth <= this.initialHealth / 2) && 
                                !this.Behavior.IsTriggered;
            return canTrigger;
        }       

        private bool IsAlive()
        {
            var isAlive = this.currentHealth > 0;
            return isAlive;
        }
    }
}