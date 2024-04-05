
using lab1;

var root = new TreeNode("root");
var a = new TreeNode("a");
var b = new TreeNode("b");
var c = new TreeNode("c");

var a1 = new TreeNode("a1");
a1.AddChildren(new TreeNode("a11"));
a1.AddChildren(new TreeNode("a12"));
a.AddChildren(a1);
a.AddChildren(new TreeNode("a2"));
b.AddChildren(new TreeNode("b1"));
c.AddChildren(new TreeNode("c1"));
c.AddChildren(new TreeNode("c2"));
c.AddChildren(new TreeNode("c3"));
root.AddChildren(a);
root.AddChildren(b);
root.AddChildren(c);

Console.WriteLine(root.ToString());