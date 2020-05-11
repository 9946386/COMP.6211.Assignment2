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

namespace BinaryTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Dictionary

        Dictionary<string, DataNode> myDictionary = new Dictionary<string, DataNode>()
        {
            {"StartNode", new DataNode() { CurrentNode = "StartNode", NextNode = "ResultNode1", Question = "Is it", ImageName = "Images/NextNode.png", Data = "StartNode"}},

            {"StartNode AND ResultNode1", new DataNode() { CurrentNode = "ResultNode1", NextNode = "ResultNode2", Question = "It is Yes or No", ImageName = "Images/NextNode.png", Data = "StartNode AND ResultNode1" }},
            {"StartNode NOT ResultNode1", new DataNode() { CurrentNode = "ResultNode1", NextNode = "ResultNode3", Question = "It is Yes or No", ImageName = "Images/NextNode.png", Data = "StartNode NOT ResultNode1"}},

            {"StartNode AND ResultNode1 AND ResultNode2", new DataNode() { CurrentNode = "ResultNode2", NextNode = "ResultNode4", Question = "Is it Yes or No", ImageName = "Images/NextNode.png", Data = "StartNode AND ResultNode1 AND ResultNode2"}},
            {"StartNode AND ResultNode1 NOT ResultNode2", new DataNode() { CurrentNode = "ResultNode2", NextNode = "ResultNode5", Question = "Is it Yes or No", ImageName = "Images/NextNode.png", Data = "StartNode AND ResultNode1 NOT ResultNode2"}},

            {"StartNode NOT ResultNode1 AND ResultNode3", new DataNode() { CurrentNode = "ResultNode3", NextNode = "ResultNode6", Question = "Is it Yes or No", ImageName = "Images/NextNode.png", Data = "StartNode NOT ResultNode1 AND ResultNode3"}},
            {"StartNode NOT ResultNode1 NOT ResultNode3", new DataNode() { CurrentNode = "ResultNode3", NextNode = "ResultNode7", Question = "Is it Yes or No", ImageName = "Images/NextNode.png", Data = "StartNode NOT ResultNode1 NOT ResultNode3"}},

            {"StartNode AND ResultNode1 AND ResultNode2 AND ResultNode4", new DataNode() { CurrentNode = "ResultNode4", NextNode = "DataNode", Question = "Data for A", ImageName = "Images/DataNode.png", Data = "Data for A"}},
            {"StartNode AND ResultNode1 AND ResultNode2 NOT ResultNode4", new DataNode() { CurrentNode = "ResultNode4", NextNode = "DataNode", Question = "Data for B", ImageName = "Images/DataNode.png", Data = "Data for B"}},
            {"StartNode AND ResultNode1 NOT ResultNode2 AND ResultNode5", new DataNode() { CurrentNode = "ResultNode5", NextNode = "DataNode", Question = "Data for C", ImageName = "Images/DataNode.png", Data = "Data for C"}},
            {"StartNode AND ResultNode1 NOT ResultNode2 NOT ResultNode5", new DataNode() { CurrentNode = "ResultNode5", NextNode = "DataNode", Question = "Data for D", ImageName = "Images/DataNode.png", Data = "Data for D"}},

            {"StartNode NOT ResultNode1 AND ResultNode3 AND ResultNode6", new DataNode() { CurrentNode = "ResultNode6", NextNode = "DataNode", Question = "Data for E", ImageName = "Images/DataNode.png", Data = "Data for E"}},
            {"StartNode NOT ResultNode1 AND ResultNode3 NOT ResultNode6", new DataNode() { CurrentNode = "ResultNode6", NextNode = "DataNode", Question = "Data for F", ImageName = "Images/DataNode.png", Data = "Data for F"}},
            {"StartNode NOT ResultNode1 NOT ResultNode3 AND ResultNode7", new DataNode() { CurrentNode = "ResultNode7", NextNode = "DataNode", Question = "Data for G", ImageName = "Images/DataNode.png", Data = "Data for G"}},
            {"StartNode NOT ResultNode1 NOT ResultNode3 NOT ResultNode7", new DataNode() { CurrentNode = "ResultNode7", NextNode = "DataNode", Question = "Data for H", ImageName = "Images/DataNode.png", Data = "Data for H"}},
        };

        #endregion

        #region Global Variables

        // Set the default selection
        int selection = 0;

        // String used to process the tree
        string processString;

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            // Set the start node for processing the tree
            processString = myDictionary.Keys.ElementAt(0).ToString();

            TextBlockQuestion.Text = "Basic Diagnostic";
            TextBlockData.Text = "Basic diagnostic to show the operation of Binary Tree Yes / No diagnostic\nThere are eight and nodes";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Setup the correct buttons for the user - Set the Start button to off
            StartButton.IsEnabled = false;
            StartButton.Visibility = Visibility.Hidden;
            StartButton.Content = "Continue";

            // Processing the Node
            if (myDictionary.ContainsKey(processString) == true)
            {
                // Display the NodeData here it can be a question Node or Data node

                // We have a match in the tree so create a temporary DataNode to process
                DataNode theDataNode = myDictionary[processString];

                // If we have a selection re-set the node
                // If yes is selected build the next processing string with the addition of an AND
                if (selection == 1)
                {
                    processString = processString + " AND " + theDataNode.NextNode;
                    if (myDictionary.ContainsKey(processString) == true)
                    {
                        theDataNode = myDictionary[processString];
                    }
                    else
                    {
                        theDataNode.Question = "Key " + processString + " not found - You have a problem with your Key or Nextnode data in your Dictionary - Problem is between nodes " + theDataNode.CurrentNode + " and " + theDataNode.NextNode;

                        TextBlockQuestion.Foreground = Brushes.Red;
                    }
                } 
                // If no is selected built the next processing string with the addition of a NOT
                if (selection == 2)
                {
                    processString = processString + " NOT " + theDataNode.NextNode;
                    if (myDictionary.ContainsKey(processString) == true)
                    {
                        theDataNode = myDictionary[processString];
                    }
                    else
                    {
                        theDataNode.Question = "Key " + processString + " not found - You have a problem with your Key or Nextnode data in your Dictionary - Problem is between nodes " + theDataNode.CurrentNode + " and " + theDataNode.NextNode;

                        TextBlockQuestion.Foreground = Brushes.Red;
                    }                    
                }
                
                if (selection == 1 || selection == 2)
                {
                    // Reset the selection flag to 0
                    selection = 0;
                }

                // Process the tree CurrentNode
                // Process the tree DataNode Question
                TextBlockQuestion.Text = theDataNode.Question;
                // Process the tree DataNode Image
                QuestionImage.Source = new BitmapImage(new Uri(theDataNode.ImageName, UriKind.RelativeOrAbsolute));
                
                // Process the tryee DataNode Data
                TextBlockData.Text = theDataNode.Data;

                // If the node is not the last (DataNode) then we need to offer and process the user selection
                // to the question (Yes or No) in the diagnostic process
                if (theDataNode.NextNode != "DataNode")
                {
                    // Switch on Yes / No buttons
                    YesButton.IsEnabled = true;
                    YesButton.Visibility = Visibility.Visible;
                    NoButton.IsEnabled = true;
                    NoButton.Visibility = Visibility.Visible;
                }
                // If the node is last (DataNode) then we need to offer the user a chance to re-start the diagnostic process
                else
                {
                    // Process the CurrentNode

                    // Re-set the search tree to the begging node
                    processString = myDictionary.Keys.ElementAt(0).ToString();
                    // Re-set the selection flag to 0 - nothing selected
                    selection = 0;
                    // Setup the correct button for the user - Set the start button to re-start
                    StartButton.Content = "Re-start";
                    StartButton.IsEnabled = true;
                    StartButton.Visibility = Visibility.Visible;

                    // Hide the selection buttons Yes / No
                    YesButton.IsEnabled = false;
                    YesButton.Visibility = Visibility.Hidden;
                    NoButton.IsEnabled = false;
                    NoButton.Visibility = Visibility.Hidden;
                }
            }
            // If we hit this we have a problem with our dictionary set up - check your Keys
            else
            {
                TextBlockQuestion.Text = $"Key {processString} not found - You have a problem with your Key or NextNode data in your Dictionary";
                TextBlockQuestion.Foreground = Brushes.Red;
                QuestionImage.Source = new BitmapImage(new Uri("Images/Error.png", UriKind.RelativeOrAbsolute));
            }
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
    }
}
