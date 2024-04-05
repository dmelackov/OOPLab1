using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class TreeNode
    {
        private List<TreeNode> _children;
        private string _value;

        public TreeNode(string value)
        {
            this._value = value;
            this._children = new List<TreeNode>();
        }

        public void AddChildren(TreeNode node) {  
            this._children.Add(node);
        }

        public string ToStringWithLevel(int level = 0)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < level; i++)
            {
                sb.Append("-");
            }
            sb.Append(this._value);
            foreach (var item in _children)
            {
                sb.Append('\n');
                sb.Append(item.ToStringWithLevel(level+1));
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return ToStringWithLevel(0);
        }
    }
}
