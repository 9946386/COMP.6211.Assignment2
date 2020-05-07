using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechSynthesizer reader;

        Dictionary<string, Drink> drinkDictionary = new Dictionary<string, Drink>()
        {
            {
                "Cosmopolitan", new Drink()
                {
                    Name = "Cosmopolitan",
                    ImageName = "Images/cosmopolitan.jpg",
                    Recipe = "1.5 ounces of citrus vodka, 1 ounce of Cointreau, half an ounce of lime juice and a quarter of an ounce of cranberry juice.",
                    Mix = "Put all the ingredients in a shaker with ice and shake. Strain into a martini glass and garnish with a lime wheel or zest."
                }
            },

            {
                "Daiquiri", new Drink()
                {
                    Name = "Daiquiri",
                    ImageName = "Images/daiquiri.jpg",
                    Recipe = "2 ounces of light rum, 1 ounce of simple syrup and 1 ounces of lime juice.",
                    Mix = "Shake ingredients with ice and strain into a cocktail glass. Garnish with a lime wheel."
                }
            },

            {
                "Dark n Stormy", new Drink()
                {
                    Name = "Dark n Stormy",
                    ImageName = "Images/DarknStormy.jpg",
                    Recipe = "1.5 ounces of Gosling’s Black Seal Rum and ginger beer to top.",
                    Mix = "Fill a highball glass with ice and add rum and ginger beer. Garnish with lime."
                }
            },

            {
                "French 75", new Drink()
                {
                    Name = "French 75",
                    ImageName = "Images/french75.jpg",
                    Recipe = "2 ounces of gin, 2 dashes of simple syrup, half an ounce of lemon juice and champagne.",
                    Mix = "Shake gin, simple syrup, and lemon juice with ice. Strain into a champagne glass. Top with champagne."
                }
            },

            {
                "Gimlet", new Drink()
                {
                    Name = "Gimlet",
                    ImageName = "Images/gimlet.jpg",
                    Recipe = "2 ounces of gin or vodka, three quarters of an ounce of simple syrup, three quarters of an ounce of lime juice.",
                    Mix = "Shake ingredients with ice and strain into a cocktail glass."
                }
            },

            {
                "Manhattan", new Drink()
                {
                    Name = "Manhattan",
                    ImageName = "Images/manhattan.jpg",
                    Recipe = "2 ounces of silver tequila, 1 ounce of Cointreau, 1 ounce of lime juice and salt for the glass rim.",
                    Mix = "It should be shaken, then serve over ice in a glass with a salted rim."
                }
            },

            {
                "Martinez", new Drink()
                {
                    Name = "Martinez",
                    ImageName = "Images/martinez.jpg",
                    Recipe = "1.5 ounces of Old Tom gin, 1.5 ounces of sweet vermouth, a quarter of an ounce of Luxardo maraschino liqueur and 2 dashes of Angostura or orange bitters.",
                    Mix = "Stir ingredients in a mixing glass with ice. Strain into chilled martini glass or cocktail glass."
                }
            },

            {
                "Martini", new Drink()
                {
                    Name = "Martini",
                    ImageName = "Images/martini.jpg",
                    Recipe = "3 ounces of gin or vodka, half an ounce of dry vermouth and lemon peel or an olive.",
                    Mix = "Stir ingredients in a mixing glass with ice. Strain into a chilled martini glass. Squeeze oil from the lemon peel into the glass or garnish with an olive."
                }
            },

            {
                "Mimosa", new Drink()
                {
                    Name = "Mimosa",
                    ImageName = "Images/mimosa.jpg",
                    Recipe = "2.5 ounces of champagne and 2.5 ounces of orange juice.",
                    Mix = "Combine equal parts of the ingredients in a champagne flute."
                }
            },

            {
                "Mint Julep", new Drink()
                {
                    Name = "Mint Julep",
                    ImageName = "Images/mintJulep.jpg",
                    Recipe = "2 ounces of bourbon, 8 to 10 mint leaves and a quarter of an ounce of simple syrup.",
                    Mix = "Mix-up the mint leaves and simple syrup in a cup. Add bourbon and fill with crushed ice. Stir until the cup is frosted. Fill with more crushed ice. Serve with a straw and a mint sprig garnish."
                }
            },

            {
                "Mojito", new Drink()
                {
                    Name = "Mojito",
                    ImageName = "Images/mojito.jpg",
                    Recipe = "2 ounces of vodka, 4 to 6 ounces of ginger beer and 5 ounces of lime juice.",
                    Mix = "Squeeze lime juice into a mug, add two or three ice cubes, pour in the vodka, and fill with cold ginger beer. Stir and serve."
                }
            },

            {
                "Negroni", new Drink()
                {
                    Name = "Negroni",
                    ImageName = "Images/negroni.jpg",
                    Recipe = "1 ounce of gin, 1 ounce of Campari and 1 ounce of sweet vermouth.",
                    Mix = "Stir ingredients with ice."
                }
            },

            {
                "Old Fashioned", new Drink()
                {
                    Name = "Old Fashioned",
                    ImageName = "Images/oldFashioned.jpg",
                    Recipe = "2 ounces of bourbon or rye whiskey, 2 dashes of Angostura bitters, 1 sugar cube or 1 tablespoon sugar and an orange twist garnish.",
                    Mix = "Put sugar in glass. Cover it with dashes of bitters. Add whiskey and stir until the sugar dissolves. Add ice, stir again, and serve."
                }
            },

            {
                "Paloma", new Drink()
                {
                    Name = "Paloma",
                    ImageName = "Images/palmona.jpg",
                    Recipe = "2 ounces of tequila, half an ounce of lime juice and grapefruit soda to top.",
                    Mix = "Add tequila and lime to a salt-rimmed glass filled with ice. Top with grapefruit soda"
                }
            },

            {
                "Pimms Cup", new Drink()
                {
                    Name = "Pimms Cup",
                    ImageName = "Images/pimmsCup.jpg",
                    Recipe = "1.75 ounces of  Pimm's No.1, 5 ounces of lemonade, mint, orange, strawberries and cucumber to garnish.",
                    Mix = "Pile all the ingredients in a tall glass, mix, and sip."
                }
            },

            {
                "Pina Colada", new Drink()
                {
                    Name = "Pina Colada",
                    ImageName = "Images/pinaColada.jpg",
                    Recipe = "3 ounces of white rum, 1.5 ounces of coconut cream, 3.5 ounces of pineapple juice, 10 ounces of crushed ice and 1 slice of pineapple.",
                    Mix = "Place the crushed ice into a blender and whizz it for 15 seconds. Now add the coconut cream, rum and the pineapple juice. Blend it on medium until you get a smooth, creamy mixture. Pour it into a tall wine glass and garnish the side of the glass with a slice of pineapple."
                }
            },

            {
                "Sazerac", new Drink()
                {
                    Name = "Sazerac",
                    ImageName = "Images/sazerac.jpg",
                    Recipe = "2 ounces of rye whiskey, half an ounce of simple syrup, 2 dashes of Peychaud's bitters and Absinthe.",
                    Mix = "Rinse a chilled glass with absinthe and discard the absinthe. Stir the other ingredients in a mixing glass, strain into the chilled glass, and garnish."
                }
            },

            {
                "Sidecar", new Drink()
                {
                    Name = "Sidecar",
                    ImageName = "Images/sideCar.jpg",
                    Recipe = "2 ounces of VS or VSOP Cognac, 1 ounce of Cointreau, three quarters of an ounce of lemon juice.",
                    Mix = "Shake ingredients with ice. Strain into a rocks glass or a cocktail class with a sugar-coated rim."
                }
            },

            {
                "Singapore Sling", new Drink()
                {
                    Name = "Singapore Sling",
                    ImageName = "Images/singaporeSling.jpg",
                    Recipe = "1.5 ounces of Ford’s Gin, a quarter of an ounce of Cherry Herring, a quarter of an ounce of Combier, a quarter of an ounce of Benedictine, 2 ounces  of pineapple juice and a quarter of an ounce of grenadine.",
                    Mix = "Add all the ingredients into a shaker over ice. Shake and strain into tiki glass with fresh pebble ice. Garnish with orange peel and macerated cherry."
                }
            },

            {
                "Surfer Girl", new Drink()
                {
                    Name = "Surfer Girl",
                    ImageName = "Images/surferGirl.jpg",
                    Recipe = "1.5 ounces of Four Pillars Rare Dry Gin, half an ounce of lime juice, half an ounce of honey, 1 ounce of watermelon juice and 5 to 6 basil leaves.",
                    Mix = "Combine all ingredients in a shaker over ice. Shake. Strain into a coupe glass and garnish with basil."
                }
            },

            {
                "Whiskey", new Drink()
                {
                    Name = "Whiskey",
                    ImageName = "Images/whiskeySour.jpg",
                    Recipe = "2 ounces of whiskey, 1 ounce of lemon juice, 1 tablespoon of sugar and 1 egg white optional.",
                    Mix = "Combine ingredients in a cocktail shaker and shake. Add ice and shake again. Strain over ice in a rocks glass."
                }
            }
        };

        public MainWindow()
        {
            InitializeComponent();

            DrinksListBox.ItemsSource = drinkDictionary.Keys;

            reader = new SpeechSynthesizer();
            reader.SetOutputToDefaultAudioDevice();
        }

        private void DrinksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string itemSelected = DrinksListBox.SelectedItem.ToString();

            if (drinkDictionary.ContainsKey(itemSelected) == false)
            {
                TextBoxName.Text += $"\nKey {itemSelected} not found.";
                ImageDrink.Source = new BitmapImage(new Uri("Images/Empty Glass.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Drink theDrink = drinkDictionary[itemSelected];

                TextBoxName.Text = theDrink.Name;
                ImageDrink.Source = new BitmapImage(new Uri(theDrink.ImageName, UriKind.RelativeOrAbsolute));
                TextBlockRecipe.Text = theDrink.Recipe;
                TextBlockMix.Text = theDrink.Mix;
            }
        }

        private void DrinksListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string DrinkString = TextBoxName.Text + " " + TextBlockRecipe.Text + " " + TextBlockMix.Text;

            if (SynthesizerState.Speaking != reader.State)
            {
                reader.SpeakAsync(DrinkString);
            }
        }
    }
}
