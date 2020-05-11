using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
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

        public void DataNode_(string currentNode_, string nextNode_, string question_, string imageName_, string data_)
        {
            CurrentNode = currentNode_;
            NextNode = nextNode_;
            Question = question_;
            ImageName = imageName_;
            Data = data_;
        }
    }
}
