using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalBinaryTree
{
    class DataNode
    {

        public string CurrentNode;
        public string NextNode;
        public string Question;
        public string ImageName;
        public string Data;

        public DataNode()
        {
            CurrentNode = "";
            NextNode = "";
            Question = "";
            ImageName = "";
            Data = "";
        }

        public DataNode(string InputCurrentNode, string inputNextNode, string inputQuestion, string inputImageName, string inputData)
        {
            CurrentNode = InputCurrentNode;
            NextNode = inputNextNode;
            Question = inputQuestion;
            ImageName = inputImageName;
            Data = inputData;
        }

    }
}
