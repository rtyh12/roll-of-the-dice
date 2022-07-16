using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNode
{

}

public class Tree<T> : List<Tree<T>>
{
    public T Value;
}

public class DialogTree
{
    Tree<DialogNode> tree;

    DialogTree()
    {

    }
}
