using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AnimalBinaryTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Dictionary

        Dictionary<string, DataNode> myDictionary = new Dictionary<string, DataNode>()
        {
            {"Animal", new DataNode() { CurrentNode = "Animal", NextNode = "Land", Question = "Do you mainly live on land?", ImageName = "images/land.jpg", Data = "Do you spend most of your life in water or on land?" } },

            {"Animal AND Land", new DataNode() { CurrentNode = "Land", NextNode = "Wings", Question = "Do you have wings?", ImageName = "images/wings.jpg", Data = "Do you have wings? Even if they aren't used for flying."} },
            {"Animal NOT Land", new DataNode() { CurrentNode = "Land", NextNode = "Cute", Question = "Are you a cute animal?", ImageName = "images/cute.jpg", Data = "When people see you do they say 'Nawww'"} },

            {"Animal AND Land AND Wings", new DataNode() { CurrentNode = "Wings", NextNode  = "Fly", Question = "Are you an animal that can fly?", ImageName = "images/fly.jpg", Data = "I wish that I could fly. Into the sky. So very high."} },
            {"Animal AND Land NOT Wings", new DataNode() { CurrentNode = "Wings", NextNode = "Pet", Question = "Are you a house pet?", ImageName = "images/pet.jpg", Data = "Do you leave droppings on the lawn or chew up homework?"} },

            {"Animal NOT Land AND Cute", new DataNode() { CurrentNode = "Cute", NextNode = "Water", Question = "Do you always live under water?", ImageName = "images/underwater.jpg", Data = "Can you only survive if you are underwater"} },
            {"Animal NOT Land NOT Cute", new DataNode() { CurrentNode = "Cute", NextNode = "Slimy", Question = "Are you slimy to touch?", ImageName = "images/slimy.jpg", Data = "Do people say 'Ewww yuck!' when they touch you?"}},

            {"Animal AND Land AND Wings AND Fly", new DataNode() { CurrentNode = "Fly", NextNode = "Corona", Question = "Do they think you caused the Coronavirus?", ImageName = "images/corona.jpg", Data = "Did someone eat you and then blame a worldwide pandemic on you?"} },
            {"Animal AND Land AND Wings NOT Fly", new DataNode() { CurrentNode = "Fly", NextNode = "Waddle", Question = "Do you waddle when you walk?", ImageName = "images/waddle.png", Data = "Does your body sway from side to side when you walk?"}},

            {"Animal AND Land NOT Wings AND Pet", new DataNode() { CurrentNode = "Pet", NextNode = "Hop", Question = "Are you a pet that can hop?", ImageName = "images/hop.jpg", Data = "Stuff walking, running or flying. Hoping is much better!" } },
            {"Animal AND Land NOT Wings NOT Pet", new DataNode() { CurrentNode = "Pet", NextNode = "Stink", Question = "Are you a stinky animal?", ImageName = "images/stink.png", Data = "Do people say 'Pee-Yew' when you walk in the room?"} },

            {"Animal NOT Land AND Cute AND Water", new DataNode() { CurrentNode = "Water", NextNode = "Pregnant", Question = "Can your males carry babies?", ImageName = "images/pregnant.png", Data = "Yes you read that right, do the males of your species carry the eggs?"} },
            {"Animal NOT Land AND Cute NOT Water", new DataNode() { CurrentNode = "Water", NextNode = "Shell", Question = "Do you have a shell?", ImageName = "images/shell.jpg", Data = "Do you carry your house around on your back?"} },

            {"Animal NOT Land NOT Cute AND Slimy", new DataNode() { CurrentNode = "Slimy", NextNode = "Tentacles", Question = "Do you have tentacles?", ImageName = "images/tentacles.jpg", Data = "Do you have any of those long, creepy things called tentacles?"} },
            {"Animal NOT Land NOT Cute NOT Slimy", new DataNode() { CurrentNode = "Slimy", NextNode = "Attack", Question = "Are you known to sometimes attack humans?", ImageName = "images/attack.jpg", Data = "It's not your fault humans are so delicious" } },

            {"Animal AND Land AND Wings AND Fly AND Corona", new DataNode() { CurrentNode = "Corona", NextNode = "DataNode", Question = "Bat", ImageName = "images/bat.png", Data = "You are a BAT! A bat is like someone made a squirrel out of a duck. I mean what’s going on there? Is it a bird? Some form of hamster bird? No it’s like a moth mixed with a cat. Some sort of bear wasp maybe?"} },
            {"Animal AND Land AND Wings AND Fly NOT Corona", new DataNode() { CurrentNode = "Corona", NextNode = "DataNode", Question = "Owl", ImageName = "images/owl.png", Data = "You are an OWL! An own is a pigeon filled with anger and knowledge. Basically a violent balloon covered in feathers. An owl’s natural predators are hurricanes and wizards."} },
            {"Animal AND Land AND Wings NOT Fly AND Waddle", new DataNode() { CurrentNode = "Waddle", NextNode = "DataNode", Question = "Penguin", ImageName = "images/penguin.png", Data = "You are a PENGUIN! Penguins vomit on their own children for fun. They live in the most remote areas of the world because they are socially awkward. Penguins have wings but don’t bloody use them. Penguins are just panda chickens."} },
            {"Animal AND Land AND Wings NOT Fly NOT Waddle", new DataNode() { CurrentNode = "Waddle", NextNode = "DataNode", Question = "Ostrich", ImageName = "images/ostrich.png", Data = "You are an OSTRICH! The word ‘Ostrich' in latin translates to ‘massive horror chicken’. The ostrich is one of the fastest land birds in the world because other birds are sensible enough to fly. Ostriches can fly but its really difficult to get them on an airplane."} },

            {"Animal AND Land NOT Wings AND Pet AND Hop", new DataNode() { CurrentNode = "Hop", NextNode = "DataNode", Question = "Rabbit", ImageName = "images/rabbit.png", Data = "You are a RABBIT! Rabbits belong to the ‘floof’ family and are genetically similar to feather dusters. Rabbits natural predators include sheep, dragons, missiles and the moon. The French word for rabbit is 'la bouncy mouse'."} },
            {"Animal AND Land NOT Wings AND Pet NOT Hop", new DataNode() { CurrentNode = "Hop", NextNode = "DataNode", Question = "Pug", ImageName = "images/pug.png", Data = "You are a PUG! Pugs are basically a normal dog that got shot into a wall or something. They breathe like Darth Vader filled with helium. Can’t be trusted with money and baby pugs are called Puglets"} },
            {"Animal AND Land NOT Wings NOT Pet AND Stink", new DataNode() { CurrentNode = "Stink", NextNode = "DataNode", Question = "Skunk", ImageName = "images/skunk.png", Data = "You are a SKUNK! Skunks are commonly known as arse badgers. According to cartoons they are perverts. Their natural enemies are deodorant and golf clubs. They don’t get arse badgers in the UK as they are allergic to tea and hate the queen." } },
            {"Animal AND Land NOT Wings NOT Pet NOT Stink", new DataNode() { CurrentNode = "Stink", NextNode = "DataNode", Question = "Armadillo", ImageName = "images/armadillo.png", Data = "You are an ARMADILLO! An Armadillo is a hedgehog in a caravan. Their skin is so thick they can’t take insults to heart. The collective noun for armadillos is ‘a bloody load of armadillos’"} },

            {"Animal NOT Land AND Cute AND Water AND Pregnant", new DataNode() { CurrentNode = "Pregnant", NextNode = "DataNode", Question = "Seahorse", ImageName = "images/seahorse.png", Data = "You are a SEAHORSE! Male seahorses have babies. Well no, not really. The female deposits fertilized eggs into the males pouch where they carry them until they are ready to be born."} },
            {"Animal NOT Land AND Cute AND Water NOT Pregnant", new DataNode() { CurrentNode = "Pregnant", NextNode = "DataNode", Question = "Dolphin", ImageName = "images/dolphin.png", Data = "You are a DOLPHIN! A dolphin is basically some sort of sea giraffe. The average dolphin eats less than 3 horses a year. Dolphins can punt a human child 2 miles using their tail.The oldest dolphin ever died."} },
            {"Animal NOT Land AND Cute NOT Water AND Shell", new DataNode() { CurrentNode = "Shell", NextNode = "DataNode", Question = "Turtle", ImageName = "images/turtle.png", Data = "You are a TURTLE! Turtles are egg-laying, scaly reptiles with oval-shaped hard shells. They lumber around incredible slowly and have wrinkly, bald heads that make them look like wide old men."} },
            {"Animal NOT Land AND Cute NOT Water NOT Shell", new DataNode() { CurrentNode = "Shell", NextNode = "DataNode", Question = "Otter", ImageName = "images/otter.png", Data = "You are an OTTER! Otters are some sort of seal cat. An otter can not survive in space by itself. Otters hold hands when they sleep because they just like to be held. A group of otters is called a street gang. Otters wouldn’t vote for Donald Trump"} },

            {"Animal NOT Land NOT Cute AND Slimy AND Tentacles", new DataNode() { CurrentNode = "Tentacles", NextNode = "DataNode", Question = "Jellyfish", ImageName = "images/jellyfish.png", Data = "You are a JELLYFISH! Some jellyfish can glow in the dark. They do this to attract prey or distract predators. Jellyfish can clone themselves. If they are cut in two the two pieces of jellyfish regenerate and create two new organisms"} },
            {"Animal NOT Land NOT Cute AND Slimy NOT Tentacles", new DataNode() { CurrentNode = "Tentacles", NextNode = "DataNode", Question = "Eel", ImageName = "images/eel.png", Data = "You are an EEL! Eels are some sort of water hose. An eel can jump 50ft out of the water if launched from a slingshot. The collective noun for a group of eels is a ‘sodding cricket, why am I covered in eels?’. If you tie a bunch of eels into a knot you get thrown out of the aquarium." } },
            {"Animal NOT Land NOT Cute NOT Slimy AND Attack", new DataNode() { CurrentNode = "Attack", NextNode = "DataNode", Question = "Shark", ImageName = "images/shark.png", Data = "You are a SHARK! The movie Jaws used 28 sharks to portray the shark because they kept forgetting they were in a movie and swimming out to sea. A cowshark is neither a cow nor a shark — no wait, it’s totally a shark. If you look closely at a shark’s smile you’ll see it’s made of souvenir necklaces."} },
            {"Animal NOT Land NOT Cute NOT Slimy NOT Attack", new DataNode() { CurrentNode = "Attack", NextNode = "DataNode", Question = "Crab", ImageName = "images/crab.png", Data = "You are a CRAB! If you hold a crab up to your ear you can hear what it’s like to be attacked by a crab up close. The collective noun for crab is a ‘bloody hello’. Crabs can breathe underwater because they are hardcore and ignore the laws of nature."} }

        };

        #endregion

        // Set the default selection
        int selection = 0;

        // String used to process the tree
        string processString;

        public MainWindow()
        {
            InitializeComponent();

            // Set the start node for processing the string
            processString = myDictionary.Keys.ElementAt(0).ToString();

            #region Starting text

            TextBlockQuestion.Text = "The Animal Quiz";

            TextBlockData.Text = "The diagnostic helps you to find out what kind of animal you are. \n\nWhether you live on land or in water, if your slimy or have a shell, or if the males in your species carry their babies until they are ready to be born";

            #endregion
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            // Yes selected for the question set the selection flag and call the main processing method
            selection = 1;

            StartButton_Click(sender, e);
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            // No selected for the question set the selection flag and call the main processing method
            selection = 2;

            StartButton_Click(sender, e);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Setup the correct buttons for the user - Set the start button to off
            StartButton.IsEnabled = false;
            StartButton.Visibility = Visibility.Hidden;
            StartButton.Content = "Continue";

            #region Processing the node

            // Process the node
            if (myDictionary.ContainsKey(processString) == true)
            {
                // Display the NodeData here it can be a question or data node.
                // Match in the tree so create a temporary DataNode to process
                DataNode theDataNode = myDictionary[processString];

                // If we have a selection re-set the node
                // If Yes is selected built the next processing string with the addition of AND

                if (selection == 1)
                {
                    processString = processString + " AND " + theDataNode.NextNode;
                    if (myDictionary.ContainsKey(processString) == true)
                    {
                        theDataNode = myDictionary[processString];
                    }

                    else
                    {
                        theDataNode.Question = "Key " + processString + " not found - Looks like Anya has made a boo-boo. Whoops";
                        TextBlockQuestion.Foreground = Brushes.Red;
                    }
                }

                // If no is selected build the next processing string with the addition of a NOT

                if (selection == 2)
                {
                    processString = processString + " NOT " + theDataNode.NextNode;
                    if (myDictionary.ContainsKey(processString) == true)
                    {
                        theDataNode = myDictionary[processString];
                    }
                    else
                    {
                        theDataNode.Question = "Key " + processString + " not found - Looks like Anya has made a boo-boo. Whoops";
                        TextBlockQuestion.Foreground = Brushes.Red;
                    }
                }

                if (selection == 1 || selection == 2)
                {
                    // Re-set the selection flag to 0 - nothing selected
                    selection = 0;
                }

                //Process the tree CurrentNode
                //Process the tree DataNode Question
                TextBlockQuestion.Text = theDataNode.Question;

                //Process the dataNode image
                QuestionImage.Source = new BitmapImage(new Uri(theDataNode.ImageName, UriKind.RelativeOrAbsolute));

                //Process the tree DataNode Data
                TextBlockData.Text = theDataNode.Data;

                //IF the node is not the last (DataNode) then we need to offer and process the user selection to the question (Yes or No) in the diagnostic process
                if (theDataNode.NextNode != "DataNode")
                {
                    // Switch on Yes / No buttons
                    YesButton.IsEnabled = true;
                    YesButton.Visibility = Visibility.Visible;
                    NoButton.IsEnabled = true;
                    NoButton.Visibility = Visibility.Visible;
                }
                //If the node is the last (DataNode) then we need to offer the user a chance to re-start the diagnostic process
                else
                {
                    //Process the tree CurrentNode
                    //Re-set the search tree to the beginning node
                    processString = myDictionary.Keys.ElementAt(0).ToString();
                    //Re-Set the selection flag to 0 - nothing selected
                    selection = 0;
                    //Set up the correct buttons for the user - set the start button to restart
                    StartButton.Content = "Re-Start";
                    StartButton.IsEnabled = true;
                    StartButton.Visibility = Visibility.Visible;

                    //Hide the other buttons
                    YesButton.IsEnabled = false;
                    YesButton.Visibility = Visibility.Hidden;
                    NoButton.IsEnabled = false;
                    NoButton.Visibility = Visibility.Hidden;
                }
            }

            else
            {
                //This means we have an error with the dictionary setup
                TextBlockQuestion.Text = "Key " + processString + " not found - Looks like Anya has made a boo-boo. Whoops";
                TextBlockQuestion.Foreground = Brushes.Red;
                QuestionImage.Source = new BitmapImage(new Uri("Error.png", UriKind.RelativeOrAbsolute));
            }

            #endregion
        }
    }
}
