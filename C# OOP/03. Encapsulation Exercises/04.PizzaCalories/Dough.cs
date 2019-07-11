using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double CaloriesPerGram = 2;
        private const double WhiteModifier = 1.5;
        private const double WholegrainModifier = 1;
        private const double CripsyModifier = 0.9;
        private const double ChewyModifier = 1.1;
        private const double HomemadeModifier = 1;
        private const string WhiteFlourType = "white";
        private const string WholegrainType = "wholegrain";
        private const string BakingCrispy = "crispy";
        private const string BakingChewy = "chewy";
        private const string BakingHomemade = "homemade";
        private const string InvalidTypeDoughMessage = "Invalid type of dough.";
        private const string InvalidWeightDoughtMessage = "Dough weight should be in the range [1..200].";

        private string floourType;
        private string bakingTechnique;
        private double weigth;
        private double exactCalories;

        public Dough(string floourType, string bakingTechnique, double weigth)
        {
            this.FloourType = floourType;
            this.BakingTechnique = bakingTechnique;
            this.Weigth = weigth;
        }

        public double ExactCalories => (this.Weigth * CaloriesPerGram) * this.MultipleModifier();

        public double Weigth
        {
            get
            {
                return this.weigth;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(InvalidWeightDoughtMessage);
                }

                this.weigth = value;
            }
        }

        public string FloourType
        {
            get
            {
                return this.floourType;
            }
            private set
            {
                var currentFlourType = value.ToLower();
                if (!(WhiteFlourType == currentFlourType || WholegrainType == currentFlourType))
                {
                    throw new ArgumentException(InvalidTypeDoughMessage);
                }

                this.floourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                var currentValue = value.ToLower();

                if (!(BakingCrispy == currentValue || BakingChewy == currentValue || BakingHomemade == currentValue))
                {
                    throw new ArgumentException(InvalidTypeDoughMessage);
                }

                this.bakingTechnique = value;
            }
        }

        private double MultipleModifier()
        {
            var result = 0d;

            if (this.FloourType.ToLower() == WhiteFlourType)
            {
                result = WhiteModifier;
            }
            else
            {
                result = WholegrainModifier;
            }

            switch (this.BakingTechnique.ToLower())
            {
                case BakingCrispy: result *= CripsyModifier; break;
                case BakingChewy: result *= ChewyModifier; break;
                case BakingHomemade: result *= HomemadeModifier; break;
            }

            return result;
        }
    }
}
