using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Drink
    {
        public string Name;
        public string ImageName;
        public string Recipe;
        public string Mix;

        public Drink()
        {
            Name = "";
            ImageName = "";
            Recipe = "";
            Mix = "";
        }

        public void Drink_(string inputName, string inputImageName, string inputRecipe, string inputMix)
        {
            Name = inputName;
            ImageName = inputImageName;
            Recipe = inputRecipe;
            Mix = inputMix;
        }
    }
}
